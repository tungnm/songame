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
    public enum Move {left,stand, right, up};
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
        const int spriteHeight = 150;
        const int spriteWidth = 104;
        Move move;
        int count;
        AnimatedTexture player;
        SpriteMovement movement;

        public Player(Game game, ref AnimatedTexture theplayer, SpriteMovement theMovement)
            : base(game)
        {
            count = 0;
            player = theplayer;
            movement = theMovement;
            texture = player.getTexture();
            sBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
            move = Move.stand;
            movement.spriteJump(new Vector2(0, -5), 2, 20);
            // TODO: Construct any child components here
        }
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            count++;
            keyboard = Keyboard.GetState();
            if(keyboard.IsKeyDown(Keys.Left))
            {
                move = Move.left;
            }
            else if (keyboard.IsKeyDown(Keys.Right))
            {
                move = Move.right;
            }
            else if (keyboard.IsKeyDown(Keys.Up))
            {
                move = Move.up;
            }
            else
            {
                move = Move.stand;
            }
            if (count == 20)
            {
                if (move == Move.right)
                {
                    player.play();
                    player.setAction(0);
                    player.setBeginCol(0);
                    movement.play();
                    movement.setVelocity(new Vector2(3, 0));
                }
                else if (move == Move.left) 
                {
                    player.play();
                    player.setAction(1);
                    player.setBeginCol(spriteWidth);
                    movement.play();
                    movement.setVelocity(new Vector2(-3, 0));
                }
                else if (move == Move.up)
                {
                    movement.playJump();
                }
                else if (move == Move.stand)
                {
                    player.stop();
                    movement.stop();
                }
                count = 0;
            }
            
            base.Update(gameTime);
            position = new Vector2(movement.getPosition().X, movement.getPosition().Y);
            spriteRectangle = new Rectangle((int)player.getRectangle().X, (int)player.getRectangle().Y, spriteWidth, spriteHeight);
        }
        public override void Draw(GameTime gameTime)
        {
            sBatch.Draw(texture, position, spriteRectangle, Color.White);
            base.Draw(gameTime);
        }
    }
}
