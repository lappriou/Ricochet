using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ricochet.IA
{
    public class RicochetIndividual : Individual
    {
        public RicochetIndividual()
        {
            genome = new List<IGene>();

            for (int i = 0; i < Parameters.initialGenesNb; i++)
            {
                genome.Add(new GeneRicochet());
            }
        }

        public RicochetIndividual(RicochetIndividual father)
        {
            this.genome = new List<IGene>();
            foreach (GeneRicochet g in father.genome)
            {
                this.genome.Add(new GeneRicochet(g));
            }
            Mutate();
        }

        public RicochetIndividual(RicochetIndividual father, RicochetIndividual mother)
        {
            this.genome = new List<IGene>();
            int cuttingPoint =
    Parameters.randomGenerator.Next(father.genome.Count);
            foreach (GeneRicochet g in father.genome.Take(cuttingPoint))
            {
                this.genome.Add(new GeneRicochet(g));
            }
            foreach (GeneRicochet g in mother.genome.Skip(cuttingPoint))
            {
                this.genome.Add(new GeneRicochet(g));
            }
            Mutate();

        }

        internal override double Evaluate()
        {
            fitness = RicochetProblem.Evaluate(this);
            return fitness;
        }

        internal override void Mutate()
        {
            MutateByDeletion();
            MutateByAddition();
            MutateByChangingValue();
        }

        private void MutateByAddition()
        {
            if (Parameters.randomGenerator.NextDouble() <
    Parameters.mutationAddRate)
            {
                genome.Add(new GeneRicochet());
            }
        }

        private void MutateByChangingValue()
        {
            foreach (GeneRicochet g in genome)
            {
                if (Parameters.randomGenerator.NextDouble() <
    Parameters.mutationsRate)
                {
                    g.Mutate();
                }
            }
        }

        private void MutateByDeletion()
        {
//                if (Parameters.randomGenerator.NextDouble() <
//Parameters.mutationDeleteRate)
//                {
//                    int geneIndex =
//                        Parameters.randomGenerator.Next(genome.Count);
//                        genome.RemoveAt(geneIndex);

//                }
        }
    }
}
