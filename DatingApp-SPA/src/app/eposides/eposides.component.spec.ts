/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { EposidesComponent } from './eposides.component';

describe('EposidesComponent', () => {
  let component: EposidesComponent;
  let fixture: ComponentFixture<EposidesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EposidesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EposidesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
