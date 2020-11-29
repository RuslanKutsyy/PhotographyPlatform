import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarouselPageSectionComponent } from './carousel-page-section.component';

describe('CarouselPageSectionComponent', () => {
  let component: CarouselPageSectionComponent;
  let fixture: ComponentFixture<CarouselPageSectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CarouselPageSectionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CarouselPageSectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
