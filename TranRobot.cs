//Interface Invariant: the implementation of tranRobot is a child class inherited from the Robot class. It supports the additional functionality
//of moving forward, backward, right, left

//Class Invariant: none



using System;

namespace P5
{
    public class TranRobot : Robot
    {

        protected Actuator actuatorRight;
        protected Actuator actuatorLeft;
        protected Actuator actuatorBackward;
        protected Sensor[] sensorsRight = new Sensor[5];
        protected Sensor[] sensorsLeft = new Sensor[5];
        protected Sensor[] sensorsBackward = new Sensor[5];

        public TranRobot()
        {
            actuatorBackward = new Actuator(2);
            actuatorRight = new Actuator(3);
            actuatorLeft = new Actuator(4);

            for (int i = 0; i < 5; i++)
            {
                sensorsForward[i] = new Sensor(grid);
            }

            for (int i = 0; i < 5; i++)
            {
                sensorsBackward[i] = new Sensor(grid, "SOUTH");
            }
            for (int i = 0; i < 5; i++)
            {
                sensorsRight[i] = new Sensor(grid, "EAST");
            }
            for (int i = 0; i < 5; i++)
            {
                sensorsLeft[i] = new Sensor(grid, "WEST");
            }
        }

        public TranRobot(int[,] Robogrid)
        {
            grid = Robogrid;
            actuatorBackward = new Actuator(2);
            actuatorRight = new Actuator(3);
            actuatorLeft = new Actuator(4);

            for (int i = 0; i < 5; i++)
            {
                sensorsForward[i] = new Sensor(grid);
            }

            for (int i = 0; i < 5; i++)
            {
                sensorsBackward[i] = new Sensor(Robogrid, "SOUTH");
            }
            for (int i = 0; i < 5; i++)
            {
                sensorsRight[i] = new Sensor(Robogrid, "EAST");
            }
            for (int i = 0; i < 5; i++)
            {
                sensorsLeft[i] = new Sensor(Robogrid, "WEST");
            }
        }

        public TranRobot(TranRobot obj)
        {
            poweredUp = obj.poweredUp;
            x = obj.x;
            y = obj.y;
            moves = obj.moves;
            direction = obj.direction;
            actuatorForward = obj.actuatorForward;
            actuatorBackward = obj.actuatorBackward;
            actuatorRight = obj.actuatorRight;
            actuatorLeft = obj.actuatorLeft;
            for (int i = 0; i < 5; i++)
            {
                sensorsForward[i] = obj.sensorsForward[i];
            }
            for (int i = 0; i < 5; i++)
            {
                sensorsBackward[i] = obj.sensorsBackward[i];
            }
            for (int i = 0; i < 5; i++)
            {
                sensorsRight[i] = obj.sensorsRight[i];
            }
            for (int i = 0; i < 5; i++)
            {
                sensorsLeft[i] = obj.sensorsLeft[i];
            }
        }

        public bool isValid(string dir)
        {

            if (dir == "FORWARD")
            {
                int firstThresholdIndex = 0;
                int secondThresholdIndex = 0;

                for (int i = 0; i < 5; i++)
                {
                    if ((sensorsForward[i].batteryLevel) > 90)
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
            else if (dir == "RIGHT")
            {
                int firstThresholdIndex = 0;
                int secondThresholdIndex = 0;

                for (int i = 0; i < 5; i++)
                {
                    if ((sensorsRight[i].batteryLevel) > 90)
                    {
                        firstThresholdIndex = i;
                    }
                    else if ((((sensorsRight[i].batteryLevel) > sensorsRight[secondThresholdIndex].batteryLevel)) && ((sensorsRight[i].batteryLevel) < sensorsRight[firstThresholdIndex].batteryLevel))
                    {
                        secondThresholdIndex = i;
                    }
                }

                if ((sensorsRight[firstThresholdIndex].batteryLevel) > 90)
                {
                    return (sensorsRight[firstThresholdIndex].isValid(x, y));
                }
                else if (((sensorsRight[firstThresholdIndex].batteryLevel) > 80) && ((sensorsRight[secondThresholdIndex].batteryLevel) > 80))
                {
                    return (sensorsRight[firstThresholdIndex].isValid(x, y));
                }
                else
                {
                    sensorsRight[firstThresholdIndex].chargeBattery();
                    return (sensorsRight[firstThresholdIndex].isValid(x, y));
                }
            }
            else if (dir == "LEFT")
            {
                int firstThresholdIndex = 0;
                int secondThresholdIndex = 0;

                for (int i = 0; i < 5; i++)
                {
                    if ((sensorsLeft[i].batteryLevel) > 90)
                    {
                        firstThresholdIndex = i;
                    }
                    else if ((((sensorsLeft[i].batteryLevel) > sensorsLeft[secondThresholdIndex].batteryLevel)) && ((sensorsLeft[i].batteryLevel) < sensorsLeft[firstThresholdIndex].batteryLevel))
                    {
                        secondThresholdIndex = i;
                    }
                }

                if ((sensorsLeft[firstThresholdIndex].batteryLevel) > 90)
                {
                    return (sensorsLeft[firstThresholdIndex].isValid(x, y));
                }
                else if (((sensorsLeft[firstThresholdIndex].batteryLevel) > 80) && ((sensorsLeft[secondThresholdIndex].batteryLevel) > 80))
                {
                    return (sensorsLeft[firstThresholdIndex].isValid(x, y));
                }
                else
                {
                    sensorsLeft[firstThresholdIndex].chargeBattery();
                    return (sensorsLeft[firstThresholdIndex].isValid(x, y));
                }

            }
            else if (dir == "BACK")
            {
                int firstThresholdIndex = 0;
                int secondThresholdIndex = 0;

                for (int i = 0; i < 5; i++)
                {
                    if ((sensorsBackward[i].batteryLevel) > 90)
                    {
                        firstThresholdIndex = i;
                    }
                    else if ((((sensorsBackward[i].batteryLevel) > sensorsBackward[secondThresholdIndex].batteryLevel)) && ((sensorsBackward[i].batteryLevel) < sensorsBackward[firstThresholdIndex].batteryLevel))
                    {
                        secondThresholdIndex = i;
                    }
                }

                if ((sensorsBackward[firstThresholdIndex].batteryLevel) > 90)
                {
                    return (sensorsBackward[firstThresholdIndex].isValid(x, y));
                }
                else if (((sensorsBackward[firstThresholdIndex].batteryLevel) > 80) && ((sensorsBackward[secondThresholdIndex].batteryLevel) > 80))
                {
                    return (sensorsBackward[firstThresholdIndex].isValid(x, y));
                }
                else
                {
                    sensorsBackward[firstThresholdIndex].chargeBattery();
                    return (sensorsBackward[firstThresholdIndex].isValid(x, y));
                }
            }
            else
            {
                return false;
            }
        }

        public void Forward()
        {
            if (isValid("FORWARD"))
            {
                actuatorForward.MoveForward();
                x -= 1;
                moves++;
            }
        }

        public void Back()
        {
            if (isValid("BACK"))
            {
                x += 1;
                moves++;
            }
        }

        public void Right()
        {
            if (isValid("RIGHT"))
            {
                y += 1;
                moves++;
            }
        }

        public void Left()
        {
            if (isValid("LEFT"))
            {
                y -= 1;
                moves++;
            }
        }
    }
}

//Implementation invariants: none