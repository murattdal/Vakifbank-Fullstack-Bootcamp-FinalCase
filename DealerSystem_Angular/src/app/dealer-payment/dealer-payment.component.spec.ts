import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DealerPaymentComponent } from './dealer-payment.component';

describe('DealerPaymentComponent', () => {
  let component: DealerPaymentComponent;
  let fixture: ComponentFixture<DealerPaymentComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DealerPaymentComponent]
    });
    fixture = TestBed.createComponent(DealerPaymentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
