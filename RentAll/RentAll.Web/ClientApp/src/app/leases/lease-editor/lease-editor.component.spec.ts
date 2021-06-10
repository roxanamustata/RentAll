import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LeaseEditorComponent } from './lease-editor.component';

describe('LeaseEditorComponent', () => {
  let component: LeaseEditorComponent;
  let fixture: ComponentFixture<LeaseEditorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LeaseEditorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LeaseEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
