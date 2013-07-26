using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskRoute
{
    /// <summary>
    /// Represents a task entity.
    /// </summary>
    public class Task
    {
        #region Task Properties

        public Int32 ID { get; set; }

        public Location Location { get; set; }

        public Double Value { get; set; }
        
        #endregion
    }
}
