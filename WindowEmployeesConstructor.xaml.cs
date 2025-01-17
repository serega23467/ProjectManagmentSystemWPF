using System;
using System.Collections;
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
    /// Логика взаимодействия для WindowEmployeesConstructor.xaml
    /// </summary>
    public partial class WindowEmployeesConstructor : Window
    {
        List<string> usersLeft;
        List<string> usersRight;
        public string result = "";
        public WindowEmployeesConstructor(bool isNew, bool isProject, int projectId = -1, int taskId = -1)
        {
            InitializeComponent();
            usersLeft = new List<string>();
            usersRight = new List<string>();
            if (isNew)
            {
                if (isProject)
                {
                    List<int> allUsers = DataBaseContext.GetDB().Users.Select(u => u.Id).ToList();
                    foreach (int userId in allUsers)
                    {
                        User user = DataBaseContext.GetDB().Users.FirstOrDefault(u => u.Id == userId);
                        if (user != null)
                        {
                            usersLeft.Add(user.Login);
                        }
                    }
                }
                else
                {
                    List<int> projectEmployersId = DataBaseContext.GetDB().ProjectsEmployees.Where(p => p.ProjectId == projectId).Select(e => e.EmployerId).ToList();
                    foreach (int employerId in projectEmployersId)
                    {
                        User user = DataBaseContext.GetDB().Users.FirstOrDefault(u => u.Id == employerId);
                        if (user != null)
                        {
                            usersLeft.Add(user.Login);
                        }
                    }
                }
            }
            else
            {
                if (isProject)
                {
                    List<int> allUsers = DataBaseContext.GetDB().Users.Select(u => u.Id).ToList();
                    foreach(int userId in allUsers)
                    {
                        User user = DataBaseContext.GetDB().Users.FirstOrDefault(u => u.Id == userId);
                        if (user != null)
                        {
                            usersLeft.Add(user.Login);
                        }
                    }

                    List<int> projectEmployersId = DataBaseContext.GetDB().ProjectsEmployees.Where(p => p.ProjectId == projectId).Select(e => e.EmployerId).ToList();
                    foreach (int employerId in projectEmployersId)
                    {
                        User user = DataBaseContext.GetDB().Users.FirstOrDefault(u => u.Id == employerId);
                        if (user != null)
                        {
                            usersRight.Add(user.Login);
                        }
                    }
                }
                else
                {
                    List<int> projectEmployersId = DataBaseContext.GetDB().ProjectsEmployees.Where(p => p.ProjectId == projectId).Select(e => e.EmployerId).ToList();
                    foreach (int employerId in projectEmployersId)
                    {
                        User user = DataBaseContext.GetDB().Users.FirstOrDefault(u => u.Id == employerId);
                        if (user != null)
                        {
                            usersLeft.Add(user.Login);
                        }
                    }
                    List<int> taskEmployersId = DataBaseContext.GetDB().TasksEmployees.Where(t => t.TaskId == taskId).Select(e => e.EmployerId).ToList();
                    foreach (int employerId in taskEmployersId)
                    {
                        User user = DataBaseContext.GetDB().Users.FirstOrDefault(u => u.Id == employerId);
                        if (user != null)
                        {
                            usersRight.Add(user.Login);
                        }
                    }
                }
            }
            UpdateLeft();
            UpdateRight();

        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            string selectedItem = listBoxToAdd.SelectedItem as string;
            if (selectedItem != null)
            {
                usersLeft.Add(selectedItem);
                UpdateRight();
                UpdateLeft();
            }
        }
        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            string selectedItem = listBoxAll.SelectedItem as string;
            if (selectedItem != null)
            {
                usersRight.Add(selectedItem);
                UpdateLeft();
                UpdateRight();
            }
        }

        private void buttonOk_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i< usersRight.Count; i++)
            {
                sb.Append(usersRight[i]);
                if(i+1 < usersRight.Count)
                    sb.Append(",");
            }
            result = sb.ToString();
            Close();
        }
        void UpdateLeft()
        {
            listBoxAll.ItemsSource = null;
            usersLeft.Sort();
            usersLeft.RemoveAll(item => usersRight.Contains(item));
            listBoxAll.ItemsSource = usersLeft;
        }
        void UpdateRight()
        {
            listBoxToAdd.ItemsSource = null;
            usersRight.Sort();
            usersRight.RemoveAll(item => usersLeft.Contains(item));
            listBoxToAdd.ItemsSource = usersRight;
        }

        private void buttonDeleteAll_Click(object sender, RoutedEventArgs e)
        {
            foreach (string login in usersRight)
            {
                usersLeft.Add(login);
            }
            UpdateRight();
            UpdateLeft();
        }

        private void buttonAddAll_Click(object sender, RoutedEventArgs e)
        {
            foreach (string login in usersLeft)
            {
                usersRight.Add(login);
            }
            UpdateLeft();
            UpdateRight();
        }
    }
}
