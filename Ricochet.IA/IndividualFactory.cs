using System;
using System.Collections.Generic;
using System.Text;

namespace Ricochet.IA
{
    internal class IndividualFactory
    {
        private static IndividualFactory instance;

        private IndividualFactory() { }

        public static IndividualFactory getInstance()
        {
            if (instance == null)
            {
                instance = new IndividualFactory();
            }
            return instance;
        }
        public Individual getIndividual(String type)
        {
            Individual ind = null;
            switch (type)
            {
                case "Ricochet":
                    ind = new RicochetIndividual();
                    break;
            }
            return ind;
        }

        public Individual getIndividual(String type,
Individual father)
        {
            Individual ind = null;
            switch (type)
            {
                case "Ricochet":
                    ind = new RicochetIndividual((RicochetIndividual)father);
                    break;
            }
            return ind;
        }

        public Individual getIndividual(String type, Individual father,
Individual mother)
        {
            Individual ind = null;
            switch (type)
            {
                case "Ricochet":
                    ind = new RicochetIndividual((RicochetIndividual)father,
(RicochetIndividual)mother);
                    break;
            }
            return ind;
        }

        internal void Init(string type)
        {
            switch (type)
            {
                case "Ricochet":
                    RicochetProblem.Init();
                    break;
            }
        }
    }
}
