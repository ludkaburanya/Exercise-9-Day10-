using System;

namespace Massiv1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите размерность массива n = ");
            int n = Convert.ToInt32(Console.ReadLine());
            Massiv mas1 = new Massiv(n);
            mas1.ShowAll();

            Console.Write("Введите индекс элемента массива i = ");
            int i = Convert.ToInt32(Console.ReadLine());
            mas1.ShowElement(i);

            Massiv mas2 = new Massiv(n);
            mas2.ShowAll();

            Massiv mas3 = mas1 + mas2;
            mas3.ShowAll();

            Massiv mas4 = mas1 - mas2;
            mas4.ShowAll();

            Console.Write("Введите целое число num = ");
            int num = Convert.ToInt32(Console.ReadLine());
            mas3 = mas3 * num;
            mas3.ShowAll();

            mas3 = mas3 / num;
            mas3.ShowAll();

            Console.ReadKey();
        }
    }

    class Massiv
    {
        public Massiv(int n)
        {
            mas = new int[n];
            Random rand = new Random();
            for (int i = 0; i < mas.Length; ++i)
            {
                mas[i] = rand.Next(0, 10);
            }
        }

        public void ShowAll()
        {
            Console.WriteLine("Массив: ");
            foreach (var elem in mas)
            {
                Console.Write(elem + " ");
            }
            Console.WriteLine();
        }

        public string ShowElement(int index)
        {
            try
            {
                return "Элемент массива с индексом " + index + " mas[" + index + "] = " + mas[index];
            }
            catch (IndexOutOfRangeException)
            {
                return "Попытка обращения к элементу массива с индексом, который находится вне границ массива.";

            }
        }

        public static Massiv operator +(Massiv mas1, Massiv mas2)
        {

            if (mas1.Length == mas2.Length)
            {
                Massiv mas = new Massiv(mas1.Length);
                for (int i = 0; i < mas1.Length; ++i)
                {
                    mas[i] = mas1[i] + mas2[i];
                }
                return mas;
            }

            Console.WriteLine("Значения индексов массивов не совпадают.");
            return null;
        }

        public static Massiv operator -(Massiv mas1, Massiv mas2)
        {

            if (mas1.Length == mas2.Length)
            {
                Massiv mas = new Massiv(mas1.Length);
                for (int i = 0; i < mas1.Length; ++i)
                {
                    mas[i] = mas1[i] - mas2[i];
                }
                return mas;
            }

            Console.WriteLine("Значения индексов массивов не совпадают.");
            return null;
        }

        public static Massiv operator *(Massiv mas1, int num)
        {
            Massiv mas = new Massiv(mas1.Length);
            for (int i = 0; i < mas1.Length; ++i)
            {
                mas[i] = mas1[i] * num;
            }
            return mas;
        }

        public static Massiv operator /(Massiv mas1, int num)
        {
            Massiv mas = new Massiv(mas1.Length);
            for (int i = 0; i < mas1.Length; ++i)
            {
                mas[i] = mas1[i] / num;
            }
            return mas;
        }

        public int Length
        {
            get { return mas.Length; }
        }

        public int this[int index]
        {
            get { return mas[index]; }
            set { mas[index] = value; }
        }

        private int[] mas;
    }
}