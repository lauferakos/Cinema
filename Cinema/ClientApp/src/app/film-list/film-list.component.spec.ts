/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { FilmListComponent } from './film-list.component';

let component: FilmListComponent;
let fixture: ComponentFixture<FilmListComponent>;

describe('film-list component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ FilmListComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(FilmListComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});