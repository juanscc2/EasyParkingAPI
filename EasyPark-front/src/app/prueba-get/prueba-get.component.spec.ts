import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PruebaGetComponent } from './prueba-get.component';

describe('PruebaGetComponent', () => {
  let component: PruebaGetComponent;
  let fixture: ComponentFixture<PruebaGetComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PruebaGetComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PruebaGetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
