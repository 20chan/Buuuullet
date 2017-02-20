using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Buuuullet
{
    public class World : DrawableGameComponent
    {
        public Player Player;
        
        public World(Game game) : base(game)
        {

        }
    }
}
