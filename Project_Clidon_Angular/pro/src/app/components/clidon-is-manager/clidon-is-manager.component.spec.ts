import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClidonIsManagerComponent } from './clidon-is-manager.component';

describe('ClidonIsManagerComponent', () => {
  let component: ClidonIsManagerComponent;
  let fixture: ComponentFixture<ClidonIsManagerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClidonIsManagerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ClidonIsManagerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
