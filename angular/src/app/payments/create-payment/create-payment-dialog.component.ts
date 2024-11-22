import {
    Component,
    Injector,
    OnInit,
    EventEmitter,
    Output,
  } from "@angular/core";
  import { BsModalRef } from "ngx-bootstrap/modal";
  import { AppComponentBase } from "@shared/app-component-base";
  import {
    PermissionDto,
    PaymentServiceProxy,
    MenuServiceProxy,
    PaymentListDto,
    PaymentListDtoListResultDto,    
    TableServiceProxy,
    TableListDtoListResultDto,
    CreatePaymentInput,
    MenuListDtoListResultDto,
  } from "@shared/service-proxies/service-proxies";
  import { forEach as _forEach, map as _map } from "lodash-es";
  
  @Component({
    templateUrl: "create-payment-dialog.component.html",
  })
  export class CreatePaymentDialogComponent
    extends AppComponentBase
    implements OnInit
  {
    saving = false;
    payment = new PaymentListDto();
    permissions: PermissionDto[] = [];
    checkedPermissionsMap: { [key: string]: boolean } = {};
    defaultPermissionCheckedStatus = true;


    categories: any[] = [
      { id: 1, name: 'Bebidas' },
      { id: 2, name: 'Lanches' },
      { id: 3, name: 'Pratos principais' },
      { id: 4, name: 'Sobremesas' },
      { id: 5, name: 'Aperitivos' },
      { id: 6, name: 'Caldinhos' },
      { id: 7, name: 'Refrigerantes' },
      { id: 8, name: 'Doces' },
    ];
    
    selectedCategory: string = '';
    @Output() onSave = new EventEmitter<any>();
    selectedTable: number = 0;
    selectedMenu: number = 0;
  
    constructor(
      injector: Injector,
      private _tableService: TableServiceProxy,
      private _paymentService: PaymentServiceProxy,
      private _menuService: MenuServiceProxy,
      public bsModalRef: BsModalRef
    ) {
      super(injector);
    }
  
    ngOnInit(): void {

      this.loadTable();
      this.loadMenu();

      this._paymentService
        .getList(false)
        .subscribe((result: PaymentListDtoListResultDto) => {        
        });     
    }    
  
    save(): void {
      this.saving = true;
  
      const payment = new CreatePaymentInput();
      payment.init(this.payment);
       
      this._paymentService.create(payment).subscribe(
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

    loadTable(): void {
      this._tableService
        .getList(false)
        .subscribe((result: TableListDtoListResultDto) => {
         // this.tables = result.items;
        });
    }

    loadMenu(): void {
      this._menuService
        .getList(false)
        .subscribe((result: MenuListDtoListResultDto) => {
          //this.menus = result.items;
        });
    }
  }
  