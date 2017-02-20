using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Buuuullet
{
    public abstract class Bullet : GameObject
    {
        public float Speed { get; set; }
        public Bullet(Game game, SpriteBatch sb) : base(game, sb)
        {

        }

        public abstract void Move();

        public override void Update(GameTime gameTime)
        {
            Move();
            base.Update(gameTime);
        }
    }
}
