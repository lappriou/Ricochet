using Ricochet.Core.Models;
using Ricochet.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ricochet.IA
{
    /// <summary>
    /// Classe representant le problème traité
    /// </summary>
    public static class RicochetProblem
    {
        public static BoardModel Board { get; set; }

        private static int xStart;
        private static int yStart;
        private static bool end = false;

        public static void Init()
        {
            Board = BoardService.GetBoard(16,4);
            xStart = Board.Target.Pawn.X;
            yStart = Board.Target.Pawn.Y;
        }

        internal static double Evaluate(RicochetIndividual individual)
        {
            var xOlds = new List<int>();
            var yOlds = new List<int>();
            bool end = false;
            var listRem = new List<GeneRicochet>();

            foreach (GeneRicochet g in individual.genome)
            {
                
                if(!end)
                {
                    xOlds.Add(g.Pawn.X);
                    yOlds.Add(g.Pawn.Y);
                    Board.MovePawn(g.Direction, (PawnModel)g.Pawn);
                    end = g.Pawn.X == Board.Target.X && g.Pawn.Y == Board.Target.Y;
                }
                else
                {
                    listRem.Add(g);
                }
            }

            foreach(var g in listRem)
            {
                individual.genome.Remove(g);
            }
            int distance = Math.Abs(Board.Target.X - Board.Target.Pawn.X) +
                Math.Abs(Board.Target.Y - Board.Target.Pawn.Y);


            for (var i = individual.genome.Count - 1; i >= 0; i-- )
            {
                GeneRicochet genome = (GeneRicochet) individual.genome[i];
                genome.Pawn.X = xOlds[i];
                genome.Pawn.Y = yOlds[i];
            }

            return distance * 100;

        }


    }
}
