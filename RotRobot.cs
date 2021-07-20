//Interface Invariant: the implementation of tranRobot is a child class inherited from the Robot class. It supports the additional functionality
//of rotating

//Class Invariant: none

using System;
namespace P5
{
    public class RotRobot: Robot
    {
        protected Sensor[] sensorsRight = new Sensor[5];
        protected Sensor[] sensorsLeft = new Sensor[5];
        public RotRobot(int[,] Robogrid)
        {
            grid = Robogrid;

            for (int i = 0; i < 5; i++)
            {
                sensorsForward[i] = new Sensor(grid);
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

        public void Rotate(string dir)
        {
            if (dir == "RIGHT")
            {
                if (direction == "NORTH")
                {
                    direction = "EAST";
                    for (int i = 0; i < 5; i++)
                    {
                        sensorsForward[i].setDirection("EAST");
                        sensorsRight[i].setDirection("SOUTH");
                        sensorsLeft[i].setDirection("NORTH");
                    }
                }
                else if (direction == "SOUTH")
                {
                    direction = "WEST";
                    for (int i = 0; i < 5; i++)
                    {
                        sensorsForward[i].setDirection("WEST");
                        sensorsRight[i].setDirection("NORTH");
                        sensorsLeft[i].setDirection("SOUTH");
                    }

                }
                else if (direction == "EAST")
                {
                    direction = "SOUTH";
                    for (int i = 0; i < 5; i++)
                    {
                        sensorsForward[i].setDirection("SOUTH");
                        sensorsRight[i].setDirection("WEST");
                        sensorsLeft[i].setDirection("EAST");
                    }
                }
                else if (direction == "WEST")
                {
                    direction = "NORTH";
                    for (int i = 0; i < 5; i++)
                    {
                        sensorsForward[i].setDirection("NORTH");
                        sensorsRight[i].setDirection("EAST");
                        sensorsLeft[i].setDirection("WEST");
                    }
                }

            }
            else if (dir == "LEFT")
            {
                if (direction == "NORTH")
                {
                    direction = "WEST";
                    for (int i = 0; i < 5; i++)
                    {
                        sensorsForward[i].setDirection("WEST");
                        sensorsRight[i].setDirection("NORTH");
                        sensorsLeft[i].setDirection("SOUTH");
                    }
                }
                else if (direction == "SOUTH")
                {
                    direction = "EAST";
                    for (int i = 0; i < 5; i++)
                    {
                        sensorsForward[i].setDirection("EAST");
                        sensorsRight[i].setDirection("SOUTH");
                        sensorsLeft[i].setDirection("NORTH");
                    }
                }
                else if (direction == "EAST")
                {
                    direction = "NORTH";
                    for (int i = 0; i < 5; i++)
                    {
                        sensorsForward[i].setDirection("NORTH");
                        sensorsRight[i].setDirection("EAST");
                        sensorsLeft[i].setDirection("WEST");
                    }
                }
                else if (direction == "WEST")
                {
                    direction = "SOUTH";
                    for (int i = 0; i < 5; i++)
                    {
                        sensorsForward[i].setDirection("SOUTH");
                        sensorsRight[i].setDirection("WEST");
                        sensorsLeft[i].setDirection("EAST");
                    }
                }
            }

        }
    }
}

//Implementation invariants: none