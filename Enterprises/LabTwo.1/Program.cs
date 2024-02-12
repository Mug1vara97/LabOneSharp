using System;

/// <summary>
/// 
/// </summary>
class Company
{
    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
}
/// <summary>
/// 
/// </summary>
class Department
{
    private string name;
    private int numOfEmployees;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int NumOfEmployees
    {
        get { return numOfEmployees; }
        set { numOfEmployees = value; }
    }
}

class Employee
{
    private string fullName;
    private string position;
    private double salary;
    private string departmentName;
    private int departmentNumOfEmployees;
    private string companyName;

    public string FullName
    {
        get { return fullName; }
        set { fullName = value; }
    }

    public string Position
    {
        get { return position; }
        set { position = value; }
    }

    public double Salary
    {
        get { return salary; }
        set { salary = value; }
    }

    public string DepartmentName
    {
        get { return departmentName; }
        set { departmentName = value; }
    }

    public int DepartmentNumOfEmployees
    {
        get { return departmentNumOfEmployees; }
        set { departmentNumOfEmployees = value; }
    }

    public string CompanyName
    {
        get { return companyName; }
        set { companyName = value; }
    }

    public double CalculateSalary()
    {
        try
        {
            if (salary < 0)
            {
                throw new SalaryException("Невозможно создать сотрудника – указан отрицательный оклад:" + salary);
            }

            return salary;
        }
        catch (SalaryException ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }

        return 0;
    }
}

class FullTimeEmployee : Employee
{
    private double bonus;

    public double Bonus
    {
        get { return bonus; }
        set { bonus = value; }
    }

    public double CalculateSalary()
    {
        try
        {
            if (bonus < 0)
            {
                throw new BonusException("Отрицательное значение премии.");
            }

            return base.CalculateSalary() + bonus;
        }
        catch (BonusException ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }

        return base.CalculateSalary();
    }
}

class ContractEmployee : Employee
{
    public double CalculateSalary()
    {
        return base.CalculateSalary();
    }
}

class SalaryException : Exception
{
    public SalaryException(string message) : base(message) { }
}

class BonusException : Exception
{
    public BonusException(string message) : base(message) { }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            FullTimeEmployee employee1 = new FullTimeEmployee();
            employee1.FullName = "Test";
            employee1.Position = "zxc";
            employee1.Salary = -2000;
            employee1.Bonus = -500;
            employee1.CompanyName = "ABC Company";
            employee1.DepartmentName = "IT";
            employee1.DepartmentNumOfEmployees = 10;
            double salary1 = employee1.CalculateSalary();
            Console.WriteLine(employee1.CompanyName + "\n" + employee1.DepartmentName + "\n" + employee1.FullName + "\n" + employee1.Position + "\n" + "Зарплата: " + salary1);

            ContractEmployee employee2 = new ContractEmployee();
            employee2.Salary = 1500;
            employee2.CompanyName = "ABC Company";
            employee2.DepartmentName = "HR";
            employee2.DepartmentNumOfEmployees = 5;
            double salary2 = employee2.CalculateSalary();
            Console.WriteLine("Зарплата: " + salary2);
        }
        catch (SalaryException ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
        catch (BonusException ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
    }
}