using Ricochet.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ricochet.Core.Services
{
    public static class BoardService
    {
        public static BoardModel GetBoard(int sizeGrid = 16, int numberPawn = 4)
        {
            var board = new BoardModel();
            board.Grid = GridService.GetGrid(sizeGrid);
            board.Pawns = (List<PawnModel>)PawnService.GetPawns(numberPawn, board.Grid);
            board.Target = TargetService.GetTarget(board.Grid, board.Pawns);
            return board;
        }

    }
}
