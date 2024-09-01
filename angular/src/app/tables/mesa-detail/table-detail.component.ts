import { Component, OnInit, Injector } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { AppComponentBase } from '@shared/app-component-base';
import { EventDetailOutput, EventServiceProxy, EventRegisterOutput, GuidEntityDto } from '@shared/service-proxies/service-proxies';

import * as _ from 'lodash';

@Component({
    templateUrl: './event-detail.component.html',
    animations: [appModuleAnimation()]
})

export class TableDetailComponent extends AppComponentBase implements OnInit {

    table: TableDetailOutput = new TableDetailOutput();
    tableId:string;

    constructor(
        injector: Injector,
        private _TableService: TableServiceProxy,
        private _router: Router,
        private _activatedRoute: ActivatedRoute
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this._activatedRoute.params.subscribe((params: Params) => {
            this.TableId = params['tableId'];
            this.loadTable();
        });
    }

    registerToTable(): void {
        var input = new GuidEntityDto();
        input.id = this.table.id;
        this._tableService.register(input)
            .subscribe((result: EventRegisterOutput) => {
                abp.notify.success('Successfully registered to event. Your registration id: ' + result.registrationId + ".");
                this.loadEvent();
            });
    };

    cancelRegistrationFromTable(): void {
        var input = new GuidEntityDto();
        input.id = this.table.id;
        
        this._tableService.cancelRegistration(input)
            .subscribe(() => {
                abp.notify.info('Canceled your registration.');
                this.loadTable();
            });
    };

    cancelTable(): void {
        var input = new GuidEntityDto();
        input.id = this.table.id;

        this._tableService.cancel(input)
            .subscribe(() => {
                abp.notify.info('Canceled the table.');
                this.backToEventsPage();
            });
    };

    isRegistered(): boolean {
        return _.some(this.table.registrations, { userId: abp.session.userId });
    };

    isEventCreator(): boolean {
        return this.table.creatorUserId === abp.session.userId;
    };

    loadEvent() {
        this._tableService.getDetail(this.tableId)
            .subscribe((result: EventDetailOutput) => {
                this.table = result;       
            });
    }

    backToEventsPage() {
        this._router.navigate(['app/events']);
    };
}