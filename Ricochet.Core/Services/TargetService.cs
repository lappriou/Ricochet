using Ricochet.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ricochet.Core.Services
{
    public static class TargetService
    {
        public static TargetModel GetTarget(GridModel grid, List<PawnModel> pawns)
        {
            return GenerateTarget(grid, pawns);
        }

        private static TargetModel GenerateTarget(GridModel grid, List<PawnModel> pawns)
        {
            var rnd = new Random();
            var target = new TargetModel();
            var targetStat = false;
            var walls1 = new List<char> { 'D', 'Q', 'Z', 'S' };
            var walls2 = new List<char> { 'L', 'O', 'P', 'M' };
            target.Pawn = pawns[rnd.Next(0, pawns.Count)];

            while (!targetStat)
            {
                var x = rnd.Next(0, grid.XLastIndex);
                var y = rnd.Next(0, grid.YLastIndex);

                if((x == 0 || x == grid.XLastIndex || y == 0 || y == grid.YLastIndex) && !(target.Pawn.X == x && target.Pawn.Y == y))
                {
                    if (walls1.Contains(grid.Grid[x, y]))
                    {
                        target.X = x;
                        target.Y = y;
                        targetStat = true;
                    }
                    else if ((x == 0 && (y == 0 || y == 15) || x == 15))
                    {
                        target.X = x;
                        target.Y = y;
                        targetStat = true;
                    }
                    else if (walls2.Contains(grid.Grid[x, y]))
                    {
                        target.X = x;
                        target.Y = y;
                        targetStat = true;
                    }
                }
            }

            return target;
        }
    }
}
