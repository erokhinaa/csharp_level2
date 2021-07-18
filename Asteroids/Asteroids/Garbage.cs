using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Asteroids.Properties;

namespace Asteroids
{
    class Garbage : Asteroid
    {
        public Garbage(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }
        public override void Draw()
        {
            //Game.Buffer.Graphics.DrawRectangle(Pens.White, Pos.X, Pos.Y, Size.Width, Size.Height);
            //Resources.garbage_bottle.MakeTransparent(Color.White);
            Game.Buffer.Graphics.DrawImage(new Bitmap(Resources.garbage_bottle, Size.Width, Size.Height), new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height));
            
        }

        public override void Update()
        {
            Pos.X += Dir.X;
            Pos.Y += Dir.Y;

            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.X > Game.Width) Dir.X = -Dir.X;
            if (Pos.Y > Game.Heigth) Dir.Y = -Dir.Y;
        }
    }
}
