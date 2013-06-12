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
    /// This is a game component that implements IUpdateable.
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
        int current;
        public Player(Game game, ref AnimatedTexture theplayer)
            : base(game)
        {
            count = 0;
            player = theplayer;
            texture = player.returnTexture();
            sBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
            move = Move.stand;
            player.getBeginCol(0);
            player.getBeginRow(spriteHeight * 2);
            player.getRange(spriteWidth);
            //height: 150
            //length: 104
            // TODO: Construct any child components here
        }
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            count++;
            current = player.getCurrent();
            keyboard = Keyboard.GetState();
            if(keyboard.IsKeyDown(Keys.Left))
            {
                move = Move.left;
            }
            else if (keyboard.IsKeyDown(Keys.Right))
            {
                move = Move.right;
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
                    player.getActionRow(0);
                    player.getBeginCol(0);
                }
                else if (move == Move.left)
                {
                    player.play();
                    player.getActionRow(spriteHeight);
                    player.getBeginCol(spriteWidth);
                }
                else if(move == Move.stand)
                {
                    player.stop();
                }
                count = 0;
            }
            
            base.Update(gameTime);

            spriteRectangle = new Rectangle((int)player.Rectangle().X, (int)player.Rectangle().Y, spriteWidth, spriteHeight);
        }
        public override void Draw(GameTime gameTime)
        {
            sBatch.Draw(texture, new Vector2(100, 600), spriteRectangle, Color.White);
            base.Draw(gameTime);
        }
    }
}
