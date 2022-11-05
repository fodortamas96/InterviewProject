using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProject
{
    internal class Garden
    {
        const int WIDTHOFGARDEN = 50;
        const int HEIGHTOFGARDEN = 50;

        const int MINOBSTACLES = 2;
        const int MAXOBSTACLES = 5;
        const int MINOBSTACLESIZE = 5;
        const int MAXOBSTACLESIZE = 10;

        char[,] garden;
        List<Obstacle> obstacles = new List<Obstacle>();

        public Garden()
        {
            this.garden = new char[WIDTHOFGARDEN, HEIGHTOFGARDEN];
        }

        public List<Obstacle> Obstacles { get => obstacles; set => obstacles = value; }

        public void CreateObstacles()
        {
            Random rnd = new Random();
            int numberOfObstacles = rnd.Next(MINOBSTACLES, MAXOBSTACLES);
            for (int i = 0; i < numberOfObstacles; i++)
            {
                int width = rnd.Next(MINOBSTACLESIZE, MAXOBSTACLESIZE);
                int height = rnd.Next(MINOBSTACLESIZE, MAXOBSTACLESIZE);
                int x = rnd.Next(0, this.garden.GetLength(0) - width - 1);
                int y = rnd.Next(0, this.garden.GetLength(1) - height - 1);

                Obstacle obstacle = new Obstacle(x, y, height, width);
                Obstacles.Add(obstacle);
            }
        }

        public void FillObstacle(Obstacle obstacle)
        {
            for (int i = obstacle.Top; i < obstacle.Top + obstacle.Height; i++)
            {
                for (int j = obstacle.Left; j < obstacle.Left + obstacle.Width; j++)
                {
                    garden[i, j] = obstacle.ObstacleChar;
                }
            }
        }

        public void ShowGarden()
        {
            for (int i = 0; i < garden.GetLength(0); i++)
            {
                for (int j = 0; j < garden.GetLength(1); j++)
                {
                    Console.Write(garden[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
