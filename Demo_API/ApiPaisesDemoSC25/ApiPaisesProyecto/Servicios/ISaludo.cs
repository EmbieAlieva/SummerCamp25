namespace ApiPaisesProyecto.Servicios;

public interface ISaludo {

    string Saludar(string nombre);
}

public class Saludo : ISaludo {
    public string Saludar(string nombre) {
        return $"Hola, {nombre}!";
    }
}

// Saludo en inglés
public class SaludoIngles : ISaludo {
    public string Saludar(string nombre) {
        return $"Hello, {nombre}!";
    }
}

// Saludo en francés
public class SaludoFrances : ISaludo {
    public string Saludar(string nombre) {
        return $"Bonjour, {nombre}!";
    }
}

// Saludo en alemán
public class SaludoAleman : ISaludo {
    public string Saludar(string nombre) {
        return $"Hallo, {nombre}!";
    }
}

// Saludo en italiano
public class SaludoItaliano : ISaludo {
    public string Saludar(string nombre) {
        return $"Ciao, {nombre}!";
    }
}

// Saludo en portugués
public class SaludoPortugues : ISaludo {
    public string Saludar(string nombre) {
        return $"Olá, {nombre}!";
    }
}

// Saludo en ruso
public class SaludoRuso : ISaludo {
    public string Saludar(string nombre) {
        return $"Привет, {nombre}!";
    }
}

// Saludo en chino
public class SaludoChino : ISaludo {
    public string Saludar(string nombre) {
        return $"你好, {nombre}!";
    }
}
