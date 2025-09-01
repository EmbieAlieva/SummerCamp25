internal partial class Program {
    public class Slot {
        public string IdSlot { get; set; } // public string Identificador { get; set; }
        public int Numero { get; set; } 
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        // Capacidad máxima del slot
        public int Capacidad { get; set; }

        // Última fecha de reposición
        public DateTime UltimaReposicion { get; set; }

        // Stock Mínimo
        public int StockMinimo { get; set; }

        // Método para Reponer el producto en el slot
        public void Reponer(int cantidad) {
            if (Cantidad + cantidad <= Capacidad) {
                Cantidad += cantidad;
                UltimaReposicion = DateTime.Now;
            } else {
               // throw new InvalidOperationException("No se puede reponer más allá de la capacidad máxima del slot.");
            }
        }

        // Establecer el producto en el slot
        public void EstablecerProducto(Producto producto) {
            Producto = producto;
            Cantidad = 0; // Inicialmente no hay producto en el slot
            UltimaReposicion = DateTime.Now; // Fecha de reposición inicial
        }

        // Verificar si el slot verifica reposición
        public bool NecesitaReposicion() {
            return Cantidad < StockMinimo;
        }

        // Retirar un producto del slot
        public bool RetirarProducto() {
            if (Cantidad > 0) {
                Cantidad--;
                return true; // Producto retirado exitosamente
            }
            return false; // No hay producto para retirar
        }

        // Si existe el producto en el slot
        public bool ExisteProducto() {
            return Producto != null && Cantidad > 0;
        }

        // Vaciar el slot
        public void Vaciar() {
            Cantidad = 0;
            Producto = null; // Eliminar el producto del slot
            UltimaReposicion = DateTime.MinValue; // Reiniciar la fecha de reposición
        }
    }
}

