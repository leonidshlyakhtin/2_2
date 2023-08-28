using System;
using _2;

class Program
{
    static void Main()
    {
        Console.InputEncoding = System.Text.Encoding.GetEncoding(1251);
        Console.OutputEncoding = System.Text.Encoding.GetEncoding(1251);
        Account ac = new Account();
        int number;
        for (; ; )
        {
            Console.WriteLine(" Меню  ");
            Console.WriteLine("1 Ввод персональных данных");
            Console.WriteLine("2 Вывод данных ");
            Console.WriteLine("3 Смена владельца банковского счёта ");
            Console.WriteLine("4 Снять сумму");
            Console.WriteLine("5 Положить сумму ");
            Console.WriteLine("6 Перевод суммы в другую валюту");
            Console.WriteLine("7 Распечатать сумму прописью ");
            Console.WriteLine("8 Выход \n");
            Console.WriteLine("Введите ваш вариант ");
            number = Convert.ToInt32(Console.ReadLine());
            switch (number)
            {
                case 1: ac.enter(); break;
                case 2: ac.show(); break;
                case 3: ac.chown(); break;
                case 4: ac.pullOf(); break;
                case 5: ac.put(); break;
                case 6: ac.change(); break;
                case 7: Account.HumanFriendlyInteger.IntegerToWritten(ac.getsumm()) ; break;
                case 8: Console.WriteLine("До свидания "); Environment.Exit(1); break;
                default: Console.WriteLine("Некорретный ввод "); break;
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}