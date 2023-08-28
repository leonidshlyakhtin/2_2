using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    internal class Account
    {
        private string name;
        private int number;
        private int summa;
        private int percent;

        public Account()
        {
            name = "";
            number = 0;
            summa = 0;
            percent = 0;
        }

        public void enter()
        {
            Console.WriteLine("Введите фамилию ");
            name = Console.ReadLine();
            Console.WriteLine("Введите номер банковского счёта ");
            number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите сумму ");
            summa = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите проценты ");
            percent = Convert.ToInt32(Console.ReadLine());
        }

        public void show()
        {
            Console.WriteLine("Фамилия " + name);
            Console.WriteLine("Номер банковского счёта " + number);
            Console.WriteLine("Сумма равна " + summa);
            Console.WriteLine("Ваши проценты равны " + percent);
        }

        public void chown()
        {
            Console.WriteLine("Смена владельца счёта ");
            Console.WriteLine("Введите фамилию нового владельца ");
            name = Console.ReadLine();
        }

        public void pullOf()
        {
            int s;
            Console.WriteLine("Вы производите снятие денег");
            Console.WriteLine("Введите сумму, которую вы хотите снять");
            s = Convert.ToInt32(Console.ReadLine());
            if (s > summa)
                Console.WriteLine("Вы не можете снять такую сумму, у вас на счету не такой суммы");
            else
            {
                summa -= s;
                Console.WriteLine("Остаток равен " + summa);
            }
        }

        public void put()
        {
            int s;
            Console.WriteLine("Введите сумму, которую вы хотите внести");
            s = Convert.ToInt32(Console.ReadLine());
            summa += s;
            Console.WriteLine("Сумма на вашем счету равна " + summa);
        }

        public int getsumm()
        {
            return this.summa;
        }

        public void per()
        {
            Console.WriteLine("Произошло начисление суммы по процентам");
            Console.WriteLine("Процент по вашему вкладу равен " + percent);
            summa = summa + ((summa * percent) / 100);
            Console.WriteLine("Сумма после начисления процента равна");
            Console.WriteLine(summa);
        }

        public void change()
        {
            int number;
            Console.WriteLine("В какую валюту хотите перевести");
            Console.WriteLine("1) доллар");
            Console.WriteLine("2) евро");
            Console.WriteLine("Введите ваш вариант");
            number = Convert.ToInt32(Console.ReadLine());
            if (number == 1)
                Console.WriteLine("Ваша сумма в долларах равна " + summa / 90);
            else if (number == 2)
                Console.WriteLine("Ваша сумма в евро равна " + summa / 100);
            else
            {
                Console.WriteLine("Не корретный ввод ");
            }
        }

        public static class HumanFriendlyInteger
        {
            static string[] ones = new string[] { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
            static string[] teens = new string[] { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
            static string[] tens = new string[] { "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
            static string[] thousandsGroups = { "", " Thousand", " Million", " Billion" };

            private static string FriendlyInteger(int n, string leftDigits, int thousands)
            {
                if (n == 0)
                {
                    return leftDigits;
                }

                string friendlyInt = leftDigits;

                if (friendlyInt.Length > 0)
                {
                    friendlyInt += " ";
                }

                if (n < 10)
                {
                    friendlyInt += ones[n];
                }
                else if (n < 20)
                {
                    friendlyInt += teens[n - 10];
                }
                else if (n < 100)
                {
                    friendlyInt += FriendlyInteger(n % 10, tens[n / 10 - 2], 0);
                }
                else if (n < 1000)
                {
                    friendlyInt += FriendlyInteger(n % 100, (ones[n / 100] + " Hundred"), 0);
                }
                else
                {
                    friendlyInt += FriendlyInteger(n % 1000, FriendlyInteger(n / 1000, "", thousands + 1), 0);
                    if (n % 1000 == 0)
                    {
                        return friendlyInt;
                    }
                }

                return friendlyInt + thousandsGroups[thousands];
            }

            public static void IntegerToWritten(int n)
            {
                if (n == 0)
                {
                    Console.WriteLine("Zero");
                }
                else if (n < 0)
                {
                    string neganswer = FriendlyInteger(-n, "", 0);
                    Console.WriteLine(neganswer);
                }

                string answer = FriendlyInteger(n, "", 0);
                Console.WriteLine(answer);

            }
        }
    }
}