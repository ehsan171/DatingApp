/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ScreenplayEdit2Component } from './screenplay-edit2.component';

describe('ScreenplayEdit2Component', () => {
  let component: ScreenplayEdit2Component;
  let fixture: ComponentFixture<ScreenplayEdit2Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ScreenplayEdit2Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ScreenplayEdit2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
