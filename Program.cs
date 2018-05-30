using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bulls_and_cow
{
    class Program
    {

        public static string Randgener(int raz)
        {
            Random rand = new Random();
            string per;
            string kod = "";
            int flag;
            int k = rand.Next(0, 10);
            kod = kod + k.ToString();
            for (int i = 1; i < raz; i++)
            {
                while (true)
                {
                    rand = new Random();
                    per = rand.Next(0, 10).ToString();
                    flag = kod.IndexOf(per[0]);
                    if (flag == -1)
                    {
                        kod = kod + per;
                        break;
                    }
                }

            }
            Console.WriteLine(kod);
            return kod;
        }

        public static int Enternumder()
        {
            int n;
            while (true)
            {
                string ch="";
                Console.WriteLine("склько цифр будет в числе");
                ch = Console.ReadLine();
                bool isNum = int.TryParse(ch, out n);
                if (isNum)
                {
                    if (n > 10) Console.WriteLine("введите число меньше 10");
                    else break;
                }
                else
                    Console.WriteLine("введите число");
            }
            return n;
        }

        public static string Enteroption(int number)
        {
            string option;
            while (true)
            {
                option = Console.ReadLine();
                if (option.Length > number | option.Length < number)
                    Console.WriteLine("введите число меньше " + Math.Pow(10, number) + " и больше " + (Math.Pow(10, number - 1) - 1));
                else
                    break;
            }
            return option;
        }

        public static int Bulls(string kod, string option, int number)
        {
            int count=0;

            for(int i=0; i<number; i++)
            {
                if (kod[i] == option[i]) count++;
            }

            return count;
        }
        public static int Cows(string kod, string option, int number)
        {
            int count = 0;
            for (int j = 0; j < number; j++)
            {
                for (int i = 0; i < number; i++)
                {
                    if (kod[j] == option[i]) count++;
                }
            }
            return count;
        }

        static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
  

            Console.Clear();
            Console.WriteLine("1 - новая игра");
            Console.WriteLine("2 - выход");

            while (true)
            {
                string key = Console.ReadLine();
                switch (key[0])
                {
                    case '1':
                        Game();
                        break;
                    case '2':
                        Environment.Exit(0);
                        break;
                }
            }
        }

        public static void Game()
        {
            Console.Clear();

            int number = Enternumder();
            string kod = Randgener(number);
            
            
            Console.WriteLine("введите число");

            while (true)
            {
                string option = Enteroption(number);

                int B = Bulls(kod, option, number);
                Console.Write("    количество быков " + B);

                int C = Cows(kod, option, number);
                Console.WriteLine("    количество коров " + C);

                if (B == number)
                {
                    Console.WriteLine("вы выиграли ");
                    break;
                }
                
            }
            
            Console.WriteLine("1 -в меню");

            while ((Console.ReadKey().Key != ConsoleKey.D1))
            { }
            Menu();
        }
    }
}
