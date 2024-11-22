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
  PaymentServiceProxy,
  PaymentListDto,
  CreatePaymentInput,
  PaymentDetailOutput,
} from '@shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'edit-payment-dialog.component.html'
})
export class EditPaymentDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  id: number;
  payment = new PaymentDetailOutput();

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    private _paymentService: PaymentServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._paymentService.getDetail(this.id)
      .subscribe((result: PaymentDetailOutput) => {
        this.payment = result;        
      });
  }  

  save(): void {
    this.saving = true;

    const payment = new PaymentListDto();
    payment.init(this.payment);
   
    this._paymentService.update(payment).subscribe(
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
