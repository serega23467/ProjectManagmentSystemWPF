# Система управления проектами на WPF

![авторизация](https://github.com/user-attachments/assets/b9df2eba-1a91-4428-afe5-590440bf8115)



![вход](https://github.com/serega23467/ProjectManagmentSystemWPF/assets/114952677/6d2b6eaf-4df4-4687-bbd7-29ce3f9979c9)
окно авторизации


![рег](https://github.com/user-attachments/assets/7624eae0-030f-431b-9021-279ceb50e56f)
окно регистрации


![юзер](https://github.com/user-attachments/assets/f4759b66-3ec0-4a15-a225-ae6b8cd24a4b)
окно обычного пользователя


![админюзерс](https://github.com/user-attachments/assets/d7b87ef9-88ef-4329-9352-6b08c2d09f49)
окно администратора список пользователей


![админ задачи](https://github.com/user-attachments/assets/6498106d-9aac-41d9-bb49-075ee57596ac)
окно администратора список задач


![админ проекты](https://github.com/user-attachments/assets/82466435-2b19-427f-a074-66d01e6d33ba)
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
