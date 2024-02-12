using System;

class SnyatSoSchetaException : Exception
{
    public SnyatSoSchetaException(string message) : base(message) { }
}

class OstatokNaScheteException : Exception
{
    public OstatokNaScheteException(string message) : base(message) { }
}

class Schet
{
    public int Номер { get; set; }
    public int PINКод { get; set; }
    private double _остаток;

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

class ObichnySchet : Schet
{
    public override void СнятьСоСчета(double сумма)
    {
        base.СнятьСоСчета(сумма);
    }
}

class LgotnySchet : Schet
{
    public override void СнятьСоСчета(double сумма)
    {
        base.СнятьСоСчета(сумма);
    }
}

class Bankomat
{
    public string ИдентификационныйНомер { get; set; }
    public string Адрес { get; set; }
}

class Program
{
    static void Main(string[] args)
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

        Console.WriteLine("обычный сёчт:");
        obichnySchet.СнятьСоСчета(500); // Снятие выполнено успешно. Остаток на счете: 500
        obichnySchet.СнятьСоСчета(700); // Ошибка: Некорректное значение суммы для снятия со счета: 700
        obichnySchet.СнятьСоСчета(-200); // Ошибка: Некорректное значение суммы для снятия со счета: -200
        obichnySchet.СнятьСоСчета(2000); // Ошибка: Некорректное значение суммы для снятия со счета: 2000

        Console.WriteLine("\n");

        Console.WriteLine("лготный сёчт:");
        lgotnySchet.СнятьСоСчета(500); // Ошибка: Некорректное значение суммы для снятия со счета: 1500
        lgotnySchet.СнятьСоСчета(1500); // Ошибка: Некорректное значение суммы для снятия со счета: 1500
    }
}