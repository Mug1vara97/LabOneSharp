using System;

///<summary>
///Класс представляет компанию. 
///</summary> 
class Company
{
    private string name;

    ///<summary>
    ///Название компании.
    ///</summary>
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
}

///<summary> 
///Класс представляет отдел компании. 
///</summary> 
class Department 
{ 
    private string name; 
    private int numOfEmployees;


///<summary>
///Название отдела.
///</summary>
public string Name
{
    get { return name; }
    set { name = value; }
}

///<summary>
///Количество сотрудников в отделе.
///</summary>
public int NumOfEmployees
{
    get { return numOfEmployees; }
    set { numOfEmployees = value; }
}
}

///<summary>
///Класс представляет сотрудника компании. 
///</summary> 
class Employee 
{ 
    private string fullName; 
    private string position; 
    private double salary; 
    private string departmentName; 
    private int departmentNumOfEmployees; 
    private string companyName;

 
///<summary>
///ФИО сотрудника.
///</summary>
public string FullName
{
    get { return fullName; }
    set { fullName = value; }
}

///<summary>
///Должность сотрудника.
///</summary>
public string Position
{
    get { return position; }
    set { position = value; }
}

///<summary>
///Оклад сотрудника.
///</summary>
public double Salary
{
    get { return salary; }
    set { salary = value; }
}

///<summary>
///Название отдела, в котором работает сотрудник.
///</summary>
public string DepartmentName
{
    get { return departmentName; }
    set { departmentName = value; }
}

///<summary>
///Количество сотрудников в отделе, в котором работает сотрудник.
///</summary>
public int DepartmentNumOfEmployees
{
    get { return departmentNumOfEmployees; }
    set { departmentNumOfEmployees = value; }
}

///<summary>
///Название компании, в которой работает сотрудник.
///</summary>
public string CompanyName
{
    get { return companyName; }
    set { companyName = value; }
}

///<summary>
///Метод для расчета зарплаты сотрудника.
///</summary>
///<returns>Зарплата сотрудника.</returns>
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

///<summary>
///Класс представляет сотрудника компании на полный рабочий день. 
///</summary> 
class FullTimeEmployee : Employee
{
    private double bonus;


    ///<summary>
    ///Премия сотрудника.
    ///</summary>
    public double Bonus
    {
        get { return bonus; }
        set { bonus = value; }
    }

    ///<summary>
    ///Метод для расчета зарплаты сотрудника на полный рабочий день.
    ///</summary>
    ///<returns>Зарплата сотрудника на полный рабочий день.</returns>
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

///<summary> 
///Класс представляет сотрудника компании по контракту.
///</summary> 
class ContractEmployee : Employee
{
    ///<summary> 
    ///Метод для расчета зарплаты сотрудника по контракту. 
    ///</summary> 
    ///<returns>Зарплата сотрудника по контракту.</returns> 
    public double CalculateSalary()
    {
        return base.CalculateSalary();
    }
}

///<summary> 
///Класс исключения для ошибки с окладом.
///</summary> 
class SalaryException : Exception
{
    ///<summary> 
    ///Конструктор класса исключения.
    ///</summary> 
    ///<param name="message">Сообщение об ошибке.</param>
    public SalaryException(string message) : base(message) { }
}

///<summary>
///Класс исключения для ошибки с премией. 
///</summary> 
class BonusException : Exception
{
    ///<summary> 
    ///Конструктор класса исключения. 
    ///</summary> 
    ///<param name="message">Сообщение об ошибке.</param> 
    public BonusException(string message) : base(message)
    {
    }
}
/// <summary>
/// 
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        try
        {
            FullTimeEmployee employee1 = new FullTimeEmployee();
            employee1.FullName = "Test";
            employee1.Position = "zxc";
            employee1.Salary = 2000;
            employee1.Bonus = -500;
            employee1.CompanyName = "ZXC";
            employee1.DepartmentName = "IT";
            employee1.DepartmentNumOfEmployees = 10;
            double salary1 = employee1.CalculateSalary();
            Console.WriteLine(employee1.CompanyName + "\n" + employee1.DepartmentName + "\n" + employee1.FullName + "\n" + employee1.Position + "\n" + "Зарплата: " + salary1);

            ContractEmployee employee2 = new ContractEmployee();
            employee2.FullName = "Test";
            employee2.Position = "zxc";
            employee2.Salary = -2000;
            employee2.CompanyName = "123";
            employee2.DepartmentName = "IT";
            employee2.DepartmentNumOfEmployees = 10;
            double salary2 = employee2.CalculateSalary();
            Console.WriteLine(employee2.CompanyName + "\n" + employee2.DepartmentName + "\n" + employee2.FullName + "\n" + employee2.Position + "\n" + "Зарплата: " + salary2);
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