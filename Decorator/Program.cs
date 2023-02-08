using Decorator;

Console.Title = "Decorator";

var cloudMailService = new CloudMailService();
cloudMailService.SendMail("Hi from cloud");


var premiseMailService = new OnpremiseMailService();
premiseMailService.SendMail("Hi from premise");

// add behavior
var statisticsDecorator = new StatisticsDecorator(cloudMailService);
statisticsDecorator.SendMail($"Hi there via {nameof(StatisticsDecorator)} wrapper");

var messageDbDecorator = new MessageDatabaseDecorator(premiseMailService);
messageDbDecorator.SendMail("hello");
messageDbDecorator.SendMail("hi");

foreach (var item in messageDbDecorator.SendMessages)
{
    Console.WriteLine($"Stored mssages are {item}");
}

Console.ReadKey();