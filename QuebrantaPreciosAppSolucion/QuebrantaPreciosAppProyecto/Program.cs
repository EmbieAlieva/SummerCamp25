

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("QuebrantaPrecios App");

        // Se agrega la dependencia de la clase Bussiness en dependencias de la clase QuebrantaPreciosAppProyecto!!!!


        // Crear instancia de la clase Building
        var building = new Building();

        // Crear instancia de la clase District
        var district = new District();

        // Crear instancia de la clase Building para buildingDreamTower
        var buildingDreamTower = new Building() {
            Name = "Dream Tower",
            Id = 2,
            FloorNumber = 20,
            HasLift = true
        };

        // Crar instancia de la clase Building para buildingSkyline
        var buildingNewGardens = new Building("SkyLine", 3, 30, true);

        var buildingSkyline = new Building(name: "SkyLine", id: 3, floorNumber: 30, hasLift: true);

        // Crear una lista de edificios
        // Todas las listas Implementan IEnumerable<T> y son genéricas
        var buildings = new List<Building> {
           buildingDreamTower,
           buildingNewGardens,
           buildingSkyline
        };

        // Mostrar información de los edificios
        // Mostrar número total de apartamentos por edificio
        //for (int i = 0; i < buildings.Count; i++) {
        //    var build = buildings[i];
        //    Console.WriteLine($"Building: {build.Name}, Id: {build.Id}, Floors: {build.FloorNumber}, Has Lift: {build.HasLift}, Apartments per Floor: {build.ApartmentsPerFloor}");
        //    Console.WriteLine($"Total Apartments in {build.Name}: {build.FloorNumber * build.ApartmentsPerFloor}");
        //}

        foreach (var build in buildings) {
            //build.ShowApartmentsNumber();
            //Console.WriteLine($"Building: {build.Name}, Id: {build.Id}, Floors: {build.FloorNumber}, Has Lift: {build.HasLift}, Apartments per Floor: {build.ApartmentsPerFloor}");

            Console.WriteLine(build);
        }

    }
}