using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Ricochet.Core.Models
{
    /// <summary>
    /// Classe represetant un pion
    /// </summary>
    public class PawnModel : ICloneable
    {
        public Color Color { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public PawnModel()
        {

        }

        public PawnModel(Color color,int x, int y)
        {
            Color = color;
            X = x;
            Y = y;
        }

        public object Clone()
        {
            return new PawnModel(this.Color, this.X, this.Y);
        }
    }
}
