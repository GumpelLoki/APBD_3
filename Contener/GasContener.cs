namespace Contener;

public class GasContener :Contener,IHazardNotifier
{
    protected double pressure;

    public GasContener(double contenerWeight, double height, double depth, double cargoCapacity, double pressure)
        : base("G", contenerWeight, height, depth, cargoCapacity)
    {
        this.pressure = pressure;
    }


    public override void UnloadCargo()
    {
        double temp = 0.05*cargoMass;
        base.UnloadCargo();
        cargoMass = temp;
    }


    public void NotifyHazard(string message)
    {
        Console.WriteLine($"{message} {serialNumber}");
    }
}