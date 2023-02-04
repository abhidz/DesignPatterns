using Singleton;

Console.Title = "Singleton";

var instance1 = Logger.Instance;
var instance2 = Logger.Instance;

if(instance1 == instance2 && instance2 == Logger.Instance)
{
    Console.WriteLine("Instances are same");
}

instance1.Log(nameof(instance1));
instance2.Log(nameof(instance2));
Logger.Instance.Log(nameof(Logger.Instance));
Console.ReadLine();