using System;
using System.Collections.Concurrent;
using ElevatorLibrary;

namespace ElevatorProgram
{
    class Program
    {
       // private const string _quit = "q";
        static void Main(string[] args)
        {
            var manager = new ElevatorScheduleManager();
           int floor =  manager.ButtonPressed(3, Status.GoingUp);            
        }
    }
}
