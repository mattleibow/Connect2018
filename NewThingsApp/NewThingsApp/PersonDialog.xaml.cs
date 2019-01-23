using System.Windows;

namespace NewThingsApp
{
    public partial class PersonDialog : Window
    {
        public PersonDialog()
        {
            InitializeComponent();
        }

        public string FirstName => firstTextBox.Text;

        public string LastName => lastTextBox.Text;

        private void OnAddClicked(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void OnCancelClicked(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
