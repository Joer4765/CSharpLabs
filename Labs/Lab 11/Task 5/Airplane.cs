namespace Task_5;

public class Airplane
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int MaxSpeed { get; set; }
    public int MaxAltitude { get; set; }

    public Airplane(string brand, string model, int maxSpeed, int maxAltitude)
    {
        Brand = brand;
        Model = model;
        MaxSpeed = maxSpeed;
        MaxAltitude = maxAltitude;
    }

    public double Cost()
    {
        return MaxSpeed * 1000 + MaxAltitude * 100;
    }

    public string Info()
    {
        return $"Brand: {Brand}, Model: {Model}, Max Speed: {MaxSpeed}, Cost: {Cost()}";
    }
}

public class Bomber : Airplane
{
    public string PilotName { get; set; }

    public Bomber(string brand, string model, int maxSpeed, int maxAltitude, string pilotName) 
        : base(brand, model, maxSpeed, maxAltitude)
    {
        PilotName = pilotName;
    }

    public new double Cost()
    {
        return base.Cost() * 2;
    }

    public string Info()
    {
        return $"Brand: {Brand}, Model: {Model}, Max Speed: {MaxSpeed}, Cost: {Cost()}, Pilot Name: {PilotName}";
    }
}

public class Fighter : Airplane
{
    public string MissionGroup { get; set; }

    public Fighter(string brand, string model, int maxSpeed, int maxAltitude, string missionGroup) 
        : base(brand, model, maxSpeed, maxAltitude)
    {
        MissionGroup = missionGroup;
    }

    public new double Cost()
    {
        return base.Cost() * 3;
    }

    public string Info()
    {
        return $"Brand: {Brand}, Model: {Model}, Max Speed: {MaxSpeed}, Cost: {Cost()}, Mission Group: {MissionGroup}";
    }
}
