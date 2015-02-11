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
    public class Tile: GameObject
    {
        Sprite sprite;

        public Tile(Sprite sprite, Vector2 position)
        {
            this.sprite = sprite;
            this.position = position;
            calculateIsoPosition();
        }

        virtual public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, isoPosition, Color.White);
        }
    }
}
