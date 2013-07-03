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

namespace secondgame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public enum EnvirType {background, landobject};
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D backgroundTexture;
        Texture2D playerTexture;
        Environment background;
        Player man;
        AnimatedTexture manTexture;
        SpriteMovement manMove;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 768;
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

            base.Initialize();
            Window.Title="My Game";
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Services.AddService(typeof(SpriteBatch), spriteBatch);
            backgroundTexture = Content.Load<Texture2D>("battlecity");
            playerTexture = Content.Load<Texture2D>("zerox4");
            background = new Environment(this,ref backgroundTexture);
            background.addMap("map1", ref backgroundTexture);
            background.setMapData("map1", 760, 0, 780, 1300, "land");

            background.setMapData("map1", 960, 1280, 960, 1400, "land");
            background.setMapData("map1", 900, 1380, 900, 1480, "land");
            manTexture = new AnimatedTexture(this, ref playerTexture);
            //add all the action contained inside the sprite with details
            manTexture.addAction("stand", 4, 5, 5, 45, 50,false);
            manTexture.addAction("move", 14, 225, 90, 50, 50,false);
            manTexture.addAction("slash", 8, 280, 50, 90, 75, true);
            manTexture.addAction("jump", 11, 75, 0, 50, 80, true);
            manMove = new SpriteMovement(this, new Vector2(100,550));
            man = new Player(this, ref manTexture, manMove);
            Components.Add(man);
            Components.Add(manTexture);
            Components.Add(manMove);
            Components.Add(background);
            
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);

            base.Draw(gameTime);
            spriteBatch.End();
        }
    }
}
