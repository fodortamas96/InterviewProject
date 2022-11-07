using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InterviewProject
{
    internal class Garden
    {
        const int WIDTHOFGARDEN = 10;
        const int HEIGHTOFGARDEN = 10;

        const int MINOBSTACLES = 2;
        const int MAXOBSTACLES = 5;
        const int MINOBSTACLESIZE = 1;
        const int MAXOBSTACLESIZE = 5;

        char[,] gardenMap;
        List<Obstacle> obstacles = new List<Obstacle>();
        LawnMower lawnMower;

        public Garden()
        {
            this.GardenMap = new char[WIDTHOFGARDEN, HEIGHTOFGARDEN];
        }

        public List<Obstacle> Obstacles { get => obstacles; set => obstacles = value; }
        internal LawnMower LawnMower { get => lawnMower; set => lawnMower = value; }
        public char[,] GardenMap { get => gardenMap; set => gardenMap = value; }

        public void CreateObstacles()
        {
            Random rnd = new Random();
            int numberOfObstacles = rnd.Next(MINOBSTACLES, MAXOBSTACLES);
            for (int i = 0; i < numberOfObstacles; i++)
            {
                int width = rnd.Next(MINOBSTACLESIZE, MAXOBSTACLESIZE);
                int height = rnd.Next(MINOBSTACLESIZE, MAXOBSTACLESIZE);
                int x = rnd.Next(0, this.GardenMap.GetLength(0) - width - 1);
                int y = rnd.Next(0, this.GardenMap.GetLength(1) - height - 1);

                Obstacle obstacle = new Obstacle(x, y, height, width);
                Obstacles.Add(obstacle);
            }
        }

        public void FillGrass()
        {
            for (int i = 0; i < GardenMap.GetLength(0); i++)
            {
                for (int j = 0; j < GardenMap.GetLength(1); j++)
                {
                    GardenMap[i, j] = '|';
                }
            }
        }

        public void FillObstacle(Obstacle obstacle)
        {
            for (int i = obstacle.Top; i < obstacle.Top + obstacle.Height; i++)
            {
                for (int j = obstacle.Left; j < obstacle.Left + obstacle.Width; j++)
                {
                    GardenMap[i, j] = obstacle.ObstacleChar;
                }
            }
        }

        public void PutDownLawnMower()
        {
            Random rnd = new Random();
            int x;
            int y;
            do
            {
                x = rnd.Next(0, WIDTHOFGARDEN);
                y = rnd.Next(0, HEIGHTOFGARDEN);
            } while (IsItObstacle(x, y));
            lawnMower = new LawnMower(x, y);
            GardenMap[x, y] = lawnMower.LawnMowerChar;
        }

        public void ShowGarden()
        {
            Console.Clear();
            for (int i = 0; i < GardenMap.GetLength(0); i++)
            {
                for (int j = 0; j < GardenMap.GetLength(1); j++)
                {
                    Console.Write(GardenMap[i, j]);
                }
                Console.WriteLine();
            }
        }

        public bool IsItObstacle(int x, int y)
        {
            if (GardenMap[x, y] == obstacles[0].ObstacleChar)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int[] WhereIsTheClosestGrass()
        {
            int minX = 0;
            int minY = 0;
            for (int i = 0; i < GardenMap.GetLength(0); i++)
            {
                for (int j = 0; j < GardenMap.GetLength(1); j++)
                {
                    if (GardenMap[i, j] == 'X' || GardenMap[i, j] == 'M' || GardenMap[i, j] == '.')
                    {
                        continue;
                    }
                    else
                    {
                        if (Math.Abs(lawnMower.PositionX - i) < Math.Abs(lawnMower.PositionX - minX) || Math.Abs(lawnMower.PositionY - j) < Math.Abs(lawnMower.PositionY - minY))
                        {
                            minX = i;
                            minY = j;
                        }
                    }
                }
            }
            return new int[] { minX, minY };
        }

        public void MoveAndCut()
        {
            int[] closestGrass = WhereIsTheClosestGrass();
            while (!(closestGrass[0] == lawnMower.PositionX && closestGrass[1] == lawnMower.PositionY))
            {
                int[] lastPosition = new int[] { lawnMower.PositionX, lawnMower.PositionY};
                if (closestGrass[0] < lawnMower.PositionX)
                {
                    lawnMower.PositionX--;
                    gardenMap[lawnMower.PositionX, lawnMower.PositionY] = lawnMower.LawnMowerChar;
                    ShowGarden();
                }
                else if (closestGrass[0] > lawnMower.PositionX)
                {
                    lawnMower.PositionX++;
                    gardenMap[lawnMower.PositionX, lawnMower.PositionY] = lawnMower.LawnMowerChar;
                    ShowGarden();
                }
                else if (closestGrass[1] < lawnMower.PositionY)
                {
                    lawnMower.PositionY--;
                    gardenMap[lawnMower.PositionX, lawnMower.PositionY] = lawnMower.LawnMowerChar;
                    ShowGarden();
                }
                else
                {
                    lawnMower.PositionY++;
                    gardenMap[lawnMower.PositionX, lawnMower.PositionY] = lawnMower.LawnMowerChar;
                    ShowGarden();
                }
                gardenMap[lastPosition[0], lastPosition[1]] = '.';
            }
            Thread.Sleep(50);
        }
    }
}
