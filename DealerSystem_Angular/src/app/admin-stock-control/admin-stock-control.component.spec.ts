import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminStockControlComponent } from './admin-stock-control.component';

describe('AdminStockControlComponent', () => {
  let component: AdminStockControlComponent;
  let fixture: ComponentFixture<AdminStockControlComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AdminStockControlComponent]
    });
    fixture = TestBed.createComponent(AdminStockControlComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
