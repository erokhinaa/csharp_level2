using Employee.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    public class DepartmentDatabase
    {
        public List<Person> Persons { get; set; }

        public DepartmentDatabase()
        {
            Persons = new List<Person>();
            Persons.Add(new Person(1, "Иванов","Иван","Иванович","Программист"));
            Persons.Add(new Person(2, "Александров", "Александр", "Александрович", "Программист"));
            Persons.Add(new Person(3, "Андреев", "Андрей", "Андреевич", "Тестировщик"));
            Persons.Add(new Person(4, "Петров", "Петр", "Петрович", "Администратор"));
            Persons.Add(new Person(5, "Олегов", "Олег", "Олегович", "Начальник отдела"));

        }


    }
}
