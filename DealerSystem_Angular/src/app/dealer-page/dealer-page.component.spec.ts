import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DealerPageComponent } from './dealer-page.component';

describe('DealerPageComponent', () => {
  let component: DealerPageComponent;
  let fixture: ComponentFixture<DealerPageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DealerPageComponent]
    });
    fixture = TestBed.createComponent(DealerPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
