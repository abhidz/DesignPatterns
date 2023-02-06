using Prototype;

Console.Title = "Prototype";

var manager = new Manager("Dan");
var managerClone = (Manager)manager.Clone();
Console.WriteLine($"Manager was cloned : { managerClone.Name}");
Console.WriteLine($"Manager was cloned : { manager.Name}");


var employee = new Employee("Abhi", managerClone);
var employeeClone = (Employee)employee.Clone();
Console.WriteLine($"Employee was cloned : { employeeClone.Name} && {employeeClone.Manager.Name}");

// chnage the manager name
managerClone.Name = "David";
Console.WriteLine($"Employee was cloned  : { employeeClone.Name} {employeeClone.Manager.Name}");
Console.ReadLine();
