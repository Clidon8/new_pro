import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClidonUserTableComponent } from './clidon-user-table.component';

describe('ClidonUserTableComponent', () => {
  let component: ClidonUserTableComponent;
  let fixture: ComponentFixture<ClidonUserTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClidonUserTableComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ClidonUserTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
