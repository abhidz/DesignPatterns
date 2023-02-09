using Strategy;

Console.Title = "Strategy";

var order = new Order("Marvin Software", 5, "Marcin");
order.Export(new CSVExportService());
order.Export(new JsonExportService());
order.Export(new XMLExportService());

Console.ReadLine();