using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProject
{
    internal class Obstacle
    {
        int x;
        int y;
        int width;
        int height;

        char obstacleChar;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
        public char ObstacleChar { get => obstacleChar; set => obstacleChar = value; }

        public Obstacle(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.obstacleChar = 'X';
        }
    }
}
