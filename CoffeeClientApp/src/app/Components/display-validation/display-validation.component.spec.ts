import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DisplayValidationComponent } from './display-validation.component';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';

describe('DisplayValidationComponent', () => {
  let component: DisplayValidationComponent;
  let fixture: ComponentFixture<DisplayValidationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DisplayValidationComponent ],
      imports: [MatDialogModule],
      providers: [
        {provide: MatDialogRef, useValue: {}},
      ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DisplayValidationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
