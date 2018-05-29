using Ricochet.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ricochet.Core.Models
{
    /// <summary>
    /// Classe representant le plateau Ricochet
    /// </summary>
    public class BoardModel
    {
        public TargetModel Target { get; set; }
        public GridModel Grid { get; set; }
        public List<PawnModel> Pawns { get; set; }
        public enum Direction { Top, Right, Bottom, Left}

        private List<char> listLeftObstacle = new List<char> { '\0', 'Q' };
        private List<char> listTopObstacle = new List<char> { 'M', 'O', 'Z', '=' };
        private List<char> listRightObstacle = new List<char> { 'M', 'D', 'P', 'H' };
        private List<char> listBottomObstacle = new List<char> { 'P', 'L', 'S', '=' };

        public void MovePawn(Direction direction, PawnModel pawn)
        {
            //Vers le haut
            if (direction == Direction.Top)
            {
                MoveTop(pawn);
            }
            //Vers la droite
            else if (direction == Direction.Right)
            {
                MoveRight(pawn);
            }
            //Vers le bas
            else if (direction == Direction.Bottom)
            {
                MoveBottom(pawn);
            }
            //Vers la gauche
            else if (direction == Direction.Left)
            {
                MoveLeft(pawn);
            }
        }

        private bool PawnIsPresent(int x, int y)
        {
            foreach(var pawn in Pawns)
            {
                if(pawn.X == x && pawn.Y == y)
                {
                    return true;
                }
            }

            return false;
        }


        private void MoveRight(PawnModel pawn)
        {
            var obstacle = false;
            var x = pawn.X;
            var y = pawn.Y;

            while (!obstacle && y < Grid.YLastIndex)
            {
                if (listRightObstacle.Contains(Grid.Grid[x, y]) || PawnIsPresent(x, y + 1))
                {
                    obstacle = true;
                }
                else if (y != Grid.YLastIndex)
                {
                    y += 1;
                }
            }

            pawn.X = x;
            pawn.Y = y;
        }

        private void MoveTop(PawnModel pawn)
        {
            var obstacle = false;
            var x = pawn.X;
            var y = pawn.Y;

            while (!obstacle && x > 0)
            {
                if (listTopObstacle.Contains(Grid.Grid[x, y]) || PawnIsPresent(x - 1, y))
                {
                    obstacle = true;
                }
                else if (x != 0)
                {
                    x -= 1;
                }
            }

            pawn.X = x;
            pawn.Y = y;
        }

        private void MoveBottom(PawnModel pawn)
        {
            var obstacle = false;
            var x = pawn.X;
            var y = pawn.Y;

            while (!obstacle && x < Grid.XLastIndex)
            {
                if (listBottomObstacle.Contains(Grid.Grid[x, y]) || PawnIsPresent(x + 1, y))
                {
                    obstacle = true;
                }
                else if (x != Grid.XLastIndex)
                {
                    x += 1;
                }
            }

            pawn.X = x;
            pawn.Y = y;
        }

        private void MoveLeft(PawnModel pawn)
        {
            var obstacle = false;
            var x = pawn.X;
            var y = pawn.Y;

            while (!obstacle && y > 0)
            {
                if (listBottomObstacle.Contains(Grid.Grid[x, y]) || PawnIsPresent(x, y - 1))
                {
                    obstacle = true;
                }
                else if (y != 0)
                {
                    y -= 1;
                }
            }

            pawn.X = x;
            pawn.Y = y;
        }
    }
}
