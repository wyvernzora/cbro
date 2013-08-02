using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libWyvernzora.Core;

namespace TaskRoute
{
    /// <summary>
    /// 2D Location of a Task
    /// </summary>
    public class Location : Pair<Double, Double>
    {
        public Location(double x, double y) : base(x, y)
        {
        }

        /// <summary>
        /// X component of the location.
        /// </summary>
        public Double X
        { get { return First; }
            set { First = value; }
        }

        /// <summary>
        /// Y component of the location.
        /// </summary>
        public Double Y
        {
            get { return Second; }
            set { Second = value; }
        }
        
        /// <summary>
        /// Calculates the distance to another location.
        /// </summary>
        /// <param name="loc"></param>
        /// <returns></returns>
        public Double DistanceTo(Location loc)
        {
            Double dx = loc.X - X;
            Double dy = loc.Y - Y;

            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
}
