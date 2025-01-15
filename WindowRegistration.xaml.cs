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

namespace ProjectManagmentSystemWPF
{
    public partial class WindowRegistration : Window
    {
        public WindowRegistration()
        {
            InitializeComponent();
            List<string> roles = new List<string>();
            foreach (Role role in DataBaseContext.GetDB().Roles)
            {
                roles.Add(role.RoleName);
            }
            comboBoxRole.ItemsSource = roles;
            comboBoxRole.SelectedIndex = 0;
        }

        private void buttonRegistration_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxRole.SelectedItem == null)
            {
                MessageBox.Show("Не выбрана роль");
                return;
            }
            if (textBoxLogin.Text.Length < 6)
            {
                MessageBox.Show("Минимум 6 символов в логине");
                return;
            }
            if (textBoxName.Text.Length < 6)
            {
                MessageBox.Show("Минимум 6 символов в имени");
                return;
            }
            if (passwordBoxPass.Password.Length < 6)
            {
                MessageBox.Show("Минимум 6 символов в пароле");
                return;
            }
            if (passwordBoxPass.Password != passwordBoxRepeatPass.Password)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }
            if (DataBaseContext.GetDB().Users.FirstOrDefault(u => u.Login == textBoxLogin.Text) != null)
            {
                MessageBox.Show("Логин используется");
                return;
            }
            Role role = DataBaseContext.GetDB().Roles.FirstOrDefault(r => r.RoleName == comboBoxRole.SelectedItem.ToString());
            if (role != null)
            {
                DataBaseContext.GetDB().Users.Add(new User() { Login = textBoxLogin.Text, Name = textBoxName.Text, Password = PasswordHasher.GetInstance().HashPassword(passwordBoxRepeatPass.Password), Description = textBoxDescription.Text, RoleId = role.Id });
                DataBaseContext.GetDB().SaveChanges();
                Close();
            }
        }
        private void textBoxLogin_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!e.Text.All(c => char.IsLetterOrDigit(c) && c <= 127))
            {
                e.Handled = true;
            }
        }

    }
}
