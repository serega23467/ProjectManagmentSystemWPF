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
    public partial class WindowEditor : Window
    {
        List<DataGridUser> users;
        List<DataGridTask> tasks;
        List<DataGridProjectCard> cards;
        Dictionary<int, string> taskPriorityDictionary = new Dictionary<int, string>() { { 1, "low" }, { 2, "middle" }, { 3, "high" } };
        public WindowEditor(User user)
        {
            InitializeComponent();
            List<string> roles = new List<string>();
            foreach (Role r in DataBaseContext.GetDB().Roles)
            {
                roles.Add(r.RoleName);
            }
            comboBoxEditRole.ItemsSource = roles;
            comboBoxEditRole.SelectedIndex = 0;

            comboBoxEditPriority.ItemsSource = new List<string> { "low", "middle", "high" };
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
                if (user.RoleName != "Admin")
                {
                    textBoxUserPass.Text = user.Password;
                }
                else
                {
                    textBoxUserPass.Text = string.Empty;
                }
            }
        }

        private void buttonEditUser_Click(object sender, RoutedEventArgs e)
        {
            DataGridUser user = dataGridAdminUsers.SelectedItem as DataGridUser;
            if (user != null)
            {
                if (user.RoleName == "Admin")
                {
                    MessageBox.Show("Impossible to change a user with the admin role");
                }
                else if (user.RoleName == comboBoxEditRole.SelectedItem.ToString() && user.Login == textBoxEditLogin.Text && user.Name == textBoxEditName.Text && user.Description == textBoxEditDescription.Text)
                {
                    MessageBox.Show("No changes");
                }
                else
                {
                    Role role = DataBaseContext.GetDB().Roles.FirstOrDefault(r => r.RoleName == comboBoxEditRole.SelectedItem.ToString());
                    if (textBoxEditName.Text.Length >= 6 && textBoxEditLogin.Text.Length >= 6 && textBoxUserPass.Text.Length >= 6 && role != null)
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
                                    userToEdit.Password = textBoxUserPass.Text;

                                    DataBaseContext.GetDB().SaveChanges();
                                    MessageBox.Show("Successfully");
                                    UpdateUsersList();
                                }
                                else if (usersWithSameLogins.Count < 2)
                                {
                                    if (usersWithSameLogins[0].Id == user.Id)
                                    {
                                        userToEdit.Name = textBoxEditName.Text;
                                        userToEdit.Description = textBoxEditDescription.Text;
                                        userToEdit.RoleId = role.Id;
                                        userToEdit.Password = textBoxUserPass.Text;

                                        DataBaseContext.GetDB().SaveChanges();
                                        MessageBox.Show("Successfully");
                                        UpdateUsersList();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Login is in use");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Login and password must be 6 symbols minimum");
                    }
                }
            }
            else
            {
                MessageBox.Show("Select a user");
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
                    MessageBox.Show("No changes");
                    return;
                }
                if (textBlockTaskId.Text == string.Empty)
                {
                    MessageBox.Show("Select a project");
                    return;
                }
                if (textBoxEditTaskName.Text == string.Empty)
                {
                    MessageBox.Show("Enter task name");
                    return;
                }
                if (textBoxEditInfo.Text == string.Empty)
                {
                    MessageBox.Show("Enter task info");
                    return;
                }
                if (comboBoxEditPriority.SelectedItem == null)
                {
                    MessageBox.Show("No selected role");
                    return;
                }
                if (DataBaseContext.GetDB().Tasks.Where(t => t.Name == textBoxEditTaskName.Text) != null)
                {
                    List<ProjectTask> tasksWithSameNames = DataBaseContext.GetDB().Tasks.Where(t => t.Name == textBoxEditTaskName.Text).ToList();
                    if (tasksWithSameNames.Count > 0 && tasksWithSameNames.Count < 2)
                    {
                        if (tasksWithSameNames[0].Id != int.Parse(textBlockTaskId.Text))
                        {
                            MessageBox.Show("Task name is in use");
                            return;
                        }
                    }
                }
                string pattern = @"^\d{4}-((0[1-9])|(1[0-2]))-((0[1-9])|([1-2][0-9])|(3[0-1]))$";
                if (!Regex.IsMatch(textBoxDeadline.Text, pattern))
                {
                    MessageBox.Show("Wrong date format");
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
                                if (DataBaseContext.GetDB().Users.FirstOrDefault(u => u.Login == employee) == null)
                                {
                                    MessageBox.Show("No user with login " + employee);
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
                    }
                    MessageBox.Show("Sucessfully");
                    DataBaseContext.GetDB().SaveChanges();
                    UpdateTasksList();

                }
                else
                {
                    MessageBox.Show("No task with this id");
                }
            }
            else
            {
                MessageBox.Show("Select a task");
            }
        }
        private void buttonAddTask_Click(object sender, RoutedEventArgs e)
        {
            ProjectCard projectCard = DataBaseContext.GetDB().ProjectsCards.FirstOrDefault(p => p.ProjectName == textBoxTaskProjectName.Text);
            if (projectCard == null)
            {
                MessageBox.Show("No project with this name");
                return;
            }
            if (textBoxEditTaskName.Text == string.Empty)
            {
                MessageBox.Show("Enter task name");
                return;
            }
            if (DataBaseContext.GetDB().Tasks.FirstOrDefault(t => t.Name == textBoxEditTaskName.Text) != null)
            {
                MessageBox.Show("Task name is in use");
                return;
            }
            if (textBoxEditInfo.Text == string.Empty)
            {
                MessageBox.Show("Enter task info");
                return;
            }
            if (comboBoxEditPriority.SelectedItem == null)
            {
                MessageBox.Show("No selected role");
                return;
            }
            string pattern = @"^\d{4}-((0[1-9])|(1[0-2]))-((0[1-9])|([1-2][0-9])|(3[0-1]))$";
            if (!Regex.IsMatch(textBoxDeadline.Text, pattern))
            {
                MessageBox.Show("Wrong date format");
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
                        MessageBox.Show("No user with login " + employee + " but the task was added");
                        return;
                    }
                    else if (DataBaseContext.GetDB().ProjectsEmployees.FirstOrDefault(p => p.EmployerId == user.Id) == null)
                    {
                        MessageBox.Show("This user is not involved in this project: " + user.Name);
                        return;
                    }
                }
                foreach (string login in employeesLogins)
                {
                    User user = DataBaseContext.GetDB().Users.FirstOrDefault(u => u.Login == login);
                    if (user != null)
                    {
                        ProjectTask task = DataBaseContext.GetDB().Tasks.FirstOrDefault(t => t.Name == textBoxEditTaskName.Text);
                        if (task != null)
                        {
                            DataBaseContext.GetDB().TasksEmployees.Add(new TaskEmployer() { TaskId = task.Id, EmployerId = user.Id });
                        }
                    }
                }
            }
            MessageBox.Show("Sucessfully");
            DataBaseContext.GetDB().SaveChanges();
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
                    MessageBox.Show("Sucessfully");
                    UpdateTasksList();
                }
            }
            else
            {
                MessageBox.Show("Select a task");
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
            if (textBoxProjectName.Text == string.Empty)
            {
                MessageBox.Show("Enter project name");
                return;
            }
            if (textBoxProjectDescription.Text == string.Empty)
            {
                MessageBox.Show("Enter project description");
                return;
            }
            if (DataBaseContext.GetDB().ProjectsCards.FirstOrDefault(p => p.ProjectName == textBoxProjectName.Text) != null)
            {
                MessageBox.Show("Project name is in use");
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
                        MessageBox.Show("No user with login " + employee + " but the project was added");
                        return;
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

            MessageBox.Show("Sucessfully");
            UpdateProjectsCardsList();
        }

        private void buttonEditProject_Click(object sender, RoutedEventArgs e)
        {
            if (textBlockProjectId.Text == string.Empty)
            {
                MessageBox.Show("Select a project");
                return;
            }
            DataGridProjectCard card = listBoxProjects.SelectedItem as DataGridProjectCard;
            ProjectCard cardToEdit = DataBaseContext.GetDB().ProjectsCards.FirstOrDefault(p => p.Id == int.Parse(textBlockProjectId.Text));
            if (cardToEdit != null && card != null)
            {
                if (textBoxProjectDescription.Text == card.ProjectDescription && textBoxProjectEmployees.Text == card.ProjectEmployees)
                {
                    MessageBox.Show("No changes");
                    return;
                }
                if (textBoxProjectDescription.Text == string.Empty)
                {
                    MessageBox.Show("Enter project description");
                    return;
                }
                if (textBoxProjectEmployees.Text != card.ProjectEmployees)
                {
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
                                MessageBox.Show("No user with login " + employee);
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
                    MessageBox.Show("Sucessfully");
                    DataBaseContext.GetDB().SaveChanges();
                    UpdateProjectsCardsList();
                }
                else
                {
                    cardToEdit.ProjectDescription = textBoxProjectDescription.Text;
                    MessageBox.Show("Sucessfully");
                    DataBaseContext.GetDB().SaveChanges();
                    UpdateProjectsCardsList();
                }
            }
            else
            {
                MessageBox.Show("Select a project");
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
                        DataBaseContext.GetDB().Tasks.Remove(task);
                    }
                    DataBaseContext.GetDB().SaveChanges();
                    DataBaseContext.GetDB().ProjectsCards.Remove(cardToDelete);
                    DataBaseContext.GetDB().SaveChanges();
                    MessageBox.Show("Sucessfully");
                    UpdateTasksList();
                    UpdateProjectsCardsList();
                }
            }
            else
            {
                MessageBox.Show("Select a project");
            }
        }

        private void buttonUpdateProjects_Click(object sender, RoutedEventArgs e)
        {
            UpdateProjectsCardsList();
        }
    }
}
