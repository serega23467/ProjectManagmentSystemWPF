   M S B A M L   `   `   `  ���� T  PProjectManagmentSystemWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:ProjectManagmentSystemWPFProjectManagmentSystemWPF  .    (ProjectManagmentSystemWPF.WindowEmployee   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     9local'clr-namespace:ProjectManagmentSystemWPF       � Title$   ��$	��450��$	��800�� � WindowStartupLocation$ CenterScreen=�.���  � RowDefinitions �� $	��20* ��� $	��80* �.+��� -    ��Name$ textBlockRole��$
��Left=�$��	10,22,0,0q�$
��Wrap=�$	��Top=��� -   $ textBlockLogin��$
��Left=�$��	10,43,0,0q�$
��Wrap=�$	��Top=��� -   $ textBlockName��$
��Left=�$��	10,64,0,0q�$
��Wrap=�$	��Top=�&   System.Windows.Controls.DataGrid  -     Name$ dataGridTasks��   AutoGenerateColumns$ False��$��1��   
IsReadOnly$
 True��$��16(�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Project��	   Width5  /System.Windows.Controls.DataGridLengthConverter$
	 Auto 1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 �� *ProjectName+  $ Task priority��$
	 Auto 
 �� *PriorityString+  $ 	Task name��$
	 Auto 
 �� *Name+  $ 	Task info��$	 * 
 �� *Info+4  .System.Windows.Controls.DataGridTemplateColumn  $ 	Completed��   MinWidth$	 100Q�   CellTemplate �� .R��� -   $��Center=�$��Center=� d� 	IsChecked �� *	Completed+