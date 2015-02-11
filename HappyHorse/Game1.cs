#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using MonoGameExtensions;
#endregion

namespace HappyHorse
{

    public class Game1 : Game
    {

        //exclude//
        Texture2D little_box, big_box;
        //////////
        float current = 0;
        KeyboardState oldState;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;
        Texture2D map;
        Player player1 = new Player();
        float Ground = new float();
        float xSpeed = new float(), ySpeed = new float(), gravity = new float();
        String Text;
        Camera camera = new Camera();
        bool jump = new bool();
        int maxjumps = new int(), Njumps = new int();
        Vector2 boxPos;
        Objects obj = new Objects();
        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 1280;
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            
            Window.SetPosition(new Point(30, 30));
            Ground = graphics.PreferredBackBufferHeight - 196-40;
            player1.Position = new Vector2(0, Ground);
            xSpeed = 500; ySpeed = 1000; gravity = 5000;
            Text = "";
            jump = false;
            maxjumps = 2;
            Njumps = 0;
            boxPos = new Vector2(500, Ground + 38);
            camera.Initialize(1280);
            player1.Initialize(player1.Position);

            base.Initialize();
        }


        protected override void LoadContent()
        {
            
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("SpriteFont1");
            map = Content.Load<Texture2D>("Sprites/env_game");
            big_box = Content.Load<Texture2D>("Sprites/big_box");
            little_box = Content.Load<Texture2D>("Sprites/little_box");
            obj.LoadContent(Content);
            player1.LoadContent(Content);
        }

        protected override void UnloadContent()
        {
            
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            
            //Keyboard Events// + //Movement//
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                player1.SpeedX = xSpeed;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                
                player1.SpeedX = (-1)*xSpeed;
            }
            else
            {
                player1.SpeedX = 0;

            }
            //ToggleFullScreen//
            if (Keyboard.GetState().IsKeyDown(Keys.RightAlt) && Keyboard.GetState().IsKeyDown(Keys.Enter)
                && !graphics.IsFullScreen)
            {
                graphics.ToggleFullScreen();
                graphics.ApplyChanges();
                IsMouseVisible = false;
            }
            /////////////////DOUBLE JUMP/////////////////
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Space) && !oldState.IsKeyDown(Keys.Space))
            {
                if (Njumps < maxjumps)
                {
                    jump = true;
                    Njumps++;
                    player1.SpeedY = (-1)*ySpeed;
                }
            }
            oldState = state;
            if(jump)
            {
                player1.SpeedY = player1.SpeedY + gravity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else
            {
                player1.SpeedY = 0;
            }
            player1.positionX = player1.positionX + player1.SpeedX * (float)gameTime.ElapsedGameTime.TotalSeconds;
            player1.positionY = player1.positionY + player1.SpeedY * (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Impulse based physics engine


            if (player1.positionY >= Ground)
            {
                jump = false;
                player1.SpeedY = 0;
                Njumps = 0;
                player1.positionY = Ground;
            }
            if (player1.positionX <= 0)
                player1.positionX = 0;
            if (player1.positionX >= 8192 - 50)
                player1.positionX = 8192 - 50;
            Text = "Viteza curenta: " + Convert.ToString(Math.Abs(player1.SpeedX))+" unitati";
            
            player1.Update(gameTime,player1.Position,player1.SpeedX, 35000/xSpeed);
            obj.Update(player1.Position, player1.width, player1.height);
            if (obj.getMulti > current)
            {
                xSpeed += obj.getMulti * 30;
                current = obj.getMulti;
            }
            camera.Update(player1.Position);
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.Deferred,BlendState.AlphaBlend,null,null,null,null,camera.getViewMatrix);
            spriteBatch.Draw(map, new Vector2(0, -168), Color.White);
            //spriteBatch.Draw(big_box, boxPos, Color.White);
            //spriteBatch.Draw(little_box, new Vector2(450, Ground+119), Color.White);
            obj.Draw(spriteBatch);
            player1.Draw(spriteBatch);
            spriteBatch.End();
            spriteBatch.Begin();
            spriteBatch.DrawString(font,Text, new Vector2(0, Ground+215), Color.Navy);
            spriteBatch.End();
            

            base.Draw(gameTime);
        }
    }
}
