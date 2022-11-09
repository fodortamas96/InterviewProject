using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(16, 16);
            Console.SetBufferSize(16, 16);

            Simulation.Init();
            Simulation.Run();

            Console.ReadLine();
        }
    }
}
