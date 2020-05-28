/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { OrderListComponent } from './order-list.component';

let component: OrderListComponent;
let fixture: ComponentFixture<OrderListComponent>;

describe('order-list component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ OrderListComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(OrderListComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});