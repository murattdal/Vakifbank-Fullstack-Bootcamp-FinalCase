import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DealerOrdersComponent } from './dealer-orders.component';

describe('DealerOrdersComponent', () => {
  let component: DealerOrdersComponent;
  let fixture: ComponentFixture<DealerOrdersComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DealerOrdersComponent]
    });
    fixture = TestBed.createComponent(DealerOrdersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
