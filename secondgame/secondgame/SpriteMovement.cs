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
    public class SpriteMovement : Microsoft.Xna.Framework.GameComponent
    {
        Vector2 position;
        Vector2 speed;
        Boolean isStop;
        /// <summary>
        /// allow the sprite to move
        /// </summary>
        /// <param name="game"></param>
        /// <param name="beginPos">the beginning position of the sprite</param>
        public SpriteMovement(Game game, Vector2 beginPos)
            : base(game)
        {
            position = beginPos;
            isStop = true;
        }
        public void setVelocity(Vector2 theSpeed)
        {
            speed = theSpeed;
        }
        public void stop()
        {
            isStop = true;
        }
        public void play()
        {
            isStop = false;
        }
        public Vector2 getPosition()
        {
            return position;
        }

        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            if (isStop == false)
            {
              
                    position.X = position.X + speed.X;
                    position.Y = position.Y + speed.Y;
            }
            base.Update(gameTime);
        }
    }
}
