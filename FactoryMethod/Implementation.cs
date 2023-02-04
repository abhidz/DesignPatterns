namespace FactoryMethod
{
    ///---------------------------------Product--------------------------------------------------
   /// <summary>
   /// Product
   /// </summary>
   public abstract class DiscountService
    {
        public abstract int DiscountPercentage { get; }

        public override string ToString()
        {
            return GetType().Name;
        }
    }

    /// <summary>
    /// Concrete Product
    /// </summary>
    public class CountryDiscountServices : DiscountService
    {
        private readonly string _countryIdentifier  ;

        public CountryDiscountServices(string countryIdentifier)
        {
            _countryIdentifier = countryIdentifier;
        }
        public override int DiscountPercentage
        {
            get
            {
                switch (_countryIdentifier)
                {
                    case "BE":
                        return 20;
                    default:
                        return 10;
                }
            }
        }
    }

    /// <summary>
    /// Concrete Product
    /// </summary>
    public class CodeDiscountServices : DiscountService
    {
        private readonly Guid _code;

        public CodeDiscountServices(Guid code)
        {
            _code = code;
        }
        public override int DiscountPercentage
        {
            get
            {
                return 15;
            }
        }
    }

    public class CityDiscountServices : DiscountService
    {
        private readonly string _cityName;

        public CityDiscountServices(string cityName)
        {
            _cityName = cityName;
        }
        public override int DiscountPercentage
        {
            get
            {
                switch (_cityName)
                {
                    case "AS":
                        return 10;
                    default:
                        return 12;
                }
            }
        }
    }

    /// ----------------------------------------Creator----------------------------
    /// <summary>
    /// Creator
    /// </summary>
    public abstract class DiscountFactory
    {
        public abstract DiscountService CreateDiscountService();
    }

    /// <summary>
    /// Concrete Creator
    /// </summary>
    /// 
    public class CountryDiscountFactory : DiscountFactory
    {
        private readonly string _countryIdentifier;

        public CountryDiscountFactory(string countryIdentifier)
        {
            _countryIdentifier = countryIdentifier;
        }
        public override DiscountService CreateDiscountService()
        {
            return new CountryDiscountServices(_countryIdentifier);
        }
    }

    /// <summary>
    /// Concrete Creator
    /// </summary>
    /// 
    public class CodeDiscountFactory : DiscountFactory
    {
        private readonly Guid _code;

        public CodeDiscountFactory(Guid code)
        {
            _code = code;
        }
        public override DiscountService CreateDiscountService()
        {
            return new CodeDiscountServices(_code);
        }
    }

    /// <summary>
    /// Concrete Creator
    /// </summary>
    /// 
    public class CityDiscountFactory : DiscountFactory
    {
        private readonly string _cityName;

        public CityDiscountFactory(string cityName)
        {
            _cityName = cityName;
        }
        public override DiscountService CreateDiscountService()
        {
            return new CityDiscountServices(_cityName);
        }
    }

}
