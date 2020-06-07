using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sights
{
    /// <summary>
    /// Собственный алгоритм.
    /// </summary>
    public class MyAlgorithm
    {
        public MyAlgorithm()
        {

        }

        public List<Sight> Sort(List<Sight> sights)
        {
            List<Sight> orderedSightsList = new List<Sight>();
            orderedSightsList.AddRange(sights.OrderByDescending(x => x.Importance).ThenByDescending(t => t.Time));
            List<Sight> optimalRoute = new List<Sight>();
            for (int i = 0; i < 2; i++)
            {
                double time = 16;
                for (int j = 0; j < orderedSightsList.Count; j++)
                {
                    int index = 0;
                    for (int k = j; k < orderedSightsList.Count - 2; k++)
                    {
                        if (orderedSightsList[k].Time > orderedSightsList[k + 1].Time)
                        {
                            index = k + 1;
                        }
                        else
                        {
                            break;
                        }

                        if (orderedSightsList[index].Time <= orderedSightsList[index + 1].Time)
                        {
                            break;
                        }
                    }
                    if (time - orderedSightsList[index].Time < 0)
                    {
                        continue;
                    }
                    optimalRoute.Add(orderedSightsList[index]);
                    time -= orderedSightsList[index].Time;
                    orderedSightsList.Remove(orderedSightsList[index]);
                    j--;

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
