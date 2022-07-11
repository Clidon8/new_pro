import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClidonSaveAFileComponent } from './clidon-save-a-file.component';

describe('ClidonSaveAFileComponent', () => {
  let component: ClidonSaveAFileComponent;
  let fixture: ComponentFixture<ClidonSaveAFileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClidonSaveAFileComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ClidonSaveAFileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
