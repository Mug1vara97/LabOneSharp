using System;

public class PremiyaException : Exception
{
    public PremiyaException(string message) : base(message)
    {
    }
}

public class OkladException : Exception
{
    public OkladException(string message) : base(message)
    {
    }
}

public class Firm
{
    public string Name { get; set; }
}

public class Department
{
    public string Name { get; set; }
    public int EmployeeCount { get; set; }
}

public class Employee
{
    public string FullName { get; set; }
    public string Position { get; set; }
    public decimal Salary { get; set; }

    public virtual decimal CalculateSalary()
    {
        return Salary;
    }
}

public class StaffEmployee : Employee
{
    public decimal Bonus { get; set; }

    public override decimal CalculateSalary()
    {
        try
        {
            if (Bonus < 0)
                throw new PremiyaException("Отрицательное значение премии");

            return base.CalculateSalary() + Bonus;
        }
        catch (PremiyaException ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
            return base.CalculateSalary();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
            return base.CalculateSalary();
        }
    }
}

public class ContractEmployee : Employee
{
    public override decimal CalculateSalary()
    {
        try
        {
            if (Salary < 0)
                throw new OkladException("Отрицательное значение оклада");

            return base.CalculateSalary();
        }
        catch (OkladException ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
            return base.CalculateSalary();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
            return base.CalculateSalary();
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {

        Firm firm = new Firm();
        firm.Name = "Моя фирма";

        Department department = new Department();
        department.Name = "Отдел разработки";
        department.EmployeeCount = 5;

        StaffEmployee staffEmployee = new StaffEmployee();
        staffEmployee.FullName = "Иванов Иван Иванович";
        staffEmployee.Position = "Программист";
        staffEmployee.Salary = 1000; // некорректного значения только при -
        staffEmployee.Bonus = -1000; // некорректного значения только при -


        decimal staffSalary = staffEmployee.CalculateSalary();
        Console.WriteLine("Зарплата штатного сотрудника: " + staffSalary);

        ContractEmployee contractEmployee = new ContractEmployee();
        contractEmployee.FullName = "Петров Петр Петрович";
        contractEmployee.Position = "Тестировщик";
        contractEmployee.Salary = -10000; // некорректного значения только при -

        decimal contractSalary = contractEmployee.CalculateSalary();
        Console.WriteLine("Зарплата сотрудника по контракту: " + contractSalary);
    }
}