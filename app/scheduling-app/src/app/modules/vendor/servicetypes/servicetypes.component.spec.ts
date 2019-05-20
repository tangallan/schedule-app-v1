import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ServicetypesComponent } from './servicetypes.component';

describe('ServicetypesComponent', () => {
  let component: ServicetypesComponent;
  let fixture: ComponentFixture<ServicetypesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ServicetypesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ServicetypesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
