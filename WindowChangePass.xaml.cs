using System;
using System.Collections.Generic;
using System.Data;
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
    /// <summary>
    /// Логика взаимодействия для WindowChangePass.xaml
    /// </summary>
    public partial class WindowChangePass : Window
    {
        public WindowChangePass()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, RoutedEventArgs e)
        {
            if (passwordBoxPass.Password.Length < 6)
            {
                MessageBox.Show("Минимум 6 символов в пароле");
                return;
            }
            if (passwordBoxRepeatPass.Password != passwordBoxPass.Password)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }
            if (textBoxLogin.Text == string.Empty)
            {
                MessageBox.Show("Введите логин");
                return;
            }
            User user = DataBaseContext.GetDB().Users.FirstOrDefault(u => u.Login == textBoxLogin.Text);
            if(user == null)
            {
                MessageBox.Show("Данного логина не существует");
                return;
            }
            string newPassword = PasswordHasher.GetInstance().HashPassword(passwordBoxPass.Password);
            if (PasswordHasher.GetInstance().VerifyPassword(newPassword, user.Password))
            {
                MessageBox.Show("Пароль не изменился");
                return;
            }

            user.Password = newPassword;
            DataBaseContext.GetDB().SaveChanges();
            MessageBox.Show("Успешно");
            Close();

        }
    }
}
