using System;
using System.Collections.Generic;
using System.Text;

namespace Ricochet.Core.Models
{
    /// <summary>
    /// Classe représentant l'objectif du jeu
    /// </summary>
    public class TargetModel
    {
        public int X { get; set; }
        public int Y { get; set; }
        public PawnModel Pawn { get; set; }

        public TargetModel()
        {

        }

        public TargetModel(int x, int y, PawnModel pawn)
        {
            X = x;
            Y = y;
            Pawn = pawn;
        }
    }
}
