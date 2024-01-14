using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalHomework
{
    internal class Elevator
    {
        private int currentFloor = 0;
        private bool[] floorButtonsPressed = new bool[4];
        private readonly object lockObject = new object();
        public SecurityLevel SecurityClearance { get; private set; }
        Semaphore Semaphore = new Semaphore(1, 1);


        public void CallElevator(int floor)
        {
            lock (lockObject)
            {
                Semaphore.WaitOne();
                floorButtonsPressed[floor] = true;
                Console.WriteLine($"{SecurityClearance} agent called the elevator from floor {floor}");
 
            }
        }

        public void MoveToFloor(int floor)
        {
            Console.WriteLine($"Moving elevator to floor {floor}...");
            Thread.Sleep(1000);
            Semaphore.Release();
            lock (lockObject)
            {
                currentFloor = floor;
                floorButtonsPressed[floor] = false; 
                Console.WriteLine($"Elevator arrived at floor {floor}");
            }
        }

        public bool OpenDoor(SecurityLevel agentSecurityLevel)
        {
            Console.WriteLine("Opening elevator door...");
            if (agentSecurityLevel == SecurityLevel.TopSecret)
            {
                Console.WriteLine($"{SecurityClearance} agent has access to this floor. Door opening...");
                return true;
            }
            else if (agentSecurityLevel == SecurityLevel.Secret)
            {
                if(currentFloor <= 3)
                {
                Console.WriteLine($"{SecurityClearance} agent has access to this floor. Door opening...");
                return true;
                }
                else { return false; }
              
            }
            else if (agentSecurityLevel == SecurityLevel.Confidental && currentFloor == 0)
            {
                if (currentFloor == 0)
                {
                    Console.WriteLine($"{SecurityClearance} agent has access to this floor. Door opening...");
                    return true;
                }
                else { return false; }

            }
            else
            {
                Console.WriteLine($"{SecurityClearance} agent does not have access to this floor. Door remains closed.");
                return false;
            }
            
        }
        
    }
}
