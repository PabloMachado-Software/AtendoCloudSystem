import { Component, Injector } from "@angular/core";
import { finalize } from "rxjs/operators";
import { BsModalRef, BsModalService } from "ngx-bootstrap/modal";
import { appModuleAnimation } from "@shared/animations/routerTransition";
import {
  PagedListingComponentBase,
  PagedRequestDto,
} from "@shared/paged-listing-component-base";
import {
  MenuServiceProxy,
  MenuListDto,
  MenuListDtoListResultDto,
} from "@shared/service-proxies/service-proxies";
 
import { CreateMenuDialogComponent } from "./create-menu/create-menu-dialog.component";
import { EditMenuDialogComponent } from "./edit-menu/edit-menu-dialog.component";

class PagedMenusRequestDto extends PagedRequestDto {
  keyword: string;
}

@Component({
  templateUrl: "./menus.component.html",
  animations: [appModuleAnimation()],
})
export class MenusComponent extends PagedListingComponentBase<MenuListDto> {
  menus: MenuListDto[] = [];
  keyword = "";

  constructor(
    injector: Injector,
    private _menusService: MenuServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }

  list(
    request: PagedMenusRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;

    this._menusService.getList(false)
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: MenuListDtoListResultDto) => {
        this.menus = result.items;
        this.showPaging(result, pageNumber);
      });
  }

  delete(menu: MenuListDto): void {
    abp.message.confirm(
      this.l("MenuDeleteWarningMessage", menu.nome),
      undefined,
      (result: boolean) => {
        if (result) {
          this._menusService
            .delete(menu.id)
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

  createMenu(): void {
    this.showCreateOrEditMenuDialog();
  }

  editMenu(menu: MenuListDto): void {
    this.showCreateOrEditMenuDialog(menu.id);
  }

  showCreateOrEditMenuDialog(id?: number): void {
    let createOrEditMenuDialog: BsModalRef;
    if (!id) {
       createOrEditMenuDialog = this._modalService.show(
          CreateMenuDialogComponent,
         {
          class: "modal-lg",
         }
      );
    } else {
       createOrEditMenuDialog = this._modalService.show(
        EditMenuDialogComponent,
         {
           class: "modal-lg",
           initialState: {
           id: id,
           },
         }
      );
    }

    createOrEditMenuDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }
}
