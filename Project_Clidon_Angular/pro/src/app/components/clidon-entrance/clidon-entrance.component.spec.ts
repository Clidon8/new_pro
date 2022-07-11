import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClidonEntranceComponent } from './clidon-entrance.component';

describe('ClidonEntranceComponent', () => {
  let component: ClidonEntranceComponent;
  let fixture: ComponentFixture<ClidonEntranceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClidonEntranceComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ClidonEntranceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
