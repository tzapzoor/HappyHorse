using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace HappyHorse
{
    public class Objects
    {
        float multiplier = 0;
        public float getMulti
        {
            get { return multiplier; }
            set { multiplier = value; }
        }
        Texture2D greenjem;
        Rectangle[] pos = new Rectangle[]
        {
            new Rectangle(420,350,111,200),
            new Rectangle(540,350,111,200),
            new Rectangle(660,110,111,200),
            new Rectangle(780,110,111,200),
            new Rectangle(900,110,111,200),
            new Rectangle(1010,110,111,200),
            new Rectangle(1724,350,111,200),
            new Rectangle(2858,350,111,200),
            new Rectangle(2978,350,111,200),
            new Rectangle(4800,350,111,200),
            new Rectangle(4910,350,111,200),
            new Rectangle(5020,110,111,200),
            new Rectangle(6300,110,111,200),
            new Rectangle(6420,110,111,200),
            new Rectangle(6540,110,111,200),
            new Rectangle(6660,110,111,200),
            new Rectangle(6780,110,111,200),
            new Rectangle(6900,110,111,200),

        };
        public void LoadContent(ContentManager content)
        {
            greenjem = content.Load<Texture2D>("Sprites/gaz");
        }
        public void Update(Vector2 playerPosition,int width, int height)
        {
            Rectangle posRect = new Rectangle((int)playerPosition.X,(int)playerPosition.Y,233,196);
            for (int i = 0; i < pos.Length; i++)
                if (posRect.Intersects(pos[i]))
                {
                    pos[i] = new Rectangle(0, 0, 0, 0);
                    multiplier++;
                }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            for(int i=0; i<pos.Length;i++)
            spriteBatch.Draw(greenjem, pos[i], Color.White);
        }
    }


}
