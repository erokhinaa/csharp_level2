using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Asteroids.Properties;

namespace Asteroids
{
    class Star : BaseObject
    {
        private int index;
        static Random rnd = new Random();
        public Star (Point pos, Point dir, Size size) : base (pos, dir, size) 
        {
            index = rnd.Next(1, 3);
        }

        public override void Draw()
        {
            //Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y + Size.Height);
            //Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X + Size.Width, Pos.Y, Pos.X, Pos.Y + Size.Height);
            switch (index)
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
            if (Pos.X > Game.Width  - this.Size.Width)  Dir.X = -Dir.X;
            if (Pos.Y > Game.Height - this.Size.Height) Dir.Y = -Dir.Y;
        }

    }
}
