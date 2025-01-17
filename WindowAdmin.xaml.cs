using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    public partial class WindowAdmin : Window
    {
        List<DataGridUser> users;
        List<DataGridTask> tasks;
        List<DataGridProjectCard> cards;
        Dictionary<int, string> taskPriorityDictionary = new Dictionary<int, string>() { { 1, "слабый" }, { 2, "средний" }, { 3, "сильный" } };
        public WindowAdmin(User user)
        {
            InitializeComponent();
            List<string> roles = new List<string>();
            foreach (Role r in DataBaseContext.GetDB().Roles)
            {
                roles.Add(r.RoleName);
            }
            comboBoxEditRole.ItemsSource = roles;
            comboBoxEditRole.SelectedIndex = 0;

            comboBoxEditPriority.ItemsSource = new List<string> { "слабый", "средний", "сильный" };
            comboBoxEditPriority.SelectedIndex = 0;

            users = new List<DataGridUser>();
            tasks = new List<DataGridTask>();
            cards = new List<DataGridProjectCard>();

            textBlockUserLogin.Text = user.Login;
            textBlockUserName.Text = user.Name;
            Role role = DataBaseContext.GetDB().Roles.FirstOrDefault(r => r.Id == user.RoleId);
            if (role != null)
            {
                textBlockUserRole.Text = role.RoleName;
            }
            UpdateUsersList();
            UpdateTasksList();
            UpdateProjectsCardsList();
        }
        void UpdateUsersList()
        {
            dataGridAdminUsers.ItemsSource = null;
            users?.Clear();
            foreach (User user in DataBaseContext.GetDB().Users)
            {
                Role role = DataBaseContext.GetDB().Roles.FirstOrDefault(r => r.Id == user.RoleId);
                if (role != null)
                {
                    users.Add(new DataGridUser() { Id = user.Id, Login = user.Login, Name = user.Name, RoleName = role.RoleName, Description = user.Description, Password = user.Password });
                }
            }
            dataGridAdminUsers.ItemsSource = users;
        }
        void UpdateTasksList()
        {
            dataGridAdminTasks.ItemsSource = null;
            tasks?.Clear();
            foreach (ProjectTask task in DataBaseContext.GetDB().Tasks)
            {
                List<string> logins = new List<string>();
                foreach (TaskEmployer employer in DataBaseContext.GetDB().TasksEmployees.Where(e => e.TaskId == task.Id))
                {
                    User user = DataBaseContext.GetDB().Users.FirstOrDefault(u => u.Id == employer.EmployerId);
                    if (user != null)
                    {
                        string userLogin = user.Login;
                        logins.Add(userLogin);
                    }
                }
                ProjectCard project = DataBaseContext.GetDB().ProjectsCards.FirstOrDefault(p => p.Id == task.ProjectId);
                if (project != null)
                {
                    if (taskPriorityDictionary.TryGetValue(task.Priority, out string priority))
                    {
                        char completed = '-';
                        if (task.Completed)
                        {
                            completed = '+';
                        }
                        tasks.Add(new DataGridTask() { Id = task.Id, Name = task.Name, ProjectName = project.ProjectName, IsCompleted = completed, Deadline = task.Deadline, Employees = string.Join(',', logins), Info = task.Info, PriorityString = priority });
                    }
                }
            }
            dataGridAdminTasks.ItemsSource = tasks;
        }
        void UpdateProjectsCardsList()
        {
            listBoxProjects.ItemsSource = null;
            cards?.Clear();
            foreach (ProjectCard card in DataBaseContext.GetDB().ProjectsCards)
            {
                List<string> logins = new List<string>();
                foreach (ProjectEmployer employer in DataBaseContext.GetDB().ProjectsEmployees.Where(e => e.ProjectId == card.Id))
                {
                    User user = DataBaseContext.GetDB().Users.FirstOrDefault(u => u.Id == employer.EmployerId);
                    if (user != null)
                    {
                        string userLogin = user.Login;
                        logins.Add(userLogin);
                    }
                }
                cards.Add(new DataGridProjectCard() { Id = card.Id, ProjectEmployees = string.Join(",", logins), Progress = card.Progress, ProjectName = card.ProjectName, ProjectDescription = card.ProjectDescription });
            }
            listBoxProjects.ItemsSource = cards;
        }
        private void textBoxEditLogin_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!e.Text.All(c => char.IsLetterOrDigit(c) && c <= 127))
            {
                e.Handled = true;
            }
        }
        private void buttonUpdateUsers_Click(object sender, RoutedEventArgs e)
        {
            UpdateUsersList();
        }

        private void dataGridAdminUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGridUser user = dataGridAdminUsers.SelectedItem as DataGridUser;
            if (user != null)
            {
                textBlockUserId.Text = user.Id.ToString();
                textBoxEditLogin.Text = user.Login;
                textBoxEditName.Text = user.Name;
                textBoxEditDescription.Text = user.Description;
                comboBoxEditRole.SelectedValue = user.RoleName;
            }
        }

        private void buttonEditUser_Click(object sender, RoutedEventArgs e)
        {
            DataGridUser user = dataGridAdminUsers.SelectedItem as DataGridUser;
            if (user != null)
            {
                if (user.RoleName == "Админ")
                {
                    MessageBox.Show("Невозможно изменить админа");
                }
                else if (user.RoleName == comboBoxEditRole.SelectedItem.ToString() && user.Login == textBoxEditLogin.Text && user.Name == textBoxEditName.Text && user.Description == textBoxEditDescription.Text)
                {
                    MessageBox.Show("Нет изменений");
                }
                else
                {
                    Role role = DataBaseContext.GetDB().Roles.FirstOrDefault(r => r.RoleName == comboBoxEditRole.SelectedItem.ToString());
                    if (textBoxEditName.Text.Length >= 6 && textBoxEditLogin.Text.Length >= 6 && role != null)
                    {
                        User userToEdit = DataBaseContext.GetDB().Users.FirstOrDefault(u => u.Id == user.Id);
                        if (userToEdit != null)
                        {
                            if (DataBaseContext.GetDB().Users.Where(u => u.Login == textBoxEditLogin.Text) != null)
                            {
                                List<User> usersWithSameLogins = DataBaseContext.GetDB().Users.Where(u => u.Login == textBoxEditLogin.Text).ToList();
                                if (usersWithSameLogins.Count == 0)
                                {
                                    userToEdit.Name = textBoxEditName.Text;
                                    userToEdit.Login = textBoxEditLogin.Text;
                                    userToEdit.Description = textBoxEditDescription.Text;
                                    userToEdit.RoleId = role.Id;

                                    DataBaseContext.GetDB().SaveChanges();
                                    MessageBox.Show("Успешно");
                                    UpdateUsersList();
                                }
                                else if (usersWithSameLogins.Count < 2)
                                {
                                    if (usersWithSameLogins[0].Id == user.Id)
                                    {
                                        userToEdit.Name = textBoxEditName.Text;
                                        userToEdit.Description = textBoxEditDescription.Text;
                                        userToEdit.RoleId = role.Id;

                                        DataBaseContext.GetDB().SaveChanges();
                                        MessageBox.Show("Успешно");
                                        UpdateUsersList();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Логин используется");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Логин должен быть от 6 символов");
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите пользователя");
            }
        }

        private void buttonUpdateTasks_Click(object sender, RoutedEventArgs e)
        {
            UpdateTasksList();
        }

        private void dataGridAdminTasks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGridTask task = dataGridAdminTasks.SelectedItem as DataGridTask;
            if (task != null)
            {
                textBlockTaskId.Text = task.Id.ToString();
                textBoxEditTaskName.Text = task.Name;
                textBoxEditTaskEmployees.Text = task.Employees;
                textBoxEditInfo.Text = task.Info;
                comboBoxEditPriority.SelectedValue = task.PriorityString;
                textBoxDeadline.Text = task.Deadline;
            }
        }

        private void buttonEditTask_Click(object sender, RoutedEventArgs e)
        {
            DataGridTask task = dataGridAdminTasks.SelectedItem as DataGridTask;
            if (task != null)
            {
                if (textBoxEditTaskName.Text == task.Name && textBoxEditTaskEmployees.Text == task.Employees && textBoxEditInfo.Text == task.Info
                && comboBoxEditPriority.SelectedValue == task.PriorityString && textBoxDeadline.Text == task.Deadline)
                {
                    MessageBox.Show("Нет изменений");
                    return;
                }
                if (textBlockTaskId.Text == string.Empty)
                {
                    MessageBox.Show("Выберите проект");
                    return;
                }
                if (textBoxEditTaskName.Text == string.Empty)
                {
                    MessageBox.Show("Введите имя задачи");
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
                if (DataBaseContext.GetDB().Tasks.Where(t => t.Name == textBoxEditTaskName.Text) != null)
                {
                    List<ProjectTask> tasksWithSameNames = DataBaseContext.GetDB().Tasks.Where(t => t.Name == textBoxEditTaskName.Text).ToList();
                    if (tasksWithSameNames.Count > 0 && tasksWithSameNames.Count < 2)
                    {
                        if (tasksWithSameNames[0].Id != int.Parse(textBlockTaskId.Text))
                        {
                            MessageBox.Show("Имя задачи занято");
                            return;
                        }
                    }
                }
                string pattern = @"^\d{4}-((0[1-9])|(1[0-2]))-((0[1-9])|([1-2][0-9])|(3[0-1]))$";
                if (!Regex.IsMatch(textBoxDeadline.Text, pattern))
                {
                    MessageBox.Show("Неверный формат даты");
                    return;
                }
                ProjectTask projectTaskToEdit = DataBaseContext.GetDB().Tasks.FirstOrDefault(t => t.Id == int.Parse(textBlockTaskId.Text));
                if (projectTaskToEdit != null)
                {
                    projectTaskToEdit.Name = textBoxEditTaskName.Text;
                    projectTaskToEdit.Priority = taskPriorityDictionary.FirstOrDefault(t => t.Value == comboBoxEditPriority.SelectedItem).Key;
                    projectTaskToEdit.Info = textBoxEditInfo.Text;
                    projectTaskToEdit.Deadline = textBoxDeadline.Text;
                    if (textBoxEditTaskEmployees.Text != task.Employees)
                    {
                        HashSet<string> employeesLogins = new HashSet<string>();
                        if (textBoxEditTaskEmployees.Text != string.Empty)
                        {
                            foreach (string s in textBoxEditTaskEmployees.Text.Split(','))
                            {
                                employeesLogins.Add(s);
                            }
                            foreach (string employee in employeesLogins)
                            {
                                User user = DataBaseContext.GetDB().Users.FirstOrDefault(u => u.Login == employee);
                                if (user == null)
                                {
                                    MessageBox.Show("Нет пользователя с логином " + employee);
                                    return;
                                }
                                else if (DataBaseContext.GetDB().ProjectsEmployees.FirstOrDefault(p => p.EmployerId == user.Id) == null)
                                {
                                    MessageBox.Show("Этот пользователь не участвует в данном проекте: " + user.Login);
                                    return;
                                }
                            }
                            List<TaskEmployer> projectTaskEmployeesToEdit = DataBaseContext.GetDB().TasksEmployees.Where(t => t.TaskId == int.Parse(textBlockTaskId.Text)).ToList();
                            foreach (TaskEmployer taskEmployer in projectTaskEmployeesToEdit)
                            {
                                DataBaseContext.GetDB().TasksEmployees.Remove(taskEmployer);
                            }
                            foreach (string login in employeesLogins)
                            {
                                User user = DataBaseContext.GetDB().Users.FirstOrDefault(u => u.Login == login);
                                if (user != null)
                                {
                                    DataBaseContext.GetDB().TasksEmployees.Add(new TaskEmployer() { TaskId = int.Parse(textBlockTaskId.Text), EmployerId = user.Id });
                                }
                            }
                        }
                        else
                        {
                            List<TaskEmployer> projectTaskEmployeesToEdit = DataBaseContext.GetDB().TasksEmployees.Where(t => t.TaskId == int.Parse(textBlockTaskId.Text)).ToList();
                            foreach (TaskEmployer taskEmployer in projectTaskEmployeesToEdit)
                            {
                                DataBaseContext.GetDB().TasksEmployees.Remove(taskEmployer);
                            }
                        }
                    }
                    MessageBox.Show("Успешно");
                    DataBaseContext.GetDB().SaveChanges();
                    UpdateTasksList();

                }
                else
                {
                    MessageBox.Show("Нет задачи с таким id");
                }
            }
            else
            {
                MessageBox.Show("Выберите задачу");
            }
        }
        private void buttonAddTask_Click(object sender, RoutedEventArgs e)
        {
            WindowAddTask windowAddTask = new WindowAddTask();
            windowAddTask.ShowDialog();
            UpdateTasksList();
        }

        private void buttonDeleteTask_Click(object sender, RoutedEventArgs e)
        {
            DataGridTask task = dataGridAdminTasks.SelectedItem as DataGridTask;
            if (task != null)
            {
                ProjectTask taskToDelete = DataBaseContext.GetDB().Tasks.FirstOrDefault(t => t.Id == task.Id);
                if (taskToDelete != null)
                {
                    int taskId = taskToDelete.Id;
                    List<TaskEmployer> projectTaskEmployeesToDelete = DataBaseContext.GetDB().TasksEmployees.Where(t => t.TaskId == taskId).ToList();
                    foreach (TaskEmployer taskEmployer in projectTaskEmployeesToDelete)
                    {
                        DataBaseContext.GetDB().TasksEmployees.Remove(taskEmployer);
                    }
                    DataBaseContext.GetDB().SaveChanges();
                    DataBaseContext.GetDB().Tasks.Remove(taskToDelete);
                    DataBaseContext.GetDB().SaveChanges();
                    MessageBox.Show("Успешно");
                    UpdateTasksList();
                }
            }
            else
            {
                MessageBox.Show("Выберите задачу");
            }
        }
        private void listBoxProjects_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGridProjectCard card = listBoxProjects.SelectedItem as DataGridProjectCard;
            if (card != null)
            {
                textBlockProjectId.Text = card.Id.ToString();
                textBoxProjectName.Text = card.ProjectName;
                textBoxProjectDescription.Text = card.ProjectDescription;
                textBoxProjectEmployees.Text = card.ProjectEmployees;
            }
        }
        private void buttonAddProject_Click(object sender, RoutedEventArgs e)
        {
           WindowAddProject windowAddProject = new WindowAddProject();
           windowAddProject.ShowDialog();
           UpdateProjectsCardsList();
        }

        private void buttonEditProject_Click(object sender, RoutedEventArgs e)
        {
            if (textBlockProjectId.Text == string.Empty)
            {
                MessageBox.Show("Выберите проект");
                return;
            }
            DataGridProjectCard card = listBoxProjects.SelectedItem as DataGridProjectCard;
            ProjectCard cardToEdit = DataBaseContext.GetDB().ProjectsCards.FirstOrDefault(p => p.Id == int.Parse(textBlockProjectId.Text));
            if (cardToEdit != null && card != null)
            {
                if (textBoxProjectDescription.Text == card.ProjectDescription && textBoxProjectEmployees.Text == card.ProjectEmployees)
                {
                    MessageBox.Show("Нет изменений");
                    return;
                }
                if (textBoxProjectDescription.Text == string.Empty)
                {
                    MessageBox.Show("Введите описание проекта");
                    return;
                }
                if (textBoxProjectEmployees.Text != card.ProjectEmployees)
                {
                    List<ProjectTask> tasks = DataBaseContext.GetDB().Tasks.Where(t => t.ProjectId == int.Parse(textBlockProjectId.Text)).ToList();
                    if (textBoxProjectEmployees.Text==string.Empty)
                    {
                        foreach (var task in tasks)
                        {
                            List<TaskEmployer> taskEmployers = DataBaseContext.GetDB().TasksEmployees.Where(t => t.TaskId == task.Id).ToList();
                            foreach (var taskEmp in taskEmployers)
                            {
                                DataBaseContext.GetDB().TasksEmployees.Remove(taskEmp);
                            }
                        }
                        return;
                    }

                    HashSet<string> employeesLogins = new HashSet<string>();
                    if (textBoxProjectEmployees.Text != string.Empty)
                    {
                        foreach (string s in textBoxProjectEmployees.Text.Split(','))
                        {
                            employeesLogins.Add(s);
                        }
                        foreach (string employee in employeesLogins)
                        {
                            if (DataBaseContext.GetDB().Users.FirstOrDefault(u => u.Login == employee) == null)
                            {
                                MessageBox.Show("Нет пользователя с логином " + employee);
                                return;
                            }
                        }
                    }            
                    List<ProjectEmployer> projectEmployeesToEdit = DataBaseContext.GetDB().ProjectsEmployees.Where(e => e.ProjectId == int.Parse(textBlockProjectId.Text)).ToList();
                    foreach (ProjectEmployer employer in projectEmployeesToEdit)
                    {
                        DataBaseContext.GetDB().ProjectsEmployees.Remove(employer);
                    }
                    foreach (string login in employeesLogins)
                    {
                        User user = DataBaseContext.GetDB().Users.FirstOrDefault(u => u.Login == login);
                        if (user != null)
                        {
                            DataBaseContext.GetDB().ProjectsEmployees.Add(new ProjectEmployer() { ProjectId = int.Parse(textBlockProjectId.Text), EmployerId = user.Id });
                        }
                    }
                    DataBaseContext.GetDB().SaveChanges();
                    foreach (var task in tasks)
                    {
                        List<TaskEmployer> taskEmployers = DataBaseContext.GetDB().TasksEmployees.Where(t => t.TaskId == task.Id).ToList();
                        foreach (var taskEmp in taskEmployers)
                        {
                            var test = DataBaseContext.GetDB().ProjectsEmployees.FirstOrDefault(e => e.EmployerId == taskEmp.EmployerId && e.ProjectId == task.ProjectId);
                            if (test == null)
                            {
                                DataBaseContext.GetDB().TasksEmployees.Remove(taskEmp);
                                DataBaseContext.GetDB().SaveChanges();
                            }
                        }
                    }

                    MessageBox.Show("Успешно");
                    UpdateProjectsCardsList();
                }
                else
                {
                    cardToEdit.ProjectDescription = textBoxProjectDescription.Text;
                    MessageBox.Show("Успешно");
                    DataBaseContext.GetDB().SaveChanges();
                    UpdateProjectsCardsList();
                }
            }
            else
            {
                MessageBox.Show("Выберите проект");
            }

        }

        private void buttonRemoveProject_Click(object sender, RoutedEventArgs e)
        {
            DataGridProjectCard card = listBoxProjects.SelectedItem as DataGridProjectCard;
            if (card != null)
            {
                ProjectCard cardToDelete = DataBaseContext.GetDB().ProjectsCards.FirstOrDefault(p => p.Id == card.Id);
                if (cardToDelete != null)
                {
                    int cardId = cardToDelete.Id;
                    List<ProjectEmployer> projectEmployeesToDelete = DataBaseContext.GetDB().ProjectsEmployees.Where(e => e.ProjectId == cardId).ToList();
                    foreach (ProjectEmployer employer in projectEmployeesToDelete)
                    {
                        DataBaseContext.GetDB().ProjectsEmployees.Remove(employer);
                    }
                    List<ProjectTask> projectTasksToDelete = DataBaseContext.GetDB().Tasks.Where(t => t.ProjectId == cardId).ToList();
                    foreach (ProjectTask task in projectTasksToDelete)
                    {
                        List<TaskEmployer> taskEmployersToDelete = DataBaseContext.GetDB().TasksEmployees.Where(t => t.TaskId == task.Id).ToList();
                        foreach(var taskEmp in taskEmployersToDelete)
                        {
                            DataBaseContext.GetDB().TasksEmployees.Remove(taskEmp);
                            DataBaseContext.GetDB().SaveChanges();
                        }
                        DataBaseContext.GetDB().Tasks.Remove(task);
                    }
                    DataBaseContext.GetDB().SaveChanges();
                    DataBaseContext.GetDB().ProjectsCards.Remove(cardToDelete);
                    DataBaseContext.GetDB().SaveChanges();
                    MessageBox.Show("Успешно");
                    UpdateProjectsCardsList();
                    UpdateTasksList();
                }
            }
            else
            {
                MessageBox.Show("Выберите проект");
            }
        }

        private void buttonUpdateProjects_Click(object sender, RoutedEventArgs e)
        {
            UpdateProjectsCardsList();
        }

        private void buttonEditTaskConstructor_Click(object sender, RoutedEventArgs e)
        {
            if(int.TryParse(textBlockTaskId.Text, out int taskId))
            {
                ProjectTask task = DataBaseContext.GetDB().Tasks.FirstOrDefault(t=>t.Id == taskId);
                if (task != null)
                {
                    string result = textBoxEditTaskEmployees.Text;
                    WindowEmployeesConstructor windowEmployeesConstructor = new WindowEmployeesConstructor(false, false, task.Id, task.ProjectId);
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
                MessageBox.Show("Сначала выберите задачу");
            }
        }

        private void buttonEditProjectConstructor_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(textBlockProjectId.Text, out int projectId))
            {
                ProjectCard project = DataBaseContext.GetDB().ProjectsCards.FirstOrDefault(t => t.Id == projectId);
                if (project != null)
                {
                    string result = textBoxProjectEmployees.Text;
                    WindowEmployeesConstructor windowEmployeesConstructor = new WindowEmployeesConstructor(false, true, projectId);
                    windowEmployeesConstructor.Closed += (s, args) =>
                    {
                        result = windowEmployeesConstructor.result;
                    };
                    windowEmployeesConstructor.ShowDialog();
                    textBoxProjectEmployees.Text = result;
                }
            }
            else
            {
                MessageBox.Show("Сначала выберите проект");
            }
        }
    }
}
