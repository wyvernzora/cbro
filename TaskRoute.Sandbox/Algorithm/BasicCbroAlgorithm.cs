using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskRoute.Sandbox
{
    public class BasicCbroAlgorithm : CbroOptimizer
    {

        public BasicCbroAlgorithm(IEnumerable<Task> tasks, int antCount)
            : base(tasks, antCount)
        {
        }

        // Straight Distance
        protected override double Distance(Task a, Task b)
        {
            Double d =  a.Location.DistanceTo(b.Location);
            return d;
        }

        // No Constraints
        protected override bool CanTransition(Ant ant, Task next)
        {
            return true;
        }

        // Value / Length
        protected override double CalculateScore(Ant ant)
        {
            return ant.TourLength;
        }

        public void Run()
        {
            for (int i = 0; i < 1000; i++)
            {
                if (SimulateAnts() == 0)
                {
                    UpdatePheromone();
                    ResetAnts();
                }
            }
        }
    }
}
