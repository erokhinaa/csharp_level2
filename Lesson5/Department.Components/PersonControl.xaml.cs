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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Department.Components
{
    /// <summary>
    /// Interaction logic for PersonControl.xaml
    /// </summary>
    public partial class PersonControl : UserControl
    {
        private Person person;

        public PersonControl()
        {
            InitializeComponent();

            cbCategory.ItemsSource = Enum.GetValues(typeof(PersonCategory)).Cast<PersonCategory>();
        }

        public void SetPerson(Person person)
        {
            this.person = person;
            tbID.Text = person.ID.ToString();
            tbLastName.Text = person.LastName;
            tbFirstName.Text = person.FirstName;
            tbSecondName.Text = person.SecondName;
            tbPosition.Text = person.Position;
            cbCategory.SelectedItem = person.Category;
            checkWorks.IsChecked = person.Works;
            tbComment.Text = person.Comment;
        }

        public void UpdatePerson()
        {
            person.ID = int.Parse(tbID.Text);
            person.LastName = tbLastName.Text;
            person.FirstName = tbFirstName.Text;
            person.SecondName = tbSecondName.Text;
            person.Position = tbPosition.Text;
            person.Category= (PersonCategory)cbCategory.SelectedItem;
            person.Works = (bool)checkWorks.IsChecked;
            person.Comment = tbComment.Text;            
        }
    }
}
