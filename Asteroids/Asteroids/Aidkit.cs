using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Asteroids.Properties;

namespace Asteroids
{
    class Aidkit : BaseObject
    {
        //private bool isLarge;
        private int index;
        static Random rnd = new Random();
        public Aidkit(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            index = rnd.Next(1, 2);
        }
        
        public override void Draw()
        {
            //switch (index) Нужно доработать генерацию маленьких аптечек
            //{
            //    case 1:
            //        Game.Buffer.Graphics.DrawImage(new Bitmap(Resources.aidkit_small, Size.Width, Size.Height), new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height));
            //        this.isLarge = false;
            //        break;
            //    case 2:
                    Game.Buffer.Graphics.DrawImage(new Bitmap(Resources.aidkit_large, Size.Width, Size.Height), new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height));
            //        this.isLarge = true;
            //        break;               
            //}
        }

        public override void Update()
        {
            Pos.X += Dir.X;
            Pos.Y += Dir.Y;

            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.X > Game.Width - this.Size.Width) Dir.X = -Dir.X;
            if (Pos.Y > Game.Height - this.Size.Height) Dir.Y = -Dir.Y;
        }
    }
}
