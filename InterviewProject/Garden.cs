using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProject
{
    internal class Garden
    {
        const int MINOBSTACLES = 2;
        const int MAXOBSTACLES = 5;
        const int MINOBSTACLESIZE = 5;
        const int MAXOBSTACLESIZE = 10;

        char[,] garden;

        public Garden()
        {
            this.garden = new char[50, 50];
        }

        List<Obstacle> obstacles = new List<Obstacle>();

        public void CreateObstacles()
        {
            Random rnd = new Random();
            int numberOfObstacles = rnd.Next(MINOBSTACLES, MAXOBSTACLES);
            for (int i = 0; i < numberOfObstacles; i++)
            {
                int width = rnd.Next(MINOBSTACLESIZE, MAXOBSTACLESIZE);
                int height = rnd.Next(MINOBSTACLESIZE, MAXOBSTACLESIZE);
                int x = rnd.Next(0, this.garden.GetLength(1) - height - 1);
                int y = rnd.Next(0, this.garden.GetLength(0) - width - 1);

                Obstacle obstacle = new Obstacle(x, y, height, width);
                obstacles.Add(obstacle);
            }
        }
    }
}
