namespace Strategy
{
    ///<summary>
    ///Strategy
    /// </summary>
    public interface IExportService
    {
        void Export(Order order);
    }

    ///<summary>
    ///Concrete Strategy
    /// </summary>  
    public class JsonExportService : IExportService
    {
        public void Export(Order order)
        {
            Console.WriteLine($"Exporting {order.Name} in Json");
        }
    }
    public class XMLExportService : IExportService
    {
        public void Export(Order order)
        {
            Console.WriteLine($"Exporting {order.Name} in XML");
        }
    }
    public class CSVExportService : IExportService
    {
        public void Export(Order order)
        {
            Console.WriteLine($"Exporting {order.Name} in CSV");
        }
    }

    ///<summary>
    ///Context
    /// </summary>
    public class Order
    {
        public Order(string name, int amount, string customer)
        {
            Name = name;
            Amount = amount;
            Customer = customer;
        }

        public string Name { get; set; }
        public string? Description { get; set; }
        public int Amount { get; set; }

        public string Customer { get; set; }

        public void Export(IExportService exportService)
        {
            if(exportService == null)
            {
                throw new ArgumentNullException(nameof(exportService));
            }
            exportService.Export(this);
        }

    }
}
