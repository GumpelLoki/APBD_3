namespace Contener;

public class RefrigeratedContener :Contener

{
    protected double temperature;
    protected ProductType? productType;
    public RefrigeratedContener(double contenerWeight, double height, double depth, double cargoCapacity, double temperature)
        : base("C", contenerWeight, height, depth, cargoCapacity)
    {
        this.temperature = temperature;
    }


    public void LoadCargo(double mass, ProductType productType)
    {
        double minTemperature = GetMinTemperature(productType);
        

        if (this.productType == null || cargoMass == 0)
        {
            this.productType = productType;
        }
        else if (this.productType!=productType){
            throw new InvalidOperationException($"The cargo is {this.productType},can't put in {productType}");
        }
        if (temperature < minTemperature)
        {
            throw new InvalidOperationException($"Temperature is too low for {productType}");
        }
        
        base.LoadCargo(mass);
    }


    private double GetMinTemperature(ProductType productType)
    {
        switch (productType)
        {
            case ProductType.Bananas:
                return 13.3;
            case ProductType.Chocolate:
                return 18.0;
            case ProductType.Fish:
                return 2.0;
            case ProductType.Meat:
                return -15.0;
            case ProductType.IceCream:
                return -18.0;
            case ProductType.FrozenPizza:
                return -30.0;
            case ProductType.Cheese:
                return 7.2;
            case ProductType.Sausages:
                return 5.0;
            case ProductType.Butter:
                return 20.5;
            case ProductType.Eggs:
                return 19.0;
            default:
                return 0.0;
        }
    }
}
public enum ProductType
{
    Bananas,
    Chocolate,
    Fish,
    Meat,
    IceCream,
    FrozenPizza,
    Cheese,
    Sausages,
    Butter,
    Eggs
}