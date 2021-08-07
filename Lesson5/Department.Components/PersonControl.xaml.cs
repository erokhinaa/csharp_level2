using Company.Data;
using Person.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Department.Components
{
    /// <summary>
    /// Interaction logic for PersonControl.xaml
    /// </summary>
    public partial class PersonControl : UserControl, INotifyPropertyChanged
    {
        private Employee _employee;

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public Employee employee
        {
            get { return _employee; }
            set { _employee = value; NotifyPropertyChanged(); }
        }

        public List<EmployeeCategory> CategoryList { get; set; } = new List<EmployeeCategory>();
        public List<Company.Data.Department> DepartmentList { get; set; } = new List<Company.Data.Department>();

        public PersonControl()
        {
            InitializeComponent();

            this.DataContext = this;

            //cbCategory.ItemsSource = Enum.GetValues(typeof(EmployeeCategory)).Cast<EmployeeCategory>();
            //сbDepartment.ItemsSource = Enum.GetValues(typeof(Company.Data.Department)).Cast<Company.Data.Department>();
            CategoryList.Add(EmployeeCategory.FullTime);
            CategoryList.Add(EmployeeCategory.Freelance);
            DepartmentList.Add(Company.Data.Department.Business);
            DepartmentList.Add(Company.Data.Department.HR);
            DepartmentList.Add(Company.Data.Department.IT);
            DepartmentList.Add(Company.Data.Department.Management);
        }
        /*
        public void SetPerson(Employee employee)
        {
            this.employee = employee;
            tbID.Text = employee.ID.ToString();
            tbLastName.Text = employee.LastName;
            tbFirstName.Text = employee.FirstName;
            tbSecondName.Text = employee.SecondName;
            tbPosition.Text = employee.Position;
            cbCategory.SelectedItem = employee.Category;
            checkWorks.IsChecked = employee.Works;
            tbComment.Text = employee.Comment;
            сbDepartment.SelectedItem = employee.department;
        }

        public void UpdatePerson()
        {
            employee.ID = int.Parse(tbID.Text);
            employee.LastName = tbLastName.Text;
            employee.FirstName = tbFirstName.Text;
            employee.SecondName = tbSecondName.Text;
            employee.Position = tbPosition.Text;
            employee.Category= (EmployeeCategory)cbCategory.SelectedItem;
            employee.Works = (bool)checkWorks.IsChecked;
            employee.Comment = tbComment.Text;
            employee.department = (Company.Data.Department)сbDepartment.SelectedItem;
        }
        */
    }
}
