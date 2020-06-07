using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sights
{
    /// <summary>
    /// Достопримечательность.
    /// </summary>
    public class Sight
    {
        /// <summary>
        /// Назавние.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Важность.
        /// </summary>
        public int Importance { get; set; }
        /// <summary>
        /// Время на прохождение.
        /// </summary>
        public double Time { get; set; }
        public Sight()
        {

        }
        public Sight(string name, int importance, double time)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            if (importance <= 0)
            {
                throw new ArgumentException(nameof(importance), "Важность не может быть меньше либо равно нулю");
            }
            if (time <= 0)
            {
                throw new ArgumentException(nameof(time), "Время не может быть меньше либо равно нулю");
            }
            Importance = importance;
            Time = time;
        }

        public override string ToString()
        {
            return $"{Name}, {Time} - {Importance}";
        }
    }
}
