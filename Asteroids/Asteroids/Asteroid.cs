using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Asteroids.Properties;

namespace Asteroids
{
    class Asteroid
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
        
        public Asteroid (Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        public virtual void Draw()
        {
            //Game.Buffer.Graphics.DrawEllipse(Pens.White, Pos.X, Pos.Y, Size.Width, Size.Height);
            Random rnd = new Random();
            int i = rnd.Next(1, 4);
            switch (i)
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

        public virtual void Update()
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
