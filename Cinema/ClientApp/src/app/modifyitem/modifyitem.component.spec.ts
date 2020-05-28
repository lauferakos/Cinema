/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { ModifyitemComponent } from './modifyitem.component';

let component: ModifyitemComponent;
let fixture: ComponentFixture<ModifyitemComponent>;

describe('modifyitem component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ ModifyitemComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(ModifyitemComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});