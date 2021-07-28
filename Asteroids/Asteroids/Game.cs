using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Asteroids.Properties;
using System.IO;

namespace Asteroids
{
    static class Game
    {
        private static BufferedGraphicsContext context;
        public static BufferedGraphics Buffer;
        static Timer timer;
        public static int Width { get; set; }
        public static int Heigth { get; set; }
        static BaseObject[] asteroids;
        static BaseObject[] stars;
        static BaseObject[] garbage;
        static BaseObject[] aidkit;
        static Bullet bullet;
        static Ship ship;        
        public static Log log;
        public delegate void DLog (string s);
        public static StreamWriter f;        

        public static void Init(Form form)
        {
            log = new Log();
            DLog dlog = log.ConsoleWriteLog;
            dlog("Start logging");
            StreamWriter f = new StreamWriter(new FileStream(AppDomain.CurrentDomain.BaseDirectory + "log.txt", FileMode.Create, FileAccess.Write));
            f.WriteLine("Start logging");
            f.Close();

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

            form.KeyDown += OnFormKeyDown;
            timer = new Timer { Interval = 60 };
            timer.Tick += Timer_Tick;
            timer.Start();            

        }

        private static void OnFormKeyDown(object sender, KeyEventArgs e)
        {
            // Управление в игре
            if (e.KeyCode == Keys.Up)   ship.Up();
            if (e.KeyCode == Keys.Down) ship.Down();
            if (e.KeyCode == Keys.ControlKey)
            {
                bullet = new Bullet(new Point(ship.Rect.X+10, ship.Rect.Y+30), new Point(35, 0), new Size(54, 9));
            }
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Update();
            if (timer.Enabled == true) Draw(); // Если таймер не остановлен, то перерисовываем
        }
        public static void Draw()
        {
            //Buffer.Graphics.Clear(Color.Black);
            Buffer.Graphics.DrawImage(new Bitmap(Resources.background, Width, Heigth), new Rectangle(0, 0, 800, 600)); // Фон

            //Buffer.Graphics.FillEllipse(Brushes.Red, new Rectangle(100, 100, 200, 200));
            Buffer.Graphics.DrawImage(new Bitmap(Resources.planet, Width, Heigth), new Rectangle(100, 100, 200, 200)); // Планета

            ship.Draw();
            Buffer.Graphics.DrawString($"Energy: {ship.Energy}", SystemFonts.DefaultFont, Brushes.White, 0, 0); // Здоровье корабля
            Buffer.Graphics.DrawString($"Score: {ship.Score}", SystemFonts.DefaultFont, Brushes.White, 100, 0); // Очки игрока

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
                if (gb == null) continue;
                gb.Draw();
            }

            foreach (BaseObject kit in aidkit)
            {
                if (kit == null) continue;
                kit.Draw();
            }

            if (bullet != null)
                bullet.Draw();
            
            Buffer.Render();

            log = new Log();
            DLog dlog = log.ConsoleWriteLog;
            dlog("Objects rendered");
            StreamWriter f = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "log.txt", true);
            f.WriteLine("Objects rendered");
            f.Close();
        }

        public static void Update()
        {
            Random rnd = new Random();

            // Пока что костыль на проверку если игрок выиграл. Нужно будет сделать через событие
            int len = 0;
            for (int i = 0; i < asteroids.Length; i++)
            {
                if (asteroids[i] == null)
                {
                    len++;

                    if (len == asteroids.Length)
                    {
                        // Победа! Останавливаем таймер
                        timer.Stop();
                        Buffer.Graphics.DrawString("You Win!", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Bold), Brushes.White, 200, 100); // Рисуем текст об окончании
                        Buffer.Graphics.DrawString($"Your Score: {ship.Score}", new Font(FontFamily.GenericSansSerif, 40, FontStyle.Bold), Brushes.White, 260, 180); // Рисуем кол-во заработанных очков
                        Buffer.Render();
                    }
                    continue;
                }
            }

            // Проверяем попадания и столкновения с астероидами
            for (int i = 0; i < asteroids.Length; i++)
            {
                if (asteroids[i] == null) continue;
                
                asteroids[i].Update();

                if (bullet != null && asteroids[i].Collision(bullet))
                {
                    System.Media.SystemSounds.Hand.Play();
                    asteroids[i] = null;
                    bullet = null;
                    ship.Score += 100;
                    continue;
                }

                if (ship.Collision(asteroids[i]))
                {
                    System.Media.SystemSounds.Asterisk.Play();
                    ship.EnergyLow(rnd.Next(10, 18));
                    if (ship.Energy <= 0)
                        ship.ShipDie();
                }

            }
            // Проверяем попадания и столкновения с мусором
            for (int i = 0; i < garbage.Length; i++)
            {
                if (garbage[i] == null) continue;
                garbage[i].Update();

                if (bullet != null && garbage[i].Collision(bullet))
                {
                    System.Media.SystemSounds.Hand.Play();
                    garbage[i] = null;
                    bullet = null;
                    ship.Score += 1;
                    continue;
                }

                if (ship.Collision(garbage[i]))
                {
                    System.Media.SystemSounds.Asterisk.Play();
                    ship.EnergyLow(1);
                    if (ship.Energy <= 0)
                        ship.ShipDie();
                }

            }
            // Проверяем столкновение с аптечкой
            for (int i = 0; i < aidkit.Length; i++)
            {
                if (aidkit[i] == null) continue;
                aidkit[i].Update();

                if (ship != null && aidkit[i].Collision(ship))
                {
                    System.Media.SystemSounds.Hand.Play();
                    aidkit[i] = null;
                    ship.Energy += 50;
                    if (ship.Energy >= 100) ship.Energy = 100;
                    continue;
                }                
            }

            foreach (BaseObject star in stars)
            {
                star.Update();
            }

            if (bullet != null)
                bullet.Update();

            ship.Update();

            log = new Log();
            DLog dlog = log.ConsoleWriteLog;
            dlog("Start updated");
            StreamWriter f = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "log.txt", true);
            f.WriteLine("Start updated");
            f.Close();
        }

        public static void Load()
        {
            Random gen = new Random();
            int rnd = 0;
            var random = new Random();

            ship = new Ship(new Point(10, 400), new Point(5, 5), new Size(80, 80));
            ship.Die += OnShipDie;
             
            // Инициализируем астероиды
            asteroids = new BaseObject[10];
            for (int i = 1; i <= asteroids.Length; i++)
            {
                rnd = gen.Next(i, asteroids.Length);
                var size = random.Next(10, 40);
                asteroids[i-1] = new Asteroid(new Point(600, i * 20 + 5), new Point(rnd, rnd), new Size(size, size));
            }

            // Инициализируем звезды
            stars = new BaseObject[20];
            for (int i = 1; i <= stars.Length; i++)
            {
                rnd = gen.Next(i, stars.Length);
                stars[i-1] = new Star(new Point(600, i * 40 + 5), new Point(-rnd, -rnd), new Size(4, 4));
            }

            // Инициализируем мусор
            garbage = new BaseObject[2];
            for (int i = 1; i <= garbage.Length; i++)
            {
                rnd = gen.Next(i, garbage.Length);
                garbage[i-1] = new Garbage(new Point(600, i * 30 + 5), new Point(rnd, rnd), new Size(36, 36));
            }

            // Инициализируем аптечки
            aidkit = new BaseObject[1];
            for (int i = 1; i <= aidkit.Length; i++)
            {
                rnd = gen.Next(i, aidkit.Length);
                aidkit[i-1] = new Aidkit(new Point(600, i * 50 + 5), new Point(rnd, rnd), new Size(50, 50));
            }

            log = new Log();
            DLog dlog = log.ConsoleWriteLog;
            dlog("Start loaded");
            StreamWriter f = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "log.txt", true);
            f.WriteLine("Start loaded");
            f.Close();
        }

        private static void OnShipDie(object sender, ShipEventArgs e)
        {
            // Игра окончена. Останавливаем таймер
            timer.Stop();
            Buffer.Graphics.DrawString("Game Over", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Bold), Brushes.White, 200, 100); // Рисуем текст об окончании
            Buffer.Graphics.DrawString($"Your Score: {ship.Score}", new Font(FontFamily.GenericSansSerif, 40, FontStyle.Bold), Brushes.White, 260, 180); // Рисуем кол-во заработанных очков
            Buffer.Render();

            log = new Log();
            DLog dlog = log.ConsoleWriteLog;
            dlog($"Game over. Score: {ship.Score}");
            StreamWriter f = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "log.txt", true);
            f.WriteLine($"Game over. Score: {ship.Score}");
            f.Close();
        }

    }
}
