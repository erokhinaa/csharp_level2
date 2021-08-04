using Department.Components;
using Employee.Data;
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
        private DepartmentDatabase database = new DepartmentDatabase();

        public MainWindow()
        {
            InitializeComponent();

            PersonsListView.ItemsSource = database.Persons;

        }

        private void PersonsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count != 0)
            {
                PersonControl.SetPerson((Person)e.AddedItems[0]);
            }
        }
    }
}
