import {
  Component,
  Injector,
  OnInit,
  EventEmitter,
  Output,
  
} from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { forEach as _forEach, includes as _includes, map as _map } from 'lodash-es';
import { AppComponentBase } from '@shared/app-component-base';
import {
  OrderServiceProxy,
  OrderListDto,
  CreateOrderInput,
  OrderDetailOutput,
} from '@shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'edit-order-dialog.component.html'
})
export class EditOrderDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  id: number;
  order = new OrderDetailOutput();

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    private _orderService: OrderServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._orderService.getDetail(this.id)
      .subscribe((result: OrderDetailOutput) => {
        this.order = result;        
      });
  }  

  save(): void {
    this.saving = true;

    const order = new CreateOrderInput();
    order.init(this.order);
   
    this._orderService.update(order).subscribe(
      () => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.bsModalRef.hide();
        this.onSave.emit();
      },
      () => {
        this.saving = false;
      }
    );
  }
}
