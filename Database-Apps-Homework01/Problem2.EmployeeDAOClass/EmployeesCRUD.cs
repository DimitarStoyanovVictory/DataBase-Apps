using System;
using System.Linq;
using DatabaseSoftUni;

public static class EmployeesCRUD
{
    private static readonly SoftUniEntities _context = new SoftUniEntities();

    public static void Add(Employee employee)
    {
        _context.Employees.Add(employee);

        _context.SaveChanges();
    }

    public static Employee FindByKey(object key)
    {
        var output = _context.Employees.Find(key);

        return output;
    }

    public static void Modify(Employee employeeForUpdate)
    {
        var employee = _context.Employees
            .Where(e => e.EmployeeID == employeeForUpdate.EmployeeID)
            .Select(e => e).ToList()[0];

        employee.FirstName = employeeForUpdate.FirstName;
        employee.MiddleName = employeeForUpdate.MiddleName;
        employee.LastName = employeeForUpdate.LastName;
        employee.JobTitle = employeeForUpdate.JobTitle;
        employee.DepartmentID = employeeForUpdate.DepartmentID;
        employee.ManagerID = employeeForUpdate.ManagerID;
        employee.HireDate = employeeForUpdate.HireDate;
        employee.Salary = employeeForUpdate.Salary;
        employee.AddressID = employeeForUpdate.AddressID;

        _context.SaveChanges();
    }

    public static void Delete(Employee employee)
    {
        var em = _context.Employees.Find(employee.EmployeeID);

        _context.Employees.Remove(em);

        _context.SaveChanges();
    }

    static void Main()
    {
        var context = new SoftUniEntities();

        #region MethodOne

        var firstEmployee = new Employee()
        {
            EmployeeID = 1,
            FirstName = "Dominik",
            LastName = "Stoyanov",
            JobTitle = "Sales Representative",
            DepartmentID = 6,
            ManagerID = 268,
            HireDate = new DateTime(2003, 12, 6),
            Salary = 2000,
            AddressID = 200
        };

        Add(firstEmployee);

        var methodOneEmployees = context.Employees.Where(e => e.FirstName == "Dominik").Select(e => e);

        methodOneEmployees.ToList().ForEach(e => Console.WriteLine(e.FirstName));

        Console.WriteLine();

        #endregion

        #region MethodTwo

        Console.WriteLine(FindByKey(12).FirstName);

        Console.WriteLine();

        #endregion

        #region MethodTree

        var thirdEmployee = new Employee()
        {
            EmployeeID = 1,
            FirstName = "Dominik",
            LastName = "Stoyanov",
            JobTitle = "Sales Representative",
            DepartmentID = 6,
            ManagerID = 268,
            HireDate = new DateTime(2003, 12, 6),
            Salary = 2000,
            AddressID = 200
        };

        Modify(thirdEmployee);

        var methodThreeEmployees = context.Employees.Where(e => e.EmployeeID == 1).Select(e => e).ToList();

        methodThreeEmployees.ForEach(e => Console.WriteLine(e.FirstName));

        Console.WriteLine();

        #endregion

        #region MethodFour

        var fourthEmployee = new Employee()
        {
            EmployeeID = 1,
            FirstName = "Kevin",
            LastName = "Brown",
            JobTitle = "Marketing Assistant",
            DepartmentID = 4,
            ManagerID = 6,
            HireDate = new DateTime(1999 - 02 - 26),
            Salary = 13500,
            AddressID = 102
        };

        Delete(fourthEmployee);

        var methodFourEmployees = _context.Employees.Select(e => e.EmployeeID).ToList();

        methodFourEmployees.ForEach(e => Console.WriteLine(e));

        #endregion
    }
}
