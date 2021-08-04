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
    public class Game : BaseScene
    {
        //private static BufferedGraphicsContext context;
        //public static BufferedGraphics Buffer;
        static Timer timer;
        //public static int Width { get; set; }
        //public static int Height { get; set; }
        static List<Asteroid> asteroids = new List<Asteroid>();
        static BaseObject[] stars;
        static List<Garbage> garbage = new List<Garbage>();
        static BaseObject[] aidkit;
        static List<Bullet> bullets = new List<Bullet>();
        static Ship ship;        
        static Log log;
        public delegate void DLog (string s);
        public static StreamWriter f;

        public override void Init(Form form)
        {
            log = new Log();
            DLog dlog = log.ConsoleWriteLog;
            dlog("Start logging");
            StreamWriter f = new StreamWriter(new FileStream(AppDomain.CurrentDomain.BaseDirectory + "log.txt", FileMode.Create, FileAccess.Write));
            f.WriteLine("Start logging");
            f.Close();

            base.Init(form);

            Load();

            form.KeyDown += OnFormKeyDown;
            timer = new Timer { Interval = 60 };
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        
        public void OnFormKeyDown(object sender, KeyEventArgs e)
        {
            // Управление в игре
            if (e.KeyCode == Keys.Up)   ship.Up();
            if (e.KeyCode == Keys.Down) ship.Down();
            if (e.KeyCode == Keys.ControlKey)
            {
                if (ship.Ammo != 0)
                {
                    bullets.Add(new Bullet(new Point(ship.Rect.X + 10, ship.Rect.Y + 30), new Point(35, 0), new Size(54, 9)));
                    ship.Ammo -= 1;
                }
            }            
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Update();
            if (timer.Enabled == true) Draw(); // Если таймер не остановлен, то перерисовываем
        }
        public override void Draw()
        {
            //Buffer.Graphics.Clear(Color.Black);
            Buffer.Graphics.DrawImage(new Bitmap(Resources.background, Width, Height), new Rectangle(0, 0, 800, 600)); // Фон

            //Buffer.Graphics.FillEllipse(Brushes.Red, new Rectangle(100, 100, 200, 200));
            Buffer.Graphics.DrawImage(new Bitmap(Resources.planet, Width, Height), new Rectangle(100, 100, 200, 200)); // Планета

            ship.Draw();
            Buffer.Graphics.DrawString($"Energy: {ship.Energy}", SystemFonts.DefaultFont, Brushes.White, 0, 0); // Здоровье корабля
            Buffer.Graphics.DrawString($"Ammo: {ship.Ammo}", SystemFonts.DefaultFont, Brushes.White, 100, 0); // Патроны
            Buffer.Graphics.DrawString($"Score: {ship.Score}", SystemFonts.DefaultFont, Brushes.White, 200, 0); // Очки игрока
            Buffer.Graphics.DrawString($"Level: {ship.Level}", SystemFonts.DefaultFont, Brushes.White, 300, 0); // Уровень

            foreach (BaseObject asteroid in asteroids)            
                asteroid.Draw();            

            foreach (BaseObject star in stars)
            {
                star.Draw();
            }

            foreach(BaseObject gb in garbage)
            {
                gb.Draw();
            }

            foreach (BaseObject kit in aidkit)
            {
                if (kit == null) continue;
                kit.Draw();
            }

            foreach (BaseObject bullet in bullets)            
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
            Random gen = new Random();

            if (ship.Level == 5)
            {
                // Победа! Останавливаем таймер
                timer.Stop();
                Buffer.Graphics.DrawString("You Win!", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Bold), Brushes.White, 200, 100); // Рисуем текст об окончании
                Buffer.Graphics.DrawString($"Your Score: {ship.Score}", new Font(FontFamily.GenericSansSerif, 40, FontStyle.Bold), Brushes.White, 260, 180); // Рисуем кол-во заработанных очков
                Buffer.Render();
            }
            // Если коллекция астероидов пуста, то следующий уровень, +1 астероид в коллекцию
            if (asteroids.Count == 0)
            {
                // Следующий уровень                
                ship.Level += 1;
                ship.Energy = 100;
                ship.Ammo = 5;
                for (int i = 1; i <= 5+ship.Level; i++)
                    asteroids.Add(new Asteroid(new Point(600, i * 20 + 5), new Point(rnd.Next(i, 20), rnd.Next(i, 20)), new Size(rnd.Next(10, 40), rnd.Next(10, 40))));

                // Если есть мусор, то удаляем и инициализируем заново
                for (int n = asteroids.Count - 1; n >= 0; n--)
                    garbage.RemoveAt(n);                

                for (int g = 2+ship.Level; g >= 0; g--)
                {                    
                    garbage.Add(new Garbage(new Point(600, g * 30 + 5), new Point(gen.Next(g, garbage.Count), gen.Next(g, garbage.Count)), new Size(36, 36)));
                }
            }
                        
            // Проверяем попадания и столкновения с астероидами с учетом коллекции
            for (int i = asteroids.Count - 1; i >= 0; i--)
            {
                if (asteroids[i].Collision(ship))
                {
                    System.Media.SystemSounds.Asterisk.Play();
                    ship.EnergyLow(rnd.Next(10, 15));
                    if (ship.Energy <= 0)
                        ship.ShipDie();
                    asteroids.RemoveAt(i);
                    continue;
                }
                for (int n = bullets.Count - 1; n >= 0; n--)
                {
                    if (asteroids[i].Collision(bullets[n]))
                    {
                        System.Media.SystemSounds.Hand.Play();
                        asteroids.RemoveAt(i);
                        bullets.RemoveAt(n);
                        ship.Score += 100;
                        ship.Ammo += 2;
                        break;
                    }
                    // Проверяем попадания и столкновения с мусором
                    for (int g = garbage.Count - 1; g >= 0; g--)
                    {
                        if (garbage[g].Collision(bullets[n]))
                        {
                            System.Media.SystemSounds.Hand.Play();
                            garbage.RemoveAt(g);
                            bullets.RemoveAt(n);
                            ship.Score += 1;
                            continue;
                        }

                        if (garbage[g].Collision(ship))
                        {
                            System.Media.SystemSounds.Asterisk.Play();
                            ship.EnergyLow(1);
                            if (ship.Energy <= 0)
                                ship.ShipDie();
                        }
                    }
                }
            }

            for (int n = bullets.Count - 1; n >= 0; n--)
            {
                if (bullets[n].Rect.X > Game.Width)
                    bullets.RemoveAt(n);
            }

            foreach (BaseObject asteroid in asteroids)
                asteroid.Update();
            
            foreach (BaseObject bullet in bullets)
                bullet.Update();

            foreach (BaseObject gb in garbage)
                gb.Update();

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
                star.Update();

            //if (bullet != null)
            //    bullet.Update();

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
            //asteroids = new BaseObject[10]; Теперь используем коллекцию
            for (int i = 1; i <= 5; i++)
            {
                rnd = gen.Next(i, 10);
                var size = random.Next(10, 40);
                asteroids.Add(new Asteroid(new Point(600, i * 20 + 5), new Point(rnd, rnd), new Size(size, size)));
            }

            // Инициализируем звезды
            stars = new BaseObject[20];
            for (int i = 1; i <= stars.Length; i++)
            {
                rnd = gen.Next(i, stars.Length);
                stars[i-1] = new Star(new Point(600, i * 40 + 5), new Point(-rnd, -rnd), new Size(4, 4));
            }

            // Инициализируем мусор
            for (int i = 1; i <= 2; i++)
            {
                rnd = gen.Next(i, 2);
                garbage.Add(new Garbage(new Point(600, i * 30 + 5), new Point(rnd, rnd), new Size(36, 36)));
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
