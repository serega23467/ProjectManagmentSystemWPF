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
    /// <summary>
    /// Логика взаимодействия для WindowAddProject.xaml
    /// </summary>
    public partial class WindowAddProject : Window
    {
        public WindowAddProject()
        {
            InitializeComponent();
        }

        private void buttonAddProject_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxProjectName.Text == string.Empty)
            {
                MessageBox.Show("Введите название проекта");
                return;
            }
            if (textBoxProjectDescription.Text == string.Empty)
            {
                MessageBox.Show("Введите описание проекта");
                return;
            }
            if (DataBaseContext.GetDB().ProjectsCards.FirstOrDefault(p => p.ProjectName == textBoxProjectName.Text) != null)
            {
                MessageBox.Show("Имя проекта используется");
                return;
            }
            ProjectCard projectCardToAdd = new ProjectCard();
            projectCardToAdd.Progress = 0;
            projectCardToAdd.ProjectName = textBoxProjectName.Text;
            projectCardToAdd.ProjectDescription = textBoxProjectDescription.Text;
            DataBaseContext.GetDB().ProjectsCards.Add(projectCardToAdd);
            DataBaseContext.GetDB().SaveChanges();

            if (textBoxProjectEmployees.Text != string.Empty)
            {
                HashSet<string> employeesLogins = new HashSet<string>();
                foreach (string s in textBoxProjectEmployees.Text.Split(','))
                {
                    employeesLogins.Add(s);
                }
                foreach (string employee in employeesLogins)
                {
                    if (DataBaseContext.GetDB().Users.FirstOrDefault(u => u.Login == employee) == null)
                    {
                        MessageBox.Show("Нет пользователя с логином " + employee + " но проект был добавлен");
                        continue;
                    }
                }
                foreach (string login in employeesLogins)
                {
                    User user = DataBaseContext.GetDB().Users.FirstOrDefault(u => u.Login == login);
                    if (user != null)
                    {
                        ProjectCard projectCard = DataBaseContext.GetDB().ProjectsCards.FirstOrDefault(P => P.ProjectName == textBoxProjectName.Text);
                        if (projectCard != null)
                        {
                            DataBaseContext.GetDB().ProjectsEmployees.Add(new ProjectEmployer() { ProjectId = projectCard.Id, EmployerId = user.Id });
                        }
                    }
                }
                DataBaseContext.GetDB().SaveChanges();
            }

            MessageBox.Show("Успешно");
            Close();
        }

        private void buttonConstructor_Click(object sender, RoutedEventArgs e)
        {
            string result = textBoxProjectEmployees.Text;
            WindowEmployeesConstructor windowEmployeesConstructor = new WindowEmployeesConstructor(true, true);
            windowEmployeesConstructor.Closed += (s, args) =>
            {
                result = windowEmployeesConstructor.result;
            };
            windowEmployeesConstructor.ShowDialog();
            textBoxProjectEmployees.Text = result;
        }
    }
}
