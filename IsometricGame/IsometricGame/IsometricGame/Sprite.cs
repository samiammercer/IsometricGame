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
    /// Stores and is responsible for drawing animations as well as static sprites
    /// </summary>
    public class Sprite
    {
        private int frameWidth, numberOfFrames, currentFrame, timePerFrame, count;
        private Texture2D sprite;

        /// <summary>
        /// constructs a static sprite
        /// </summary>
        /// <param name="sprite">The 2D texture of the object</param>
        public Sprite(Texture2D sprite)
        {
            this.sprite = sprite;
            frameWidth = sprite.Width;
            numberOfFrames = 1;
            currentFrame = 1;
            timePerFrame = 1;
        }

        /// <summary>
        /// contructs and animated sprite
        /// </summary>
        /// <param name="sprite">The 2D texture of the object</param>
        /// <param name="frameWidth">The width of each piece of the animation</param>
        /// <param name="numberOfFrames">The number of frames in the animation texture</param>
        /// <param name="timePerFrame">How long each section of the texture will be displayed</param>
        /// <param name="currentFrame">The frame currently selected to be drawn</param>
        public Sprite(Texture2D sprite, int frameWidth, int numberOfFrames, int timePerFrame, int currentFrame)
        {
            this.sprite = sprite;
            this.frameWidth = frameWidth;
            this.numberOfFrames = numberOfFrames;
            this.timePerFrame = timePerFrame;
            this.currentFrame = currentFrame;
        }

        /// <summary>
        /// Returns the width of the sprite.
        /// </summary>
        public int Width { get { return sprite.Width / numberOfFrames; } }

        /// <summary>
        /// Returns the height of the sprite.
        /// </summary>
        public int Height { get { return sprite.Height; } }

        /// <summary>
        /// Updates the sprite's animation.
        /// </summary>
        public void Update()
        {
            if (count >= timePerFrame)
            {
                currentFrame = (currentFrame + 1) % numberOfFrames;
                count = 0;
            }

            count++;
        }

        /// <summary>
        /// Draws a sprite given a position
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch used to draw</param>
        /// <param name="position">Position to draw the sprite at</param>
        /// <param name="color">Color to tint the sprite</param>
        virtual public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(sprite, position, new Rectangle(frameWidth * currentFrame, 0, Width, Height), color, 0, new Vector2(), 1, 0, 0);
            spriteBatch.End();
        }
    }
}
