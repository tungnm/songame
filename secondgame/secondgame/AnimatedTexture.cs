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
    public class AnimatedTexture : Microsoft.Xna.Framework.GameComponent
    {
        int BegRow;
        int originAcRow;
        int originAcCol;
        int BegCol;
        int AcRow;
        int AcCol;
        int myRange;
        int count;
        int frameNum;
        int updateCol;
        int updateRow;
        Texture2D texture;
        Boolean isStop;
        public AnimatedTexture(Game game, Texture2D theTexture, int frame)
            : base(game)
        {
            count = 0;
            frameNum = frame;
            texture = theTexture;
            isStop = true;
            updateRow = BegRow ;
            updateCol = BegCol ;
            // TODO: Construct any child components here
        }
        /// <summary>
        /// get the beginning action row
        /// </summary>
        /// <param name="theRow"></param>
        public void getBeginRow(int theRow)
        {
            BegRow = theRow;
        }
        /// <summary>
        /// get the beginning collum of the sprite
        /// </summary>
        /// <param name="theCol"></param>
        public void getBeginCol(int theCol)
        {
            BegCol = theCol;
        }
        /// <summary>
        /// get the action collum
        /// </summary>
        /// <param name="theCol"></param>
        public void getActionCol(int theCol)
        {
            AcCol = theCol;
            originAcCol = theCol;
        }
        /// <summary>
        /// get the range between frame
        /// </summary>
        /// <param name="range"></param>
        public void getRange(int range)
        {
           myRange  = range;
        }
        /// <summary>
        /// get tthe action Row
        /// </summary>
        /// <param name="theRow"></param>
        public void getActionRow(int theRow)
        {
            AcRow = theRow;
            originAcRow = theRow;
        }
        /// <summary>
        /// stop the action
        /// </summary>
        public void stop()
        {
            isStop = true;
        }
        /// <summary>
        /// play the action
        /// </summary>
        public void play()
        {
            isStop = false;
        }
        /// <summary>
        /// return the vector2 of source Rectangle
        /// </summary>
        /// <returns></returns>
        public Vector2 Rectangle()
        {
            return new Vector2(updateCol, updateRow);
        }
        /// <summary>
        /// return the texture 2D
        /// </summary>
        /// <returns></returns>
        public Texture2D returnTexture()
        {
            return texture;
        }
        /// <summary>
        /// get the current frame
        /// </summary>
        /// <returns></returns>
        public int getCurrent()
        {
            return updateCol/myRange;
        }
        public override void Initialize()
        {
            base.Initialize();
        }
        public override void Update(GameTime gameTime)
        {
            int x = 0;
            updateCol = BegCol;
            updateRow = BegRow;
            count++;
            if (isStop == false)
            {
                updateRow = AcRow;
                updateCol = AcCol;
                if (count == 10)
                {
                    if (AcCol < (frameNum-1)*myRange)
                    {
                        AcCol+=myRange;
                        count = 0;
                        updateRow = AcRow;
                        updateCol = AcCol;
                    }
                    else
                    {
                        AcRow = originAcRow;
                        AcCol = originAcCol;
                        updateRow = AcRow;
                        updateCol = AcCol;
                        count = 0;
                    }
                }
            }
            else
            {
                updateRow = BegRow;
                updateCol = BegCol;
                count = 0;
            }

            base.Update(gameTime);
        }
    }
}