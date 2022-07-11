import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClidonManagementOperationsComponent } from './clidon-management-operations.component';

describe('ClidonManagementOperationsComponent', () => {
  let component: ClidonManagementOperationsComponent;
  let fixture: ComponentFixture<ClidonManagementOperationsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClidonManagementOperationsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ClidonManagementOperationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
