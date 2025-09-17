using System.Security.Policy;

namespace ApiPaisesProyecto.Utilidades
{
    public static class Utilidades {
        public static string ConvertirMayusculas(this string texto) {
            if (string.IsNullOrEmpty(texto)) {
                return string.Empty; // Retorna una cadena vacía si el texto es nulo o vacío
            }
            return texto.ToUpper()+"----------"; // Convierte el texto a mayúsculas
        }

        public static string CapitalizarPrimeraLetra(this string texto) {
            if (string.IsNullOrEmpty(texto)) {
                return string.Empty; // Retorna una cadena vacía si el texto es nulo o vacío
            }
            return char.ToUpper(texto[0]) + texto.Substring(1); // Capitaliza la primera letra del texto
        }

        public static int CalcularAntiguedad(this DateTime fecha) {
            var edad = DateTime.Now.Year - fecha.Year;
            if (DateTime.Now < fecha.AddYears(edad)) {
                edad--; // Ajusta la edad si el cumpleaños aún no ha ocurrido este año
            }
            return edad; // Retorna la edad calculada
        }
    }
}
