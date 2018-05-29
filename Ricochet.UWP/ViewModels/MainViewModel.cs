using Ricochet.Core.Models;
using Ricochet.Core.Services;
using Ricochet.IA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Ricochet.UWP.ViewModels
{
    public class MainViewModel : IGUI
    {
        public EvolutionaryProcess GeneticAlgoRicochet { get; set; }

        public MainViewModel()
        {
            InitGrid();
            Run();
        }

        private void InitGrid()
        {

        }


        public void Run()
        {
            // Init  
            Parameters.crossoverRate = 0.5;
            Parameters.mutationsRate = 0.4;
            Parameters.mutationAddRate = 0.3;
            Parameters.mutationDeleteRate = 0.1;
            Parameters.minFitness = 0;
            Parameters.generationsMaxNb = 1000;
            Parameters.initialGenesNb = 2;
            Parameters.individualsNb = 100;
            GeneticAlgoRicochet =
            new EvolutionaryProcess(this, "Ricochet");
            GeneticAlgoRicochet.Run();
        }

        public void PrintBestIndividual(Individual individual, int generation)
        {
            throw new NotImplementedException();
        }

        public void PrintProblem()
        {
            throw new NotImplementedException();
        }
    }
}
