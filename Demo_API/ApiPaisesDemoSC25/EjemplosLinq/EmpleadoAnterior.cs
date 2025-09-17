// See https://aka.ms/new-console-template for more information

public class EmpleadoAnterior
{
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
}