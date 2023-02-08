namespace ClassAdapter
{
    /// <summary>
    /// Helper class
    /// </summary>
    public class CityFromExternalSystem
    {
        public CityFromExternalSystem(string name, string nickName, int inhabitants)
        {
            Name = name;
            NickName = nickName;
            Inhabitants = inhabitants;
        }

        public string Name { get; private set; }
        public string NickName { get; private set; }
        public int Inhabitants { get; private set; }

    }

    public class City
    {
        public City(string fullName, long inhabitants)
        {
            FullName = fullName;
            Inhabitants = inhabitants;
        }

        public string FullName { get; private set; }
        public long Inhabitants { get; private set; }

    }

    /// <summary>
    /// Adaptee
    /// </summary>
    public class ExternalSystem
    {
        public CityFromExternalSystem GetCity()
        {
            return new CityFromExternalSystem("Delhi", "Dil", 10000);
        }
    }

    /// <summary>
    /// Target
    /// </summary>
    public interface ICityAdaptor
    {
        City GetCity();
    }

    /// <summary>
    /// Adapter
    /// </summary>
    public class CityAdaptor :ExternalSystem, ICityAdaptor
    {
        public City GetCity()
        {
            // call into the external system
            var cityFromExternalSystem = base.GetCity();
            // adapt the cityFromExternalCity to a city
            return new City($"{cityFromExternalSystem.Name} - {cityFromExternalSystem.NickName}", cityFromExternalSystem.Inhabitants);
        }
    }
}

// Here City and CityFromExternalSystem are incompatiable classes. Clients want to use ExternalSystem class which is exposing CityFromExternalSystem
// through its GetCity() method
//But, our system cannot work with ExternalSystem class, it will work with City class having different properties as compared to CityFromExternalSystem
// Hence we want to convert City from ExternalSystem to City or adapt ExternalSystem
// Hence,we can create a new wrapper/Adaptor which is ICityAdaptor