using Ricochet.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ricochet.IA
{
    public class Parameters
    {
        public static int individualsNb = 30;
        public static int generationsMaxNb = 50;
        public static int initialGenesNb = 10;
        public static int minFitness = 0;

        public static double mutationsRate = 0.10;
        public static double mutationAddRate = 0.20;
        public static double mutationDeleteRate = 0.10;
        public static double crossoverRate = 0.50;

        public static Random randomGenerator = new Random();

    }
}
