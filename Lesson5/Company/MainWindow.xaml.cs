using Department.Components;
using Person.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Company
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Database database = new Database();

        public ObservableCollection<Employee> EmployeesList { get; set; }

        public Employee SelectedEmployee { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;
            
            EmployeesList = database.Employees;
            //UpdateBinding();
        }

        private void PersonsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count != 0)
            {
                personControl.employee = (Employee)(e.AddedItems[0] as Employee).Clone();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (PersonsListView.SelectedItems.Count > 0)
            {
                database.Employees[database.Employees.IndexOf((Employee)PersonsListView.SelectedItems[0])] = personControl.employee;
                //personControl.UpdatePerson();
                //UpdateBinding();
            }
        }

        /*private void UpdateBinding()
        {
            PersonsListView.ItemsSource = null;
            PersonsListView.ItemsSource = database.Employees;
        }*/

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (PersonsListView.SelectedItems.Count < 1)
                return;

            if (MessageBox.Show("Хотите уволить сотрудника?", "Увольнение сотрудника", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                database.Employees.Remove((Employee)PersonsListView.SelectedItems[0]);                
                //UpdateBinding();
            }
            
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Close();
        }
    }
}
