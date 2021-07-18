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
        static Asteroid[] asteroids;
        static Asteroid[] stars;
        static Asteroid[] garbage;

        public static void Init(Form form)
        {
            context = BufferedGraphicsManager.Current;
            Graphics g = form.CreateGraphics();

            Width = form.ClientSize.Width;
            Heigth = form.ClientSize.Height;
            
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

            foreach (var asteroid in asteroids)
            {
                asteroid.Draw();
            }
            foreach (var star in stars)
            {
                star.Draw();
            }
            foreach(var gb in garbage)
            {
                gb.Draw();
            }

            Buffer.Render();

        }

        public static void Update()
        {
            foreach (var asteroid in asteroids)
            {
                asteroid.Update();
            }
            foreach (var star in stars)
            {
                star.Update();
            }
            foreach (var gb in garbage)
            {
                gb.Update();
            }
        }

        public static void Load()
        {
            Random gen = new Random();
            int rnd = 0;
            var random = new Random();
            asteroids = new Asteroid[10];
            for (int i = 1; i <= asteroids.Length; i++)
            {
                rnd = gen.Next(i, asteroids.Length);
                var size = random.Next(10, 40);
                asteroids[i-1] = new Asteroid(new Point(600, i * 20 + 5), new Point(rnd, rnd), new Size(size, size));
            }
            
            stars = new Asteroid[20];
            for (int i = 1; i <= stars.Length; i++)
            {
                rnd = gen.Next(i, stars.Length);
                stars[i-1] = new Star(new Point(600, i * 40 + 5), new Point(-rnd, -rnd), new Size(4, 4));
            }

            garbage = new Asteroid[2];
            for (int i = 1; i <= garbage.Length; i++)
            {
                rnd = gen.Next(i, garbage.Length);
                garbage[i-1] = new Garbage(new Point(600, i * 30 + 5), new Point(rnd, rnd), new Size(36, 36));
            }
        }

    }
}
