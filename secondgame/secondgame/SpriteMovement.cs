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
        Boolean isJump;
        Vector2 jump;
        int velocity;
        int mass;
        int jumpRange;
        int maxJumpRange;
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
            jumpRange = 0;
            isJump = false;
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
        public void playJump()
        {
            isJump = true;
        }
        /// <summary>
        /// allow the sprite to jump
        /// </summary>
        /// <param name="jump">the jumping direction + velocity</param>
        /// <param name="mass">weight</param>
        /// <param name="theJumpRange">jumping range</param>
        public void spriteJump(Vector2 theJump, int theMass, int theJumpRange)
        {
            jump = theJump;
            mass = theMass;
            maxJumpRange = theJumpRange;
        }
        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            if (isStop == false)
            {
                if (isJump == true)
                {
                    velocity = (int)jump.Y -mass;
                    if (jumpRange < maxJumpRange / 2)
                    {
                        
                        position.X = (position.X + jump.X) / 2;
                        position.Y = position.Y + velocity + speed.Y;
                        jumpRange = jumpRange + velocity;
                    }
                    else if(jumpRange >= maxJumpRange/2)
                    {
                        velocity = velocity - velocity/maxJumpRange;
                        position.X = (position.X + jump.X ) / 2;
                        position.Y = position.Y + velocity;
                        if (velocity >= 0)
                        {
                            jumpRange = jumpRange + velocity;
                        }
                        else
                        {
                            jumpRange = jumpRange - velocity;
                        }
                    }
                    if (jumpRange == maxJumpRange * 2)
                    {
                        velocity = 0;
                        isJump = false;
                    }

                }
                else
                {
                    position.X = position.X + speed.X;
                    position.Y = position.Y + speed.Y;
                }
            }
            base.Update(gameTime);
        }
    }
}
