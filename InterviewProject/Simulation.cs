using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProject
{
    internal class Simulation
    {
        static Garden garden = new Garden();

        static public void Init()
        {
            garden.FillGrass();
            garden.CreateObstacles();
            for (int i = 0; i < garden.Obstacles.Count; i++)
            {
                garden.FillObstacle(garden.Obstacles[i]);
            }
            garden.PutDownLawnMower();
            garden.ShowGarden();
        }

        static public void Run()
        {
            while (true)
            {
                garden.MoveAndCut();
            }
        }
    }
}
