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

namespace Buuuullet
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Player player;
        ChaseBullet bullet;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            player = new Player(this, spriteBatch);
            player.Sprite = Content.Load<Texture2D>("player");
            player.Speed = 3f;
            player.Scale = 0.5f;
            player.Location = new Vector2(400, 300);
            player.BulletTexture = Content.Load<Texture2D>("playerbullet");
            player.WorldRect = new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height);

            bullet = new ChaseBullet(this, spriteBatch);
            bullet.Sprite = Content.Load<Texture2D>("enemyBullet");
            bullet.Speed = 1f;
            bullet.Torque = 1f;
            bullet.Target = player;
            bullet.Location = new Vector2(100, 100);

            bullet.Initialize();
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            player.Update(gameTime);
            bullet.Update(gameTime);
            Window.Title = $"{bullet.Location.X}, {bullet.Location.Y}, {bullet.Angle}";
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            player.Draw(gameTime);
            bullet.Draw(gameTime);
            spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}
