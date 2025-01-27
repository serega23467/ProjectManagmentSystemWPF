﻿using System.Text;
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
            string password = PasswordHasher.GetInstance().HashPassword(passwordBoxPass.Password);
            User user = DataBaseContext.GetDB().Users.FirstOrDefault(u => u.Login == login);
            if (user != null && PasswordHasher.GetInstance().VerifyPassword(password, user.Password)) 
            {
                Role role = DataBaseContext.GetDB().Roles.FirstOrDefault(r => r.Id == user.RoleId);
                if (role != null)
                {
                    switch (role.RoleName)
                    {
                        case "Админ":
                            WindowAdmin windowAdmin = new WindowAdmin(user);
                            Close();
                            windowAdmin.Show();
                            break;
                        case "Сотрудник":
                            WindowEmployee windowEmployee = new WindowEmployee(user);
                            Close();
                            windowEmployee.Show();
                            break;
                        case "Редактор":
                            WindowEditor windowEditor = new WindowEditor(user);
                            Close();
                            windowEditor.Show();
                            break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль");
            }
        }


        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
            WindowRegistration registration = new WindowRegistration();
            registration.ShowDialog();
        }

        private void buttonChangePass_Click(object sender, RoutedEventArgs e)
        {
            WindowChangePass windowChangePass = new WindowChangePass();
            windowChangePass.ShowDialog();
        }
    }
}