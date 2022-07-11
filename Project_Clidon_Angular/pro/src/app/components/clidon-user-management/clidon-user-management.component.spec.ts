import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClidonUserManagementComponent } from './clidon-user-management.component';

describe('ClidonUserManagementComponent', () => {
  let component: ClidonUserManagementComponent;
  let fixture: ComponentFixture<ClidonUserManagementComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClidonUserManagementComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ClidonUserManagementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
