namespace Contener;

public class LiquidContener : Contener,IHazardNotifier

{
    protected bool hazardous;

    public LiquidContener(double contenerWeight, double height, double depth, double cargoCapacity, bool hazardous) 
        : base("L", contenerWeight, height, depth, cargoCapacity)
    {
        this.hazardous = hazardous;
    }

    public override void LoadCargo(double mass)
    {   
        double multiplier = 0.9;
        if (hazardous)
        {
            multiplier = 0.5;
        }
        
        double loadLimit = multiplier * cargoCapacity;
        if (cargoMass + mass > loadLimit)
        {
            NotifyHazard($"Trying to overflow contener {serialNumber}");
        }
        base.LoadCargo(mass);
    }


    public void NotifyHazard(string message)
    {
        Console.WriteLine(message);
    }
}

