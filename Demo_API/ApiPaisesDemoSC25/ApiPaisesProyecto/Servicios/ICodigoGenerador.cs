namespace ApiPaisesProyecto.Servicios;

public interface ICodigoGenerador {
    string GenerarCodigo(string prefijo);
}

public class CodigoGenerador : ICodigoGenerador {
    int numRandom = new Random().Next(1000, 9999);
    string date = DateTime.Now.ToString("yyyyMMdd");
    public string GenerarCodigo(string prefijo) {
        return $"{prefijo}-{date}-{numRandom}";
    }
}