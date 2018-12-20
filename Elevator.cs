using System;
using System.Collections.Generic;
using System.Text;

namespace ElevatorLibrary
{
    public class Elevator
    {
        public int TopFloor;

        public Elevator(int topFloor)
        {
            TopFloor = topFloor;
        }

        public int CurrentFloor { get; set; } = 1;
        public Status Status { get; set; } = Status.Stopped;

        public void MoveUp(int floor)
        {
            Status = Status.GoingUp;
            Console.WriteLine("Going up to: {0}", floor);
            CurrentFloor = floor;
            OpenDoor();
            CloseDoor();
        }

        public void MoveDown(int floor)
        {
            Status = Status.GoingDown;
            Console.WriteLine("Going down to: {0}", floor);
            CurrentFloor = floor;
            OpenDoor();
            CloseDoor();
        }

        private void OpenDoor()
        {
            Console.WriteLine("Door opening");
        }

        private void CloseDoor()
        {
            Console.WriteLine("Door closing, at floor: {0}", this.CurrentFloor);
        }
    }
}
