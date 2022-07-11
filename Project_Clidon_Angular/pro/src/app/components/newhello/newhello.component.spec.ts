import { ComponentFixture, TestBed } from '@angular/core/testing';
import { NewhelloComponent } from './newhello.component';


describe('NewhelloComponent', () => {
  let component: NewhelloComponent;
  let fixture: ComponentFixture<NewhelloComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewhelloComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NewhelloComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
