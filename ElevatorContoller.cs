using System;
using System.Collections.Generic;
using System.Text;

namespace ElevatorLibrary
{
    public interface IElevatorController
    {
        ElevatorStatus ElevatorRequests(int input);
    }
    public class ElevatorContoller : IElevatorController
    {
        private readonly IManager _manager;
        private ElevatorStatus _status = new ElevatorStatus();
        public ElevatorContoller(IManager manager)
        {
            _manager = manager;
        }

        public ElevatorStatus ElevatorRequests(int input)
        {
            _manager.ButtonPressed(input);
            _status.Floor =  _manager.GetCurrentFloor();
            _status.Direction = _manager.GetCurrentDirection();

            return _status;
        }
    }
}
