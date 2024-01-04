public class SatelliteDish
{
    public double Diameter { get; set; }
    public string Material { get; set; }
    public double Price { get; set; }

    public SatelliteDish(double diameter, string material, double price)
    {
        Diameter = diameter;
        Material = material;
        Price = price;
    }

    public virtual double Q()
    {
        return Diameter / Price;
    }

    public override string ToString()
    {
        return $"Diameter: {Diameter}, Material: {Material}, Price: {Price}";
    }
}

public class SatelliteDishChild : SatelliteDish
{
    public string SuspensionType { get; set; }

    public SatelliteDishChild(double diameter, string material, double price, string suspensionType) : base(diameter, material, price)
    {
        SuspensionType = suspensionType;
    }

    public override double Q()
    {
        if (SuspensionType == "azimuthal")
            return base.Q();
        else if (SuspensionType == "polar")
            return 2 * base.Q();
        else if (SuspensionType == "toroidal")
            return 2.5 * base.Q();
        else
            return 0;
    }

    public override string ToString()
    {
        return base.ToString() + $", Suspension Type: {SuspensionType}";
    }
}