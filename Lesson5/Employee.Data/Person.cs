using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Data
{
    public class Person
    {
        public int ID { get; set; } // Идентификатор сотрудника
        public string FirstName { get; set; } // Имя сотрудника
        public string LastName { get; set; } // Фамилия сотрудника
        public string SecondName { get; set; } // Отчество сотрудника
        public string Position { get; set; } // Должность сотрудника
        public string Comment { get; set; } // Комментарий
        public bool Works { get; set; } // Статус - работает ли сотрудник в настоящий момент

        public PersonCategory Category { get; set; } = PersonCategory.FullTime;

        public string FIO // Метод для вывода ФИО сотрудника
        {
            get { return $"{LastName} {FirstName} {SecondName}"; }
        }

        public Person() { } // Конструктор по умолчанию

        public Person(int id, string lastname, string firstname, string secondname, string position)
        {
            ID = id;
            LastName = lastname;
            FirstName = firstname;
            SecondName = secondname;
            Position = position;
        }
        public Person(int id, string lastname, string firstname, string secondname, string position, bool works, PersonCategory category)
        {
            ID = id;
            LastName = lastname;
            FirstName = firstname;            
            SecondName = secondname;
            Position = position;

            Works = true;
            Category = category;
        }

        public override string ToString()
        {
            return $"{ID} - {LastName} {FirstName} {SecondName}";
        }



    }
}
