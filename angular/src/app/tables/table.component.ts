import { Component, Injector, ViewChild } from "@angular/core";
import { BsModalService, BsModalRef } from "ngx-bootstrap/modal";
import {
  EventServiceProxy,
  EventListDto,
  EventListDtoListResultDto,
} from "@shared/service-proxies/service-proxies";
import {
  PagedListingComponentBase,
  PagedRequestDto,
} from "shared/paged-listing-component-base";
import { CreateEventComponent } from "app/events/create-event/create-event.component";
import { appModuleAnimation } from "@shared/animations/routerTransition";

@Component({
  templateUrl: "./table.component.html",
  animations: [appModuleAnimation()],
})
export class TablesComponent extends PagedListingComponentBase<TableListDto> {
  @ViewChild("createTableModal") createTabletModal: CreateTableComponent;

  active: boolean = false;
  table: TableListDto[] = [];
  includeCanceledEvents: boolean = false;

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
    this.loadTable();
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

  includeCanceledEventsCheckboxChanged() {
    this.loadEvent();
  }

  createEvent(): void {
    this.showCreateOrEditEventDialog();
  }

  showCreateOrEditEventDialog(): void {
    let createOrEditEventDialog: BsModalRef;
    createOrEditEventDialog = this._modalService.show(CreateEventComponent, {
      class: "modal-lg",
    });
    createOrEditEventDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }

  loadEvent(): void {
    this._eventService
      .getList(this.includeCanceledEvents)
      .subscribe((result: EventListDtoListResultDto) => {
        this.events = result.items;
      });
  }
}
