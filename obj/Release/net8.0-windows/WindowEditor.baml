   M S B A M L   `   `   `  ���� T  PProjectManagmentSystemWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:ProjectManagmentSystemWPFProjectManagmentSystemWPF  ,    &ProjectManagmentSystemWPF.WindowEditor   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     9local'clr-namespace:ProjectManagmentSystemWPF       � Title$!  Окно редактора��$	��820��$
��1273�� � WindowStartupLocation$ CenterScreen=�.���  � RowDefinitions �� $	��15* ��� $	��85* �.+��� -    ��Name$ 
tabControl��$��1�� �� SelectedIndex$ 0��$��20(�.@��� $��Пользователи��.��� ���	#FFE5E5E5 � ColumnDefinitions �� $	��70* ��� $	��30* �.+�&   System.Windows.Controls.DataGrid  -     Name$ dataGridAdminUsers��   AutoGenerateColumns$ False��   
IsReadOnly$
 True��$��16(�	   Columns	 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn
   Header$
 ID��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Id+  $
 
Логин��   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto  �� *Login+  $
 Роль��$
 Auto  �� *
RoleName+  $
 Имя��$
 Auto  �� *Name+  $
 Описание��$ *  �� *Description+�� -    ��Name$ buttonUpdateUsers��$��1��$��Обновить��$
��Left=�$��
234,10,0,0q�$	��Top=�$	��114��$��20(��� $��1��$
��Left=�$��	11,58,0,0q�$
��Wrap=�$��Id��$	��Top=�$��20(��� $��1��$
��Left=�$��	11,90,0,0q�$
��Wrap=�$��
Логин��$	��Top=�$��20(��� $��1��$
��Left=�$��
11,130,0,0q�$
��Wrap=�$��Имя��$	��Top=�$��20(��� $��1��$
��Left=�$��
11,166,0,0q�$
��Wrap=�$��Роль��$	��Top=�$��20(��� $��1��$
��Left=�$��
11,209,0,0q�$
��Wrap=�$��Описание��$	��Top=�$��20(��� -    ��Name$ textBlockUserId��$��1��$
��Left=�$��
147,57,0,0q�$
��Wrap=�$�� ��$	��Top=�$��20(��� -    ��Name$ textBoxEditLogin��$��1��$
��Left=�$��
146,89,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��204��$��20(� �� 	MaxLength$ 20��$
��28.6���� -   $ textBoxEditName��$��1��$
��Left=�$��145,129,0,0q�$
 Wrap=�$	��Top=�$	��203��$��20(�$ 20��$
��28.6���� -    ��Name$ comboBoxEditRole��$��1��$
��Left=�$��147,166,0,0q�$	��Top=�$	��202��$��32��$��20(��� -   $ textBoxEditDescription��$��1��$
��Left=�$��145,207,0,0q�$
 Wrap=�$	��Top=�$	��203��$��20(�$	��134��$	 120��$	��134���� -	   $ buttonEditUser��$��1��$��Изменить��$
��Left=�$��255,479,0,0q�$	��Top=�$��20(����	#FF9CFFEB�� $��Задачи��.��� ���	#FFE5E5E5 �� $	��70* ��� $	��30* �.+�  -
   $ dataGridAdminTasks��$ False��$
 True��$��16(�	   $
 ID�� �� *Id+  $
 Имя задачи��$
 Auto  �� *Name+  $
 Проект��$
 Auto  �� *ProjectName+  $
 Выполнена��$
 Auto  �� *IsCompleted+  $
 Дедлайн��$
 Auto  �� *
Deadline+  $
 Приоритет��$
 Auto  �� *PriorityString+  $
 Сотрудники��$
 Auto  �� *	Employees+  $
 Информация��$ *  �� *Info+�� -   $ buttonUpdateTasks��$��1��$��Обновить��$
��Left=�$��
235,10,0,0q�$	��Top=�$	��114��$��20(��� $��1��$
��Left=�$��	11,58,0,0q�$
��Wrap=�$��Id��$	��Top=�$��20(��� $��1��$
��Left=�$��	11,90,0,0q�$
��Wrap=�$��Имя��$	��Top=�$��20(��� $��1��$
��Left=�$��
11,130,0,0q�$
��Wrap=�$��Информация��$	��Top=�$��20(��� $��1��$
��Left=�$��
11,255,0,0q�$
��Wrap=�$��Приоритет��$	��Top=�$��20(��� $��1��$
��Left=�$��
11,304,0,0q�$
��Wrap=�$S��MСотрудники (логины разделенные запятаями)��$	��Top=�$��20(�$	��136���� $��1��$
��Left=�$��
12,466,0,0q�$
��Wrap=�$!��Дедлайн (yyyy-mm-dd)��$	��Top=�$	��131��$��62���� -   $ textBlockTaskId��$��1��$
��Left=�$��
147,57,0,0q�$
��Wrap=�$�� ��$	��Top=�$��20(��� -   $ textBoxEditTaskName��$��1��$
��Left=�$��
146,89,0,0q�$
 Wrap=�$	��Top=�$��29��$	��204��$��20(�$ 40���� -   $ textBoxEditInfo��$��1��$
��Left=�$��145,129,0,0q�$
 Wrap=�$	��Top=�$	��203��$��20(�$	��113��$	 200��$	��113���� -   $ textBoxEditTaskEmployees��$��1��$
��Left=�$��151,304,0,0q�$
 Wrap=�$	��Top=�$	��199��$	��106��$��20(�$	 500��$	��106���� -   $ comboBoxEditPriority��$��1��$
��Left=�$��149,257,0,0q�$	��Top=�$	��202��$��32��$��20(��� -   $ textBoxDeadline��$��1��$
��Left=�$��152,466,0,0q�$
 Wrap=�$	��Top=�$	��199��$ 12��$
��28.6���� -   $ buttonEditTask��$��1��$��Изменить��$
��Left=�$��140,562,0,0q�$	��Top=�$��20(����	#FF9CFFEB�� -   $ buttonAddTask��$��1��$��+��$
��Left=�$��
10,562,0,0q�$	��Top=�$��20(�$��50�����	#FFA2FF70�� -   $ buttonDeleteTask��$��1��$��Удалить��$
��Left=�$��271,562,0,0q�$	��Top=�$��20(����	#FFFF9F9F�� -   $ buttonEditTaskConstructor��$��1��$3��-Конструктор сотрудников��$
��Left=�$��108,415,0,0q�$	��Top=��� $��Проекты��.��� ���	#FFE5E5E5 �� $	��70* ��� $	��30* �.+��� -    ��Name$ listBoxProjects��$
��Auto=����� .R�� $��10q� �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $
��Bold"�$��34(�$��0������ *ProjectName+�� $%��Выполнено задач: ��$��14(�$��1���� $��	120,0,0,0q�$��14(�$��1������ *
Progress+�� $��2��$��24(�$
��Wrap=�$	��800��$
��auto������ *ProjectDescription+�� $��Сотрудники:��$��3���� $��0,30,0,0q�$��4��$��24(�$
��Wrap=�$	��800��$
��auto������ *ProjectEmployees+�� -   $ textBlockProjectId��$��1��$
��Left=�$��
161,58,0,0q�$
��Wrap=�$	��Top=��� -   $ textBoxProjectName��$��1��$
��Left=�$��161,102,0,0q�$
��Wrap=�$	��Top=�$	��203��$��20(�$��34���� $��1��$
��Left=�$��	19,58,0,0q�$
��Wrap=�$��Id��$	��Top=�$��20(��� $��1��$
��Left=�$��	19,94,0,0q�$
��Wrap=�$��Имя��$	��Top=�$��20(�$	��100���� $��1��$
��Left=�$��
19,179,0,0q�$
��Wrap=�$��Описание��$	��Top=�$��20(��� $��1��$
��Left=�$��
19,322,0,0q�$
��Wrap=�$S��MСотрудники (логины разделенные запятаями)��$	��Top=�$��20(�$	��137��$	��144���� -   $ textBoxProjectEmployees��$��1��$
��Left=�$��161,322,0,0q�$
 Wrap=�$	��Top=�$	��203��$��20(�$��92��$	 500��$��92���� -   $ textBoxProjectDescription��$��1��$
��Left=�$��161,158,0,0q�$
 Wrap=�$	��Top=�$	��203��$��20(�$	��160��$	 500��$	��160���� -   $ buttonEditProject��$��1��$��Изменить��$
��Left=�$��262,493,0,0q�$	��Top=�$��20(����	#FF9CFFEB�� -   $ buttonUpdateProjects��$��1��$��Обновить��$
��Left=�$��
242,10,0,0q�$	��Top=�$	��114��$��20(��� -   $" buttonEditProjectConstructor��$��1��$3��-Конструктор сотрудников��$
��Left=�$��114,442,0,0q�$	��Top=��� -   $ textBlockUserRole��$
��Left=�$��	15,10,0,0q�$
��Wrap=�$	��Top=�$��24(��� -   $ textBlockUserLogin��$
��Left=�$��	14,38,0,0q�$
��Wrap=�$	��Top=�$��18(��� -    $ textBlockUserName��$
��Left=�$��	15,59,0,0q�$
��Wrap=�$	��Top=�$��18(�