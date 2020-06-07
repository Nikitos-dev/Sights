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
            List<Sight> newList = MakeSightList();
            foreach (var item in newList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            
            SightList sights = new SightList();
            List<Sight> randomList = sights.GetRandomSights(10);
            List<Sight> list = sights.GetSights();
            foreach (var item in randomList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            ExhaustiveAlgorithm exhaustiveAlgorithm = new ExhaustiveAlgorithm(16, randomList);
            exhaustiveAlgorithm.MakeAllSets(randomList);
            var time = 0.0;
            var sum = 0;
            List<Sight> optimalRoute1 = exhaustiveAlgorithm.GetAllSights();
            foreach (var item in optimalRoute1)
            {
                time += item.Time;
                sum += item.Importance;
                Console.WriteLine(item);
            }
            Console.WriteLine(time);
            Console.WriteLine(sum);
            Console.WriteLine();


            GreedyAlgorithm greedyAlgorithm = new GreedyAlgorithm();
            List<Sight> optimalroute2 = greedyAlgorithm.GreedySort(randomList);

            sum = 0;
            time = 0;
            foreach (var item in optimalroute2)
            {
                time += item.Time;
                sum += item.Importance;
                Console.WriteLine(item);
            }
            Console.WriteLine(time);
            Console.WriteLine(sum);
            Console.WriteLine();

            MyAlgorithm myAlgorithm = new MyAlgorithm();
            List<Sight> optimalroute3 = myAlgorithm.Sort(list);

            time = 0;
            sum = 0;
            foreach (var item in optimalroute3)
            {
                time += item.Time;
                sum += item.Importance;
                Console.WriteLine(item);
            }
            Console.WriteLine(time);
            Console.WriteLine(sum);

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
