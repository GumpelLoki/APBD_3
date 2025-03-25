namespace Contener;

public abstract class Contener
{
    public double cargoMass;
    protected double cargoCapacity;
    protected double height;
    protected double depth;
    public double contenerWeight;
    public string serialNumber;
    private static int _idcounter = 0;

    public Contener(string type, double contenerWeight, double height, double depth, double cargoCapacity)
    {
        this.contenerWeight = contenerWeight;
        this.height = height;
        this.depth = depth;
        this.cargoCapacity = cargoCapacity;
        this.cargoMass = 0;
        this.serialNumber = $"KON-{type}-{++_idcounter}";
        
        
        
    }

    public virtual void UnloadCargo()
    {
        cargoMass = 0;
    }
    public virtual void LoadCargo(double mass)
    {
        if (cargoMass + mass > cargoCapacity)
        {
            throw new OverfillException("Max Capacity Exceeded!");
        }
        cargoMass += mass;
    }

    public override string ToString()
    {
        return $"serialNumber: {serialNumber}\ncargoMass: {cargoMass}\ncargoCapacity: {cargoCapacity}\nheight: {height}\ndepth: {depth}\ncontenerWeight: {contenerWeight}\n";
    }
}
public class OverfillException : Exception
{
    public OverfillException(string message) : base(message) { }
}
public interface IHazardNotifier
{
    void NotifyHazard(string message);
}