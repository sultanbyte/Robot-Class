//Interface Invariant: the implementation of submersible class. It is an add-onn class that
//is used in SunRobot to simulate multiple inheritance. It has two vertical sensors and an actuator
//and supports moving up and down through multiple grids

//Class Invariant: none 

using System;
using System.Collections;
namespace P5
{
    public class Submersible
    {
        protected Actuator actuatorVertical;
        protected Sensor[] sensorsUp = new Sensor[5];
        protected Sensor[] sensorsDown = new Sensor[5];
        protected int[,] grid;
        
        public Submersible(int[,] Robogrid)
        {
            grid = Robogrid;
            actuatorVertical = new Actuator(5);

            for (int i = 0; i < 5; i++)
            {
                sensorsUp[i] = new Sensor(Robogrid, "UP");
            }
            for (int i = 0; i < 5; i++)
            {
                sensorsDown[i] = new Sensor(Robogrid, "DOWN");
            }
        }

        public Submersible(Submersible obj)
        {
            actuatorVertical = obj.actuatorVertical;
            grid = obj.grid;
          
            for (int i = 0; i < 5; i++)
            {
                sensorsUp[i] = obj.sensorsUp[i];
            }
            for (int i = 0; i < 5; i++)
            {
                sensorsDown[i] = obj.sensorsDown[i];
            }
        }

        public bool MoveUP(int[,] Robogrid)
        {
            if (sensorsUp[0].isValidVertical(Robogrid))
            {
                actuatorVertical.MoveForward();
                return true;
            }
            return false;
        }

        public bool MoveDown(int[,] Robogrid)
        {
            if(sensorsDown[0].isValidVertical(Robogrid))
            {
                actuatorVertical.MoveBack();
                return true;
            }
            return false;
        }
    }
}

//Implementation invariants: Assumes that the desired grid to move to is passed to MoveDown or MoveUp
//from the provided grids by the client/driver