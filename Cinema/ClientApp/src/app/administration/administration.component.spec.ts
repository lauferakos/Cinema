/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { AdministrationComponent } from './administration.component';

let component: AdministrationComponent;
let fixture: ComponentFixture<AdministrationComponent>;

describe('administration component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ AdministrationComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(AdministrationComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});