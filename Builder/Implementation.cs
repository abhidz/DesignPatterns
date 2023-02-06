using System.Text;

namespace BuilderPattern
{
    /// <summary>
    /// Product
    /// </summary>
    public class Car
    {
        private readonly List<string> _parts = new();
        private readonly string _carType;
        public Car(string carType)
        {
            _carType = carType;
        }

        public void AddPart(string part)
        {
            _parts.Add(part);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (string part in _parts)
            {
                sb.Append($"Car of Type {_carType} has part {part}");
            }
            return sb.ToString();
        }
    }

    /// <summary>
    /// Builder
    /// </summary>
    public abstract class CarBuilder
    {
        public Car car { get; private set; }
        public CarBuilder(string carType)
        {
            car = new Car(carType);
        }

        public abstract void BuildEngine();
        public abstract void BuildFrame();
    }

    /// <summary>
    /// Conceret Builder
    /// </summary>
    public class MiniBuilder : CarBuilder
    {
        public MiniBuilder() : base("Mini")
        {

        }
        public override void BuildEngine()
        {
            car.AddPart("'not a v8'");
        }

        public override void BuildFrame()
        {
            car.AddPart("'3 door'");
        }
    }

    public class BMWBuilder : CarBuilder
    {
        public BMWBuilder() : base("BMW")
        {

        }
        public override void BuildEngine()
        {
            car.AddPart("'a fancy v8'");
        }

        public override void BuildFrame()
        {
            car.AddPart("'7 door'");
        }
    }
    /// <summary>
    /// Director
    /// </summary>
    public class Garage
    {
        private CarBuilder _builder;

        public Garage()
        {

        }
        public void Construct(CarBuilder carBuilder)
        {
            _builder = carBuilder;
            _builder.BuildFrame();
            _builder.BuildEngine();
        }
    }
}
