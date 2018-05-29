using System;
using System.Collections.Generic;
using System.Text;

namespace Ricochet.Core.Models
{
    /// <summary>
    /// Classe represenant la grille du jeu
    /// </summary>
    public class GridModel
    {
        public char[,] Grid { get; set; }

        public int XLastIndex { get; set; }
        public int YLastIndex { get; set; }

        public GridModel()
        {

        }

        public GridModel(int xSize, int ySize)
        {
            Grid = new char[xSize, ySize];
            XLastIndex = xSize - 1;
            YLastIndex = ySize - 1;
        }
    }
}
