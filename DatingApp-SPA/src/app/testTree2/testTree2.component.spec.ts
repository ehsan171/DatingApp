/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { TestTree2Component } from './testTree2.component';

describe('TestTree2Component', () => {
  let component: TestTree2Component;
  let fixture: ComponentFixture<TestTree2Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TestTree2Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TestTree2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
