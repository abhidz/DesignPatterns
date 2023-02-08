using Bridge;

Console.Title = "Bridge";

var noCoupon = new Nocoupon();
var oneEuroCoupn = new OneEurocoupon();

var nonVegMenu = new NonVegeterianMenu(noCoupon);
Console.WriteLine($"Non veg menu, no coupon {nonVegMenu.CalculatePrice()} euro");

nonVegMenu = new NonVegeterianMenu(oneEuroCoupn);
Console.WriteLine($"Non veg menu, one euro coupon {nonVegMenu.CalculatePrice()} euro");

var vegMenu = new VegeterianMenu(noCoupon);
Console.WriteLine($"Non veg menu, no coupon {vegMenu.CalculatePrice()} euro");

vegMenu = new VegeterianMenu(oneEuroCoupn);
Console.WriteLine($"Non veg menu, one euro  coupon {vegMenu.CalculatePrice()} euro");

Console.ReadLine();