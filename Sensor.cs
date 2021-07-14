//Sensor Class
//Interface Invariant: the implementation of Sensor class. It encapsulate its state, battery level, and orientation, position,
//and its only functionality is isValid, isValidVertical, setDirection, and chargeBattery

//Class Invariant: None

using System;

namespace P5
{
    public class Sensor
    {
        private bool state;
        internal int batteryLevel;
        int dischargeRate;

        public int[,] grid;
        public string direction;
        public const int BATTERYLIFETIME = 100;
        public const int BATTERYTHRESHOLD = 10;
        internal int sensorX;
        internal int sensorY;


        private void reduceBattery()
        {
            if (batteryLevel <= 0)
            {
                state = false;
            }
            else
            {
                batteryLevel = batteryLevel - dischargeRate;
            }
        }


        public Sensor(int[,] roboGrid)
		{
            state = true;
            batteryLevel = BATTERYLIFETIME;
            dischargeRate = 1;
            sensorX = 5;
            sensorY = 5;
            direction = "NORTH";
            grid = new int[11,11];

            for (int k = 0; k < 11; k++)
			{
                for (int h = 0; h < 11; h++)
                {
                    grid[k,h] = roboGrid[k,h];
                }
			}
		}

        public Sensor(int[,] roboGrid, string dir)
		{
            state = true;
            batteryLevel = BATTERYLIFETIME;
            dischargeRate = 1;
            direction = dir;
            grid = new int[11,11];
            sensorX = 5;
            sensorY = 5;

            for (int k = 0; k < 11; k++)
            {
                for (int h = 0; h < 11; h++)
                {
                    grid[k,h] = roboGrid[k,h];
                }
            }

        }
        public Sensor(Sensor obj)
		{
            state = obj.state;
            batteryLevel = obj.batteryLevel;
            dischargeRate = obj.dischargeRate;
            direction = obj.direction;
            grid = obj.grid;
            sensorX = obj.sensorX;
            sensorY = obj.sensorY;
		}

        public bool isValid(int x, int y)
		{
            if (state)
            {
                if (batteryLevel <= BATTERYTHRESHOLD)
                {
                    reduceBattery();
                    return false;
                }
                else if (direction == "NORTH" && grid[x - 1,y] == 0)
                {
                    reduceBattery();
                    return false;
                }
                else if (direction == "NORTH" && grid[x - 1, y] == 1)
                {
                    reduceBattery();
                    sensorX -= 1;
                    return true;
                }
                else if (direction == "SOUTH" && grid[x + 1, y] == 0)
                {
                    reduceBattery();
                    return false;
                }
                else if (direction == "SOUTH" && grid[x + 1, y] == 1)
                {
                    reduceBattery();
                    sensorX += 1;
                    return true;
                }
                else if (direction == "EAST" && grid[x, y + 1] == 0)
                {
                    reduceBattery();
                    return false;
                }
                else if (direction == "EAST" && grid[x, y + 1] == 1)
                {
                    reduceBattery();
                    sensorY += 1;
                    return true;
                }
                else if (direction == "WEST" && grid[x, y - 1] == 0)
                {
                    reduceBattery();
                    sensorY -= 1;
                    return false;
                }
                else if (direction == "WEST" && grid[x, y - 1] == 1)
                {
                    reduceBattery();
                    return true;
                }
            }

            reduceBattery();
            return false;
        }

        public bool isValidVertical(int[,] roboGrid)
        {
            if (state)
            {
                if (batteryLevel <= BATTERYTHRESHOLD)
                {
                    reduceBattery();
                    return false;
                }
                else if (direction == "UP" && roboGrid[sensorX, sensorY] == 0)
                {
                    reduceBattery();
                    return false;
                }
                else if (direction == "UP" && roboGrid[sensorX, sensorY] == 1)
                {
                    reduceBattery();
                    return true;
                }
                else if (direction == "DOWN" && roboGrid[sensorX, sensorY] == 0)
                {
                    reduceBattery();
                    return false;
                }
                else if (direction == "DOWN" && roboGrid[sensorX, sensorY] == 1)
                {
                    reduceBattery();
                    return true;
                }
            }

            reduceBattery();
            return false;
        }

        public void chargeBattery()
		{
            if (batteryLevel <= 0)
            {
                batteryLevel = BATTERYLIFETIME;
                state = true;
            }
            else
            {
                batteryLevel = BATTERYLIFETIME;
            }
        }

        public void setDirection(string dir)
        {
            direction = dir;
        }

    }
}


//Implementation Invariant: the move for the desired grid in isValidVertical is passed as a parameter 