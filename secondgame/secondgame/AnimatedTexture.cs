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
        int myFrameRange;
        int count;
        int frameNum;
        int updateCol;
        int updateRow;
        int rowLength;
        Texture2D texture;
        Boolean isStop;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="game">the game</param>
        /// <param name="theTexture">texture</param>
        /// <param name="frame">number of frame in each action</param>
        /// <param name="beginRow">the beginning frame row</param>
        /// <param name="beginCol">the beginning frame collum</param>
        /// <param name="beginActionRow">the beginning action row</param>
        /// <param name="actionRowRange">the range between each action</param>
        public AnimatedTexture(Game game, Texture2D theTexture, int frame, int beginRow, int beginCol, int beginActionRow,int beginActionCol, int actionRowRange, int frameRange)
            : base(game)
        {
            count = 0;
            frameNum = frame;
            texture = theTexture;
            isStop = true;
            BegRow = beginRow;
            BegCol = beginCol;
            updateRow = BegRow ;
            updateCol = BegCol ;
            AcRow = beginActionRow;
            originAcRow = beginActionRow;
            AcCol = beginActionCol;
            originAcCol = beginActionCol;
            rowLength = actionRowRange;
            myFrameRange = frameRange;
            // TODO: Construct any child components here
        }
        public void setAction(int action)
        {
            AcRow = action*rowLength;
            originAcRow = action * rowLength;
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
        public Vector2 getRectangle()
        {
            return new Vector2(updateCol, updateRow);
        }
        /// <summary>
        /// return the texture 2D
        /// </summary>
        /// <returns></returns>
        public Texture2D getTexture()
        {
            return texture;
        }
        /// <summary>
        /// get the current frame
        /// </summary>
        /// <returns></returns>
        public void setBeginRow(int row)
        {
            BegRow = row;
        }
        public void setBeginCol(int col)
        {
            BegCol = col;
        }
        public override void Update(GameTime gameTime)
        {
            updateCol = BegCol;
            updateRow = BegRow;
            count++;
            if (isStop == false)
            {
                updateRow = AcRow;
                updateCol = AcCol;
                if (count == 10)
                {
                    if (AcCol < (frameNum-1)*myFrameRange)
                    {
                        AcCol+=myFrameRange;
                        count = 0;
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