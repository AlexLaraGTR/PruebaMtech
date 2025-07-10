import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageProduct } from './manage';

describe('Manage', () => {
  let component: ManageProduct;
  let fixture: ComponentFixture<ManageProduct>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ManageProduct]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ManageProduct);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
