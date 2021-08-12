using Company.Communication.CompanyService;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Company
{
    public class Database
    {
        // private string pcname = Environment.MachineName; 
        //private string ConnectionString = $@"Data Source={pcname}\SQLEXPRESS; Initial Catalog=Company; User ID=user1; Password=user; TRUSTED_CONNECTION = TRUE";
        //private string ConnectionString = "Data Source=DESKTOP-QTQ7ASM\\SQLEXPRESS; Initial Catalog=Company; User ID=user1; Password=user; TRUSTED_CONNECTION = TRUE";

        CompanyServiceSoapClient soapClient = new CompanyServiceSoapClient();

        //public List<Employee> Employees { get; set; }
        public ObservableCollection<Employee> Employees { get; set; }

        public int Add(Employee employee)
        {
            var result = soapClient.Add(employee);
            if (result > 0) Employees.Add(employee);

            return result;
        }

        public void Load()
        {
            foreach (var employee in soapClient.Load())
            {
                Employees.Add(employee);
            }
        }

        public int Update(Employee employee)
        {
            return soapClient.Update(employee);            
        }

        public Database()
        {
            Employees = new ObservableCollection<Employee>();
            soapClient.DeleteFromEmployees();            
            soapClient.Load();            
        }
    }
}
