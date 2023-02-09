namespace Facade
{
    ///<summary>
    ///Subsystem class
    /// </summary>
    public class OrderService
    {
        public bool HasEnoughOrders(int customerId)
        {
            return (customerId > 5);
        }
    }
  
    public class CustomerDiscountBaseService
    {
        public double CalculateDiscountBase(int customerId)
        {
            return (customerId > 8) ? 10 : 20;
        }
    }

    public class DayOfTheWeekFactorService
    {
        public double CalculateDayOfTheWeekfactor(int customerId)
        {
            switch (DateTime.UtcNow.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                case DayOfWeek.Saturday:
                    return 0.8;
                default:
                    return 1.2;
            }
        }
    }
    ///<summary>
    ///Facade
    /// </summary>
    public class DiscountFacade
    {
        private readonly OrderService _orderService = new OrderService();
        private readonly CustomerDiscountBaseService _customerDiscountBaseServicee = new CustomerDiscountBaseService();
        private readonly DayOfTheWeekFactorService _dayOfTheWeekFactorService = new DayOfTheWeekFactorService();

        public double CalculateDiscountPercentage(int customerId)
        {
            if (!_orderService.HasEnoughOrders(customerId))
            {
                return 0;
            }
            return _customerDiscountBaseServicee.CalculateDiscountBase(customerId) * _dayOfTheWeekFactorService.CalculateDayOfTheWeekfactor(customerId);
        }
    }
}
