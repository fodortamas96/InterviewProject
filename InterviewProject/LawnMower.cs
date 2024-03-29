﻿using System;
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

        int startingPosX;
        int startingPosY;

        char lawnMowerChar;

        public int PositionX { get => positionX; set => positionX = value; }
        public int PositionY { get => positionY; set => positionY = value; }
        public char LawnMowerChar { get => lawnMowerChar; set => lawnMowerChar = value; }
        public int StartingPosX { get => startingPosX; set => startingPosX = value; }
        public int StartingPosY { get => startingPosY; set => startingPosY = value; }

        public LawnMower(int positionX, int positionY)
        {
            this.positionX = positionX;
            this.positionY = positionY;
            this.lawnMowerChar = 'M';
        }
    }
}
