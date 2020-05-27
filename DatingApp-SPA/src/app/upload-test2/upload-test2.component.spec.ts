/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { UploadTest2Component } from './upload-test2.component';

describe('UploadTest2Component', () => {
  let component: UploadTest2Component;
  let fixture: ComponentFixture<UploadTest2Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UploadTest2Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UploadTest2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
