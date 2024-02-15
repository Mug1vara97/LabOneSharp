using System;

/// <summary>
/// Класс исключения, которое возникает при указании отрицательной суммы вклада.
/// </summary>
class KolichestvoException : Exception
{
    /// <summary>
    /// Создает новый экземпляр класса kolichestvoexception с указанным сообщением об ошибке.
    /// </summary>
    /// <param name="message">Сообщение об ошибке.</param>
    public KolichestvoException(string message) : base(message) { }
}
/// <summary>
/// Класс исключения, которое возникает при указании отрицательного значения количества месяцев
/// </summary>
class VkladException : Exception
{
    /// <summary>
    /// Создает новый экземпляр класса vkladexception с указанным сообщением об ошибке.
    /// </summary>
    /// <param name="message">Сообщение об ошибке.</param>
    public VkladException(string message) : base(message) { }
}
/// <summary>
/// Абстрактный класс, представляющий вклад
/// </summary>
abstract class Vklad
{
    private string fioVkladchika;
    private double summaVklada;
    private string name;
    private string companyName;
    /// <summary>
    /// Название вклада.
    /// </summary>
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    /// <summary>
    /// Название компании.
    /// </summary>
    public string CompanyName
    {
        get { return companyName; }
        set { companyName = value; }
    }
    /// <summary>
    /// ФИО вкладчика.
    /// </summary>
    public string FioVkladchika
    {
        get { return fioVkladchika; }
        set { fioVkladchika = value; }
    }
    /// <summary>
    /// Сумма вклада.
    /// </summary>
    public double SummaVklada
    {
        get { return summaVklada; }
        set
        {
            if (value < 0)
            {
                throw new VkladException("Невозможно создать вклад – указана отрицательная сумма вклада: " + value);
            }
            summaVklada = value;
        }
    }
    /// <summary>
    /// Расчитывает сумму вклада после указанного количества месяцев.
    /// </summary>
    /// <param name="kolichestvoMesyac">Количество месяцев.</param>
    /// <returns>Сумма вклада после указанного количества месяцев.</returns>
    public abstract double RaschitatSummuVklada(int kolichestvoMesyac);

}
/// <summary>
/// Класс, представляющий долгосрочный вклад.
/// </summary>
class DolgosrochnyVklad : Vklad
{
    /// <summary>
    /// Расчитывает сумму вклада после указанного количества месяцев.
    /// </summary>
    /// <param name="kolichestvoMesyac">Количество месяцев.</param>
    /// <returns>Сумма вклада после указанного количества месяцев.</returns>
    public override double RaschitatSummuVklada(int kolichestvoMesyac)
    {
        try
        {
            if (kolichestvoMesyac < 0)
            {
                throw new KolichestvoException("Отрицательное значение количества месяцев.");
            }
            double result = SummaVklada * Math.Pow(1 + 0.05, kolichestvoMesyac / 12);

            return result;
        }
        catch (KolichestvoException ex)
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
/// <summary>
/// Класс, представляющий вклад до востребования
/// </summary>
class VkladDoVostrebovaniya : Vklad
{
    /// <summary>
    /// Расчитывает сумму вклада после указанного количества месяцев.
    /// </summary>
    /// <param name="kolichestvoMesyac">Количество месяцев.</param>
    /// <returns>Сумма вклада после указанного количества месяцев.</returns>
    public override double RaschitatSummuVklada(int kolichestvoMesyac)
    {
        try
        {
            if (kolichestvoMesyac < 0)
            {
                throw new KolichestvoException("Отрицательное значение количества месяцев.");
            }

            double result = SummaVklada * Math.Pow(1 + 0.03, kolichestvoMesyac / 12);

            return result;
        }
        catch (KolichestvoException ex)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            DolgosrochnyVklad vklad1 = new DolgosrochnyVklad();
            vklad1.Name = "Иван Иванов";
            vklad1.CompanyName = "Тинькоф банк";
            vklad1.SummaVklada = 1000;
            double result1 = vklad1.RaschitatSummuVklada(12);
            Console.WriteLine(vklad1.Name + "\n" + vklad1.CompanyName + "\n" + "Сумма вклада: " + result1);

            Console.WriteLine("\n");
             

            VkladDoVostrebovaniya vklad2 = new VkladDoVostrebovaniya();
            vklad2.Name = "Иван Иванов";
            vklad2.CompanyName = "Сбербанк";
            vklad2.SummaVklada = 21000;
            double result2 = vklad2.RaschitatSummuVklada(12);
            Console.WriteLine(vklad2.Name + "\n" + vklad2.CompanyName + "\n" + "Сумма вклада: " + result2);
        }
        catch (VkladException ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
        catch (KolichestvoException ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
    }
}
