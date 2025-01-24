# Система управления проектами на WPF


![image](https://github.com/user-attachments/assets/9ddb3e35-3f68-4a06-a7ea-0c00783c53d1)


окно авторизации




![image](https://github.com/user-attachments/assets/9db9f922-f485-491e-97f6-c580cfc13210)


окно регистрации




![image](https://github.com/user-attachments/assets/6a60ae2d-c410-4276-a372-aaf1e2f9f637)


окно обычного пользователя




![image](https://github.com/user-attachments/assets/2d9cb4fb-cc4b-48cd-8b94-f4b1088229a6)


окно администратора список пользователей




![image](https://github.com/user-attachments/assets/226c457d-27da-4aa3-931a-9f36d1db20ff)


окно администратора список задач




![image](https://github.com/user-attachments/assets/ecc1f97b-c08c-45d0-a16a-bad4171f8cda)


окно администратора список проектов


## Функциональность

1. **Регистрация и авторизация**: Возможность создать аккаунт и зайти в него.
2. **Функциональность админа**: Изменение списка пользователей, задач и проектов.
3. **Функциональность редактора**: Как у админа, но без возможности добавлять пользователей.
4. **Функциональность пользователя**: Возможность видеть назначенные задачи и выполнять их.

## Технические детали

- **Разработано на**: WPF
- **База данных**: SQLite с использованием Entity Framework

  ## Создание класса DataBaseContext для связи с БД

``` C#
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagmentSystemWPF
{
    public class DataBaseContext : DbContext
    {
        private static DataBaseContext instance;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<ProjectTask> Tasks { get; set; } = null!;
        public DbSet<TaskEmployer> TasksEmployees { get; set; } = null!;
        public DbSet<ProjectCard> ProjectsCards{ get; set; } = null!;
        public DbSet<ProjectEmployer> ProjectsEmployees { get; set; } = null!;
        private DataBaseContext(){}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=ProjectManagmentDB.db");
        }
        public static DataBaseContext GetDB()
        {
            if(instance!= null)
            {
                return instance;
            }
            else
            {
                instance = new DataBaseContext();
                return instance;
            }
        }
    }
}

```
  ## Код создания таблиц SQLite 

``` SQLite
CREATE TABLE "ProjectsCards" (
	"Id"	INTEGER NOT NULL,
	"ProjectName"	TEXT NOT NULL UNIQUE,
	"ProjectDescription"	TEXT NOT NULL,
	"Progress"	INTEGER,
	PRIMARY KEY("Id")
)

CREATE TABLE "ProjectsEmployees" (
	"Id"	INTEGER NOT NULL,
	"ProjectId"	INTEGER NOT NULL,
	"EmployerId"	INTEGER NOT NULL,
	FOREIGN KEY("ProjectId") REFERENCES "ProjectsCards"("Id"),
	FOREIGN KEY("EmployerId") REFERENCES "Users"("Id"),
	PRIMARY KEY("Id" AUTOINCREMENT)
)

CREATE TABLE "Roles" (
	"Id"	INTEGER NOT NULL,
	"RoleName"	TEXT NOT NULL,
	PRIMARY KEY("Id" AUTOINCREMENT)
)

CREATE TABLE "Tasks" (
	"Id"	INTEGER NOT NULL,
	"Name"	TEXT NOT NULL UNIQUE,
	"Info"	TEXT NOT NULL,
	"Deadline"	TEXT NOT NULL,
	"Priority"	INTEGER NOT NULL,
	"ProjectId"	INTEGER NOT NULL,
	"Completed"	INTEGER NOT NULL,
	PRIMARY KEY("Id"),
	FOREIGN KEY("ProjectId") REFERENCES "ProjectsCards"("Id")
)

CREATE TABLE "TasksEmployees" (
	"Id"	INTEGER NOT NULL,
	"EmployerId"	INTEGER NOT NULL,
	"TaskId"	INTEGER NOT NULL,
    PRIMARY KEY("Id" AUTOINCREMENT),
    FOREIGN KEY(EmployerId) REFERENCES Users(Id),
    FOREIGN KEY(TaskId) REFERENCES Tasks(Id)	
)

CREATE TABLE "Users" (
	"Id"	INTEGER NOT NULL,
	"RoleId"	INTEGER NOT NULL,
	"Login"	INTEGER NOT NULL UNIQUE,
	"Name"	TEXT NOT NULL,
	"Password"	TEXT NOT NULL,
	"Description"	TEXT,
	PRIMARY KEY("Id" AUTOINCREMENT),
	FOREIGN KEY("RoleId") REFERENCES "Roles"("Id")
)

Users - пользователи, ProjectCards - карточки проектов, Roles - роли пользователей, Tasks - задачи,
ProjectEmployees - связь проектов и их исполнителей, TasksEmployees - связь задач и их исполнителей
```

## Автор программы

### Сергей А.
