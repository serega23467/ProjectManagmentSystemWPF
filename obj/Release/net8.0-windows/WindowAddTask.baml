   M S B A M L   `   `   `  ���� T  PProjectManagmentSystemWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:ProjectManagmentSystemWPFProjectManagmentSystemWPF  -    'ProjectManagmentSystemWPF.WindowAddTask   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     9local'clr-namespace:ProjectManagmentSystemWPF       � Title$'  !Добавление задачи��$	��841��$	��618�� � WindowStartupLocation$ CenterScreen=�.��� .+��� $
��Left=�$��	44,90,0,0q�$
��Wrap=�$��Имя задачи��$	��Top=�$��20(�$	��112���� $
��Left=�$��
44,130,0,0q�$
��Wrap=�$��Информация��$	��Top=�$��20(�$	��131���� $
��Left=�$��
44,255,0,0q�$
��Wrap=�$��Приоритет��$	��Top=�$��20(�$	��168���� $
��Left=�$��
44,304,0,0q�$
��Wrap=�$S��MСотрудники (логины разделенные запятаями)��$	��Top=�$��20(�$	��224���� $
��Left=�$��
44,468,0,0q�$
��Wrap=�$!��Дедлайн (yyyy-mm-dd)��$	��Top=�$	��215��$��62��$��20(��� $
��Left=�$��
47,540,0,0q�$
��Wrap=�$��Имя проекта��$	��Top=�$	��211��$��20(��� -    ��Name$ textBoxEditTaskName��$
��Left=�$��
274,89,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��327��$��20(� �� 	MaxLength$ 40���� -   $ textBoxEditInfo��$
��Left=�$��274,129,0,0q�$
 Wrap=�$	��Top=�$	��324��$��20(�$	��113��$	 200���� -   $ textBoxEditTaskEmployees��$
��Left=�$��274,304,0,0q�$
 Wrap=�$	��Top=�$	��327��$	��106��$��20(�$	 500���� -    ��Name$ buttonConstructor��$3��-Конструктор сотрудников��$
��Left=�$��274,415,0,0q�$	��Top=�$��16(�$��33��$	��324���� -    ��Name$ comboBoxEditPriority��$
��Left=�$��274,257,0,0q�$	��Top=�$	��329��$��32��$��20(��� -   $ textBoxDeadline��$
��Left=�$��274,468,0,0q�$
 Wrap=�$	��Top=�$	��327��$ 12��$��24(��� -   $ comboBoxTaskProjectName��$
��Left=�$��274,548,0,0q�$	��Top=�$��20(�$	��326��$��34���� -   $ buttonAddTask��$	��Oк��$
��Left=�$��197,709,0,0q�$	��Top=�$��24(�$	��112��