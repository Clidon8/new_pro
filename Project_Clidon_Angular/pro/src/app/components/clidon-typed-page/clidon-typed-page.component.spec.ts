import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClidonTypedPageComponent } from './clidon-typed-page.component';

describe('ClidonTypedPageComponent', () => {
  let component: ClidonTypedPageComponent;
  let fixture: ComponentFixture<ClidonTypedPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClidonTypedPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ClidonTypedPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
