using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace ElevatorLibrary
{
    public class ElevatorScheduleManager
    {
        private ConcurrentDictionary<int, Status> _floors = new ConcurrentDictionary<int, Status>();

        public ElevatorScheduleManager()
        {
            IManager manager = new Manager();
            IElevatorController controller = new ElevatorContoller(manager);
            var status = controller.ElevatorRequests(4);
            _floors.TryAdd(status.Floor, status.Direction);
            IManager manager1 = new Manager();
            IElevatorController controller1 = new ElevatorContoller(manager1);
            var status1 = controller1.ElevatorRequests(9);
            _floors.TryAdd(status1.Floor, status1.Direction);
            IManager manager2 = new Manager();
            IElevatorController controller2 = new ElevatorContoller(manager2);
            var status2 = controller2.ElevatorRequests(1);
            _floors.TryAdd(status2.Floor, status2.Direction);
        }

        public int ButtonPressed(int reqfloor, Status reqstatus)
        {
            bool startAgain = false;
            ElevatorStatus elevatorMovingInSameDirection = new ElevatorStatus();
            ElevatorStatus idleElevator = new ElevatorStatus();
            foreach (var floorstatus in _floors)
            {
                if (reqfloor == floorstatus.Key && reqstatus == floorstatus.Value)
                {
                    startAgain = true;
                    break;
                }

                
                if (floorstatus.Value == Status.Idle) {
                    idleElevator.Floor = floorstatus.Key;
                    idleElevator.Direction = floorstatus.Value;
                }
                
                if (floorstatus.Value == reqstatus)
                {                    
                    if (reqstatus == Status.GoingUp && reqfloor - floorstatus.Key > 0)
                    {
                        elevatorMovingInSameDirection.Floor = floorstatus.Key; 
                        elevatorMovingInSameDirection.Direction = floorstatus.Value;
                    }
                    
                    if (reqstatus == Status.GoingDown && reqfloor - floorstatus.Key < 0)
                    {
                        elevatorMovingInSameDirection.Floor = floorstatus.Key; 
                        elevatorMovingInSameDirection.Direction = floorstatus.Value;
                    }
                }
               
                if (!startAgain && idleElevator != null)
                {
                    idleElevator.Floor = floorstatus.Key;                    
                }

                if (!startAgain && elevatorMovingInSameDirection != null)
                {
                    elevatorMovingInSameDirection.Floor = floorstatus.Key;                    
                }
            }
            return elevatorMovingInSameDirection.Floor;
        }
    }
}
