import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogtextComponent } from './dialogtext.component';

describe('DialogtextComponent', () => {
  let component: DialogtextComponent;
  let fixture: ComponentFixture<DialogtextComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DialogtextComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogtextComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
