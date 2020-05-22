/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { Upload2Component } from './upload2.component';

describe('Upload2Component', () => {
  let component: Upload2Component;
  let fixture: ComponentFixture<Upload2Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ Upload2Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(Upload2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
