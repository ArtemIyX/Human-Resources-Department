   M S B A M L   `   `   `  ���� U  QHuman Resources Department, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Human_Resources_DepartmentHuman_Resources_Department  +    %Human_Resources_Department.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     :local(clr-namespace:Human_Resources_Department     -     �Name$  Window_Main�� � Title$ Відділ кадрів��$	��720��$
��1280��.���  � RowDefinitions �� $
��633* ��� $	��56* � � ColumnDefinitions �� $
��479* ��� $
��157* �.+�&   System.Windows.Controls.DataGrid  -     Name$ grid_employeers��$��18(�   CanUserAddRows .     SelectionMode$ Single=�   CanUserDeleteRows .     
IsReadOnly . $��1��	   Columns	 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn
   Header$
 Прізвище��   MinWidth$	 100Q�1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	surname+  $
 Ім'я��$	 100Q� �� *name+  $
 По батькові��$	 150Q� �� *
lastname+  $
 Пiдроздiл��$	 150Q� �� *
department+  $
 Посада��$	 150Q� �� *
position+  $/
 )Дата прийому на роботу��$	 150Q� �� *employment_date+�� $��1��$��5q�$��2��.+��� -    ��Name$ button_createNew��$��
0,12,10,10q�$��75��$��Right=�$	��250��$��50�����	#FFFAFFFF
���   �.���� $)��#Новий співробітник�� �� TextAlignment$ Center=�$��28(�$
��Wrap=�$��0q��� -   $ button_edit��$��
0,12,10,10q�$��75��$��Right=����	#FFFAFFFF
���   �$	��250��$��50��.���� $��Редагувати��$ Center=�$��28(�$
��Wrap=�$��0q��� -   $ button_delete��$��
0,12,10,10q�$��75��$��Right=����	#FFFFE5E5
���   �$	��250��$��50��.���� $��Видалити��$ Center=�$��28(�$
��Wrap=�$��0q��� -   $ button_debug��$��
0,12,10,10q�$��75��$��Right=����	#FFEEFFFE
���   �$	��250��$��50��$y�	Collapsed=�.��DEBUG��  �� Orientation$ 
Horizontal=�$��
10,10,0,10q�.+�(� $��35��$��35��.���� -    ��Name$ check_ageSort���� $��Center=�$
��Left=�$)��#Сортування за вiком��$��20(��� -    ��Name$ 
stack_sort��{�.  $��	10,0,0,10q�$ 
Horizontal=�.+��� -	    ��Name$ 	text_from��$��Вiд��$��25(��� -
    ��Name$ 
textB_from��$��18(�$��35��$��5q��� -   $ text_to��$
��До��$��25(��� -   $ textB_to��$��18(�$��35��$��5q��� -   $ btn_updSort��$��3q�
�������.���� $��Оновити��$��21(��� -   $ 
stack_find��.+��� $ 
Horizontal=�.+��� $��Знайти за ��$��10,0,0,0q�$
��Left=�$��25(��� -    ��Name$ combo_findFilter��$	��160��$��0,5,5,0q��� $ 
Horizontal=�.+��� -   $ textB_surSort�� �� TextAlignment$ Right=�$��Stretch=�$��24(�$��7,7,7,7q�$	��186���� -   $ btn_findSur��$
��Left=�$��5q�
�������$��34��.���� $��Знайти��$��20(��� -   $ 
text_found��$y�	Collapsed=�$��Знайдено: ��$��10,0,0,0q�$
��Left=�$��25(��� $ 
Horizontal=�$��1��$��5q�.+��� $
��Left=�$��Center=�$��Сотрудникiв:��$��25(��� -   $ 
text_total�� �� 
IsReadOnly . $
��Left=�$ Right=�$��Stretch=�$��0��$��24(�$��75��$��7q��� $
��Left=�$��Center=�$��Чоловiкiв:��$��25(��� -   $ 	text_male�� . $
��Left=�$ Right=�$��Stretch=�$��0��$��24(�$��75��$��7q��� $
��Left=�$��Center=�$��
Жiнок:��$��25(��� -   $ text_female�� . $
��Left=�$ Right=�$��Stretch=�$��0��$��24(�$��75��$��7q��� $��Right=�$ Right=�$��Center=�$��На таблицi:��$��25(��� -   $ text_currentCount�� . $
��Left=�$ Right=�$��Stretch=�$��0��$��24(�$��75��$��7q�