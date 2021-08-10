using Company.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Person.Data
{
    public class Employee : INotifyPropertyChanged, ICloneable
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public int _ID; // Идентификатор сотрудника
        public string _FirstName; // Имя сотрудника
        public string _LastName; // Фамилия сотрудника
        public string _SecondName; // Отчество сотрудника
        public string _Position; // Должность сотрудника
        public string _Comment; // Комментарий
        public bool _Works; // Статус - работает ли сотрудник в настоящий момент
        public EmployeeCategory _Category = EmployeeCategory.FullTime; // Категория работника
        public Department _department; // Департамент
        
        public int ID
        {
            get { return _ID; }
            set { _ID = value; NotifyPropertyChanged(); } 
        } 
        
        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; NotifyPropertyChanged(); }
        }
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; NotifyPropertyChanged(); }
        }
        public string SecondName
        {
            get { return _SecondName; }
            set { _SecondName = value; NotifyPropertyChanged(); }
        }
        public string Position
        {
            get { return _Position; }
            set { _Position = value; NotifyPropertyChanged(); }
        }
        public string Comment
        {
            get { return _Comment; }
            set { _Comment = value; NotifyPropertyChanged(); }
        }
        public bool Works
        {
            get { return _Works; }
            set { _Works = value; NotifyPropertyChanged(); }
        }

        public EmployeeCategory Category
        {
            get { return _Category; }
            set { _Category = value; NotifyPropertyChanged(); }
        }

        public Department department
        {
            get { return _department; }
            set { _department = value; NotifyPropertyChanged(); }
        }

        public string FIO // Метод для вывода ФИО сотрудника
        {
            get { return $"{LastName} {FirstName} {SecondName}"; }
        }

        public Employee() { } // Конструктор по умолчанию

        public Employee(int id, string lastname, string firstname, string secondname, string position)
        {
            ID = id;
            LastName = lastname;
            FirstName = firstname;
            SecondName = secondname;
            Position = position;
            
            Works = true;            
        }

        public Employee(int id, string lastname, string firstname, string secondname, string position, EmployeeCategory category)
        {
            ID = id;
            LastName = lastname;
            FirstName = firstname;            
            SecondName = secondname;
            Position = position;

            Works = true;
            Category = category;
        }

        public Employee(int id, string lastname, string firstname, string secondname, string position, EmployeeCategory category, Department department)
        {
            ID = id;
            LastName = lastname;
            FirstName = firstname;
            SecondName = secondname;
            Position = position;

            Works = true;
            Category = category;
            this.department = department;
        }

        public Employee(int id, string lastname, string firstname, string secondname, string position, EmployeeCategory category, Department department, bool works)
        {
            ID = id;
            LastName = lastname;
            FirstName = firstname;
            SecondName = secondname;
            Position = position;

            Works = works;
            Category = category;
            this.department = department;
        }

        public override string ToString()
        {
            return $"{ID} - {LastName} {FirstName} {SecondName}";
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
