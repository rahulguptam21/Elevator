using System;

namespace ElevatorLibrary
{
    public enum Status
    {
        GoingUp,
        GoingDown,
        Stopped,
        Idle
    }

    public class ElevatorStatus
    {
        public int Floor { get; set; }
        public Status Direction { get; set; }
    }
}
