import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClidonViewFilesComponent } from './clidon-view-files.component';

describe('ClidonViewFilesComponent', () => {
  let component: ClidonViewFilesComponent;
  let fixture: ComponentFixture<ClidonViewFilesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClidonViewFilesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ClidonViewFilesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
