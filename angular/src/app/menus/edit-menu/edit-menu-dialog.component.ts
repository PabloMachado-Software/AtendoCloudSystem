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
  MenuServiceProxy,
  MenuListDto,
  MenuDetailOutput,
} from '@shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'edit-menu-dialog.component.html'
})
export class EditMenuDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  id: number;
  menu = new MenuDetailOutput();

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    private _menuService: MenuServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._menuService.getDetail(this.id)
      .subscribe((result: MenuDetailOutput) => {
        this.menu = result;        
      });
  }  

  save(): void {
    this.saving = true;

    const menu = new MenuListDto();
    menu.init(this.menu);
   
    this._menuService.update(menu).subscribe(
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
