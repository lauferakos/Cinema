/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { ProjectionListComponent } from './projection-list.component';

let component: ProjectionListComponent;
let fixture: ComponentFixture<ProjectionListComponent>;

describe('projection-list component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ ProjectionListComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(ProjectionListComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});