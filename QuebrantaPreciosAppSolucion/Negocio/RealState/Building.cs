
namespace Business.RealState;  
public class Building  {
    public string Name { get; set; }
    public int Id { get; set; }
    public int FloorNumber { get; set; }
    public bool HasLift { get; set; }
    public int ApartmentsPerFloor { get; private set; }

    public District District { get; set; }

    public Building() { }

    // Constructor with parameters
    //public Building(string name, int id, int floorNumber, bool hasLift) {
    //    Name = name;
    //    Id = id;
    //    FloorNumber = floorNumber;
    //    HasLift = hasLift;
    //}

    // Constructor with default values
    public Building(string name = "", int id = 0, int floorNumber = 0, bool hasLift = false) {
        Name = name;
        Id = id;
        FloorNumber = floorNumber;
        HasLift = hasLift;
        ApartmentsPerFloor = 4;
    }

    // Crear una lista de edificios
    public static List<Building> GetBuildings() {
        return new List<Building> {
            new Building("Dream Tower", 1, 20, true),
            new Building("SkyLine", 2, 30, true),
            new Building("Ocean View", 3, 15, false)
        };
    }

    //public void ShowApartmentsNumber() {
    //    Console.WriteLine($"Total Apartments in {Name}: {FloorNumber * ApartmentsPerFloor}");
    //}

    private string ShowApartmentsNumber()
    {
         return $"Total Apartments in {Name}: {FloorNumber * ApartmentsPerFloor}";
    }

    public override string ToString() {
        return $"Building: {Name}, Id: {Id}, Floors: {FloorNumber}, Has Lift: {HasLift}, Apartments per Floor: {ApartmentsPerFloor}. Total Apartamentos: {ShowApartmentsNumber}";
    }
}
