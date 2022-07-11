import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClidonManagerPasswordComponent } from './clidon-manager-password.component';

describe('ClidonManagerPasswordComponent', () => {
  let component: ClidonManagerPasswordComponent;
  let fixture: ComponentFixture<ClidonManagerPasswordComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClidonManagerPasswordComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ClidonManagerPasswordComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
