   M S B A M L   `   `   `  ���� U  QHuman Resources Department, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Human_Resources_DepartmentHuman_Resources_Department  0    *Human_Resources_Department.EducationWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     :local(clr-namespace:Human_Resources_Department     -     � Title$  Освiта��$��477.391��$
��1280�� � 	Resources  �� 
TargetType 
  Text_1 �� Property �� Value 
 Text_2  	TextBox_1��%�  &	        &	 �     &	 /    �� " ��.���  �@��TextAlignment$ Right=���  � ��$ 18(���  � ��$
 Wrap=���  � ��$ Center=���  � ��$ 0,0,5,0q��� " ��.���  � ��$ 0,0,5,5q���  � ��$ Bottom=���  �@��TextAlignment$ Center=���  � ��$ 18(���  � ��$
 Wrap=��� " ��.���  � ��$ 5,7,10,4q���  �@��TextWrapping$
 Wrap=�.���  � RowDefinitions �� $
��274* ��� $	��41* ��� $	��45* ��� $	��45* ��� $	��41* � � ColumnDefinitions �� $
��240* ��� $
��407* ��� $
��210* ��� $
��409* ��� $��6* �.+�&   System.Windows.Controls.DataGrid  -     Name$ EducationGrid��$��5,5,10,5q�   
IsReadOnly . 	   SelectionMode$	 Single=�$��1��$��2��
   Columns
 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$3 -Назва освiтнього закладу��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 250 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *UniversityName+  $< 6Диплом(свiдоцтво), серiя, номер��$	 300  �� *DiplomaName+  $ Рiк закiнчення�� �� *Year+�� #��[  $��Center=�$��1��$3��-Назва освiтнього закладу��$��5,8,5,9q�$��24���� #��[  $<��6Диплом(свiдоцтво), серiя, номер��$��2�� �� TextAlignment$ Right=�$��16(�$��0,1,5,2q�$��42���� #��[  $��Рiк закiнчення��$��3��$��0,12,5,9q�$��24���� -    ��Name$ 
text_uName��#��[  �� 	MaxLength$	 150��$��Light"�$��14(�$��Center=�$��1��$��1��$��5q�$��31���� -   $ 
text_dName��#��[ $	 150��$��Light"�$��12(�$��1��$��2��$��5,7,2,4q��� -   $ 	text_year��#��[ $ 4��$��Light"�$��23(�$��1��$��3��$
��Left=�$��75��$��5,7,0,4q��� $��158,5,159,5q� �� Orientation$ 
Horizontal=�$��4��$��2��$��Center=�$	��330��.+��� -    ��Name$ btn_addA��$	��100��$��5,0,5,0q����	#FFD7FFD0.���� $��Додати��$��16(�$��Center=�$��	15,0,15,0q��� -   $ 	btn_editA��$	��100��$��5,0,5,0q����	#FFFFFDD4.���� $��Редагувати��$��13(�$��	15,0,15,0q��� -   $ btn_removeA��$	��100��$��5,0,5,0q����	#FFFFE2E2.���� $��Видалити��$��13(�$��	15,0,15,0q�  -	   $ ProfessionGrid��$��2��$��10,5,2,5q� . $	 Single=�$��1��$��2��
   $3 -Назва освiтнього закладу��$	 200  �� *
Profession+  $< 6Диплом(свiдоцтво), серiя, номер��$	 300  �� *Qualification+  $! Форма навчання�� �� *	StudyForm+�� #��[  $��Center=�$��Спецiальнiсть��$��2��$��0,9,5,8q�$��24��$��1���� #��[  $��Center=�$��Квалiфiкацiя��$��2��$��2��$ Right=�$��16(�$��	0,11,5,12q�$��22���� #��[  $��Center=�$!��Форма навчання��$��2��$��3��$��0,12,5,9q�$��24���� -
   $ text_profession��#��[ $	 150��$��Light"�$��18(�$��Center=�$��3��$��1��$��5q�$��31���� -   $ text_qualification��#��[ $	 150��$��Light"�$��23(�$��3��$��2��$��5,7,2,4q��� -    ��Name$ combo_studyForm��$��3��$��3��$
��Left=�$	��180��$��7,7,0,7q��� $��145,5,144,5q�$ 
Horizontal=�$��4��$��2��$��2��$��Center=�$	��330��.+��� -   $ btn_addB��$	��100��$��5,0,5,0q����	#FFD7FFD0.���� $��Додати��$��16(�$��Center=�$��	15,0,15,0q��� -   $ 	btn_editB��$	��100��$��5,0,5,0q����	#FFFFFDD4.���� $��Редагувати��$��13(�$��	15,0,15,0q��� -   $ btn_removeB��$	��100��$��5,0,5,0q����	#FFFFE2E2.���� $��Видалити��$��13(�$��	15,0,15,0q�