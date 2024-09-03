import { Component, Injector, ViewChild } from "@angular/core";
import { BsModalService, BsModalRef } from "ngx-bootstrap/modal";
import {
  TableServiceProxy,
  TableListDto,
  TableListDtoListResultDto,
} from "@shared/service-proxies/service-proxies";
import {
  PagedListingComponentBase,
  PagedRequestDto,
} from "shared/paged-listing-component-base";
import { CreateTableComponent } from "../tables/create-table/create-table.component";
import { appModuleAnimation } from "@shared/animations/routerTransition";

@Component({
  templateUrl: "./table.component.html",
  animations: [appModuleAnimation()],
})
export class TablesComponent extends PagedListingComponentBase<TableListDto> {
  @ViewChild("createTableModal") createTabletModal: CreateTableComponent;

  active: boolean = false;
  tables: TableListDto[] = [];
  includeCanceledTables: boolean = false;

  constructor(
    injector: Injector,
    private _tableService: TableServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }

  protected list(
    request: PagedRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    this.loadTables();
    finishedCallback();
  }

  delete(table: TableListDto): void {
    abp.message.confirm(
      "Are you sure you want to cancel this event?",
      undefined,
      (result: boolean) => {
        if (result) {
          this._tableService.cancel(table);
          abp.notify.success("table is deleted");
          this.refresh();
        }
      }
    );
  }

  includeCanceledTablesCheckboxChanged() {
    this.loadTables();
  }

  createTable(): void {
    this.showCreateOrEditTableDialog();
  }

  showCreateOrEditTableDialog(): void {
    let createOrEditTableDialog: BsModalRef;
    createOrEditTableDialog = this._modalService.show(CreateTableComponent, {
      class: "modal-lg",
    });
    createOrEditTableDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }

  loadTables(): void {
    this._tableService
      .getList(this.includeCanceledTables)
      .subscribe((result: TableListDtoListResultDto) => {
        this.tables = result.items;
      });
  }
}
