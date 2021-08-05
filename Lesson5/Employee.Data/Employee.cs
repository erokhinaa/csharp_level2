using Company.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Data
{
    public class Employee
    {
        public int ID { get; set; } // Идентификатор сотрудника
        public string FirstName { get; set; } // Имя сотрудника
        public string LastName { get; set; } // Фамилия сотрудника
        public string SecondName { get; set; } // Отчество сотрудника
        public string Position { get; set; } // Должность сотрудника
        public string Comment { get; set; } // Комментарий
        public bool Works { get; set; } // Статус - работает ли сотрудник в настоящий момент

        public EmployeeCategory Category { get; set; } = EmployeeCategory.FullTime;

        public Department department { get; set; }

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
        }

        public Employee(int id, string lastname, string firstname, string secondname, string position, bool works, EmployeeCategory category)
        {
            ID = id;
            LastName = lastname;
            FirstName = firstname;            
            SecondName = secondname;
            Position = position;

            Works = true;
            Category = category;
        }

        public Employee(int id, string lastname, string firstname, string secondname, string position, bool works, EmployeeCategory category, Department department)
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
        public override string ToString()
        {
            return $"{ID} - {LastName} {FirstName} {SecondName}";
        }



    }
}
