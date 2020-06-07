using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sights
{
    /// <summary>
    /// Класс для создания поставленного в задаче набора достопримечательностей, либо для создания случайного набора достопримечательностей
    /// </summary>
    public class SightList
    {
        public SightList()
        {

        }
        /// <summary>
        /// Получение поставленного в задаче набора достопримечательностей.
        /// </summary>
        /// <returns>Поставленный в задаче набор достопримечательностей.</returns>
        public List<Sight> GetSights()
        {
            List<Sight> sights = new List<Sight>();
            sights.Add(new Sight("Исаакиевский собор", 10, 5));
            sights.Add(new Sight("Эрмитаж", 11, 8));
            sights.Add(new Sight("Кунсткамера", 4, 3.5));
            sights.Add(new Sight("Петропавловская крепость", 7, 10));
            sights.Add(new Sight("Ленинградский зоопарк", 15, 9));
            sights.Add(new Sight("Медный всадник", 17, 1));
            sights.Add(new Sight("Казанский собор", 3, 4));
            sights.Add(new Sight("Спас на Крови", 9, 2));
            sights.Add(new Sight("Зимний дворец Петра I", 12, 7));
            sights.Add(new Sight("Зоологический музей", 6, 5.5));
            sights.Add(new Sight("Музей обороны и блокады Ленинграда", 19, 2));
            sights.Add(new Sight("Русский музей", 8, 5));
            sights.Add(new Sight("Навестить друзей", 20, 12));
            sights.Add(new Sight("Музей восковых фигур", 13, 2));
            sights.Add(new Sight("Литературно-мемориальный музей Ф.М. Достоевского", 2, 4));
            sights.Add(new Sight("Екатерининский дворец", 5, 1.5));
            sights.Add(new Sight("Петербургский музей кукол", 14, 1));
            sights.Add(new Sight("Музей микроминиатюры «Русский Левша»", 18, 3));
            sights.Add(new Sight("Всероссийский музей А.С. Пушкина и филиалы", 1, 6));
            sights.Add(new Sight("Музей современного искусства Эрарта", 16, 7));

            return sights;
        }
        /// <summary>
        /// Получение случайного набора достопримечательностей.
        /// </summary>
        /// <param name="number">Необходимое колчество достопримечательностей. </param>
        /// <returns>Случайный набор достопримечательностей. </returns>
        public List<Sight> GetRandomSights(int number)
        {
            List<Sight> sights = new List<Sight>();
            Random rnd = new Random();
            for (int i = 0; i < number; i++)
            {
                string name = $"Sight {i+1}";
                int importance = rnd.Next(1, number);
                double time = rnd.Next(2, 12) + Convert.ToDouble(rnd.Next(0,2))/2;

                Sight sight = new Sight(name, importance, time);
                sights.Add(sight);
            }
            return sights;
        }
    }
}
