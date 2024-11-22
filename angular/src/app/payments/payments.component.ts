import { Component, Injector } from "@angular/core";
import { finalize } from "rxjs/operators";
import { BsModalRef, BsModalService } from "ngx-bootstrap/modal";
import { appModuleAnimation } from "@shared/animations/routerTransition";
import {
  PagedListingComponentBase,
  PagedRequestDto,
} from "@shared/paged-listing-component-base";
import {
  PaymentServiceProxy,
  PaymentListDto,
  PaymentListDtoListResultDto,
} from "@shared/service-proxies/service-proxies";
 
import { CreatePaymentDialogComponent } from "./create-payment/create-payment-dialog.component"
import { EditPaymentDialogComponent } from "./edit-payment/edit-payment-dialog.component";

class PagedPaymentsRequestDto extends PagedRequestDto {
  keyword: string;
}

@Component({
  templateUrl: "./payments.component.html",
  animations: [appModuleAnimation()],
})
export class PaymentsComponent extends PagedListingComponentBase<PaymentListDto> {
  payments: PaymentListDto[] = [];
  
  keyword = "";

  constructor(
    injector: Injector,
    private _paymentsService: PaymentServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }

  list(
    request: PagedPaymentsRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;

    this._paymentsService.getList(false)
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: PaymentListDtoListResultDto) => {
        this.payments = result.items;
        this.showPaging(result, pageNumber);
      });
  }

  delete(payment: PaymentListDto): void {
    abp.message.confirm(
      this.l("PaymentDeleteWarningMessage", payment.orderID),
      undefined,
      (result: boolean) => {
        if (result) {
          this._paymentsService
            .delete(payment.orderID)
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

  createPayment(): void {
    this.showCreateOrEditPaymentDialog();
  }

  editPayment(payment: PaymentListDto): void {
    this.showCreateOrEditPaymentDialog(payment.orderID);
  }

  showCreateOrEditPaymentDialog(id?: number): void {
    let createOrEditPaymentDialog: BsModalRef;
    if (!id) {
       createOrEditPaymentDialog = this._modalService.show(
          CreatePaymentDialogComponent,
         {
          class: "modal-lg",
         }
      );
    } else {
       createOrEditPaymentDialog = this._modalService.show(
        EditPaymentDialogComponent,
         {
           class: "modal-lg",
           initialState: {
           id: id,
           },
         }
      );
    }

    createOrEditPaymentDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }
}
