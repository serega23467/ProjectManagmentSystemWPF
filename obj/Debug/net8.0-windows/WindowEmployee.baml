   M S B A M L   `   `   `  ����T  PProjectManagmentSystemWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:ProjectManagmentSystemWPFProjectManagmentSystemWPF  5   	   .    (ProjectManagmentSystemWPF.WindowEmployee   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:ProjectManagmentSystemWPF     5   	     � Title$   ��5      $	��450��6   $	��800��6#    � WindowStartupLocation$ CenterScreen=�6/   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��20* �6   �� 5      $	��80* �6   .+�5   
   �� -   5         ��Name$ textBlockRole��5      $
��Left=�6+   $��	10,22,0,0q�6F   $
��Wrap=�6Y   $	��Top=�6m   �� 5   
   -   5        $ textBlockLogin��5      $
��Left=�6,   $��	10,43,0,0q�6G   $
��Wrap=�6Z   $	��Top=�6n   �� 5   
   -   5        $ textBlockName��5      $
��Left=�6+   $��	10,64,0,0q�6F   $
��Wrap=�6Y   $	��Top=�6m   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGridTasks��5         AutoGenerateColumns$ False��6U   $��1��6q      
IsReadOnly$
 True��6~   $��16(�6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Project��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$
	 Auto 6V   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 66   �� *ProjectName+6V     5      $ Task priority��6%   $
	 Auto 6_   
 6<   �� *PriorityString+6_     5      $ 	Task name��6%   $
	 Auto 6Q   
 68   �� *Name+6Q     5      $ 	Task info��6%   $	 * 6Q   
 68   �� *Info+6Q   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ 	Completed��6)      MinWidth$	 100Q�6<      CellTemplate 5      �� 5      .R�5      �� -   5        $��Center=�5   '   $��Center=�6B    d� 	IsChecked 6_   �� *	Completed+6�   5      5      5       5!      5"      