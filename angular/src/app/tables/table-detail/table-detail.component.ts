import { Component, OnInit, Injector } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { AppComponentBase } from '@shared/app-component-base';
import { TableDetailOutput, TableServiceProxy, GuidEntityDto, Int32EntityDto } from '@shared/service-proxies/service-proxies';

import * as _ from 'lodash';

@Component({
    templateUrl: './table-detail.component.html',
    animations: [appModuleAnimation()]
})

export class TableDetailComponent extends AppComponentBase implements OnInit {

    table: TableDetailOutput = new TableDetailOutput();
    tableId:number;

    constructor(
        injector: Injector,
        private _tableService: TableServiceProxy,
        private _router: Router,
        private _activatedRoute: ActivatedRoute
    ) {
        super(injector);
    }

    status: any[] = [
        { id: 1, name: 'Livre' },
        { id: 2, name: 'Ocupada' },
        { id: 3, name: 'Reservada' },
      ];

    ngOnInit(): void {
        this._activatedRoute.params.subscribe((params: Params) => {
            this.tableId = params['tableId'];
            this.loadTable();
        });
    }
   
    cancelTable(): void {
        var input = new Int32EntityDto();
        input.id = this.table.id;

        this._tableService.cancel(input)
            .subscribe(() => {
                abp.notify.info('Canceled the table.');
                this.backToTablesPage();
            });
    };

    loadTable() {
        this._tableService.getDetail(this.tableId)
            .subscribe((result: TableDetailOutput) => {
                this.table = result;       
            });
    }

    backToTablesPage() {
        this._router.navigate(['app/tables']);
    };
}