import {
  Component,
  ViewChild,
  Injector,
  Output,
  EventEmitter,
  ElementRef,
  OnInit,
} from "@angular/core";
import {
  TableServiceProxy,
  CreateTableInput,
} from "@shared/service-proxies/service-proxies";
import { AppComponentBase } from "@shared/app-component-base";
import { BsModalRef } from "ngx-bootstrap/modal";

@Component({
  templateUrl: "./create-table.component.html",
})
export class CreateTableComponent extends AppComponentBase implements OnInit {
  saving = true;
  table = new CreateTableInput();
  
  @ViewChild("TableDate") tableDate: ElementRef;
  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    private _tableService: TableServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  status: any[] = [
    { id: 1, name: 'Livre' },
    { id: 2, name: 'Ocupada' },
    { id: 3, name: 'Reservada' },
  ];
  
  ngOnInit(): void {}

  save(): void {
    this.saving = true;

    this._tableService.create(this.table).subscribe(
      () => {
        this.notify.info(this.l("SavedSuccessfully"));
        this.bsModalRef.hide();
        this.onSave.emit();
      },
      () => {
        this.saving = false;
      }
    );
  }
}
