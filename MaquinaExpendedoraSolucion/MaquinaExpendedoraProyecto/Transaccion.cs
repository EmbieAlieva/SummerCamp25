internal partial class Program {
    public class Transaccion
    {
        public Producto Producto { get; set; }
        public decimal MontoPagado { get; set; }
        public decimal Cambio { get; set; }
        public bool Exitosa { get; set; }
        public DateTime FechaHoraTransaccion { get; set; }
    }


}

