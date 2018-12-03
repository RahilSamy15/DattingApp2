/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { MembrelistsComponent } from './membrelists.component';

describe('MembrelistsComponent', () => {
  let component: MembrelistsComponent;
  let fixture: ComponentFixture<MembrelistsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MembrelistsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MembrelistsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
