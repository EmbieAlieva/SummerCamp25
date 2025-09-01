internal partial class Program {
    public class Monedero {
        // Clase que representa un monedero para manejar el saldo de la maquina expendedora.

        public decimal Saldo { get; private set; }
        // Moneda de 1 Euro
        public int MonedaTipoEuro { get; set; }

        // Moneda de 50 Céntimos
        public int MonedaTipoCincuentaCentimos { get; set; }
    }



}

