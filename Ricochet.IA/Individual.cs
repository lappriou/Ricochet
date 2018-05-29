using System;
using System.Collections.Generic;
using System.Text;

namespace Ricochet.IA
{
    public abstract class Individual
    {
        protected double fitness = -1;
        public double Fitness
        {
            get
            {
                return fitness;
            }
        }

        internal List<IGene> genome;

        internal abstract void Mutate();

        internal abstract double Evaluate();

        public override string ToString()
        {
            String gen = fitness + $" : nb: {genome.Count} :";
            gen += String.Join(" - ", genome);
            return gen;
        }
    }
}
