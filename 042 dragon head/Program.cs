using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _042
{
    class Program
    {

        static void Main(string[] args)
        {


            File.Delete("output.txt");
            if (File.Exists("input.txt"))
            { Start(); }

            else
            {
                Console.WriteLine("Фаил 'input.txt' не существует");
                Console.ReadKey();
                Environment.Exit(1);
            }



        }

        static void Start()
        {
            StreamReader sr = new StreamReader("input.txt");
            int aNumber = new int();
            int summ = new int();
            int num;
            int d = new int();

            string line;
            line = sr.ReadLine();
            string[] array;
            if (line == null)
            {
                Console.WriteLine("Фаил 'input.txt' пуст, введите туде число, не превышающее 46340");
                Console.ReadKey();
                Environment.Exit(1);
            }
            array = line.Split(new char[] { ' ' }, 2);


            if (Int32.TryParse(array[0], out num))
            {
                aNumber = Convert.ToInt32(array[0]);
            }
            else
            {
                Console.WriteLine("Первая запись не являтся числом");
                Console.ReadKey();
                Environment.Exit(1);
            }

            if (Math.Abs(aNumber) > 59)
            {
                Console.WriteLine("Введенное число слишком велико, введите число меньше 59");
                Console.ReadKey();
                Environment.Exit(1);
            }
          
            for (int i=0; ;++i)
            {
                if (3 * i > aNumber)
                    break;

                d = Convert.ToInt32(Math.Pow(3, i))*(aNumber-3* i);
                if (summ < d) summ = d;
            }
            

            line = Convert.ToString(summ);
            Console.WriteLine("Сила дракона: " + line);

            File.WriteAllText("output.txt", line);
            Console.ReadKey();
        }
    }
}
