using Department.Components;
using Person.Data;
using System;
using System.Collections.Generic;
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

        public MainWindow()
        {
            InitializeComponent();

            PersonsListView.Items.Clear();
            PersonsListView.ItemsSource = database.Employees;

        }

        private void PersonsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count != 0)
            {
                personControl.SetPerson((Employee)e.AddedItems[0]);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (PersonsListView.SelectedItems.Count > 0)
            {
                personControl.UpdatePerson();
                UpdateBinding();
            }
        }

        private void UpdateBinding()
        {
            PersonsListView.ItemsSource = null;
            PersonsListView.ItemsSource = database.Employees;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (PersonsListView.SelectedItems.Count < 1)
                return;

            if (MessageBox.Show("Хотите уволить сотрудника?", "Увольнение сотрудника", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                database.Employees.Remove((Employee)PersonsListView.SelectedItems[0]);
                UpdateBinding();
            }
            
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Close();
        }
    }
}
