//Actuator Class
//Interface Invariant: the implementation of actuator that is used in robot class is pertty straighforward. it encapsulate its state, position, and orientation
//and its only functionality is MoveForward, isPoweredUp, setOrientation, and getPosition

//Class Invariant: None


using System;

namespace P5
{
    public class Actuator
    {
        private bool state;
        private int position;
        private int orientation;
        private enum dir { FORWARD = 1, BACKWARD = 2, RIGHT = 3, LEFT = 4, VERTICAL = 5};

        public Actuator()
        {
            state = true;
            position = 0;
            orientation = 1;
        }

        public Actuator(int dir)
        {
            state = true;
            position = 0;
            orientation = dir;
        }

        public Actuator(ref Actuator obj)
        {
            this.state = obj.state;
            this.position = obj.position;
            this.orientation = obj.orientation;
        }

        public void MoveForward()
        {
            if(state)
            {
                position += 1;
            }
        }

        public void MoveBack()
        {
            if(state)
            {
                position -= 1;
            }
        }

        public bool isPoweredUp()
        {
            return state;
        }

        public int getPosition()
        {
            return position;
        }


    }
}

//Implementation Invariant: assumed the actuator is a physical component that will move when position is incremented