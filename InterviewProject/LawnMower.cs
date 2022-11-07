using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProject
{
    internal class LawnMower
    {
        int positionX;
        int positionY;

        char lawnMowerChar;

        public int PositionX { get => positionX; set => positionX = value; }
        public int PositionY { get => positionY; set => positionY = value; }
        public char LawnMowerChar { get => lawnMowerChar; set => lawnMowerChar = value; }

        public LawnMower(int positionX, int positionY)
        {
            this.positionX = positionX;
            this.positionY = positionY;
            this.lawnMowerChar = 'M';
        }

        public int[] WhereIsTheClosestGrass(char[,] garden)
        {
            int minX = 0;
            int minY = 0;
            for (int i = 0; i < garden.GetLength(0); i++)
            {
                for (int j = 0; j < garden.GetLength(1); j++)
                {
                    if (garden[i, j] == 'X' || garden[i, j] == 'M' || garden[i, j] == '.')
                    {
                        continue;
                    }
                    else
                    {
                        if (positionX - i < positionX - minX || positionY - j < positionY - minY)
                        {
                            minX = i;
                            minY = j;
                        }
                    }
                }
            }
            return new int[] { minX, minY };
        }
    }
}
