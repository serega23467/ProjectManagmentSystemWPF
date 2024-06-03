# Система управления проектами на WPF

![авторизация](https://github.com/serega23467/ProjectManagmentSystemWPF/assets/114952677/43a20d5f-b1d9-4a78-a65d-c7cebd5670c0)

окно авторизации

![регистрация](https://github.com/serega23467/ProjectManagmentSystemWPF/assets/114952677/6d2b6eaf-4df4-4687-bbd7-29ce3f9979c9)

окно регистрации

![юзер](https://github.com/serega23467/ProjectManagmentSystemWPF/assets/114952677/59705168-34b7-4553-9ba3-6687593a40dd)

окно обычного пользователя

![админюзерс](https://github.com/serega23467/ProjectManagmentSystemWPF/assets/114952677/b94c6da4-0711-4149-922b-bc2450829d83)

окно администратора список пользователей

![админ задачи](https://github.com/serega23467/ProjectManagmentSystemWPF/assets/114952677/e1237b72-6144-4797-97b9-b0e828a83eec)

окно администратора список задач

![админ проекты](https://github.com/serega23467/ProjectManagmentSystemWPF/assets/114952677/9a5c4bf1-c9b1-4bda-a400-d111c9d6d22f)

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
