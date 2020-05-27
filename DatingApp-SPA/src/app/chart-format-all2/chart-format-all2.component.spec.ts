/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ChartFormatAll2Component } from './chart-format-all2.component';

describe('ChartFormatAll2Component', () => {
  let component: ChartFormatAll2Component;
  let fixture: ComponentFixture<ChartFormatAll2Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChartFormatAll2Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChartFormatAll2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
