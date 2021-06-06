import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LeaseViewComponent } from './lease-view.component';

describe('LeaseViewComponent', () => {
  let component: LeaseViewComponent;
  let fixture: ComponentFixture<LeaseViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LeaseViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LeaseViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
