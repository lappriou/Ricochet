using Ricochet.Core.Services;
using Ricochet.IA;
using System;
using System.Drawing;

/// <summary>
/// Projet console pour afficher la résolution et le résultat de l'intlligence artificiel
/// </summary>
namespace Ricochet.IhmConsole
{
    class Program : IGUI
    {
        static void Main(string[] args)
        {

            Program p = new Program();
            p.Run();
           
        }

        public void PrintBestIndividual(Individual individual, int generation)
        {
            /// Affichage du meilleur indivivu de la génération
            Console.WriteLine(generation + " -> " + individual);
        }

        public void PrintProblem()
        {
            int rowLength = RicochetProblem.Board.Grid.Grid.GetLength(0);
            int colLength = RicochetProblem.Board.Grid.Grid.GetLength(1);

            Console.WriteLine("La grille");
            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("{0} ", RicochetProblem.Board.Grid.Grid[i, j]));
                }
                Console.Write(Environment.NewLine);
            }

            Console.WriteLine("Les pions");

            foreach (var pawn in RicochetProblem.Board.Pawns)
            {
                Console.WriteLine($"Couleur : {pawn.Color.Name}, Position : [{pawn.X},{pawn.Y}]");
            }

            Console.WriteLine($"L'objectif! Pos: [{RicochetProblem.Board.Target.X},{RicochetProblem.Board.Target.Y}], couleur du pion concerné : {RicochetProblem.Board.Target.Pawn.Color.Name}");
        }

        public void Run()
        {
            // Init  
            Parameters.crossoverRate = 0.5;
            Parameters.mutationsRate = 0.4;
            Parameters.mutationAddRate = 0.3;
            Parameters.minFitness = 0;
            Parameters.generationsMaxNb = 1000;
            Parameters.initialGenesNb = 2;
            Parameters.individualsNb = 100;
            EvolutionaryProcess geneticAlgoRicochet =
            new EvolutionaryProcess(this, "Ricochet");

            PrintProblem();
            Console.ReadLine();
            // Lancement  
            geneticAlgoRicochet.Run();

            Console.ReadLine();
        }
    }
}
