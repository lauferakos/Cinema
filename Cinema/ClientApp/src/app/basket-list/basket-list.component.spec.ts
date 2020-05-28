/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { BasketListComponent } from './basket-list.component';

let component: BasketListComponent;
let fixture: ComponentFixture<BasketListComponent>;

describe('basket-list component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ BasketListComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(BasketListComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});