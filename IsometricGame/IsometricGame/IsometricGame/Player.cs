﻿using System;
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
    class Player: GameObject
    {
        Sprite sprite;

        public Player(Sprite sprite, Vector2 position)
        {
            this.sprite = sprite;
            this.position = position;
        }
    }
}
