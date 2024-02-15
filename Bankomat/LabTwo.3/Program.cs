using System;

/// <summary>
/// Исключение при снятии счета
/// </summary>
class SnyatSoSchetaException : Exception
{
    /// <summary>
    /// Конструктор исключения
    /// </summary>
    /// <param name="message"></param>
    public SnyatSoSchetaException(string message) : base(message) { }
}
/// <summary>
/// Исключение при некорректном остатке на счете
/// </summary>
class OstatokNaScheteException : Exception
{
    /// <summary>
    /// Конструктор исключения
    /// </summary>
    /// <param name="message"></param>
    public OstatokNaScheteException(string message) : base(message) { }
}
/// <summary>
/// Класс счета
/// </summary>
class Schet
{
    /// <summary>
    /// Номер счета
    /// </summary>
    public int Номер { get; set; }
    /// <summary>
    /// Пин-код счета
    /// </summary>
    public int PINКод { get; set; }
    /// <summary>
    /// Остаток на счете
    /// </summary>
    private double _остаток;
    /// <summary>
    /// Свойство остатка на счете
    /// </summary>
    public double Остаток
    {
        get { return _остаток; }
        set
        {
            if (value < 0)
            {
                throw new OstatokNaScheteException("Некорректное значение остатка на счете: " + value);
            }
            _остаток = value;
        }
    }
    /// <summary>
    /// Метод для снятия средств со счета
    /// </summary>
    /// <param name="сумма"></param>
    public virtual void СнятьСоСчета(double сумма)
    {
        try
        {
            if (сумма < 0 || сумма > Остаток)
            {
                throw new SnyatSoSchetaException("Некорректное значение суммы для снятия со счета: " + сумма);
            }
            Остаток -= сумма;
            Console.WriteLine("Снятие выполнено успешно. Остаток на счете: " + Остаток);
        }
        catch (SnyatSoSchetaException ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
        catch (OstatokNaScheteException ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
    }
}
/// <summary>
/// Класс обычного счета
/// </summary>
class ObichnySchet : Schet
{
    /// <summary>
    /// Метод для снятия средств со счета
    /// </summary>
    /// <param name="сумма"></param>
    public override void СнятьСоСчета(double сумма)
    {
        base.СнятьСоСчета(сумма);
    }
}
/// <summary>
/// Класс льготного счета
/// </summary>
class LgotnySchet : Schet
{
    /// <summary>
    /// Метод для снятия средств со счета
    /// </summary>
    /// <param name="сумма"></param>
    public override void СнятьСоСчета(double сумма)
    {
        base.СнятьСоСчета(сумма);
    }
}
/// <summary>
/// Класс банкомата
/// </summary>
class Bankomat
{
    /// <summary>
    /// Идентификационный номер банкомата
    /// </summary>
    public string ИдентификационныйНомер { get; set; }
    /// <summary>
    /// Адрес банкомата
    /// </summary>
    public string Адрес { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            ObichnySchet obichnySchet = new ObichnySchet();
            obichnySchet.Номер = 1234567890;
            obichnySchet.PINКод = 1111;
            obichnySchet.Остаток = 1000;

            LgotnySchet lgotnySchet = new LgotnySchet();
            lgotnySchet.Номер = 987654321;
            lgotnySchet.PINКод = 2222;
            lgotnySchet.Остаток = 2000;

            Bankomat bankomat = new Bankomat();
            bankomat.ИдентификационныйНомер = "BM001";
            bankomat.Адрес = "ул. Пролетарская, 10";

            Console.WriteLine("обычный счет:");
            try
            {
                obichnySchet.СнятьСоСчета(500); // Снятие выполнено успешно. Остаток на счете: 500
                obichnySchet.СнятьСоСчета(700); // Ошибка: Некорректное значение суммы для снятия со счета: 700
                obichnySchet.СнятьСоСчета(-200); // Ошибка: Некорректное значение суммы для снятия со счета: -200
                obichnySchet.СнятьСоСчета(2000); // Ошибка: Некорректное значение суммы для снятия со счета: 2000
            }
            catch (SnyatSoSchetaException ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
            catch (OstatokNaScheteException ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }

            Console.WriteLine("\n");

            Console.WriteLine("льготный счет:");
            try
            {
                lgotnySchet.СнятьСоСчета(500); // Ошибка: Некорректное значение суммы для снятия со счета: 1500
                lgotnySchet.СнятьСоСчета(1500); // Ошибка: Некорректное значение суммы для снятия со счета: 1500
            }
            catch (SnyatSoSchetaException ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
            catch (OstatokNaScheteException ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
    }

}
