using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProject
{
    internal class Obstacle
    {
        int left;
        int top;
        int width;
        int height;

        char obstacleChar;

        public int Left { get => left; set => left = value; }
        public int Top { get => top; set => top = value; }
        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
        public char ObstacleChar { get => obstacleChar; set => obstacleChar = value; }

        public Obstacle(int left, int top, int width, int height)
        {
            this.left = left;
            this.top = top;
            this.width = width;
            this.height = height;
            this.obstacleChar = 'X';
        }
    }
}
