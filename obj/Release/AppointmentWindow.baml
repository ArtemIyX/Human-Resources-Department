   M S B A M L   `   `   `  ���� U  QHuman Resources Department, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Human_Resources_DepartmentHuman_Resources_Department  2    ,Human_Resources_Department.AppointmentWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     :local(clr-namespace:Human_Resources_Department     -     � Title$5  /Призначення i переведення��$	��720��$	��800�� � 	Resources  �� 
TargetType 
  Text_1 �� Property �� Value 
 Text_2  	TextBox_1��%�  &	        &	 �     &	 0    �� " ��.���  � ��$ 0,0,10,0q���  �@��TextAlignment$ Right=���  � ��$ 21(���  � ��$
 Wrap=���  � ��$ Bottom=��� " ��.���  � ��$ 0,0,5,5q���  � ��$ Bottom=���  �@��TextAlignment$ Center=���  � ��$ 18(���  � ��$
 Wrap=��� " ��.���  � ��$ 10,0,7,0q���  � ��$ Bottom=���  � ��$ 35����  � ��$ 22(�.���  � RowDefinitions �� $
��218* ��� $	��30* ��� $	��30* ��� $	��30* ��� $	��30* ��� $	��30* ��� $	��30* ��� $	��35* � � ColumnDefinitions �� $
��200* ��� $
��293* ��� $��2* �.+�&   System.Windows.Controls.DataGrid  -     Name$ AppointmentGrid��$��5,5,2,5q�   
IsReadOnly . 	   SelectionMode$	 Single=�$��1��$��2��
   Columns
 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   MinWidth$ 75Q�   Header$ Дата��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Date+  $	 100Q�$# Назва пiдроздiлу��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 150  �� *
Department+  $	 150Q�$ Назва посади�� �� *
Position+  $ 75Q�$ Код за КП*�� �� *Code+  $	 100Q�$ 
Оклад�� �� *Salary+  $	 150Q�$# Пiдстава, наказ #�� �� *Reason+�� $��Дата��$��1��#��[  �� $<��6Назва структурного пiдроздiлу��$��2��#��[  �� $��Назва посади��$��3��#��[  �� $��Код за КП��$��4��#��[  �� $��Розряд(Оклад)��$��5��#��[  �� $%��Пiдстава, наказ №��$��6��#��[  (  "System.Windows.Controls.DatePicker  -     Name$ datePicker_date��$��18(�$��1��$��1��$
��Left=�$��Bottom=�$	��150��$��10,0,0,0q�$��37���� -    ��Name$ text_department��$��Light"�$��2��$��1��#��[ �� -   $ text_position��$��Light"�$��3��$��1��#��[ �� -   $ 	text_code��$��Light"� �� 	MaxLength$ 10��$	��200��$
��Left=�$��4��$��1��#��[ �� -   $ text_salary��$��Light"�$ 10��$	��200��$
��Left=�$��5��$��1��#��[ �� -   $ text_reason��$��Light"�$ 50��$��6��$��1��#��[ �� $��Right=�$��0,10,5,5q� �� Orientation$ 
Horizontal=�$��7��$	��366��$��1��.+��� -	    ��Name$ btn_add��$	��100��$��5,0,5,0q����	#FFD7FFD0.���� $��Додати��$��16(�$��Center=�$��	15,0,15,0q��� -
   $ btn_edit��$	��100��$��5,0,5,0q����	#FFFFFDD4.���� $��Редагувати��$��13(�$��	15,0,15,0q��� -   $ 
btn_remove��$	��100��$��5,0,5,0q����	#FFFFE2E2.���� $��Видалити��$��13(�$��	15,0,15,0q�