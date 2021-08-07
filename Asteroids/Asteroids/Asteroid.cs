using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Asteroids.Properties;

namespace Asteroids
{
    class Asteroid : BaseObject
    {
        private int _Default = 5;
        private int index;
        static Random rnd = new Random();
                
        public Asteroid (Point pos, Point dir, Size size) : base (pos, dir, size)
        {
            index = rnd.Next(1, 4);
        }
        public int Default
        {
            get { return _Default; }            
        }
        override public void Draw()
        {
            //Game.Buffer.Graphics.DrawEllipse(Pens.White, Pos.X, Pos.Y, Size.Width, Size.Height);
            switch (index)
            {
            case 1:
                Game.Buffer.Graphics.DrawImage(new Bitmap(Resources.meteorBrown_big1, Size.Width, Size.Height), new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height));
                break;
            case 2:
                Game.Buffer.Graphics.DrawImage(new Bitmap(Resources.meteorBrown_big2, Size.Width, Size.Height), new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height));
                break;
            case 3:
                Game.Buffer.Graphics.DrawImage(new Bitmap(Resources.meteorBrown_big3, Size.Width, Size.Height), new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height));
                break;
            case 4:
                Game.Buffer.Graphics.DrawImage(new Bitmap(Resources.meteorBrown_big4, Size.Width, Size.Height), new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height));
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
