using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sights
{
    /// <summary>
    /// Алгоритм полного перебора.
    /// </summary>
    public class ExhaustiveAlgorithm
    {
        /// <summary>
        /// Лучший набор.
        /// </summary>
        private List<Sight> bestSights = null;
        /// <summary>
        /// Изначальный набор достопримечательностей.
        /// </summary>
        private List<Sight> originalSightList;
        /// <summary>
        /// Максимальный запас времени на день.
        /// </summary>
        private double maxTime;
        /// <summary>
        /// Лучшая суммарная важность.
        /// </summary>
        private double bestImp;
        /// <summary>
        /// Конструктор алгоритма полного перебора.
        /// </summary>
        /// <param name="time">Максимальное время на день.</param>
        /// <param name="sights">Изначальный набор достопримечательностей.</param>
        public ExhaustiveAlgorithm(double time, List<Sight> sights)
        {
            maxTime = time;
            originalSightList = sights;
        }
        /// <summary>
        /// Подсчёт времени набора достопримечательностей.
        /// </summary>
        /// <param name="sights">Набор достопримечательностей.</param>
        /// <returns>Суммарное время на посещение.</returns>
        private double CalcTime(List<Sight> sights)
        {
            double timeSum = 0;

            foreach (Sight item in sights)
            {
                timeSum += item.Time;
            }

            return timeSum;
        }
        /// <summary>
        /// Подсчёт суммарной важности.
        /// </summary>
        /// <param name="sights">Набор достопримечательностей.</param>
        /// <returns>Суммарная важность.</returns>
        private double CalcImp(List<Sight> sights)
        {
            double impSum = 0;

            foreach (Sight item in sights)
            {
                impSum += item.Importance;
            }

            return impSum;
        }
        /// <summary>
        /// Проверка для установки нового лучшего набора достопримечательностей.
        /// </summary>
        /// <param name="sights">Набор достопримечательностей.</param>
        private void CheckSet(List<Sight> sights)
        {
            if (bestSights == null)
            {
                if (CalcTime(sights) <= maxTime)
                {
                    bestSights = sights;
                    bestImp = CalcImp(sights);
                }
            }
            else
            {
                if (CalcTime(sights) <= maxTime && CalcImp(sights) > bestImp)
                {
                    bestSights = sights;
                    bestImp = CalcImp(sights);
                }
            }
        }
        /// <summary>
        /// Рекурсивный метод полного перебора.
        /// </summary>
        /// <param name="sights">Набор достопримечательностей.</param>
        public void MakeAllSets(List<Sight> sights)
        {
            if (sights.Count > 0)
                CheckSet(sights);

            for (int i = 0; i < sights.Count; i++)
            {
                List<Sight> newSet = new List<Sight>(sights);

                newSet.RemoveAt(i);

                MakeAllSets(newSet);
            }

        }
        /// <summary>
        /// Получение лучшего пути за оба дня.
        /// </summary>
        /// <returns></returns>
        public List<Sight> GetAllSights()
        {
            List<Sight> firstDay = GetSights();
            List<Sight> temp = new List<Sight>();
            temp.AddRange(originalSightList);
            foreach (var item in firstDay)
            {
                temp.Remove(item);
            }

            ExhaustiveAlgorithm exhaustiveAlgorithm = new ExhaustiveAlgorithm(16, temp);
            exhaustiveAlgorithm.MakeAllSets(temp);
            List<Sight> secondDay = exhaustiveAlgorithm.GetSights();

            firstDay.AddRange(secondDay);
            return firstDay;
        }

        /// <summary>
        /// Получение лучшего пути.
        /// </summary>
        /// <returns>Лучший набор достопримечательностей.</returns>
        private List<Sight> GetSights()
        {
            return bestSights;
        }
    }
}
