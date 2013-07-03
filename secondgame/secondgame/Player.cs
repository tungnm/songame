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
//if falling, check bottom axis, i
// if move left/right check left/right axis
//if jumping, check top axis, if jump + move, then check 2 axis at the same time

namespace secondgame
{
    public enum Move {left,stand, right, up, slash, dash};
    /// <summary>
    /// This class represents a player
    /// </summary>
    
    public class Player : Microsoft.Xna.Framework.DrawableGameComponent
    {
        protected Texture2D texture;
        protected SpriteBatch sBatch;
        protected Vector2 position;
        protected Rectangle spriteRectangle;
        KeyboardState keyboard;
        const int spriteHeightStand = 50;
        const int spriteWidthStand = 50;
        const int spriteHeightMove = 50;
        const int spriteWidthMove = 50;
        const int spriteHeightSlash = 75;
        const int spriteWidthSlash = 90;
        Move move;
        Move lastMove;
        int count;
        AnimatedTexture player;
        SpriteMovement movement;
        Boolean flip;
        public Player(Game game, ref AnimatedTexture theplayer, SpriteMovement theMovement)
            : base(game)
        {
            flip = false;
            count = 0;
            player = theplayer;
            movement = theMovement;
            texture = player.getTexture();
            sBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
            move = Move.stand;
            player.setDefaultAction("stand");
            
            // TODO: Construct any child components here
        }
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            count++;
            
            keyboard = Keyboard.GetState();
            if(keyboard.IsKeyDown(Keys.Left))
            {
                lastMove = move;
                move = Move.left;
            }
            else if (keyboard.IsKeyDown(Keys.Right))
            {
                lastMove = move;
                move = Move.right;
            }
            else if (keyboard.IsKeyDown(Keys.Up))
            {
                move = Move.up;
            }
            else if (keyboard.IsKeyDown(Keys.Z))
            {
                lastMove = move;
                move = Move.slash;
            }
            else
            {
                lastMove = move;
                move = Move.stand;
            }
            if (count ==5)
            {
                if (move == Move.right)
                {
                    player.play("move");
                    flip = false;
                    movement.play();
                    movement.setVelocity(new Vector2(3, 0));
                }
                else if (move == Move.left) 
                {
                    player.play("move");
                    flip = true;
                    movement.play();
                    movement.setVelocity(new Vector2(-3, 0));
                }
                else if (move == Move.up)
                {
                    player.play("jump");
                }
                else if (move == Move.slash)
                {
                    player.play("slash");
                    movement.stop();
                }
                else if (move == Move.stand)
                {
                    player.play("stand");
                    movement.stop();
                }
                count = 0;
                
            }
          
            base.Update(gameTime);
            position = new Vector2(movement.getPosition().X, movement.getPosition().Y);
            spriteRectangle = new Rectangle((int)player.getRectangle().Y, (int)player.getRectangle().X, (int)player.getRange(), (int)player.getSpriteHeight());
        }
        public override void Draw(GameTime gameTime)
        {
            System.Console.Write("\n flip = :" + flip.ToString());
            if(flip == false)
                sBatch.Draw(texture, position, spriteRectangle, Color.White, 0f, new Vector2(0f, 0f), 1.5f, SpriteEffects.None,0f);
            else
               
                sBatch.Draw(texture, position , spriteRectangle, Color.White,0f, new Vector2(0f,0f),1.5f,SpriteEffects.FlipHorizontally, 0f);
            base.Draw(gameTime);
        }
    }
}
