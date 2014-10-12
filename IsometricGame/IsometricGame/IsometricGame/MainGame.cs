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
    public class MainGame : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Game states
        public enum GameStates {TitleScreen, InstructionPage, Playing, GameOver, GameWin};
        public static GameStates gameState;

        //create a sprite dictionary
        public Dictionary<string, Sprite> spriteDictionary = new Dictionary<string,Sprite>();

        //Tile and mapping
        public enum mapTiles {walkable, horizontalWallBottom, horizontalWallTop, verticalWallBottom, verticalWallTop, topLeftCorner, bottomLeftCorner, topRightCorner, bottomRightCorner};
        Texture2D mapTile0, mapTile1, mapTile2, mapTile3, mapTile4, mapTile5, mapTile6, mapTile7, mapTile8;
        public int[,] map;
        public const int mapWidth = 5, mapHeight = 6;
        public Tile[,] tileMap = new Tile[mapWidth,mapHeight];

        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            //create maps
            map = new int[,] {{5,2,2,2,2,7},
                              {4,0,0,0,0,3},
                              {4,0,0,0,0,3},
                              {4,0,0,0,0,3},
                              {6,1,1,1,1,8}};

            

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //starts the game at the title screen
            gameState = GameStates.TitleScreen;

            //loads environment tiles and adds them to the spriteDictionary
            spriteDictionary["mapTile0"] = new Sprite(Content.Load<Texture2D>("MapTiles\\mt0"));
            spriteDictionary["mapTile1"] = new Sprite(Content.Load<Texture2D>("MapTiles\\mt1"));
            spriteDictionary["mapTile2"] = new Sprite(Content.Load<Texture2D>("MapTiles\\mt2"));
            spriteDictionary["mapTile3"] = new Sprite(Content.Load<Texture2D>("MapTiles\\mt3"));
            spriteDictionary["mapTile4"] = new Sprite(Content.Load<Texture2D>("MapTiles\\mt4"));
            spriteDictionary["mapTile5"] = new Sprite(Content.Load<Texture2D>("MapTiles\\mt5"));
            spriteDictionary["mapTile6"] = new Sprite(Content.Load<Texture2D>("MapTiles\\mt6"));
            spriteDictionary["mapTile7"] = new Sprite(Content.Load<Texture2D>("MapTiles\\mt7"));
            spriteDictionary["mapTile8"] = new Sprite(Content.Load<Texture2D>("MapTiles\\mt8"));

            CreateMap(map, spriteDictionary);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();
            KeyboardState keyboard = Keyboard.GetState();

            switch (gameState)
            {
                case GameStates.TitleScreen:
                    //TODO: display title screen

                    if (mouse.LeftButton == ButtonState.Pressed)
                    {
                        //game begins
                        gameState = GameStates.Playing;
                    }
                    if (keyboard.IsKeyDown(Keys.I))
                    {
                        //displays instructions
                        gameState = GameStates.InstructionPage;
                    }
                    break;
                case GameStates.InstructionPage:
                    if (mouse.LeftButton == ButtonState.Pressed)
                    {
                    }
                    break;
                case GameStates.Playing:
                    if (keyboard.IsKeyDown(Keys.W))
                    {
                        //Player moves up
                    }
                    if (keyboard.IsKeyDown(Keys.A))
                    {
                        //Player moves left
                    }
                    if (keyboard.IsKeyDown(Keys.S))
                    {
                        //Player moves down
                    }
                    if (keyboard.IsKeyDown(Keys.D))
                    {
                        //Player moves right
                    }
                    if (mouse.LeftButton == ButtonState.Pressed)
                    {
                        //pick up item
                        //TODO make item disappear, switch player sprite,
                        //set boolean to has object to allow item use
                    }
                    break;
                case GameStates.GameOver:
                    break;
                case GameStates.GameWin:
                    break;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //Draws the map
            foreach (Tile tile in tileMap)
                tile.Draw(spriteBatch);
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
        
        public void CreateMap(int[,] map, Dictionary<string, Sprite> spriteDictionary)
        {
            Sprite tileSprite;
            for(int i = 0; i < mapWidth; ++i)
            {
                for (int j = 0; j < mapHeight; j++)
                {
                    int tile = map[i,j];
                    switch(tile)
                    {
                        case 0:
                            tileSprite = spriteDictionary["mapTile0"];
                            break;
                        case 1:
                            tileSprite = spriteDictionary["mapTile1"];
                            break;
                        case 2:
                            tileSprite = spriteDictionary["mapTile2"];
                            break;
                        case 3:
                            tileSprite = spriteDictionary["mapTile3"];
                            break;
                        case 4:
                            tileSprite = spriteDictionary["mapTile4"];
                            break;
                        case 5:
                            tileSprite = spriteDictionary["mapTile5"];
                            break;
                        case 6:
                            tileSprite = spriteDictionary["mapTile6"];
                            break;
                        case 7:
                            tileSprite = spriteDictionary["mapTile7"];
                            break;
                        case 8:
                            tileSprite = spriteDictionary["mapTile8"];
                            break;
                        default:
                            tileSprite = spriteDictionary["mapTile0"];
                            break;
                    }
                    tileMap[i,j] = new Tile(tileSprite, new Vector2(j * tileSprite.Width, i * tileSprite.Height));
                }
            }
        }
    }
}
