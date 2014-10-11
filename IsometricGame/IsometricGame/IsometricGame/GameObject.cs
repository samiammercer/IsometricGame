using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IsometricGame
{
    public class GameObject
    {
        private int positionX, positionY, length, width;
        public int getX()
        {
            return positionX;
        }
        public int getY()
        {
            return positionY;
        }
        public int getLength()
        {
            return length;
        }
        public int getWidth()
        {
            return width;
        }
    }
}
