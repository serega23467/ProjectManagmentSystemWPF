using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectManagmentSystemWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text;
            string password = passwordBoxPass.Password;
            User user = DataBaseContext.GetDB().Users.FirstOrDefault(u => u.Login == login && u.Password == password);
            if (user != null)
            {
                Role role = DataBaseContext.GetDB().Roles.FirstOrDefault(r => r.Id == user.RoleId);
                if (role != null)
                {
                    switch (role.RoleName)
                    {
                        case "Admin":
                            WindowAdmin windowAdmin = new WindowAdmin(user);
                            windowAdmin.ShowDialog();
                            break;
                        case "Employee":
                            WindowEmployee windowEmployee = new WindowEmployee(user);
                            windowEmployee.ShowDialog();
                            break;
                        case "Editor":
                            WindowEditor windowEditor = new WindowEditor(user);
                            windowEditor.ShowDialog();
                            break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Wrong login or password");
            }
        }


        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
            WindowRegistration registration = new WindowRegistration();
            registration.ShowDialog();
        }
    }
}