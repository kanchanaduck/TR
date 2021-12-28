import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AproveCenterComponent } from './aprove-center.component';

describe('AproveCenterComponent', () => {
  let component: AproveCenterComponent;
  let fixture: ComponentFixture<AproveCenterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AproveCenterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AproveCenterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
