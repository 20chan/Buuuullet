using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Buuuullet
{
    public class ChaseBullet : Bullet
    {
        public GameObject Target { get; set; }
        public float Torque { get; set; } = 20f;

        private Vector2 _direction;

        public ChaseBullet(Game game, SpriteBatch sb) : base(game, sb)
        {
            
        }

        public override void Initialize()
        {
            _direction = Target.Location - Location;
            base.Initialize();
        }

        public float Angle;
        public override void Move()
        {
            Vector2 vec = Target.Location - Location;
            float lr = Vector2.Dot(Target.Location, vec) > 0 ? -1 : 1;
            float angle = lr * (float)Math.Atan2(vec.X * _direction.Y - _direction.X * vec.Y,
                vec.X * _direction.X + vec.Y * _direction.Y);
            _direction = new Vector2(_direction.X * (float)Math.Cos(angle) - _direction.Y * Torque * (float)Math.Sin(angle),
                _direction.X * Torque * (float)Math.Sin(angle) + _direction.Y * Torque * (float)Math.Cos(angle));
            _direction.Normalize();
            Angle = angle;
            Location += _direction * Speed;

            //HACK: 각이 90도 이상이 되면 미쳐버림!!!
        }
    }
}
