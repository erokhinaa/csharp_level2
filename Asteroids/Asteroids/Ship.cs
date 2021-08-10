using Asteroids.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    class Ship : BaseObject
    {
        private int _Energy = 100;

        private int _Damage;

        private int _Ammo = 5;

        private int _Score = 0;

        private int _Level = 1;

        public event EventHandler<ShipEventArgs> Die;
        public int Energy
        {
            get { return _Energy; }
            set { _Energy = value; }
        }
        public int Score
        {
            get { return _Score; }
            set { _Score = value; }
        }
        public int Ammo
        {
            get { return _Ammo; }
            set { _Ammo = value; }
        }
        public int Level
        {
            get { return _Level; }
            set { _Level = value; }
        }

        public void EnergyLow (int damage)
        {
            _Energy -= damage;
            _Damage = damage;
        }

        public void ShipDie()
        {
            if (Die != null)
            {
                Die.Invoke(this, new ShipEventArgs(_Damage));
            }
        }

        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(new Bitmap(Resources.Ship, Size.Width, Size.Height), new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height));              
        }

        public override void Update()
        {
            
        }

        public void Up()
        {
            if (Pos.Y > 0) 
                Pos.Y -= Dir.Y;
        }

        public void Down()
        {
            if (Pos.Y < Game.Height - Size.Height - 2) // Что бы корабль не уходил ниже границы экрана Size.Height - 2
                Pos.Y += Dir.Y;
        }
                       
    }

    class ShipEventArgs : EventArgs
    {
        private int _Damage;

        public int Damage
        {
            get { return _Damage; }
        }

        public ShipEventArgs(int damage)
        {
            _Damage = damage;
        }

    }
}
