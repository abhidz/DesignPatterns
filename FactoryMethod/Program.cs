using FactoryMethod;

Console.Title = "Factory Method";
var factories = new List<DiscountFactory>()
{
    new CodeDiscountFactory(Guid.NewGuid()),
    new CountryDiscountFactory("BE"),
    new CityDiscountFactory("RR")
};

foreach (var item in factories)
{
    var discountService = item.CreateDiscountService();
    Console.WriteLine(discountService.DiscountPercentage + " " + discountService);
}

Console.ReadLine();