using System;
using System.IO;
using System.Text;

namespace rebebra
{
    class Program
    {
        static void Main(string[] args)
        {
            bool writeStatus = true;

            while(writeStatus)
            {
                Console.Write("Введите еду которую вы ели: ");
                string food = Console.ReadLine();
                Console.Write("Введите ее калорийность: ");
                int calloriesInFood = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите количество штук: ");
                int countOfFood = Convert.ToInt32(Console.ReadLine());

                using(var sw = new StreamWriter(@"C:\BebraFood.txt", true, Encoding.Unicode))
                {
                    sw.WriteLine($"Еда: {food} | Количество каллорий в 1 шт: {calloriesInFood} " +
                        $"| Съедено штук: {countOfFood} | Набранное число калорий: " +
                        $"{calloriesInFood * countOfFood}");
                }

                Console.WriteLine("Продолжить запись? Да/Нет");
                string answer = Console.ReadLine();

                writeStatus = answer.Equals("Да", StringComparison.OrdinalIgnoreCase) ? true : false;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nВывод списка =>");
            Console.ResetColor();

            using (var sr = new StreamReader(@"C:\BebraFood.txt"))
            {
                while (!sr.EndOfStream)
                {
                    Console.WriteLine(sr.ReadLine());
                }
            }
        }
    }
}
