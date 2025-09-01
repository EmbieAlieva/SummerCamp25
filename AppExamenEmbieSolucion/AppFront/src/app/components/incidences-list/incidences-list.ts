import { Component } from '@angular/core';
import { Incidence } from '../../models/incidence';
import { Router } from '@angular/router';
import { IncidencesService } from '../../services/incidence';

@Component({
  selector: 'app-incidences-list',
  standalone: false,
  templateUrl: './incidences-list.html',
  styleUrl: './incidences-list.css'
})
export class IncidencesList {
  incidences: Incidence[] = [];
  page = 1;
  pageSize = 10;
  totalRegisters = 0;
  totalPages = 1;
  filterName = '';
  filterStatus: string = '';

  deleteIncidence(id: number) {
    if (confirm('¿Seguro que deseas eliminar esta incidencia?')) {
      this.incidenceService.deleteIncidence(id).subscribe(() => {
        this.loadAllIncidences();
      });
    }
  }

  constructor(private incidenceService: IncidencesService, private router: Router) {}

  ngOnInit(): void {
    const saved = localStorage.getItem('incidencesFilters');
    if (saved) {
      const filters = JSON.parse(saved);
      this.filterName = filters.filterName || '';
      this.filterStatus = filters.filterStatus || '';
      this.page = filters.page || 1;
    }
    this.loadAllIncidences();
  }

  loadAllIncidences() {
    this.incidenceService.getIncidences(
      this.page,
      this.pageSize,
      this.filterName.trim() || undefined,
      this.filterStatus || undefined
    ).subscribe(result => {
      if (Array.isArray(result)) {
        this.incidences = result;
        this.totalRegisters = result.length;
      } else {
        this.incidences = result.data || [];
        this.totalRegisters = typeof result.total === 'number' ? result.total : this.incidences.length;
      }
      this.totalPages = Math.max(1, Math.ceil(this.totalRegisters / this.pageSize));
    });
  }

  applyFilters() {
    this.page = 1;
    this.loadAllIncidences();
  }

  onFilterChange() {
    this.page = 1;
    this.applyFilters();
  }

  firstPage() {
    if (this.page !== 1) {
      this.page = 1;
      this.loadAllIncidences();
    }
  }

  nextPage() {
    if (this.page < this.totalPages) {
      this.page++;
      this.loadAllIncidences();
    }
  }

  previousPage() {
    if (this.page > 1) {
      this.page--;
      this.loadAllIncidences();
    }
  }

  lastPage() {
    if (this.page !== this.totalPages) {
      this.page = this.totalPages;
      this.loadAllIncidences();
    }
  }

  translateStatus(status: string): string {
    const translations: any = {
      Reported: 'Reportado',
      InProgress: 'En progreso',
      Resolved: 'Resuelto',
      Closed: 'Cerrado'
    };
    return translations[status] || status;
  }

  // Eliminadas funciones duplicadas y referencias a refresh
  viewDetail(id: number) {
    localStorage.setItem('incidencesFilters', JSON.stringify({
      filterName: this.filterName,
      filterStatus: this.filterStatus,
      page: this.page
    }));
    this.router.navigate(['/incidencia', id]);
  }
}
