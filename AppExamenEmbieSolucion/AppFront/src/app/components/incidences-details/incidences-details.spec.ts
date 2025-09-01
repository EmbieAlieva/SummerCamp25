import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IncidencesDetails } from './incidences-details';

describe('IncidencesDetails', () => {
  let component: IncidencesDetails;
  let fixture: ComponentFixture<IncidencesDetails>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [IncidencesDetails]
    })
    .compileComponents();

    fixture = TestBed.createComponent(IncidencesDetails);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
