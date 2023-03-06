// Объявляем интерфейсы Ix, Iy, Iz
interface Ix
{
    void IxF0(double параметр);
    void IxF1();
}

interface Iy
{
    void F0(double параметр);
    void F1();
}

interface Iz
{
    void F0(double параметр);
    void F1();
}

// Класс TestClass, который наследует интерфейсы Ix, Iy, Iz и реализует их методы
class TestClass : Ix, Iy, Iz
{
    // Член w класса TestClass
    public double w;

// Неявная реализация методов интерфейсов Iy и Iz
public void F0(double x)
    {
        Console.WriteLine("Результат неявной реализации метода F0: " + Math.Sqrt(x));
    }

    public void F1()
    {
        Console.WriteLine("Результат неявной реализации метода F1");
    }

    public void IxF0(double x)
    {
        Console.WriteLine("Результат неявной реализации метода IxF0: " + Math.Pow(x, 2));
    }

    public void IxF1()
    {
        Console.WriteLine("Результат неявной реализации метода IxF1");
    }

    // Явная реализация метода интерфейса Iz
    void Iz.F0(double z)
    {
        Console.WriteLine("Результат явной реализации метода F0: " + ((z * z) + 5));
    }

    void Iz.F1()
    {
        Console.WriteLine("Результат явной реализации метода F1");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создаем объект класса TestClass
        TestClass obj = new TestClass();

        // Присваиваем значение члену w
    obj.w = 4.0;

        // Вызываем методы объекта через интерфейсы
        Ix objIx = obj;
        objIx.IxF0(obj.w);
        objIx.IxF1();

        Iy objIy = obj;
        objIy.F0(obj.w);
        objIy.F1();

        Iz objIz = obj;
        objIz.F0(obj.w);
        objIz.F1();

        // Вызываем метод объекта через интерфейсную ссылку с параметром типа double
        IxF0((double)obj.w);
    }

    // Метод, который вызывает метод IxF0 объекта через интерфейсную ссылку с параметром типа double
    static void IxF0(double параметр)
    {
        TestClass obj = new TestClass();
        Ix objIx = obj;
        objIx.IxF0(параметр);
    }
}