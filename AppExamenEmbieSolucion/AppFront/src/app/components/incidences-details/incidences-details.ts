import { Component, OnInit } from '@angular/core';
import { Incidence } from '../../models/incidence';
import { ActivatedRoute, Router } from '@angular/router';
import { IncidencesService } from '../../services/incidence';

@Component({
  selector: 'app-incidences-details',
  standalone: false,
  templateUrl: './incidences-details.html',
  styleUrl: './incidences-details.css'
})
export class IncidencesDetails implements OnInit {
  incidence!: Incidence;

  constructor(
    private route: ActivatedRoute,
    private incidentService: IncidencesService,
    private router: Router
  ) { }

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.incidentService.getIncidenceById(id).subscribe(data => {
      // reportedAt se deja tal cual viene del backend, solo recortando la hora si existe
      if (data && data.reportedAt) {
        if (data.reportedAt.includes('T')) {
          data.reportedAt = data.reportedAt.split('T')[0];
        } else if (data.reportedAt.includes(' ')) {
          data.reportedAt = data.reportedAt.split(' ')[0];
        }
      }
      this.incidence = data;
    });
  }

  saveChanges() {
    this.incidentService.updateIncidence(this.incidence.id, this.incidence).subscribe(() => {
      alert('Incidencia actualizada');
      this.router.navigate(['/']);
    });
  }

  // El modelo reportedAt se mantiene en formato yyyy-MM-dd, compatible con input type=date
}
