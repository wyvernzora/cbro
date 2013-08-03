using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskRoute
{
    /// <summary>
    /// Base class for all customized CBRO optimizers.
    /// </summary>
    public abstract class CbroOptimizerBase<T>
    {
        //Random number generator
        protected static readonly Random Rand = new Random();

        #region Nested Types

        /// <summary>
        /// Task wrapper.
        /// </summary>
        /// <typeparam name="TData">Type of enclosed type data.</typeparam>
        public class Task<TData>
        {
            public Int32 Id { get; set; }

            public TData Data { get;set; }
        }

        /// <summary>
        /// Representation of ant in ACO
        /// </summary>
        protected class Ant
        {
            public Ant()
            {
                CurrentTask = null;
                Path = new List<Task<T>>();
                TourCost = 0.0;
            }

            /// <summary>
            /// Current task
            /// </summary>
            public Task<T> CurrentTask { get; set; }
            
            /// <summary>
            /// Array to quickly flag visited tasks
            /// </summary>
            public Boolean[] VisitFlags { get; set; }

            /// <summary>
            /// Visited path up to the current task
            /// </summary>
            public List<Task<T>> Path { get; set; }

            /// <summary>
            /// Length of current tour up to the current task
            /// </summary>
            public Double TourCost { get; set; }

            /// <summary>
            /// Value of the current tour up to the current task
            /// </summary>
            public Double TourProfit { get; set; }
        }

        #endregion

        #region Persistent Optimizer Parameters

        /// <summary>
        /// All tasks that need to be routed.
        /// </summary>
        public Task<T>[] Tasks { get; set; }

        /// <summary>
        /// Sum of all task values.
        /// </summary>
        public Double PotentialProfit { get; set; }
        
        /// <summary>
        /// Alpha value, trail weight.
        /// </summary>
        public Double Alpha { get; set; }

        /// <summary>
        /// Beta value, visibility weight.
        /// </summary>
        public Double Beta { get; set; }

        /// <summary>
        /// Rho value, pheromon persistence.
        /// </summary>
        public Double Rho { get; set; }

        /// <summary>
        /// Specifies the constant Q, which is multiplied
        /// by value coefficient during pheromone calculation.
        /// </summary>
        public Double Q { get; set; }

        /// <summary>
        /// Maximum number of ants per iteration.
        /// </summary>
        public Int32 AntCount { get; set; }

        /// <summary>
        /// Initial pheromone deposit.
        /// </summary>
        public Double InitialPheromone { get; set; }
        
        #endregion

        #region Algorithm Parameters

        // Pheromone Map
        protected Double[,] pheromone;
        protected Ant[] ants;


        /// <summary>
        /// Best solution up to the point.
        /// </summary>
        public List<Task<T>> BestSolution { get; protected set; }
        
        /// <summary>
        /// Best tour distance up to the point.
        /// </summary>
        public Double BestCost { get; protected set; }

        /// <summary>
        /// Best tour value up to the point.
        /// </summary>
        public Double BestProfit { get; protected set; }

        /// <summary>
        /// Delta from the previous run.
        /// </summary>
        public Double Delta { get; protected set; }

        #endregion

        #region Abstract Methods

        /// <summary>
        /// Abstract method that calculates cost of transition between two tasks.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        protected abstract Double Cost(Task<T> a, Task<T> b);

        /// <summary>
        /// Abstract method that calculates the profit of visiting a specific task.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        protected abstract Double Profit(Task<T> a);

        /// <summary>
        /// Abstract predicate that determines whether the ant can transition to a given task.
        /// </summary>
        /// <param name="ant"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        protected abstract Boolean CanTransition(Ant ant, Task<T> next);

        #endregion


        protected CbroOptimizerBase(IEnumerable<T> tasks, Int32 antCount)
        {
            // Copy tasks
            Tasks = (from t in tasks select new Task<T> {Data = t}).ToArray();
            
            // Initialize Task IDs
            for (int i = 0; i < Tasks.Length; i++)
                Tasks[i].Id = i;

            // Check parameters
            if (Tasks.Length < 3)
                throw new ArgumentException("Optimizing for less than 3 tasks? Are you joking?");
            if (antCount < 1)
                throw new ArgumentException("There is really no point optimizing with no ants.");

            // Calculate sum of all values
            PotentialProfit = Tasks.Sum(t => Profit(t));

            // Initialize Best Solution
            BestSolution = null;
            BestCost = Double.MaxValue;
            BestProfit = 0;
            Delta = Double.MaxValue;

            // Initialize default parameters (unweighted)
            Alpha = 1.0;
            Beta = 1.0;
            Rho = 0.9;
            
            // Calculate Initial Pheromone Distribution
            InitialPheromone = 1.0 / Tasks.Length;

            // Initialize the Algorithm
            
            // Initialize Pheromone Map
            pheromone = new double[Tasks.Length, Tasks.Length];
            for (int i = 0; i < Tasks.Length; i++)
                for (int j = 0; j < Tasks.Length; j++)
                    if (i != j)
                        pheromone[i, j] = InitialPheromone;
            
            // Populate the Ant Colony
            AntCount = antCount;
            ants = new Ant[antCount];
            Int32 ctask = 0;
            for (int i = 0; i < ants.Length; i++)
            {
                // TODO Initial Ant Distribution (??)
                ants[i] = new Ant
                    {
                        VisitFlags = new Boolean[Tasks.Length],
                        CurrentTask = Tasks[ctask]
                    };

                ants[i].VisitFlags[ctask] = true;
                ants[i].Path.Add(Tasks[ctask]);
                ants[i].TourProfit += Profit(Tasks[ctask]);
                if (++ctask >= Tasks.Length) ctask = 0;
            }
        }

        /// <summary>
        /// Runs one step of the algorithm.
        /// </summary>
        /// <returns>Number of ants that did not finish the tour yet.</returns>
        protected Int32 SimulateAnts()
        {
            Int32 unfinished = 0;

            foreach (var ant in ants)
            {
                // Pick the next transition for the ant
                var next = SelectTransition(ant);

                if (next != null)
                {
                    // ...if the transition is not null, the ant still has a way to go

                    // Process the next transition
                    ant.VisitFlags[next.Id] = true;
                    ant.Path.Add(next);
                    ant.TourCost += Cost(ant.CurrentTask, next);
                    ant.TourProfit += Profit(next);

                    // TODO Option for completing the cycle (?)
                    
                    // Transition the ant and mark it unfinished
                    ant.CurrentTask = next;
                    unfinished++;
                }

            }

            return unfinished;
        }

        /// <summary>
        /// Resets all ants to their initial state.
        /// </summary>
        protected void ResetAnts()
        {
            Double bestP = BestProfit - BestCost;

            Int32 ctask = 0;
            for (int i = 0; i < ants.Length; i++)
            {
                // TODO Tour Score?
                Double newP = ants[i].TourProfit - ants[i].TourCost;

                if (newP > bestP)
                {
                    BestSolution = ants[i].Path.ToList(); // Make a copy!
                    BestCost = ants[i].TourCost;
                    BestProfit = ants[i].TourProfit;

                    Delta = newP - bestP;
                }

                // TODO Initial Ant Distribution (??)
                ants[i] = new Ant
                {
                    VisitFlags = new Boolean[Tasks.Length],
                    CurrentTask = Tasks[ctask]
                };

                ants[i].VisitFlags[ctask] = true;
                ants[i].Path.Add(Tasks[ctask]);
                ants[i].TourProfit += Profit(Tasks[ctask]);
                if (++ctask >= Tasks.Length) ctask = 0;
            }

            if (BestProfit - BestCost == bestP)
                Delta = 0;
        }

        /// <summary>
        /// Updates (decays) all pheromone trails.
        /// </summary>
        protected void UpdatePheromone()
        {
            // Decay what is already there
            for (int i = 0; i < Tasks.Length; i++)
                for (int j = 0; j < Tasks.Length; j++)
                    if (i != j)
                    {
                        pheromone[i, j] *= (1.0 - Rho);
                        if (pheromone[i, j] < 0)
                            pheromone[i, j] = InitialPheromone;
                    }

            // Add new pheromone for finished ants
            foreach (Ant ant in ants)
            {
                for (int j = 0; j < ant.Path.Count - 1; j++)
                {
                    var from = ant.Path[j];
                    var to = ant.Path[j + 1];

                    // Pheromone Addition
                    Double paddition = /*(ant.TourValue / TotalValue * Q)*/ Q / ant.TourCost * Rho;

                    pheromone[@from.Id, to.Id] += paddition;

                    // TODO Is the graph bidirectional?? Option to disable this (?)
                    pheromone[to.Id, @from.Id] = pheromone[@from.Id, to.Id];
                }
            }
        }

        /// <summary>
        /// Selects the next transition for the ant.
        /// </summary>
        /// <param name="ant"></param>
        /// <returns></returns>
        protected Task<T> SelectTransition(Ant ant)
        {
            // Get all possible transitions for the ant
            var transitions = GetPossibleTransitions(ant);

            // If there are no more transitions, return null
            if (transitions.Length == 0)
                return null;

            // Calculate Transition Possibility Denominator
            Double denominator = transitions.Sum(t => AntProduct(ant.CurrentTask, t));

            // Check if denominator is zero...
            if (denominator == 0)
                throw new Exception("Transition Possibility Formula denominator is 0.0, you have a bug (?).");

            Int32 i;
            Double x = Rand.NextDouble();

            for (i = 0; i < transitions.Length; i++)
            {
                Double p = AntProduct(ant.CurrentTask, transitions[i]) / denominator;
                x -= p;
                if (x <= 0) break;
            }

            return transitions[i];
        }
        
        /// <summary>
        /// Calculates the nominator part of the transition probability formula.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        protected Double AntProduct(Task<T> from, Task<T> to)
        {
            Double p = pheromone[from.Id, to.Id];
            Double d = 1.0 / Cost(from, to);

            return 
                Math.Pow(p, Alpha) * Math.Pow(d, Beta);
        }

        /// <summary>
        /// Gets a list of possible transition tasks for the ant.
        /// </summary>
        /// <param name="ant"></param>
        /// <returns></returns>
        protected Task<T>[] GetPossibleTransitions(Ant ant)
        {
            return
                (from t in Tasks where !ant.VisitFlags[t.Id] && CanTransition(ant, t) select t).ToArray();
        }
    }
}
