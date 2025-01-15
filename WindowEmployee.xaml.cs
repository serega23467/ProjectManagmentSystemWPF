using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
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
using System.Windows.Threading;

namespace ProjectManagmentSystemWPF
{
    public partial class WindowEmployee : Window
    {
        int? userId;
        private DispatcherTimer timer;
        List<DataGridTask> tasks;
        bool hasNotice = false;
        Dictionary<int, string> taskPriorityDictionary = new Dictionary<int, string>() { { 1, "слабый" }, { 2, "средний" }, { 3, "сильный" } };
        public WindowEmployee(User user)
        {
            InitializeComponent();
            userId = user.Id;
            textBlockLogin.Text = user.Login;
            textBlockName.Text = user.Name;
            tasks = new List<DataGridTask>();
            Role role = DataBaseContext.GetDB().Roles.FirstOrDefault(r => r.Id == user.Id);
            if (role != null)
            {
                textBlockRole.Text = role.RoleName;
            }
            UpdateDataGridTasks();
            CheckNotification();
            StartTimer();
        }
        private void StartTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMinutes(2);
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private async void Timer_Tick(object sender, EventArgs e)
        {
            await ExecuteAsyncMethod();
        }

        private async Task ExecuteAsyncMethod()
        {
            await Task.Run(() =>
            {
                CheckNotification();
                UpdateDataGridTasks();

            });
        }
        void UpdateDataGridTasks()
        {
            if (userId != null)
            {
                dataGridTasks.ItemsSource = null;
                tasks?.Clear();
                List<int> tasksId = DataBaseContext.GetDB().TasksEmployees.Where(e => e.EmployerId == userId).Select(t => t.TaskId).ToList();
                foreach (int id in tasksId)
                {
                    ProjectTask task = DataBaseContext.GetDB().Tasks.FirstOrDefault(t => t.Id == id);
                    if (task != null)
                    {
                        ProjectCard card = DataBaseContext.GetDB().ProjectsCards.FirstOrDefault(p => p.Id == task.ProjectId);
                        if (taskPriorityDictionary.TryGetValue(task.Priority, out string priority) && card != null)
                        {
                            tasks.Add(new DataGridTask { Name = task.Name, PriorityString = priority, ProjectName = card.ProjectName, Completed = task.Completed, Info = task.Info, Deadline = task.Deadline });

                        }
                    }
                }
                dataGridTasks.ItemsSource = tasks;
            }
        }
        private void CheckNotification()
        {
            if (userId != null && tasks != null)
            {
                List<int> tasksId = DataBaseContext.GetDB().TasksEmployees.Where(e => e.EmployerId == userId).Select(t => t.TaskId).ToList();
                foreach (int id in tasksId)
                {
                    ProjectTask task = DataBaseContext.GetDB().Tasks.FirstOrDefault(t => t.Id == id);
                    if (task != null)
                    {
                        if(!tasks.Select(t=>t.Name).Contains(task.Name))
                        {
                            MessageBox.Show("Вам назначена новая задача!");
                        }
                        else
                        {
                            if (task.Info != tasks.FirstOrDefault(t => t.Name == task.Name).Info)
                            {
                                MessageBox.Show("Информация о проекте изменена!");                      
                            }
                            if(!hasNotice)
                            {
                                DateTime date = DateTime.ParseExact(task.Deadline, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                                TimeSpan dif = date - DateTime.Now;
                                if (dif.TotalDays > 0)
                                {
                                    MessageBox.Show($"Задача {task.Name} просрочена на {Math.Abs(dif.Days)} дней");
                                    hasNotice = true;
                                }
                                if (dif.TotalDays<7)
                                {
                                    MessageBox.Show($"До выполнения задачи {task.Name} осталось {dif.Days} дней");
                                    hasNotice = true;
                                }
                            }
                        }
                    }
                }
            }
        }
        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox != null)
            {
                DataGridTask task = ((FrameworkElement)sender).DataContext as DataGridTask;
                if (task != null)
                {
                    ProjectTask taskToEdit = DataBaseContext.GetDB().Tasks.FirstOrDefault(t => t.Name == task.Name);
                    ProjectCard card = DataBaseContext.GetDB().ProjectsCards.FirstOrDefault(p => p.ProjectName == task.ProjectName);
                    if (taskToEdit != null && card != null)
                    {
                        if (checkBox.IsChecked != taskToEdit.Completed)
                        {
                            taskToEdit.Completed = true;
                            card.Progress++;
                            DataBaseContext.GetDB().SaveChanges();
                            UpdateDataGridTasks();
                        }
                    }
                }
            }
        }

        private void checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox != null)
            {
                DataGridTask task = ((FrameworkElement)sender).DataContext as DataGridTask;
                if (task != null)
                {
                    ProjectTask taskToEdit = DataBaseContext.GetDB().Tasks.FirstOrDefault(t => t.Name == task.Name);
                    ProjectCard card = DataBaseContext.GetDB().ProjectsCards.FirstOrDefault(p => p.ProjectName == task.ProjectName);
                    if (taskToEdit != null && card != null)
                    {
                        if (checkBox.IsChecked != taskToEdit.Completed)
                        {
                            taskToEdit.Completed = false;
                            card.Progress--;
                            DataBaseContext.GetDB().SaveChanges();
                            UpdateDataGridTasks();
                        }
                    }
                }
            }
        }
    }
}
