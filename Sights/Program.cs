using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sights
{
    class Program
    {
        static void Main(string[] args)
        {
            SightList sights = new SightList();
            List<Sight> randomList = sights.GetRandomSights(10);
            List<Sight> list = sights.GetSights();

            ExhaustiveAlgorithm exhaustiveAlgorithm = new ExhaustiveAlgorithm(16, randomList);
            GreedyAlgorithm greedyAlgorithm = new GreedyAlgorithm();
            MyAlgorithm myAlgorithm = new MyAlgorithm();

            Console.WriteLine("Случайный набор достопримечательностей:");
            foreach (var item in randomList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine("Алгоритм полного перебора для случайных достопримечательностей:");
            exhaustiveAlgorithm.MakeAllSets(randomList);
            var sum = 0;
            List<Sight> optimalRoute1 = exhaustiveAlgorithm.GetAllSights();
            foreach (var item in optimalRoute1)
            {
                sum += item.Importance;
                Console.WriteLine(item);
            }
            Console.WriteLine($"Суммарная важность = {sum}");
            Console.WriteLine();

            Console.WriteLine("Жадный алгоритм для случайных достопримечательностей:");
            List<Sight> optimalRoute2 = greedyAlgorithm.GreedySort(randomList);
            sum = 0;
            foreach (var item in optimalRoute2)
            {
                sum += item.Importance;
                Console.WriteLine(item);
            }
            Console.WriteLine($"Суммарная важность = {sum}");
            Console.WriteLine();

            Console.WriteLine("Собственный алгоритм для случайных достопримечательностей:");
            List<Sight> optimalRoute3 = myAlgorithm.Sort(randomList);

            sum = 0;
            foreach (var item in optimalRoute3)
            {
                sum += item.Importance;
                Console.WriteLine(item);
            }
            Console.WriteLine($"Суммарная важность = {sum}");
            Console.WriteLine();


            Console.WriteLine("Выбор оптимального маршрута с использованием жадного алгоритма");
            List<Sight> finalRoute1 = greedyAlgorithm.GreedySort(list);
            sum = 0;
            foreach (var item in finalRoute1)
            {
                sum += item.Importance;
                Console.WriteLine(item);
            }
            Console.WriteLine($"Суммарная важность = {sum}");
            Console.WriteLine();

            Console.WriteLine("Выбор оптимального маршрута с использованием собственного алгоритма");
            List<Sight> finalRoute2 = myAlgorithm.Sort(list);
            sum = 0;
            foreach (var item in finalRoute2)
            {
                sum += item.Importance;
                Console.WriteLine(item);
            }
            Console.WriteLine($"Суммарная важность = {sum}");
            Console.ReadLine();
        }
        /// <summary>
        /// Создание новой достопримечательности.
        /// </summary>
        /// <returns>Достопримечательность.</returns>
        private static Sight EnterSight()
        {
            string name;
            int importance;
            double time;
            Console.WriteLine("Введите название достопримечательности:");
            name = EnterName();
            Console.WriteLine("Введите важность достопримечательности:");
            importance = EnterInt();
            Console.WriteLine("Введите время, необхожимое для похода на достопримечательность:");
            time = EnterDouble();

            Sight sight = new Sight(name, importance, time);
            return sight;
        }
        /// <summary>
        /// Ввод 
        /// </summary>
        /// <returns></returns>
        private static double EnterDouble()
        {
            while (true)
            {
                if (Double.TryParse(Console.ReadLine(), out double result))
                {
                    if (result >= 0)
                    {
                        return result;
                    }
                    else
                    {
                        Console.WriteLine("Значение не может быть меньше либо равно 0");

                    }
                }
                else
                {
                    Console.WriteLine("Неверный формат ввода");
                }
            }

        }

        private static int EnterInt()
        {
            while (true)
            {
                if (Int32.TryParse(Console.ReadLine(), out int result))
                {
                    if (result >= 0)
                    {
                        return result;
                    }
                    else
                    {
                        Console.WriteLine("Важность не может быть меньше либо равной 0");
                    }

                }
                else
                {
                    Console.WriteLine("Неверный формат ввода для важности");
                }
            }

        }

        private static string EnterName()
        {
            while (true)
            {
                var sightName = Console.ReadLine();
                if (sightName.Length == 0)
                {
                    Console.WriteLine("Имя не может быть пустым");
                }
                else
                {
                    return sightName;
                }

            }

        }

        private static List<Sight> MakeSightList()
        {
            Console.WriteLine("Введите количество необходимых достопримечательностей:");
            int number = EnterInt();
            List<Sight> sights = new List<Sight>();
            for (int i = 0; i < number; i++)
            {
                Console.WriteLine($"Достопримечательность номер {number + 1}");
                sights.Add(EnterSight());
            }

            return sights;
        }
    }
}
