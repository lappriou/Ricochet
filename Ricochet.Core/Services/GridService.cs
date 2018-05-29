using Ricochet.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ricochet.Core.Services
{
    public static class GridService
    {
        public static GridModel GetGrid(int size)
        {
            return GenerateGrid(size);
        }

        private static GridModel GenerateGrid(int size)
        {
            var rnd = new Random();
            var grid = new GridModel(size, size);

            //On décide au début quel quart de grille aura un mur intérieur supplémentaires
            var nbrQuarterWin = rnd.Next(0,3);
            var nbrWallIn = new int[] { 4,4,4,4 };
            nbrWallIn[nbrQuarterWin] = 5;

            var xLastIndexQuarter = (size / 2) - 1;
            var yLastIndexQuarter = (size / 2) - 1;

            // Quart en haut à gauche
            var quarterGridTopLeft = new char[size / 2, size / 2];
            quarterGridTopLeft = GenerateQuarter(quarterGridTopLeft, 0, 0, nbrWallIn[0]);
            quarterGridTopLeft[xLastIndexQuarter, yLastIndexQuarter] = 'O';
            quarterGridTopLeft[xLastIndexQuarter, yLastIndexQuarter - 1] = 'D';
            quarterGridTopLeft[xLastIndexQuarter - 1, yLastIndexQuarter] = 'S';
            

            grid.Grid = QuarterToGrid(0, 0, grid.Grid, quarterGridTopLeft);

            //Quart en haut à droite
            var quarterGridTopRight= new char[size / 2, size / 2];
            quarterGridTopRight = GenerateQuarter(quarterGridTopRight, 0, yLastIndexQuarter, nbrWallIn[1]);
            quarterGridTopRight[xLastIndexQuarter, 0] = 'M';
            quarterGridTopRight[xLastIndexQuarter, 1] = 'Q';
            quarterGridTopRight[xLastIndexQuarter - 1, 0] = 'S';
            grid.Grid = QuarterToGrid(0, yLastIndexQuarter + 1, grid.Grid, quarterGridTopRight);

            //Quart en bas à gauche
            var quarterGridBottomLeft = new char[size / 2, size / 2];
            quarterGridBottomLeft = GenerateQuarter(quarterGridBottomLeft, xLastIndexQuarter, 0, nbrWallIn[2]);
            quarterGridBottomLeft[0, yLastIndexQuarter] = 'L';
            quarterGridBottomLeft[0, yLastIndexQuarter - 1] = 'D';
            quarterGridBottomLeft[1, yLastIndexQuarter] = 'Z';          
            grid.Grid = QuarterToGrid(xLastIndexQuarter + 1, 0, grid.Grid, quarterGridBottomLeft);

            //Quart en bas à droite
            var quarterGridBottomRight = new char[size / 2, size / 2];
            quarterGridBottomRight = GenerateQuarter(quarterGridBottomRight, xLastIndexQuarter, yLastIndexQuarter, nbrWallIn[3]);
            quarterGridBottomRight[0, 0] = 'P';
            quarterGridBottomRight[0, 1] = 'Q';
            quarterGridBottomRight[1, 0] = 'Z';
            grid.Grid = QuarterToGrid(xLastIndexQuarter + 1, yLastIndexQuarter + 1, grid.Grid, quarterGridBottomRight);
            
            return grid;
        }

        private static char[,] GenerateQuarter(char[,] quarter, int xWallGenerateOut, int yWallGenerateOut, int numberWallIn)
        {
            quarter = RandomGenOutWall(xWallGenerateOut, yWallGenerateOut, quarter);
            quarter = RandomGenWallIn(numberWallIn, quarter);
            return quarter;
        }
        private static char[,] RandomGenOutWall(int x, int y, char[,] quarter)
        {
            var xLastIndex = quarter.GetLength(0) - 1;
            var yLastIndex = quarter.GetLength(1) - 1;
            quarter = GenerateHorizontalWallOut(x, xLastIndex, y, yLastIndex, quarter);
            quarter = GenerateVerticalWallOut(x, xLastIndex, y, yLastIndex, quarter);
            return quarter;
        }

        private static char[,] QuarterToGrid(int xStart, int yStart, char[,] grid, char[,] quarter) 
        {
            for (var x = xStart; x < xStart + quarter.GetLength(0); x++)
            {
                for (var y = yStart; y < yStart + quarter.GetLength(1); y++)
                {
                    grid[x, y] = quarter[x - xStart, y - yStart];
                }
            }

            return grid;
        }
        private static char[,] GenerateVerticalWallOut(int x, int xLastIndex, int y, int yLastIndex, char[,] quarter)
        {
            var autodirect = false;

            var rnd = new Random();
            var numberRandomWall = rnd.Next(0, xLastIndex);

            if (numberRandomWall == 0 && ((x == 0 && y == 0) || (x == xLastIndex && y == 0)))
            {
                numberRandomWall = rnd.Next(1, xLastIndex);
            }
            else if (numberRandomWall == xLastIndex && ((x == 0 && y == yLastIndex) || (x == xLastIndex && y == yLastIndex)))
            {
                numberRandomWall = rnd.Next(0, xLastIndex - 1);
            }
            else
            {
                autodirect = true;
            }

            if (numberRandomWall == 0)
            {
                quarter[numberRandomWall, y] = 'S';
                quarter[numberRandomWall + 1, y] = 'Z';
            }
            else if (numberRandomWall == xLastIndex)
            {
                quarter[numberRandomWall, y] = 'Z';
                quarter[numberRandomWall - 1, y] = 'S';
            }
            else
            {
                int direction;
                if (autodirect)
                {
                    direction = rnd.Next(0, 1);
                }
                else
                {
                    direction = numberRandomWall == 0 ? 1 : 0;
                }

                if (direction == 0)
                {
                    quarter[numberRandomWall, y] = 'Z';
                    quarter[numberRandomWall - 1, y] = 'S';
                }
                else
                {
                    quarter[numberRandomWall, y] = 'S';
                    quarter[numberRandomWall + 1, y] = 'Z';
                }
            }

            return quarter;
        }

        private static char[,] GenerateHorizontalWallOut(int x, int xLastIndex, int y, int yLastIndex, char[,] quarter)
        {
            var rnd = new Random();
            var numberRandomWall = rnd.Next(0, yLastIndex);

            if (numberRandomWall == 0)
            {
                quarter[x, numberRandomWall] = 'D';
                quarter[x, numberRandomWall + 1] = 'Q';
            }
            else if (numberRandomWall == yLastIndex)
            {
                quarter[x, numberRandomWall] = 'Q';
                quarter[x, numberRandomWall - 1] = 'D';
            }
            else
            {
                var direction = rnd.Next(0, 1);
                if (direction == 0)
                {
                    quarter[x, numberRandomWall] = 'Q';
                    quarter[x, numberRandomWall - 1] = 'D';
                }
                else
                {
                    quarter[x, numberRandomWall] = 'D';
                    quarter[x, numberRandomWall + 1] = 'Q';
                }
            }

            return quarter;
        }

        private static char[,] RandomGenWallIn(int nbrWall, char[,] quarter)
        {
            var indexWall = 0;
            var rnd = new Random();
            //Cas des murs qui sont ok
            var listLeftOK = new List<char> { '\0', 'Q' };
            var listTopOK = new List<char> { '\0', 'Z' };
            var listRightOK = new List<char> { '\0', 'D' };
            var listBottomOK = new List<char> { '\0', 'S' };

            while (indexWall != nbrWall)
            {
                var rndX = rnd.Next(1, quarter.GetLength(0) - 2);
                var rndY = rnd.Next(1, quarter.GetLength(1) - 2);

                if (quarter[rndX, rndY] == '\0')
                {
                    var rndAngle = rnd.Next(1, 4);
                    //#Mur 1(HautGauche)
                    if (rndAngle == 1)
                    {
                        if (!listLeftOK.Contains(quarter[rndX, rndY - 1]) || !listTopOK.Contains(quarter[rndX - 1, rndY]))
                        {

                        }
                        else
                        {
                            quarter[rndX, rndY] = 'O';
                            if (quarter[rndX, rndY - 1] == 'Q')
                            {
                                quarter[rndX, rndY - 1] = 'H';
                            }
                            else
                            {
                                quarter[rndX, rndY - 1] = 'D';
                            }

                            if (quarter[rndX - 1, rndY] == 'Z')
                            {
                                quarter[rndX - 1, rndY] = '=';
                            }
                            else
                            {
                                quarter[rndX - 1, rndY] = 'S';
                            }

                            indexWall += 1;
                        }
                    }

                    //Mur M(HautDroite)
                    else if (rndAngle == 2)
                    {
                        if (!listRightOK.Contains(quarter[rndX, rndY + 1]) || !listTopOK.Contains(quarter[rndX - 1, rndY]))
                        {

                        }
                        else
                        {
                            quarter[rndX, rndY] = 'M';
                            if (quarter[rndX, rndY + 1] == 'D')
                            {
                                quarter[rndX, rndY + 1] = 'H';
                            }
                            else
                            {
                                quarter[rndX, rndY + 1] = 'Q';
                            }

                            if (quarter[rndX - 1, rndY] == 'Z')
                            {
                                quarter[rndX - 1, rndY] = '=';
                            }
                            else
                            {
                                quarter[rndX - 1, rndY] = 'S';
                            }
                            indexWall += 1;
                        }
                    }
                    //Mur L(BasGauche)
                    else if (rndAngle == 3)
                    {
                        if (!listLeftOK.Contains(quarter[rndX, rndY - 1]) || !listBottomOK.Contains(quarter[rndX + 1, rndY]))
                        {

                        }
                        else
                        {
                            quarter[rndX, rndY] = 'L';
                            if (quarter[rndX, rndY - 1] == 'Q')
                            {
                                quarter[rndX, rndY - 1] = 'H';
                            }
                            else
                            {
                                quarter[rndX, rndY - 1] = 'D';
                            }

                            if (quarter[rndX + 1, rndY] == 'S')
                            {
                                quarter[rndX + 1, rndY] = '=';
                            }
                            else
                            {
                                quarter[rndX + 1, rndY] = 'Z';
                            }
                            indexWall += 1;
                        }
                    }
                    //Mur P(Bas droite)
                    else
                    {
                        if (!listRightOK.Contains(quarter[rndX, rndY + 1]) || !listBottomOK.Contains(quarter[rndX + 1, rndY]))
                        {

                        }
                        else
                        {
                            quarter[rndX, rndY] = 'P';
                            if (quarter[rndX, rndY + 1] == 'Q')
                            {
                                quarter[rndX, rndY + 1] = 'H';
                            }
                            else
                            {
                                quarter[rndX, rndY + 1] = 'D';
                            }

                            if (quarter[rndX + 1, rndY] == 'S')
                            {
                                quarter[rndX + 1, rndY] = '=';
                            }
                            else
                            {
                                quarter[rndX + 1, rndY] = 'Z';
                            }
                            indexWall += 1;
                        }
                    }
                }
            }
            return quarter;
        }
    }
}
