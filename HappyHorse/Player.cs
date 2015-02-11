using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
namespace HappyHorse
{
    public class Player
    {
        Rectangle sourceRect;
        Animation anim = new Animation();
        Vector2 position,speed;
        Texture2D player;
        int Fwidth = new int(), Fheight = new int();
        System.TimeSpan TargetElapsedTime = new System.TimeSpan();
        int LR = 1;
        public int width
        {
            get { return player.Width; }
        }
        public int height
        {
            get { return player.Height; }
        }
        public float positionX
        {
            get { return position.X; }
            set { position.X = value; }
        }
        public float positionY
        {
            get { return position.Y; }
            set { position.Y = value; }
        }
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        public float SpeedX
        {
            get { return speed.X; }
            set { speed.X = value; }
        }
        public float SpeedY
        {
            get { return speed.Y; }
            set { speed.Y = value; }
        }
        public Vector2 Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public void Initialize(Vector2 playerPosition)
        {
            Fwidth = 233;
            Fheight = 196;
            position = playerPosition;
            speed = new Vector2(0, 0);
            TargetElapsedTime = TimeSpan.FromSeconds(1 / 30.0);
            sourceRect = new Rectangle(0, 0, Fwidth, Fheight);
        }

        public void LoadContent(ContentManager Content)
        {
            player = Content.Load<Texture2D>("Sprites/Retardedsheet");
        }

        public void Update(GameTime gameTime, Vector2 playerPosition,float Speed, double timeperframe)
        {
            float elapsed = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            anim.UpdateFrame(elapsed,Speed,timeperframe);
            position = playerPosition;
            if (Speed > 0)
                LR = 1;
            else if(Speed<0)
                LR = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            sourceRect = new Rectangle(Fwidth*anim.getFrame, Fheight*LR, Fwidth, Fheight);
            spriteBatch.Draw(player, position, sourceRect, Color.White);

        }

    }
}
