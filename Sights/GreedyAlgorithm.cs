using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sights
{
    /// <summary>
    /// Жадный алгоритм.
    /// </summary>
    public class GreedyAlgorithm
    {
        public GreedyAlgorithm()
        {

        }
        /// <summary>
        /// Жадный алгоритм.
        /// </summary>
        /// <param name="list">Изначальная коллекция.</param>
        /// <returns>Оптимальный путь.</returns>
        public List<Sight> GreedySort(List<Sight> sights)
        {
            List<Sight> orderedSights = new List<Sight>();
            orderedSights.AddRange(sights.OrderByDescending(x => x.Importance / x.Time));

            List<Sight> optimalRoute = new List<Sight>();

            for (int j = 0; j < 2; j++)
            {
                double time = 16;
                for (int i = 0; i < orderedSights.Count; i++)
                {

                    if (time - orderedSights[i].Time < 0)
                    {
                        continue;
                    }


                    optimalRoute.Add(orderedSights[i]);
                    time -= orderedSights[i].Time;
                    orderedSights.Remove(orderedSights[i]);
                    i--;

                    if (time == 0)
                    {
                        break;
                    }


                }

            }

            return optimalRoute;
        }
    }
}
