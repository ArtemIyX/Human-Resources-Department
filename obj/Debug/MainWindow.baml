   M S B A M L   `   `   `  ����U  QHuman Resources Department, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Human_Resources_DepartmentHuman_Resources_Department  5   	   +    %Human_Resources_Department.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:Human_Resources_Department     5   	   -   5          �Name$  Window_Main��5   	    � Title$ Відділ кадрів��5   	   $	��720��6   $
��1280��6,   .��5      �  � RowDefinitions 5   
   �� 5      $
��633* �6   �� 5      $	��56* �6    � ColumnDefinitions 5   
   �� 5      $
��479* �6   �� 5      $
��157* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ grid_employeers��5      $��18(�6,      CanUserAddRows .     SelectionMode$ Single=�6Q      CanUserDeleteRows .     
IsReadOnly . $��1��5   %   	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Прізвище��6%      MinWidth$	 100Q�67   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6F   �� *	surname+6d     5      $
 Ім'я��6%   $	 100Q�63    6C   �� *name+6^     5      $
 По батькові��6%   $	 150Q�6:    6J   �� *
lastname+6i     5      $
 Пiдроздiл��6%   $	 150Q�68    6H   �� *
department+6i     5      $
 Посада��6%   $	 150Q�65    6E   �� *
position+6d     5      $/
 )Дата прийому на роботу��6%   $	 150Q�6E    6T   �� *employment_date+6z   5      �� 5   
   $��1��6   $��5q�6%   $��2��60   .+�5       �� -   5         ��Name$ button_createNew��5       $��
0,12,10,10q�5!      $��75��5"      $��Right=�5#      $	��250��5$      $��50��6!   ���	#FFFAFFFF
���   �.��5&      �� $)��#Новий співробітник��6    �� TextAlignment$ Center=�66   $��28(�6N   $
��Wrap=�6\   $��0q�6p   6   5'      �� 5(      -   5        $ button_edit��5(      $��
0,12,10,10q�5)      $��75��5*      $��Right=�5+      ���	#FFFAFFFF
���   �$	��250��5,      $��50��6!   .��5.      �� $��Редагувати��6   $ Center=�6.   $��28(�6F   $
��Wrap=�6T   $��0q�6h   6w   5/      �� 50      -   5        $ button_delete��50      $��
0,12,10,10q�51      $��75��52      $��Right=�53      ���	#FFFFE5E5
���   �$	��250��54      $��50��6!   .��56      �� $��Видалити��6   $ Center=�6,   $��28(�6D   $
��Wrap=�6R   $��0q�6f   6u   57      �� 58      -   5        $ button_debug��58      $��
0,12,10,10q�59      $��75��5:      $��Right=�5;      ���	#FFEEFFFE
���   �$	��250��5<      $��50��5=      $y�	Collapsed=�5?      .��6,   DEBUG5A      �� 5C       �� Orientation$ 
Horizontal=�6   $��
10,10,0,10q�62   .+�5D      (� $��35��6   $��35��6%   .��5E      �� -   5         ��Name$ check_ageSort��5E   c   6}   5F      �� 5G      $��Center=�6   $
��Left=�67   $)��#Сортування за вiком��6R   $��20(�6m   6}   5H      �� 5I      -   5         ��Name$ 
stack_sort��5I      {�.  $��	10,0,0,10q�6?   $ 
Horizontal=�6R   .+�5J      �� -	   5         ��Name$ 	text_from��5J      $��Вiд��6/   $��25(�6:   6J   �� 5K      -
   5         ��Name$ 
textB_from��5K      $��18(�6.   $��35��6<   $��5q�6G   6T   �� 5L      -   5        $ text_to��5L      $
��До��6-   $��25(�67   6G   �� 5M      -   5        $ textB_to��5M      $��18(�6,   $��35��6:   $��5q�6E   6R   �� 5N      -   5        $ btn_updSort��5N      $��3q�6H   
�������.��5O      �� $��Оновити��6    $��21(�6/   6@   5P      5Q      �� 5R      -   5        $ 
stack_find��5R      .+�5S      �� $ 
Horizontal=�6   .+�5T      �� $��Знайти за ��6!   $��10,0,0,0q�63   $
��Left=�6E   $��25(�6`   6p   �� 5U      -   5         ��Name$ combo_findFilter��5U      $	��160��69   $��0,5,5,0q�6E   6X   5V      �� 5W      $ 
Horizontal=�6   .+�5X      �� -   5        $ textB_surSort��5X       �� TextAlignment$ Right=�67   $��Stretch=�6M   $��24(�6j   $��7,7,7,7q�6x   $	��186��6�   6�   �� 5Y      -   5        $ btn_findSur��5Y      $
��Left=�6L   $��5q�6g   
�������$��34��6�   .��5Z      �� $��Знайти��6$   $��20(�62   6B   5[      5\      5]      �� 5_      -   5        $ 
text_found��5_   /   $y�	Collapsed=�6   $��Знайдено: ��6C   $��10,0,0,0q�6U   $
��Left=�6g   $��25(�6�   6�   5`      �� 5a   
   $ 
Horizontal=�6   $��1��6.   $��5q�6;   .+�5b      �� $
��Left=�6   $��Center=�63   $��Сотрудникiв:��6N   $��25(�6b   6r   �� 5c      -   5        $ 
text_total��5c       �� 
IsReadOnly . $
��Left=�6<   $ Right=�6W   $��Stretch=�6m   $��0��6�   $��24(�6�   $��75��6�   $��7q�6�   6�   �� 5d      $
��Left=�6   $��Center=�63   $��Чоловiкiв:��6N   $��25(�6`   6p   �� 5e      -   5        $ 	text_male��5e       . $
��Left=�6;   $ Right=�6V   $��Stretch=�6l   $��0��6�   $��24(�6�   $��75��6�   $��7q�6�   6�   �� 5f      $
��Left=�6   $��Center=�63   $��
Жiнок:��6N   $��25(�6\   6l   �� 5g      -   5        $ text_female��5g       . $
��Left=�6=   $ Right=�6X   $��Stretch=�6n   $��0��6�   $��24(�6�   $��75��6�   $��7q�6�   6�   �� 5h      $��Right=�6   $ Right=�64   $��Center=�6J   $��На таблицi:��6e   $��25(�6x   �� 5i      -   5        $ text_currentCount��5i       . $
��Left=�6C   $ Right=�6^   $��Stretch=�6t   $��0��6�   $��24(�6�   $��75��6�   $��7q�6�   6�   5j      5k      5l      