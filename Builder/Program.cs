using BuilderPattern;

Console.Title = "Builder";
var garage = new Garage();

var miniBuilder = new MiniBuilder();
var bmwBuider  =   new BMWBuilder();

garage.Construct(miniBuilder);
Console.WriteLine(miniBuilder.car.ToString());

garage.Construct(bmwBuider);
Console.WriteLine(bmwBuider.car.ToString());

Console.ReadLine();

