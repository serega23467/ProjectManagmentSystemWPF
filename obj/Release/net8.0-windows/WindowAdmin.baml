   M S B A M L   `   `   `  ���� T  PProjectManagmentSystemWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:ProjectManagmentSystemWPFProjectManagmentSystemWPF  +    %ProjectManagmentSystemWPF.WindowAdmin   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     9local'clr-namespace:ProjectManagmentSystemWPF       � Title$   ��$	��882��$
��1273�� � WindowStartupLocation$ CenterScreen=�.���  � RowDefinitions �� $	��10* ��� $	��90* �.+��� -    ��Name$ 
tabControl��$��1�� �� SelectedIndex$ 0��$��20(�.@��� $��Users��.��� ���	#FFE5E5E5 � ColumnDefinitions �� $	��70* ��� $	��30* �.+�&   System.Windows.Controls.DataGrid  -     Name$ dataGridAdminUsers��   AutoGenerateColumns$ False��   
IsReadOnly$
 True��$��16(�	   Columns	 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn
   Header$
 ID��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Id+  $
 Login��   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto  �� *Login+  $

 Role��$
 Auto  �� *
RoleName+  $

 Name��$
 Auto  �� *Name+  $
 Description��$ *  �� *Description+�� -    ��Name$ buttonUpdateUsers��$��1��$��Update list��$
��Left=�$��
234,10,0,0q�$	��Top=�$	��114��$��20(��� $��1��$
��Left=�$��	11,58,0,0q�$
��Wrap=�$��Id��$	��Top=�$��20(��� $��1��$
��Left=�$��	11,90,0,0q�$
��Wrap=�$��Login��$	��Top=�$��20(��� $��1��$
��Left=�$��
11,130,0,0q�$
��Wrap=�$
��Name��$	��Top=�$��20(��� $��1��$
��Left=�$��
11,166,0,0q�$
��Wrap=�$
��Role��$	��Top=�$��20(��� $��1��$
��Left=�$��
11,209,0,0q�$
��Wrap=�$��Description��$	��Top=�$��20(��� $��1��$
��Left=�$��
19,353,0,0q�$
��Wrap=�$��Password��$	��Top=�$��20(�$	��103���� -    ��Name$ textBlockUserId��$��1��$
��Left=�$��
147,57,0,0q�$
��Wrap=�$�� ��$	��Top=�$��20(��� -    ��Name$ textBoxEditLogin��$��1��$
��Left=�$��
146,89,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��204��$��20(� �� 	MaxLength$ 20���� -   $ textBoxEditName��$��1��$
��Left=�$��145,129,0,0q�$
 Wrap=�$	��Top=�$	��203��$��20(�$ 20���� -    ��Name$ comboBoxEditRole��$��1��$
��Left=�$��147,166,0,0q�$	��Top=�$	��202��$��32��$��20(��� -   $ textBoxEditDescription��$��1��$
��Left=�$��145,207,0,0q�$
 Wrap=�$	��Top=�$	��203��$��20(�$	��134��$	 120���� -	   $ textBoxUserPass��$��1��$
��Left=�$��147,353,0,0q�$	��Top=�$	��203��$��20(�$ 20���� -
   $ buttonEditUser��$��1��$��	Edit user��$
��Left=�$��268,479,0,0q�$	��Top=�$��20(��� -   $ buttonAddUser��$��1��$��Add user��$
��Left=�$��147,479,0,0q�$	��Top=�$��20(��� $��Tasks��.��� ���	#FFE5E5E5 �� $	��70* ��� $	��30* �.+�  -   $ dataGridAdminTasks��$ False��$
 True��$��16(�	   $
 ID�� �� *Id+  $

 Name��$
 Auto  �� *Name+  $
 Project��$
 Auto  �� *ProjectName+  $
 	Completed��$
 Auto  �� *IsCompleted+  $
 Deadline��$
 Auto  �� *
Deadline+  $
 Priority��$
 Auto  �� *PriorityString+  $
 	Employees��$
 Auto  �� *	Employees+  $

 Info��$ *  �� *Info+�� -   $ buttonUpdateTasks��$��1��$��Update list��$
��Left=�$��
235,10,0,0q�$	��Top=�$	��114��$��20(��� $��1��$
��Left=�$��	11,58,0,0q�$
��Wrap=�$��Id��$	��Top=�$��20(��� $��1��$
��Left=�$��	11,90,0,0q�$
��Wrap=�$
��Name��$	��Top=�$��20(��� $��1��$
��Left=�$��
11,130,0,0q�$
��Wrap=�$
��Info��$	��Top=�$��20(��� $��1��$
��Left=�$��
11,255,0,0q�$
��Wrap=�$��Priority��$	��Top=�$��20(��� $��1��$
��Left=�$��
11,304,0,0q�$
��Wrap=�$,��&Employees (logins separated by commas)��$	��Top=�$��20(�$	��136���� $��1��$
��Left=�$��
11,431,0,0q�$
��Wrap=�$��Deadline (yyyy-mm-dd)��$	��Top=�$	��131��$��62���� $��1��$
��Left=�$��
13,503,0,0q�$
��Wrap=�$ ��Project name (to add task)��$	��Top=�$	��128���� -   $ textBlockTaskId��$��1��$
��Left=�$��
147,57,0,0q�$
��Wrap=�$�� ��$	��Top=�$��20(��� -   $ textBoxEditTaskName��$��1��$
��Left=�$��
146,89,0,0q�$
 Wrap=�$	��Top=�$	��204��$��20(�$ 40���� -   $ textBoxEditInfo��$��1��$
��Left=�$��145,129,0,0q�$
 Wrap=�$	��Top=�$	��203��$��20(�$	��113��$	 200���� -   $ textBoxEditTaskEmployees��$��1��$
��Left=�$��151,304,0,0q�$
 Wrap=�$	��Top=�$	��199��$	��106��$��20(�$	 500���� -   $ comboBoxEditPriority��$��1��$
��Left=�$��149,257,0,0q�$	��Top=�$	��202��$��32��$��20(��� -   $ textBoxDeadline��$��1��$
��Left=�$��151,431,0,0q�$
 Wrap=�$	��Top=�$	��199��$ 12���� -   $ textBoxTaskProjectName��$��1��$
��Left=�$��150,510,0,0q�$
 Wrap=�$	��Top=�$��20(�$	��199��$ 50���� -   $ buttonEditTask��$��1��$��	Edit task��$
��Left=�$��274,583,0,0q�$	��Top=�$��20(��� -   $ buttonAddTask��$��1��$��Add task��$
��Left=�$��153,583,0,0q�$	��Top=�$��20(��� -   $ buttonDeleteTask��$��1��$��Delete task��$
��Left=�$��
21,583,0,0q�$	��Top=�$��20(��� $��Projects��.��� ���	#FFE5E5E5 �� $	��70* ��� $	��30* �.+��� -    ��Name$ listBoxProjects��$
��Auto=����� .R�� $��10q� �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $
��Bold"�$��34(�$��0������ *ProjectName+�� $��Tasks completed: ��$��14(�$��1���� $��	120,0,0,0q�$��14(�$��1������ *
Progress+�� $��2��$��24(�$
��Wrap=�$	��800��$
��auto������ *ProjectDescription+�� $��
Employees:��$��3���� $��0,30,0,0q�$��4��$��24(�$
��Wrap=�$	��800��$
��auto������ *ProjectEmployees+�� -   $ textBlockProjectId��$��1��$
��Left=�$��
161,58,0,0q�$
��Wrap=�$	��Top=��� -   $ textBoxProjectName��$��1��$
��Left=�$��161,102,0,0q�$
 Wrap=�$	��Top=�$	��203��$��20(�$��34��$ 50���� -   $ textBoxProjectEmployees��$��1��$
��Left=�$��161,322,0,0q�$
 Wrap=�$	��Top=�$	��203��$��20(�$��92��$	 500���� -   $ textBoxProjectDescription��$��1��$
��Left=�$��161,158,0,0q�$
 Wrap=�$	��Top=�$	��203��$��20(�$	��160��$	 500���� -   $ buttonAddProject��$��1��$��Add project��$
��Left=�$��
27,497,0,0q�$	��Top=�$��20(��� -   $ buttonEditProject��$��1��$��Edit project��$
��Left=�$��191,497,0,0q�$	��Top=�$��20(��� -   $ buttonRemoveProject��$��1��$��Remove project��$
��Left=�$��
27,548,0,0q�$	��Top=�$��20(��� $��1��$
��Left=�$��	19,58,0,0q�$
��Wrap=�$��Id��$	��Top=�$��20(��� $��1��$
��Left=�$��	19,94,0,0q�$
��Wrap=�$��Name (can't edit)��$	��Top=�$��20(�$	��100���� $��1��$
��Left=�$��
19,158,0,0q�$
��Wrap=�$��Description��$	��Top=�$��20(��� $��1��$
��Left=�$��
19,322,0,0q�$
��Wrap=�$,��&Employees (logins separated by commas)��$	��Top=�$��20(�$	��100��$	��144���� -    $ buttonUpdateProjects��$��1��$��Update list��$
��Left=�$��
242,10,0,0q�$	��Top=�$	��114��$��20(��� -!   $ textBlockUserRole��$
��Left=�$��	15,10,0,0q�$
��Wrap=�$	��Top=�$��24(��� -"   $ textBlockUserLogin��$
��Left=�$��	14,38,0,0q�$
��Wrap=�$	��Top=�$��18(��� -#   $ textBlockUserName��$
��Left=�$��	15,59,0,0q�$
��Wrap=�$	��Top=�$��18(�