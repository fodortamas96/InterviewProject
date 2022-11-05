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

    }
}
