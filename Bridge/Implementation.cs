namespace Bridge
{
    ///<summary>
    ///Abstarction
    /// </summary>
    public abstract class Menu
    {
        public readonly ICoupon _coupon = null!;
        public abstract int CalculatePrice();
        public Menu(ICoupon coupon)
        {
            _coupon = coupon;
        }
    }

    ///<summary>
    ///ConceretAbstarction
    /// </summary>
    public class VegeterianMenu : Menu
    {
        public VegeterianMenu(ICoupon coupon):base(coupon)
        {

        }
        public override int CalculatePrice()
        {
            return 20 - _coupon.CouponValue;
        }
    }

    ///<summary>
    ///ConceretAbstarction
    /// </summary>
    public class NonVegeterianMenu : Menu
    {
        public NonVegeterianMenu(ICoupon coupon) : base(coupon)
        {

        }
        public override int CalculatePrice()
        {
            return 30 - _coupon.CouponValue;
        }
    }
    ///<summary>
    ///Implementor
    /// </summary>
    public interface ICoupon
    {
        int CouponValue { get; }
    }

    ///<summary>
    ///ConcereteImplementor
    /// </summary>
    public class Nocoupon:  ICoupon
    {
        public int CouponValue => 0;
    }
    public class OneEurocoupon : ICoupon
    {
        public int CouponValue => 1;
    }
    public class TwoEurocoupon : ICoupon
    {
        public int CouponValue => 2;
    }
}