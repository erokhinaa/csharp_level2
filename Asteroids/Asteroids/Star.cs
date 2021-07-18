using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Asteroids.Properties;

namespace Asteroids
{
    class Star : Asteroid
    {
        public Star (Point pos, Point dir, Size size) : base (pos, dir, size) 
        {

        }

        public override void Draw()
        {
            //Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y + Size.Height);
            //Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X + Size.Width, Pos.Y, Pos.X, Pos.Y + Size.Height);
            Random rnd = new Random();
            int i = rnd.Next(1, 3);
            switch (i)
            {
                case 1:
                    Game.Buffer.Graphics.DrawImage(new Bitmap(Resources.star1, Size.Width, Size.Height), new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height));
                    break;
                case 2:
                    Game.Buffer.Graphics.DrawImage(new Bitmap(Resources.star2, Size.Width, Size.Height), new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height));
                    break;
                case 3:
                    Game.Buffer.Graphics.DrawImage(new Bitmap(Resources.star3, Size.Width, Size.Height), new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height));
                    break;               
            }
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
