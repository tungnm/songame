using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
//currrent view
//add scene
//harsh table of class of scene information

namespace secondgame
{
    
    public class Scene
    {
        private int Col;
        private int Row;
        private int eCol;
        private int eRow;
        private String data;
        Texture2D Texture;
        public String[,] field = new String[80 ,60];
        


        public Scene(Texture2D myBackground)
        {
            for (int i = 0; i <= 78; i++)//initialize the field data to empty
             {
                 for(int j = 0 ; j <= 58; j++)
                 {
                     field[i,j] = "empty";
                 }
             }
       
        }
        public void  addMapData(int begRow, int begCol, int endRow, int endCol, String dataType)
        {
            data = dataType;
            Col = begCol;
            Row = begRow;
            eCol = endCol;
            if(eCol == 0)
                eCol = begCol;
            if(eRow == 0)
                eRow = begRow;
            eRow = endRow;
            for(int i = begRow; i <= eRow; i++)
            {
                for(int j = begCol; j <= eCol; j++)
                {
                  // field[i,j] = data;
                }
            }
        }
    }
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>\
    
    public class Environment : Microsoft.Xna.Framework.DrawableGameComponent
    {
        
        String mapName;
        SpriteBatch sBatch;
        Scene myScene;
        String editName;
        Texture2D texture;
        protected Hashtable hashtable = new Hashtable();
        public Environment(Game game, ref Texture2D myTexture)
            : base(game)
        {
            texture = myTexture;
            sBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
        }
        public void addMap(String name, ref Texture2D texture)
        {
            mapName = name;
            myScene = new Scene(texture);
            hashtable.Add(name, myScene);
        }
        public void setMapData(String name, int begRow, int begCol, int endRow, int endCol, String dataType)
        {
            editName = name;
            myScene = (Scene)hashtable[name];
            myScene.addMapData(begRow / 20, begCol / 20, endRow / 20, endCol / 20, dataType);
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
            {
                sBatch.Draw(texture, new Vector2(0, 0), new Rectangle(0, 0, 1024, 768), Color.White, 0f, new Vector2(0, 0), 1.0f,SpriteEffects.None, 1f);
            }
            base.Draw(gameTime);
        }
    }
}
