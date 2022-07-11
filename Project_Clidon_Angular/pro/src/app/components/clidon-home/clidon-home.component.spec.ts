import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClidonHomeComponent } from './clidon-home.component';

describe('ClidonHomeComponent', () => {
  let component: ClidonHomeComponent;
  let fixture: ComponentFixture<ClidonHomeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClidonHomeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ClidonHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
