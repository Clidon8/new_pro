import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClidonChangeUserPasswordComponent } from './clidon-change-user-password.component';

describe('ClidonChangeUserPasswordComponent', () => {
  let component: ClidonChangeUserPasswordComponent;
  let fixture: ComponentFixture<ClidonChangeUserPasswordComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClidonChangeUserPasswordComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ClidonChangeUserPasswordComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
