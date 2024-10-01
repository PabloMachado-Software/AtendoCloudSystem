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
    OrderServiceProxy,
    OrderListDto,
    OrderListDtoListResultDto,
  } from "@shared/service-proxies/service-proxies";
  import { forEach as _forEach, map as _map } from "lodash-es";
  
  @Component({
    templateUrl: "create-order-dialog.component.html",
  })
  export class CreateOrderDialogComponent
    extends AppComponentBase
    implements OnInit
  {
    saving = false;
    order = new OrderListDto();
    permissions: PermissionDto[] = [];
    checkedPermissionsMap: { [key: string]: boolean } = {};
    defaultPermissionCheckedStatus = true;

    categories: any[] = [
      { id: 1, name: 'Bebidas' },
      { id: 2, name: 'Lanches' },
      { id: 3, name: 'Pratos principais' },
      { id: 4, name: 'Sobremesas' },
      { id: 5, name: 'Aperitivos' }
    ];
    
    selectedCategory: string = '';
    @Output() onSave = new EventEmitter<any>();
  
    constructor(
      injector: Injector,
      private _orderService: OrderServiceProxy,
      public bsModalRef: BsModalRef
    ) {
      super(injector);
    }
  
    ngOnInit(): void {
      this._orderService
        .getList(false, 0)
        .subscribe((result: OrderListDtoListResultDto) => {       
         
        });     
    }

     
  
    save(): void {
      this.saving = true;
  
      const order = new OrderListDto();
      order.init(this.order);
       
      this._orderService.create(order).subscribe(
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
  