import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateLastnameComponent } from './update-lastname.component';

describe('UpdateLastnameComponent', () => {
  let component: UpdateLastnameComponent;
  let fixture: ComponentFixture<UpdateLastnameComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdateLastnameComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateLastnameComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
