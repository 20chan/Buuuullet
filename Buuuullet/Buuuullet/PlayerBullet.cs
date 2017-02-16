using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Buuuullet
{
    public class PlayerBullet : Bullet
    {
        private Player _player;
        public float Speed;
        public PlayerBullet(Game game, SpriteBatch sb, Player player) : base(game, sb)
        {
            this._player = player;
        }

        public override void Update(GameTime gameTime)
        {
            this.Location = new Vector2(Location.X, Location.Y - Speed);
            base.Update(gameTime);
        }
    }
}
