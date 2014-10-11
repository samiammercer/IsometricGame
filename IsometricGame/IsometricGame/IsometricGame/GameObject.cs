using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace IsometricGame
{
    /// <summary>
    /// Generic class that holds variables and functions for any kind of object
    /// </summary>
    public class GameObject
    {
        protected Vector2 position, isoPosition;

        /// <summary>
        /// GameObject constructor that takes no parameter; For classes that extend game object
        /// </summary>
        public GameObject(){}

        /// <summary>
        /// GameObject constructor that takes position
        /// </summary>
        /// <param name="position">Position of the GameObject</param>
        public GameObject(Vector2 position)
        {
            this.position = position;
            calculateIsoPosition(position);
        }

        /// <summary>
        /// Returns the x coordinate of the object
        /// </summary>
        /// <returns>positionX</returns>
        public float getX()
        {
            return position.X;
        }
        public float getY()
        {
            return position.Y;
        }

        private void calculateIsoPosition(Vector2 position)
        {
            isoPosition.X = position.X - position.Y;
            isoPosition.Y = (position.X + position.Y) / 2;
        }
    }
}
