using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskRoute
{
    public abstract class CbroOptimizer
    {

        protected static Random rand = new Random();

        #region Nested Types

        /// <summary>
        /// Representation of ant in ACO
        /// </summary>
        internal protected class Ant
        {
            public Ant()
            {
                CurrentTask = null;
                Path = new List<Task>();
                TourLength = 0.0;
            }

            /// <summary>
            /// Current task
            /// </summary>
            public Task CurrentTask { get; set; }
            
            /// <summary>
            /// Array to quickly flag visited tasks
            /// </summary>
            public Boolean[] VisitFlags { get; set; }

            /// <summary>
            /// Visited path up to the current task
            /// </summary>
            public List<Task> Path { get; set; }

            /// <summary>
            /// Length of current tour up to the current task
            /// </summary>
            public Double TourLength { get; set; }

            /// <summary>
            /// Value of the current tour up to the current task
            /// </summary>
            public Double TourValue { get; set; }
        }

        #endregion

        #region Persistent Optimizer Parameters

        /// <summary>
        /// All tasks that need to be routed.
        /// </summary>
        public Task[] Tasks { get; set; }

        /// <summary>
        /// Sum of all task values.
        /// </summary>
        public Double TotalValue { get; set; }
        
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
        public Double AntCount { get; set; }

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
        public List<Task> BestSolution { get; protected set; }

        /// <summary>
        /// Best score
        /// </summary>
        public Double BestScore { get; protected set; }

        /// <summary>
        /// Best tour distance up to the point.
        /// </summary>
        public Double BestDistance { get; protected set; }

        /// <summary>
        /// Best tour value up to the point.
        /// </summary>
        public Double BestValue { get; protected set; }

        #endregion

        #region Abstract Methods

        /// <summary>
        /// Abstract method that calculates distance between two tasks.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        protected abstract Double Distance(Task a, Task b);

        /// <summary>
        /// Abstract predicate that determines whether the ant can transition to a given task.
        /// </summary>
        /// <param name="ant"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        protected abstract Boolean CanTransition(Ant ant, Task next);

        /// <summary>
        /// Calculates the score for a solution represented by a 
        /// finished ant.
        /// </summary>
        /// <param name="ant"></param>
        /// <returns></returns>
        protected abstract Double CalculateScore(Ant ant);

        #endregion


        protected CbroOptimizer(IEnumerable<Task> tasks, Int32 antCount)
        {
            // Copy tasks
            Tasks = tasks.ToArray();

            // Check parameters
            if (Tasks.Length < 3)
                throw new ArgumentException("Optimizing for less than 3 tasks? Are you joking?");
            if (antCount < 1)
                throw new ArgumentException("There is really no point optimizing with no ants.");

            // Calculate sum of all values
            TotalValue = Tasks.Sum(t => t.Value);

            // Initialize Best Solution
            BestSolution = null;
            BestDistance = Double.MaxValue;
            BestValue = 0;
            BestScore = 0;

            // Initialize default parameters (unweighted)
            Alpha = 1.0;
            Beta = 1.0;
            Rho = 0.9;
            
            // Calculate Initial Pheromone Distribution
            InitialPheromone = 1.0 / Tasks.Length;

            // Initialize the Algorithm

            // Initialize Task IDs
            for (int i = 0; i < Tasks.Length; i++)
                Tasks[i].ID = i;

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
                    ant.VisitFlags[next.ID] = true;
                    ant.Path.Add(next);
                    ant.TourLength += Distance(ant.CurrentTask, next);
                    ant.TourValue += next.Value;

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
            Int32 ctask = 0;
            for (int i = 0; i < ants.Length; i++)
            {
                // TODO Tour Score?
                if (ants[i].TourLength < BestDistance)
                {
                    BestSolution = ants[i].Path.ToList(); // Make a copy!
                    BestDistance = ants[i].TourLength;
                    BestValue = ants[i].TourValue;
                }

                // TODO Initial Ant Distribution (??)
                ants[i] = new Ant
                {
                    VisitFlags = new Boolean[Tasks.Length],
                    CurrentTask = Tasks[ctask]
                };

                ants[i].VisitFlags[ctask] = true;
                ants[i].Path.Add(Tasks[ctask]);
                if (++ctask >= Tasks.Length) ctask = 0;
            }
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
                    Task from = ant.Path[j];
                    Task to = ant.Path[j + 1];

                    // Pheromone Addition
                    Double paddition = /*(ant.TourValue / TotalValue * Q)*/ Q / ant.TourLength * Rho;

                    pheromone[@from.ID, to.ID] += paddition;

                    // TODO Is the graph bidirectional?? Option to disable this (?)
                    pheromone[to.ID, @from.ID] = pheromone[@from.ID, to.ID];
                }
            }
        }

        /// <summary>
        /// Selects the next transition for the ant.
        /// </summary>
        /// <param name="ant"></param>
        /// <returns></returns>
        protected Task SelectTransition(Ant ant)
        {
            // Get all possible transitions for the ant
            Task[] transitions = GetPossibleTransitions(ant);

            // If there are no more transitions, return null
            if (transitions.Length == 0)
                return null;

            // Calculate Transition Possibility Denominator
            Double denominator = transitions.Sum(t => AntProduct(ant.CurrentTask, t));

            // Check if denominator is zero...
            if (denominator == 0)
                throw new Exception("Transition Possibility Formula denominator is 0.0, you have a bug (?).");

            Int32 i;
            Double x = rand.NextDouble();

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
        protected Double AntProduct(Task from, Task to)
        {
            Double p = pheromone[from.ID, to.ID];
            Double d = 1.0 / Distance(from, to);

            return 
                Math.Pow(p, Alpha) * Math.Pow(d, Beta);
        }

        /// <summary>
        /// Gets a list of possible transition tasks for the ant.
        /// </summary>
        /// <param name="ant"></param>
        /// <returns></returns>
        protected Task[] GetPossibleTransitions(Ant ant)
        {
            return
                (from t in Tasks where !ant.VisitFlags[t.ID] && CanTransition(ant, t) select t).ToArray();
        }
    }
}
