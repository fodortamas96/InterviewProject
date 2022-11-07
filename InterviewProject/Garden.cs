using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProject
{
    internal class Garden
    {
        const int WIDTHOFGARDEN = 30;
        const int HEIGHTOFGARDEN = 30;

        const int MINOBSTACLES = 2;
        const int MAXOBSTACLES = 5;
        const int MINOBSTACLESIZE = 5;
        const int MAXOBSTACLESIZE = 10;

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
    }
}
