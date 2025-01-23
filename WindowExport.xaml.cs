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
using ExportTasks;
using Microsoft.Win32;
using System.IO;
using Microsoft.EntityFrameworkCore;
using ExportTxt;

namespace ProjectManagmentSystemWPF
{
    /// <summary>
    /// Логика взаимодействия для WindowExport.xaml
    /// </summary>
    public partial class WindowExport : Window
    {
        string role;
        string login;
        Dictionary<int, string> taskPriorityDictionary = new Dictionary<int, string>() { { 1, "слабый" }, { 2, "средний" }, { 3, "сильный" } };
        public WindowExport(string userLogin, string userRole)
        {
            InitializeComponent();
            role = userRole;
            login = userLogin;
        }

        private async void buttonExport_Click(object sender, RoutedEventArgs e)
        {
            string fileType = "JSON|*.json|TXT|*.txt"; // Опции для выбора формата

            // Открываем диалог для сохранения файла
            var dialog = new SaveFileDialog
            {
                Filter = fileType,
                DefaultExt = "json"
            };

            if (dialog.ShowDialog() == true)
            {
                
                string filePath = dialog.FileName;
                try
                {
                    List<SerializableTask> exportTasks = new List<SerializableTask>();
                    if(role == "Админ" || role == "Редактор")
                    {
                        List<ProjectTask> allTasks = DataBaseContext.GetDB().Tasks.ToList();
                        foreach (var task in allTasks)
                        {
                            ProjectCard projectCard = DataBaseContext.GetDB().ProjectsCards.FirstOrDefault(p => p.Id == task.ProjectId);
                            if (projectCard == null)
                            {
                                return;
                            }
                            SerializableTask dataGridTask = new SerializableTask();
                            dataGridTask.Id = task.Id;
                            dataGridTask.ProjectName = projectCard.ProjectName;
                            dataGridTask.Name = task.Name;
                            dataGridTask.Deadline = task.Deadline;
                            dataGridTask.Info = task.Info;
                            dataGridTask.IsCompleted = task.Completed ? '+' : '-';
                            dataGridTask.PriorityString = taskPriorityDictionary[task.Priority];
                            List<int> employesId = DataBaseContext.GetDB().TasksEmployees.Where(t=>t.TaskId == task.Id).Select(t=>t.EmployerId).ToList();
                            StringBuilder employees = new StringBuilder();
                            for (int i = 0; i < employesId.Count; i++)
                            {
                                var user = DataBaseContext.GetDB().Users.FirstOrDefault(u => u.Id == employesId[i]);
                                if (user != null)
                                {
                                    if (i + 1 >= employesId.Count)
                                    {
                                        employees.Append(user.Name);
                                    }
                                    else
                                    {
                                        employees.Append(user.Name + ",");
                                    }
                                }
                            }
                            dataGridTask.Employees = employees.ToString();
                            exportTasks.Add(dataGridTask);
                        }
                    }
                    else
                    {
                        var employer = DataBaseContext.GetDB().Users.FirstOrDefault(u => u.Login == login);
                        if(employer == null)
                        {
                            return;
                        }
                        var allTasksEmp = DataBaseContext.GetDB().TasksEmployees.Where(t=>t.EmployerId == employer.Id).ToList();
                        List<ProjectTask> allTasks = new List<ProjectTask>();
                        foreach (var task in allTasksEmp)
                        {
                            var taskToAdd = DataBaseContext.GetDB().Tasks.FirstOrDefault(t => t.Id == task.TaskId);
                            if(taskToAdd!= null)
                            {
                                allTasks.Add(taskToAdd);
                            }
                        }
                        foreach (var task in allTasks)
                        {
                            ProjectCard projectCard = DataBaseContext.GetDB().ProjectsCards.FirstOrDefault(p => p.Id == task.ProjectId);
                            if (projectCard == null)
                            {
                                return;
                            }
                            SerializableTask dataGridTask = new SerializableTask();
                            dataGridTask.Id = task.Id;
                            dataGridTask.ProjectName = projectCard.ProjectName;
                            dataGridTask.Name = task.Name;
                            dataGridTask.Deadline = task.Deadline;
                            dataGridTask.Info = task.Info;
                            dataGridTask.IsCompleted = task.Completed ? '+' : '-';
                            dataGridTask.PriorityString = taskPriorityDictionary[task.Priority];
                            List<int> employesId = DataBaseContext.GetDB().TasksEmployees.Where(t => t.TaskId == task.Id).Select(t => t.EmployerId).ToList();
                            StringBuilder employees = new StringBuilder();
                            for (int i = 0; i < employesId.Count; i++)
                            {
                                var user = DataBaseContext.GetDB().Users.FirstOrDefault(u => u.Id == employesId[i]);
                                if (user != null)
                                {
                                    if (i + 1 >= employesId.Count)
                                    {
                                        employees.Append(user.Name);
                                    }
                                    else
                                    {
                                        employees.Append(user.Name + ",");
                                    }
                                }
                            }
                            dataGridTask.Employees = employees.ToString();
                            exportTasks.Add(dataGridTask);
                        }
                    }
                    bool result = await Exporter.Export(exportTasks.ToList(), System.IO.Path.GetExtension(filePath), filePath);
                    if (result)
                    {
                        MessageBox.Show("Файл успешно сохранён.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
