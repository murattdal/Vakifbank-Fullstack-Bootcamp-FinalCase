import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DealerMailComponent } from './dealer-mail.component';

describe('DealerMailComponent', () => {
  let component: DealerMailComponent;
  let fixture: ComponentFixture<DealerMailComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DealerMailComponent]
    });
    fixture = TestBed.createComponent(DealerMailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
