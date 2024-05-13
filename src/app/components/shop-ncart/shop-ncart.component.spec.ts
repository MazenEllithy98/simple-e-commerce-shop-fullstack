import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShopNcartComponent } from './shop-ncart.component';

describe('ShopNcartComponent', () => {
  let component: ShopNcartComponent;
  let fixture: ComponentFixture<ShopNcartComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ShopNcartComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ShopNcartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
