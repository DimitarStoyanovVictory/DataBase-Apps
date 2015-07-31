using System;
using System.Linq;
using DataBase_Apps_Lectures;

class Program
{
    static void Main()
    {
        var context = new SoftUniEntities();
        var employees = context.Employees
            .Where(e => e.FirstName == "Jhon")
            .OrderBy(e => e.LastName)
            .Select(e => e.Address.AddressText);

        foreach (string employee in employees)
        {
            Console.WriteLine(employee);    
        }
    }
}
