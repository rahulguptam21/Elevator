using System;
using System.Collections.Generic;
using System.Text;

namespace ElevatorLibrary
{
    public interface IManager
    {
        void ButtonPressed(int floor);
        int GetCurrentFloor();
        Status GetCurrentDirection();
    }
    public class Manager : IManager
    {
        private readonly Queue<Request> _downRequests = new Queue<Request>();
        private readonly Elevator _elevator = new Elevator(10);
        private readonly Queue<Request> _upRequests = new Queue<Request>();

        public void ButtonPressed(int floor)
        {
            if (floor > _elevator.TopFloor)
            {
                Console.WriteLine("Only have {0} floors", _elevator.TopFloor);
                return;
            }

            if (floor > _elevator.CurrentFloor)
                _upRequests.Enqueue(new Request(floor));
            else
                _downRequests.Enqueue(new Request(floor));

            Move(floor);
        }

        private void Move(int floor)
        {
            switch (_elevator.Status)
            {
                case Status.GoingDown:
                    while (_downRequests.Count > 0)
                        _elevator.MoveDown(_downRequests.Dequeue().Floor);

                    _elevator.Status = Status.GoingDown;
                    break;

                case Status.GoingUp:
                    while (_upRequests.Count > 0)
                        _elevator.MoveUp(_upRequests.Dequeue().Floor);

                    _elevator.Status = Status.GoingUp;
                    break;

                case Status.Stopped:
                    if (floor > _elevator.CurrentFloor)
                        _elevator.Status = Status.GoingUp;
                    else if (floor <= _elevator.CurrentFloor)
                    {
                        _elevator.Status = Status.GoingDown;
                    }
                    Move(floor);

                    break;
                default:
                    break;
            }
        }

        public int GetCurrentFloor()
        {
            return _elevator.CurrentFloor;
        }

        public Status GetCurrentDirection()
        {
            return _elevator.Status;
        }
    }
}
