using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Asteroids.Properties;

namespace Asteroids
{
    static class Game
    {
        private static BufferedGraphicsContext context;
        public static BufferedGraphics Buffer;

        public static int Width { get; set; }
        public static int Heigth { get; set; }
        static BaseObject[] asteroids;
        static BaseObject[] stars;
        static BaseObject[] garbage;
        static Bullet bullet;

        public static void Init(Form form)
        {
            context = BufferedGraphicsManager.Current;
            Graphics g = form.CreateGraphics();
                        
            Width  = form.ClientSize.Width;
            Heigth = form.ClientSize.Height;           

            if (Width > 0 && Width < 1000)
                Width = Width;            
            else
                throw new ArgumentOutOfRangeException("Width", "Width must be between 0 and 1000");
            if (Heigth > 0 && Heigth < 1000)
                Heigth = Heigth;            
            else
                throw new ArgumentOutOfRangeException("Heigth", "Heigth must be between 0 and 1000");

            Buffer = context.Allocate(g, new Rectangle(0, 0, Width, Heigth));

            Load();

            Timer timer = new Timer();
            timer.Interval = 60;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Update();
            Draw();
        }
        public static void Draw()
        {
            //Buffer.Graphics.Clear(Color.Black);
            Buffer.Graphics.DrawImage(new Bitmap(Resources.background, Width, Heigth), new Rectangle(0, 0, 800, 600));

            //Buffer.Graphics.FillEllipse(Brushes.Red, new Rectangle(100, 100, 200, 200));
            Buffer.Graphics.DrawImage(new Bitmap(Resources.planet, Width, Heigth), new Rectangle(100, 100, 200, 200));

            foreach (BaseObject asteroid in asteroids)
            {
                if (asteroid == null) continue; 
                asteroid.Draw();
            }
            foreach (BaseObject star in stars)
            {
                star.Draw();
            }
            foreach(BaseObject gb in garbage)
            {
                gb.Draw();
            }

            bullet.Draw();
            
            Buffer.Render();
        }

        public static void Update()
        {
            Random rnd = new Random();
            int r = 0;
            for (int i = 0; i < asteroids.Length; i++)
            {
                r = rnd.Next(10, 200);

                if (asteroids[i] == null) continue;

                asteroids[i].Update();

                if (bullet != null && asteroids[i].Collision(bullet))
                {
                    System.Media.SystemSounds.Hand.Play();
                    asteroids[i] = null;
                    bullet = null;
                    bullet = new Bullet(new Point(0, r), new Point(35, 0), new Size(54, 9));
                    //continue;
                }                
                else bullet.Update();
                                
            }

            foreach (BaseObject star in stars)
            {
                star.Update();
            }

            foreach (BaseObject gb in garbage)
            {
                gb.Update();
            }

            bullet.Update();                    
        }

        public static void Load()
        {
            Random gen = new Random();
            int rnd = 0;
            var random = new Random();
            asteroids = new BaseObject[10];
            for (int i = 1; i <= asteroids.Length; i++)
            {
                rnd = gen.Next(i, asteroids.Length);
                var size = random.Next(10, 40);
                asteroids[i-1] = new Asteroid(new Point(600, i * 20 + 5), new Point(rnd, rnd), new Size(size, size));
            }
            
            stars = new BaseObject[20];
            for (int i = 1; i <= stars.Length; i++)
            {
                rnd = gen.Next(i, stars.Length);
                stars[i-1] = new Star(new Point(600, i * 40 + 5), new Point(-rnd, -rnd), new Size(4, 4));
            }

            garbage = new BaseObject[2];
            for (int i = 1; i <= garbage.Length; i++)
            {
                rnd = gen.Next(i, garbage.Length);
                garbage[i-1] = new Garbage(new Point(600, i * 30 + 5), new Point(rnd, rnd), new Size(36, 36));
            }

            bullet = new Bullet(new Point(0, 200), new Point(35, 0), new Size(54,9));
        }

    }
}
