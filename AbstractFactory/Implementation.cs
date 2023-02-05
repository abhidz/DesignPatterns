namespace AbstractFactory
{
    /// <summary>
    /// Abstract Factory
    /// </summary>

    public interface IShoppingCartPurchaseFactory
    {
        IDiscountService CreateDiscountService();

        IShippingCostsService CreateShippingCostsService();
    }

    /// <summary>
    /// Abstract Product
    /// </summary>
    public interface IDiscountService
    {
        int DiscountPercentage { get; }
    }

    public interface IShippingCostsService
    {
        decimal ShoppingCosts { get; }
    }

    /// <summary>
    /// Concrete Product
    /// </summary>
    public class BelgiumDiscountService : IDiscountService
    {
        public int DiscountPercentage => 20;
    }

    public class FranceDiscountService : IDiscountService
    {
        public int DiscountPercentage => 10;
    }

    public class BelgiumShippingCostsService : IShippingCostsService
    {
        public decimal ShoppingCosts => 20;
    }
    public class FranceShippingCostsService : IShippingCostsService
    {
        public decimal ShoppingCosts => 25;
    }
    /// <summary>
    /// Concrete Factory
    /// </summary>
    public class BelgiumShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
    {
        public IDiscountService CreateDiscountService()
        {
            return new BelgiumDiscountService();
        }

        public IShippingCostsService CreateShippingCostsService()
        {
            return new BelgiumShippingCostsService();
        }
    }

    public class FranceShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
    {
        public IDiscountService CreateDiscountService()
        {
            return new FranceDiscountService();
        }

        public IShippingCostsService CreateShippingCostsService()
        {
            return new FranceShippingCostsService();
        }
    }

    /// <summary>
    /// Client class
    /// </summary>
    public class ShoppingCart
    {
        private readonly IDiscountService _discountService;
        private readonly IShippingCostsService _shippingCostsService;
        private int _orderCosts;
        public ShoppingCart(IShoppingCartPurchaseFactory _factory)
        {
            _discountService = _factory.CreateDiscountService();
            _shippingCostsService = _factory.CreateShippingCostsService();
            _orderCosts = 200;
        }

        public void CalculateCosts()
        {
            Console.WriteLine($"Total costs = " + $"{ _orderCosts - (_orderCosts / 100 * _discountService.DiscountPercentage) + _shippingCostsService.ShoppingCosts}");
        }
    }
}
