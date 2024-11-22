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
    MenuServiceProxy,
    OrderListDto,
    OrderListDtoListResultDto,    
    TableListDto,
    TableServiceProxy,
    TableListDtoListResultDto,
    CreateOrderInput,
    MenuListDto,
    MenuListDtoListResultDto,
    OrderItensServiceProxy
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
    tables: TableListDto[] = [];
    menus: MenuListDto[] = [];

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
      private _orderService: OrderServiceProxy,
      private _orderItensService: OrderItensServiceProxy,
      private _menuService: MenuServiceProxy,
      public bsModalRef: BsModalRef
    ) {
      super(injector);
    }
  
    ngOnInit(): void {

      this.loadTable();
      this.loadMenu();

      this._orderService
        .getList(false, 0)
        .subscribe((result: OrderListDtoListResultDto) => {        
        });     
    }    
  
    save(): void {
      this.saving = true;
  
      const order = new CreateOrderInput();
      order.tableId = this.selectedTable;
      order.menuId = this.selectedMenu;
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

    loadTable(): void {
      this._tableService
        .getList(false)
        .subscribe((result: TableListDtoListResultDto) => {
          this.tables = result.items;
        });
    }

    loadMenu(): void {
      this._menuService
        .getList(false)
        .subscribe((result: MenuListDtoListResultDto) => {
          this.menus = result.items;
        });
    }
  }
  