import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChildHomePageComponent } from './child-home-page.component';

describe('ChildHomePageComponent', () => {
  let component: ChildHomePageComponent;
  let fixture: ComponentFixture<ChildHomePageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ChildHomePageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ChildHomePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
