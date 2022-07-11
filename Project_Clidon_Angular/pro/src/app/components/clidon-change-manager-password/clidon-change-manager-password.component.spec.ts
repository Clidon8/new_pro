import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClidonChangeManagerPasswordComponent } from './clidon-change-manager-password.component';

describe('ClidonChangeManagerPasswordComponent', () => {
  let component: ClidonChangeManagerPasswordComponent;
  let fixture: ComponentFixture<ClidonChangeManagerPasswordComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClidonChangeManagerPasswordComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ClidonChangeManagerPasswordComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
