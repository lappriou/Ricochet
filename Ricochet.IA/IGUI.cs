using System;
using System.Collections.Generic;
using System.Text;

namespace Ricochet.IA
{
    public interface IGUI
    {
        void PrintBestIndividual(Individual individual, int generation);

        void PrintProblem();
    }
}
