using Ricochet.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ricochet.IA
{
    public class GeneRicochet : IGene
    {
        public BoardModel.Direction Direction { get; set; }

        public PawnModel Pawn { get; set; }

        public GeneRicochet()
        {
            InitRandomGene();
        }

        public GeneRicochet(GeneRicochet g)
        {
            Direction = g.Direction;
            Pawn = (PawnModel)g.Pawn;
        }

        public override string ToString()
        {
            return $"{Pawn.Color}, {Direction}  ////";
        }

        public void Mutate()
        {
            InitRandomGene();
        }

        private void InitRandomGene()
        {
            Direction = (BoardModel.Direction)Parameters.randomGenerator.Next(4);
            Pawn = (PawnModel)RicochetProblem.Board.Pawns[Parameters.randomGenerator.Next(RicochetProblem.Board.Pawns.Count)];
        }
    }
}
