using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
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
    /// hasrh table if action
    /// return rectangle
    /// 
    public class textureAction
    {      
        public int nFrame;
        public int range;
        public int Row;
        public int Col;
        public bool requireFinish;
        public int height;
        public textureAction(int frame, int row, int col, int Range, int frameHeight, Boolean finish)
        {
            nFrame = frame;
            Row = row;
            Col = col;
            range = Range;
            requireFinish = finish;
            height = frameHeight;
        }
    }

    public class AnimatedTexture : Microsoft.Xna.Framework.GameComponent
    {
        protected Texture2D texture;
        protected Hashtable hashtable = new Hashtable();
        protected textureAction tact;
        protected Boolean isStop;
        protected String action;
        protected textureAction currentAction;
        protected int count;
        protected int originCol;
        protected int currentFrame;
        protected int currentX;
        protected int currentY;
        protected Boolean playAgain;
        protected String lastAction;
        protected Boolean isFinish;

        public AnimatedTexture(Game game, ref Texture2D theTexture)
            : base(game)
        {
            texture = theTexture;
            count = 0;
            currentFrame = 0;
            // TODO: Construct any child components here
        }
        public Texture2D getTexture()
        {
            return texture;
        }
        /// <summary>
        /// input all the actions in the sprite by providing these information
        /// </summary>
        /// <param name="name">name of the action</param>
        /// <param name="nFrame">number of frames</param>
        /// <param name="Row">row position</param>
        /// <param name="Col">collum position</param>
        /// <param name="range"> distance between frame</param>
        public void addAction(String name, int nFrame, int Row, int Col,int range, int height, Boolean finish)
        {
            tact = new textureAction(nFrame, Row, Col, range, height, finish);
            action = name;
            hashtable.Add(action, tact);//implement the action into harshtable
        }
        public void setDefaultAction(String defaultAct)
        {
            currentAction = (textureAction)hashtable[action];
        }
        public void play(String theAction)
        {
            isStop = false;
            action = theAction;
            if (lastAction != theAction)
            {
                if (currentAction.requireFinish == true)
                {
                    if (isFinish == true)
                    {
                        currentAction = (textureAction)hashtable[action];
                        originCol = currentAction.Col;
                        currentX = currentAction.Col;
                        lastAction = theAction;
                    }
                }
                else
                {
                    currentAction = (textureAction)hashtable[action];
                    originCol = currentAction.Col;
                    currentX = currentAction.Col;
                    lastAction = theAction;
                }
            }
            isFinish = false;
            System.Console.Write("\nReset Current Frame!!!");
            System.Console.Write("origin Colum is"+ originCol.ToString());
            //isFinish = false;
        }
        public void stop()
        {
            isStop = true;
        }
        public Vector2 getRectangle()
        {
            return new Vector2(currentAction.Row, currentX);
        }
        public Boolean finish()
        {
            return isFinish;
        }
        public int getSpriteHeight()
        {
            return currentAction.height;
        }
        public int getRange()
        {
            return currentAction.range;
        }
        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            count++;
            //limiy update to 1 every 20 frame
            if (count == 5)
            {
                System.Console.Write("\ncurrentFrame is:"+ currentFrame.ToString());
                System.Console.Write("\ncurrent Action size is:" + currentAction.nFrame.ToString());
                if (isStop == false)
                {
                    currentFrame++;
                    if (currentFrame < currentAction.nFrame)
                    {
                        currentX += currentAction.range;
                    }
                    else
                    {
                        isFinish = true;
                        currentFrame = 0;
                       currentX = originCol;
                    }
                }
                else
                {
                    currentX= originCol;
                }
                
                count = 0;
            }
            // TODO: Add your update code here

            base.Update(gameTime);
        }
    }
}
