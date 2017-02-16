using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Buuuullet
{
    public class GameObject : DrawableGameComponent
    {
        public Texture2D Sprite { get; set; }
        public Vector2 Location { get; set; }
        public float Rotation { get; set; }
        public float Scale { get; set; } = 1f;
        public Rectangle Rect 
            => new Rectangle((int)Location.X, (int)Location.Y, 
                (int)(Sprite.Width * Scale), (int)(Sprite.Height * Scale));

        public Vector2 Origin
            => new Vector2(Rect.Width / 2, Rect.Height / 2);

        public SpriteBatch SpriteBatch { get; set; }

        public GameObject(Game game, SpriteBatch sb) : base(game)
        {
            SpriteBatch = sb;
        }

        public bool IsCollided(GameObject obj)
        {
            return Rect.Intersects(obj.Rect);
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Draw(Sprite, Rect, null, Color.White, Rotation, Origin, SpriteEffects.None, 0f);
            base.Draw(gameTime);
        }
    }
}
