import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MainPageWrapComponent } from './main-page-wrap.component';

describe('MainPageWrapComponent', () => {
  let component: MainPageWrapComponent;
  let fixture: ComponentFixture<MainPageWrapComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MainPageWrapComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MainPageWrapComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
