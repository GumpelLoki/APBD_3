using Contener;
Contenership shipA = new Contenership(20,5,50);
Contenership shipB = new Contenership(23,14,100000);
var cont1 = new RefrigeratedContener(2000,250,600,1000,4);
var cont2 = new LiquidContener(2000,250,600,1000,true);
var cont3 = new GasContener(1500, 220, 500, 5000, 1.0);
try
{
    cont1.LoadCargo(1000,ProductType.Eggs);
    
}
catch (Exception e)
{
    Console.WriteLine(e);
    
}
cont2.LoadCargo(600);
try
{
    cont3.LoadCargo(6000);
    
}
catch (Exception e)
{
    Console.WriteLine(e);
    
}
cont1.LoadCargo(1000,ProductType.Fish);
cont3.LoadCargo(1000);
try
{
    ;
    shipB.LoadContener(cont1);
    shipB.LoadContener(cont2);

    
    var extraConteners = new List<Contener.Contener>
    {
        new GasContener(1600, 220, 500, 4000, 1.2),
        new RefrigeratedContener(2500, 300, 600, 12000, 5)
    };
    shipA.LoadConteners(extraConteners);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
Console.Write(shipB);

shipB.TransferContener(shipA,cont3.serialNumber);
shipB.TransferContener(shipA,cont2.serialNumber);
