import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClidonPaymentComponent } from './clidon-payment.component';

describe('ClidonPaymentComponent', () => {
  let component: ClidonPaymentComponent;
  let fixture: ComponentFixture<ClidonPaymentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClidonPaymentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ClidonPaymentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
