namespace Contener;

public class Contenership
{
    protected double maxSpeed;
    protected int maxContenersCount;
    protected int maxWeight;
    private List<Contener> conteners;

    public Contenership(double maxSpeed, int maxContenersCount, int maxWeight)
    
    {
      this.maxSpeed = maxSpeed;
      this.maxContenersCount = maxContenersCount;
      this.maxWeight = maxWeight;
      this.conteners = new List<Contener>();
    }

    public void LoadContener(Contener contener)
    {
        if (conteners.Count >= this.maxContenersCount)
        {
            Console.WriteLine("Contenership is full");
            return;
        }

        double totalWeight = (conteners.Sum(c => c.contenerWeight + c.cargoMass) + contener.contenerWeight + contener.cargoMass)/1000;
        

        if (totalWeight > maxWeight)
        {
            Console.WriteLine("Contenership can't hold more weight");
            return;
        }
        conteners.Add(contener); 
    }

    public void LoadConteners(List<Contener> conteners)
    {
        foreach (Contener contener in conteners)
        {
            LoadContener(contener);
        }
    }
    

    public void UnloadContener(string serialNumber)
    {
        Contener? c = conteners.Find(c => c.serialNumber == serialNumber);
        if (c == null)
        {
            Console.WriteLine("Contener not found");
            return;
        }
        conteners.Remove(c);
    }

    public void UnloadCargofromContener(string serialNumber)
    {
        Contener? c = conteners.Find(c => c.serialNumber == serialNumber);
        if (c == null)
        {
            Console.WriteLine("Contener not found");
            return;
        }
        c.UnloadCargo();
    }

    public void TransferContener(Contenership target,string serialNumber)
    {
        Contener? c = conteners.Find(c => c.serialNumber == serialNumber);
        if (c == null)
        {
            Console.WriteLine("Contener not found");
            return;
        }
        target.LoadContener(c);
        UnloadContener(serialNumber);
    }

    public override string ToString()
    {
        string result = $"maxSpeed: {maxSpeed}\nmaxContenersCount: {maxContenersCount}\nmaxWeight: {maxWeight}\nCurrent weight: {(conteners.Sum(c => c.contenerWeight + c.cargoMass))/1000}\nList of conteners: \n";
        foreach (Contener contener in conteners)
        {
            result += contener.ToString();
        }
        return result;
    }
}