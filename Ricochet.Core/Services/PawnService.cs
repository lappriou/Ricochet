using Ricochet.Core.Helpers;
using Ricochet.Core.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Ricochet.Core.Services
{
    public static class PawnService
    {
        public static IEnumerable<PawnModel> GetPawns(int numberPawn, GridModel grid)
        {
            var pawns = GeneratePawns(numberPawn, grid);
            return pawns;
        }

        private static IEnumerable<PawnModel> GeneratePawns(int number, GridModel grid)
        {
            var namesColor = ColorsHelper.ColorStructToList();
            var pawns = new List<PawnModel>();
            var noGen = false;


            for (var i = 0; i < number && !noGen; i++)
            {
                var pawn = GeneratePawn(pawns, grid, namesColor[pawns.Count]);
                if(pawn != null)
                {
                    pawns.Add(pawn);
                }
                else
                {
                    noGen = true;
                }
            }

            return pawns;
        }

        private static PawnModel GeneratePawn(List<PawnModel> pawns, GridModel grid, Color color)
        {
            Random randomGen = new Random();
            var pawn = new PawnModel()
            {
                Color = color
            };

            var xLastIndex = grid.Grid.GetLength(0);
            var numberTest = 10;
            var stat_pawn = false;

            for (var i = 0; i < numberTest && !stat_pawn; i++)
            {
                int x = randomGen.Next(0, grid.XLastIndex);
                int y = randomGen.Next(0, grid.YLastIndex);
                var tryAgain = false;
                for(var j = 0; j < pawns.Count && !tryAgain; j++)
                {
                    if(pawns[j].X == x && pawns[j].Y == y)
                    {
                        tryAgain = true;
                    }
                }
                stat_pawn = !tryAgain;
                if (stat_pawn)
                {
                    pawn.X = x;
                    pawn.Y = y;
                }
            }


            return stat_pawn ? pawn : null;
        }
    }
}
