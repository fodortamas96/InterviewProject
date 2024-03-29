﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InterviewProject
{
    internal class Garden
    {
        const int WIDTHOFGARDEN = 15;
        const int HEIGHTOFGARDEN = 15;

        const int MINOBSTACLES = 5;
        const int MAXOBSTACLES = 7;
        const int MINOBSTACLESIZE = 2;
        const int MAXOBSTACLESIZE = 3;

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
            for (int i = obstacle.Y; i < obstacle.Y + obstacle.Height; i++)
            {
                for (int j = obstacle.X; j < obstacle.X + obstacle.Width; j++)
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
            lawnMower.StartingPosX = x;
            lawnMower.StartingPosY = y;
            GardenMap[x, y] = lawnMower.LawnMowerChar;
        }

        public void ShowGarden()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < GardenMap.GetLength(0); i++)
            {
                for (int j = 0; j < GardenMap.GetLength(1); j++)
                {
                    Console.Write(GardenMap[i, j]);
                }
                Console.WriteLine();
            }
            Thread.Sleep(150);
        }

        public bool IsItObstacle(int x, int y)
        {
            if (!IsItOutOfRange(x, y) && GardenMap[x, y] == 'X')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsItOutOfRange(int x, int y)
        {
            if (x == WIDTHOFGARDEN || y == HEIGHTOFGARDEN || x < 0 || y < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsValidMove(int x, int y)
        {
            if (!IsItOutOfRange(x, y) && !IsItObstacle(x, y))
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
            double distance;
            double lastDistance = 100d;
            for (int i = 0; i < GardenMap.GetLength(0); i++)
            {
                for (int j = 0; j < GardenMap.GetLength(1); j++)
                {
                    distance = Math.Abs(lawnMower.PositionX - i) + Math.Abs(lawnMower.PositionY - j);
                    if (GardenMap[i, j] == 'X' || GardenMap[i, j] == 'M' || GardenMap[i, j] == '.')
                    {
                        continue;
                    }
                    else
                    {
                        
                        if (distance < lastDistance)
                        {
                            minX = i;
                            minY = j;
                            lastDistance = distance;
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
                int[] lastPosition = new int[] { lawnMower.PositionX, lawnMower.PositionY };
                if (IsValidMove(lawnMower.PositionX + 1, lawnMower.PositionY) && closestGrass[0] > lawnMower.PositionX)
                {
                    lawnMower.PositionX++;
                    gardenMap[lawnMower.PositionX, lawnMower.PositionY] = lawnMower.LawnMowerChar;
                    ShowGarden();
                }
                else if (IsValidMove(lawnMower.PositionX, lawnMower.PositionY - 1) && closestGrass[1] < lawnMower.PositionY)
                {
                    lawnMower.PositionY--;
                    gardenMap[lawnMower.PositionX, lawnMower.PositionY] = lawnMower.LawnMowerChar;
                    ShowGarden();
                }
                else if (IsValidMove(lawnMower.PositionX - 1, lawnMower.PositionY) && closestGrass[0] < lawnMower.PositionX)
                {
                    lawnMower.PositionX--;
                    gardenMap[lawnMower.PositionX, lawnMower.PositionY] = lawnMower.LawnMowerChar;
                    ShowGarden();
                }
                else if (IsValidMove(lawnMower.PositionX, lawnMower.PositionY + 1) && closestGrass[1] > lawnMower.PositionY)
                {
                    lawnMower.PositionY++;
                    gardenMap[lawnMower.PositionX, lawnMower.PositionY] = lawnMower.LawnMowerChar;
                    ShowGarden();
                }

                gardenMap[lastPosition[0], lastPosition[1]] = '.';
            }
        }
    }
}
