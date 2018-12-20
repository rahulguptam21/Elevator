using System;
using System.Collections.Generic;
using System.Text;

namespace ElevatorLibrary
{
    public class Request
    {
        public Request(int floor)
        {
            Floor = floor;
        }

        public int Floor { get; set; }
    }
}
