using Facade;

Console.Title = "Facade";
var facade = new DiscountFacade();
Console.WriteLine(facade.CalculateDiscountPercentage(1));
Console.WriteLine(facade.CalculateDiscountPercentage(10));
Console.ReadLine();