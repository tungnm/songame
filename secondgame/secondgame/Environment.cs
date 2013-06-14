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
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Environment : Microsoft.Xna.Framework.DrawableGameComponent
    {
        Texture2D texture;
        EnvirType type;
        SpriteBatch sBatch;
        public Environment(Game game, ref Texture2D theTexture, EnvirType theType)
            : base(game)
        {
            texture = theTexture;
            type = theType;
            sBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
        }
        
  

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            if (type == EnvirType.background)
            {
                sBatch.Draw(texture, new Vector2(0, 0), Color.White);
            }
            base.Draw(gameTime);

        }
    }
}
