import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminDealerInquiryComponent } from './admin-dealer-inquiry.component';

describe('AdminDealerInquiryComponent', () => {
  let component: AdminDealerInquiryComponent;
  let fixture: ComponentFixture<AdminDealerInquiryComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AdminDealerInquiryComponent]
    });
    fixture = TestBed.createComponent(AdminDealerInquiryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
