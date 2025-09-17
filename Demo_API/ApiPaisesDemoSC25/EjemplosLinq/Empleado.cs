using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemplosLinq{

     public enum Departamento {
        RH = 201,
        Desarrollo = 520,
        Soporte = 402,
        Admin = 309
     }

    public class Empleado {

        public string Nombre { get; set; }
        public string Cargo { get; set; }
        public decimal SalarioMensual { get; set; }
        public int AntiguedadAnios { get; set; }

        // Campos agregados por procesos
        public decimal SalarioAnual { get; set; }
        public int DiasVacaciones { get; set; }
        public string ClasificacionSalarial { get; set; }
        public decimal Bonificacion { get; set; }
        public int EdadEstimada { get; set; }
        public DateTime FechaEstimadaAscenso { get; internal set; }
        public DateTime FechaReviionContrato { get; internal set; }
        public string PlanSalud { get; internal set; }
        public int HorasTrabajadasAnuales { get; internal set; }
        public decimal IRPF { get; internal set; }
        public string Apellidos { get; internal set; }
        public string Ciudad { get; internal set; }
        public string Telefono { get; internal set; }
        public int Edad { get; internal set; }
        public Departamento Departamento { get; internal set; }
    }
}
