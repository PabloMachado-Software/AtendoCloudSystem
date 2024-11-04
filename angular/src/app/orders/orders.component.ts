import { Component, Injector } from "@angular/core";
import { finalize } from "rxjs/operators";
import { BsModalRef, BsModalService } from "ngx-bootstrap/modal";
import { appModuleAnimation } from "@shared/animations/routerTransition";
import {
  PagedListingComponentBase,
  PagedRequestDto,
} from "@shared/paged-listing-component-base";
import {
  OrderServiceProxy,
  OrderListDto,
  OrderListDtoListResultDto,
} from "@shared/service-proxies/service-proxies";
 
import { CreateOrderDialogComponent } from "./create-order/create-order-dialog.component"
import { EditOrderDialogComponent } from "./edit-order/edit-order-dialog.component";

class PagedOrdersRequestDto extends PagedRequestDto {
  keyword: string;
}

@Component({
  templateUrl: "./orders.component.html",
  animations: [appModuleAnimation()],
})
export class OrdersComponent extends PagedListingComponentBase<OrderListDto> {
  orders: OrderListDto[] = [];
  
  keyword = "";

  constructor(
    injector: Injector,
    private _ordersService: OrderServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }

  list(
    request: PagedOrdersRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;

    this._ordersService.getList(false, 0)
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: OrderListDtoListResultDto) => {
        this.orders = result.items;
        this.showPaging(result, pageNumber);
      });
  }

  delete(order: OrderListDto): void {
    abp.message.confirm(
      this.l("OrderDeleteWarningMessage", order.id),
      undefined,
      (result: boolean) => {
        if (result) {
          this._ordersService
            .delete(order.id)
            .pipe(
              finalize(() => {
                abp.notify.success(this.l("SuccessfullyDeleted"));
                this.refresh();
              })
            )
            .subscribe(() => {});
        }
      }
    );
  }

  createOrder(): void {
    this.showCreateOrEditOrderDialog();
  }

  editOrder(order: OrderListDto): void {
    this.showCreateOrEditOrderDialog(order.id);
  }

  showCreateOrEditOrderDialog(id?: number): void {
    let createOrEditOrderDialog: BsModalRef;
    if (!id) {
       createOrEditOrderDialog = this._modalService.show(
          CreateOrderDialogComponent,
         {
          class: "modal-lg",
         }
      );
    } else {
       createOrEditOrderDialog = this._modalService.show(
        EditOrderDialogComponent,
         {
           class: "modal-lg",
           initialState: {
           id: id,
           },
         }
      );
    }

    createOrEditOrderDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }
}
