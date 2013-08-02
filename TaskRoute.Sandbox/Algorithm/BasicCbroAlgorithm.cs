using System.Collections.Generic;

namespace TaskRoute.Sandbox.Algorithm
{
    public class BasicCbroAlgorithm : CbroOptimizerBase<DataPoint>
    {
        public BasicCbroAlgorithm(IEnumerable<DataPoint> tasks, int antCount)
            : base(tasks, antCount)
        {
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

        protected override double Cost(Task<DataPoint> a, Task<DataPoint> b)
        {
            return a.Data.Location.DistanceTo(b.Data.Location);
        }

        protected override double Profit(Task<DataPoint> a)
        {
            return a.Data.Profit;
        }

        protected override bool CanTransition(Ant ant, Task<DataPoint> next)
        {
            return true;
        }
    }
}
