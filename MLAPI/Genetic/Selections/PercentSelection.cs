using System;
using System.Collections.Generic;
using System.Text;

namespace MLAPI.Genetic.Selections
{
    /// <summary>
    /// Selects the top percent of a population for reproduction.
    /// </summary>
    public class PercentSelection : ISelection
    {
        private float TopPercent { get; set; }

        public PercentSelection(float topPercent)
        {
            this.TopPercent = topPercent;
        }

        public List<Chromosome> SelectParents(Population pop)
        {
            int numberToSelect = (int)(pop.Chromosomes.Count * this.TopPercent);

            pop.Chromosomes.Sort((x, y) => x.Fitness.Value.CompareTo(y.Fitness.Value));
            return pop.Chromosomes.GetRange(pop.Chromosomes.Count - numberToSelect, numberToSelect);
        }
    }
}
