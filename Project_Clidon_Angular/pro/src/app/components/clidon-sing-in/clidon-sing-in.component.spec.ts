import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClidonSingInComponent } from './clidon-sing-in.component';

describe('ClidonSingInComponent', () => {
  let component: ClidonSingInComponent;
  let fixture: ComponentFixture<ClidonSingInComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClidonSingInComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ClidonSingInComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
