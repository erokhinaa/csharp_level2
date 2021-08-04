using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    abstract class Payment
    {
        protected string Name { get; set; }
        public double Pay { get; set; }
        protected double HourPay;
        protected double FixPay;
        public Payment(string name, double pay)
        {
            Name = name;
            Pay = pay;
        }
        public abstract double PayCount();

        public override string ToString()
        {
            return $"Сотрудник: {Name}. Зарплата: {Pay}";
        }
    }

    class HourPayment : Payment
    {
        public HourPayment(string name, double pay) : base(name, pay)
        {
            
        }
        public double GetHourPay { get; set; }
        public override double PayCount()
        {
            return 20.8 * 8 * HourPay;
        }        
    }

    class FixPaymaent : Payment
    {
        public FixPaymaent(string name, double pay) : base(name, pay)
        {
           
        }
        public double GetFixPay { get; set; }
        public override double PayCount()
        {
            return FixPay;
        }        
    }

    class PayComparer : IComparer<Payment>
    {
        public int Compare(Payment x, Payment y)
        {
            return Convert.ToInt32(x.Pay) - Convert.ToInt32(y.Pay);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            #region 1.Построить три класса(базовый и 2 потомка), описывающих некоторых работников с почасовой оплатой(один из потомков) и фиксированной оплатой(второй потомок).
            //а) Описать в базовом классе абстрактный метод для расчёта среднемесячной заработной платы.Для «повременщиков» формула для расчета такова: «среднемесячная заработная плата = 20.8 * 8 * почасовая ставка», для работников с фиксированной оплатой «среднемесячная заработная плата = фиксированная месячная оплата».
            //б) Создать на базе абстрактного класса массив сотрудников и заполнить его.
            //в) *Реализовать интерфейсы для возможности сортировки массива, используя Array.Sort().
            //г) *Создать класс, содержащий массив сотрудников, и реализовать возможность вывода данных с использованием foreach.
            Console.WriteLine("*** Программа расчета заработной планы для сотрудников ***");

            var hourpayment = new Payment[]
            {
                new HourPayment("Bill",  10),
                new HourPayment("Mike",  25),
                new HourPayment("Kate",   9),
                new HourPayment("Mary", 4.5)
            };
            var fixpayment = new Payment[]
            {
                new FixPaymaent("John", 120000),
                new FixPaymaent("Paul", 250000),
                new FixPaymaent("Jack",  90000),
                new FixPaymaent("Aron",  45000)
            };

            Console.WriteLine("Расчет почасовой оплаты");
            foreach (var hp in hourpayment)
                Console.WriteLine(hp + hp.PayCount().ToString());
            Console.WriteLine("Расчет фиксированной оплаты");
            foreach (var fp in fixpayment)
                Console.WriteLine(fp + fp.PayCount().ToString());

            Console.WriteLine();
            Console.WriteLine("Делаем сортировку");
            Array.Sort(hourpayment, new PayComparer());
            Array.Sort(fixpayment,  new PayComparer());
            Console.WriteLine();

            Console.WriteLine("Расчет почасовой оплаты");
            foreach (var hp in hourpayment)
                Console.WriteLine(hp + hp.PayCount().ToString());
            Console.WriteLine("Расчет фиксированной оплаты");
            foreach (var fp in fixpayment)
                Console.WriteLine(fp + fp.PayCount().ToString());
            Console.ReadKey();

            #endregion
        }
    }
}
