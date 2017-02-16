using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Buuuullet
{
    public class Player : GameObject
    {
        public Texture2D BulletTexture { get; set; }

        public Rectangle WorldRect { get; set; }
        public List<PlayerBullet> Bullets;

        public float Speed { get; set; } = 1f;

        public Player(Game game, SpriteBatch sb) : base(game, sb)
        {
            Bullets = new List<PlayerBullet>();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            float x = 0, y = 0, spd = Speed;
            if (Keyboard.GetState().IsKeyDown(Keys.W))
                y -= 1;
            if (Keyboard.GetState().IsKeyDown(Keys.S))
                y += 1;
            if (Keyboard.GetState().IsKeyDown(Keys.A))
                x -= 1;
            if (Keyboard.GetState().IsKeyDown(Keys.D))
                x += 1;

            if (Keyboard.GetState().IsKeyDown(Keys.LeftShift))
                spd *= 0.5f;
            else if (Keyboard.GetState().IsKeyDown(Keys.LeftControl))
                spd *= 1.5f;

            MoveTo(x, y, spd);

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                Shoot();

            for(int i = Bullets.Count - 1; i >= 0; i--)
            {
                Bullets[i].Update(gameTime);

                if (!WorldRect.Intersects(Bullets[i].Rect))
                {
                    Bullets[i].Dispose();
                    Bullets.RemoveAt(i);
                }
            }
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (Bullet b in Bullets)
                b.Draw(gameTime);
            base.Draw(gameTime);
        }

        public void MoveTo(float x, float y, float speed)
        {
            Location = new Vector2(Location.X + x * speed, Location.Y + y * speed);
        }

        public void Shoot()
        {
            PlayerBullet b = new PlayerBullet(Game, SpriteBatch, this);
            b.Sprite = BulletTexture;
            b.Speed = 5f;
            b.Location = Location;
            Bullets.Add(b);
        }
    }
}
