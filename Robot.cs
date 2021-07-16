using System;
//Robot class
//Interface Invariant: the implementation of tranRobot is a child class inherited from the Robot class. It supports the additional functionality
//of rotating

//Class Invariant: none
namespace P5
{
    public class Robot
    {
        protected Actuator actuatorForward;
        protected Sensor[] sensorsForward = new Sensor[5];
        protected bool poweredUp;
        public int[,] grid;
        protected int x;
        protected int y;
        protected int z;
        protected int moves;
        protected string direction;

        public Robot()
        {
            poweredUp = true;
            x = 5;
            y = 5;
            z = 5;
            direction = "NORTH";
            moves = 0;
            actuatorForward = new Actuator(1);
            grid = new int[11, 11];
            for (int i = 0; i < 5; i++)
            {
                sensorsForward[i] = new Sensor(grid);
            }
        }

        public Robot(int[,] Robogrid)
        {
            poweredUp = true;
            grid = Robogrid;
            x = 5;
            y = 5;
            z = 5;
            direction = "NORTH";
            moves = 0;
            actuatorForward = new Actuator(1);
            for (int i = 0; i < 5; i++)
            {
                sensorsForward[i] = new Sensor(grid);
            }         
        }

        public Robot(Robot obj)
        {
            poweredUp = obj.poweredUp;
            x = obj.x;
            y = obj.y;
            moves = obj.moves;
            direction = obj.direction;
            actuatorForward = obj.actuatorForward;

            sensorsForward = obj.sensorsForward;
        }

        public bool isValid()
        {
            int firstThresholdIndex = 0;
            int secondThresholdIndex = 0;

            for (int i = 0; i < 4; i++)
            {
                if (sensorsForward[i].batteryLevel > 90)
                {
                    firstThresholdIndex = i;
                }
                else if ((((sensorsForward[i].batteryLevel) > sensorsForward[secondThresholdIndex].batteryLevel)) && ((sensorsForward[i].batteryLevel) < sensorsForward[firstThresholdIndex].batteryLevel))
                {
                    secondThresholdIndex = i;
                }
            }

            if ((sensorsForward[firstThresholdIndex].batteryLevel) > 90)
            {
                return (sensorsForward[firstThresholdIndex].isValid(x, y));
            }
            else if (((sensorsForward[firstThresholdIndex].batteryLevel) > 80) && ((sensorsForward[secondThresholdIndex].batteryLevel) > 80))
            {
                return (sensorsForward[firstThresholdIndex].isValid(x, y));
            }
            else
            {
                sensorsForward[firstThresholdIndex].chargeBattery();
                return (sensorsForward[firstThresholdIndex].isValid(x, y));
            }
        }

        public void Move()
        {
            while (isValid())
            {
                MoveOne();
            }

        }

        public bool MoveOne()
        {
            if (isValid())
            {
                actuatorForward.MoveForward();
                if (direction == "NORTH")
                {
                    x -= 1;
                    moves++;
                }
                else if (direction == "SOUTH")
                {
                    x += 1;
                    moves++;
                }
                else if (direction == "EAST")
                {
                    y += 1;
                    moves++;
                }
                else if (direction == "WEST")
                {
                    y -= 1;
                    moves++;
                }
                return true;
            }
            return false;
        }

        public bool hasPower()
        {
            return poweredUp;
        }

        public int getXPosition()
        {
            return x;
        }

        public int getYPosition()
        {
            return y;
        }
    }
}

//Implementation invariants: all the sensors and actuator are dynamically allocated and deallocated using a destructor. Also I chose to implement the big 5
//for object manipulation