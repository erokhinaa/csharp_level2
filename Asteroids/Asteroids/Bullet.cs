using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Asteroids.Properties;

namespace Asteroids
{
    class Bullet : BaseObject
    {
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size) { }

        public override void Draw() //(Bullet bullet)
        {            
            Game.Buffer.Graphics.DrawImage(new Bitmap(Resources.laserRed011, Size.Width, Size.Height), new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height));            
        }

        public override void Update()
        {
            //if (Pos.X > Game.Width - this.Size.Width + 10)
            //else
                Pos.X += Dir.X;            
        }
    }
}
