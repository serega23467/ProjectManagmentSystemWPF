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
using System.Text.RegularExpressions;

namespace ProjectManagmentSystemWPF
{
    /// <summary>
    /// Логика взаимодействия для WindowAddTask.xaml
    /// </summary>
    public partial class WindowAddTask : Window
    {
        Dictionary<int, string> taskPriorityDictionary = new Dictionary<int, string>() { { 1, "слабый" }, { 2, "средний" }, { 3, "сильный" } };
        List<string> projects;
        public WindowAddTask()
        {
            InitializeComponent();
            comboBoxEditPriority.ItemsSource = new List<string> { "слабый", "средний", "сильный" };
            comboBoxEditPriority.SelectedIndex = 0;
            projects = new List<string>();

            List<ProjectCard> projectCards = DataBaseContext.GetDB().ProjectsCards.ToList();
            foreach(var project in projectCards)
            {
                projects.Add(project.ProjectName);
            }
            comboBoxTaskProjectName.ItemsSource = projects;
            comboBoxTaskProjectName.SelectedIndex = 0;
        }

        private void buttonAddTask_Click(object sender, RoutedEventArgs e)
        {
            if(comboBoxTaskProjectName.SelectedItem == null)
            {
                MessageBox.Show("Выберите проект");
                return;
            }
            ProjectCard projectCard = DataBaseContext.GetDB().ProjectsCards.FirstOrDefault(p => p.ProjectName == comboBoxTaskProjectName.SelectedItem);
            if (projectCard == null)
            {
                MessageBox.Show("Нет проекта с таким именем");
                return;
            }
            if (textBoxEditTaskName.Text == string.Empty)
            {
                MessageBox.Show("Введите имя задачи");
                return;
            }
            if (DataBaseContext.GetDB().Tasks.FirstOrDefault(t => t.Name == textBoxEditTaskName.Text) != null)
            {
                MessageBox.Show("Имя задачи используется");
                return;
            }
            if (textBoxEditInfo.Text == string.Empty)
            {
                MessageBox.Show("Введите информацию о задаче");
                return;
            }
            if (comboBoxEditPriority.SelectedItem == null)
            {
                MessageBox.Show("Не выбран приоритет");
                return;
            }
            string pattern = @"^\d{4}-((0[1-9])|(1[0-2]))-((0[1-9])|([1-2][0-9])|(3[0-1]))$";
            if (!Regex.IsMatch(textBoxDeadline.Text, pattern))
            {
                MessageBox.Show("Неверный формат даты");
                return;
            }
            ProjectTask projectTaskToAdd = new ProjectTask();
            projectTaskToAdd.Name = textBoxEditTaskName.Text;
            projectTaskToAdd.Priority = taskPriorityDictionary.FirstOrDefault(t => t.Value == comboBoxEditPriority.SelectedItem).Key;
            projectTaskToAdd.Info = textBoxEditInfo.Text;
            projectTaskToAdd.Deadline = textBoxDeadline.Text;
            projectTaskToAdd.ProjectId = projectCard.Id;
            DataBaseContext.GetDB().Tasks.Add(projectTaskToAdd);
            DataBaseContext.GetDB().SaveChanges();
            if (textBoxEditTaskEmployees.Text != string.Empty)
            {
                HashSet<string> employeesLogins = new HashSet<string>();
                foreach (string s in textBoxEditTaskEmployees.Text.Split(','))
                {
                    employeesLogins.Add(s);
                }
                foreach (string employee in employeesLogins)
                {
                    User user = DataBaseContext.GetDB().Users.FirstOrDefault(u => u.Login == employee);
                    if (user == null)
                    {
                        MessageBox.Show("Нет пользователя с логином " + employee + " но задача была добавлена");
                        continue;
                    }
                    else if (DataBaseContext.GetDB().ProjectsEmployees.FirstOrDefault(p => p.EmployerId == user.Id) == null)
                    {
                        MessageBox.Show("Этот пользователь не участвует в данном проекте: " + user.Login + " но задача была добавлена");
                        continue;
                    }
                    else
                    {
                        ProjectTask task = DataBaseContext.GetDB().Tasks.FirstOrDefault(t => t.Name == textBoxEditTaskName.Text);
                        if (task != null)
                        {
                            DataBaseContext.GetDB().TasksEmployees.Add(new TaskEmployer() { TaskId = task.Id, EmployerId = user.Id });
                        }
                    }
                }
            }
            DataBaseContext.GetDB().SaveChanges();
            MessageBox.Show("Успешно");
            Close();
        }

        private void buttonConstructor_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxTaskProjectName.SelectedItem != null)
            {
                ProjectCard projectCard = DataBaseContext.GetDB().ProjectsCards.FirstOrDefault(p => p.ProjectName == comboBoxTaskProjectName.SelectedItem);
                if (projectCard != null)
                {
                    string result = textBoxEditTaskEmployees.Text;
                    WindowEmployeesConstructor windowEmployeesConstructor = new WindowEmployeesConstructor(true, false, projectCard.Id);
                    windowEmployeesConstructor.Closed += (s, args) =>
                    {
                        result = windowEmployeesConstructor.result;
                    };
                    windowEmployeesConstructor.ShowDialog();
                    textBoxEditTaskEmployees.Text = result;
                }
            }
            else
            {
                MessageBox.Show("Сначала введите имя проекта");
            }
        }
    }
}
