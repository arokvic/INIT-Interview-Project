import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarsContainerComponent } from './cars-container.component';

describe('CarsContainerComponent', () => {
  let component: CarsContainerComponent;
  let fixture: ComponentFixture<CarsContainerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CarsContainerComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CarsContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
