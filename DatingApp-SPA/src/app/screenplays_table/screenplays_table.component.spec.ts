/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { Screenplays_tableComponent } from './screenplays_table.component';

describe('Screenplays_tableComponent', () => {
  let component: Screenplays_tableComponent;
  let fixture: ComponentFixture<Screenplays_tableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ Screenplays_tableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(Screenplays_tableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
