   M S B A M L   `   `   `  ����C  ?TopicWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:TopicWPFTopicWPF  5   	       TopicWPF.TopicList   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:TopicWPF     5   	     � Title$  	TopicList��5   	   $	��450��6   $	��800��6(   $��	Helvetica)�64   
������� � 	Resources 5         TopicCollection �� Source �� Path��%C   &	        �� 5   
    5      �� $ 	TopicList�5      5      .��5      � $	��421��6   $��0,0,0.333,-0.333q�6   $��Bottom=�62    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $	��37* �6   �� 5      $	��55* �6   �� 5      $	��35* �6   �� 5      $	��70* �6   �� 5      $
��539* �6    � RowDefinitions 5!   
   �� 5"      $
��Auto �6   �� 5#      $��* �6   �� 5$      $
��Auto �6   .+�5'   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridView1��5-      $��6��5(      
�������   AutoGenerateColumns .     SelectionMode$ Single=�5/      	   SelectionUnit$	 FullRow=�50      
   GridLinesVisibility$
 
Horizontal=�51         CanUserDeleteRows .     CanUserAddRows .     CanUserResizeRows .  $	��324��58      $��2��6   $��Bottom=�59      ��5,      ��  �� Source# [     Columns 5;      0  *System.Windows.Controls.DataGridTextColumn  5<      -   5        ID��,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 40 5<   M      Header$ ID��6X   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� $ ID�6X     5=      -   5        FullName��$	 100 5=   Y   $
 Name��6e    67   �� $ FullName�6e     5>      -   5        	Title��$	 250 5>   S   $ Title��6_    64   �� $ Title�6_     5?      -   5        Text��$	 350 5?   Q   $
 Text��6]    63   �� $
 Text�6]      	CellStyle 5B      �� 5C       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6    �� Triggers 5D      P� 5E       P� Property �@ 
IsSelected P� Value . . �5F      ��  �� Property � �� �� Value$ 0q�6@   5G      5I      5K      �� 5M   
    �� Orientation$ 
Horizontal=�6   $��2��6.   $��2��6;   $��Center=�6K   $��51.333,0,87.762,-0.333q�6h   $��6��6�   .+�5N      �� -   5         ��Name$ btnAdd��5N   T   $
��Add ��6   $��75��6$   $��20��6/   
������ $��20q�6d   6q   �� 5P      -   5        $ 	btnDelete��5P   W   $��Delete ��6   $��75��6'   $��20��62   
������ $��20q�6j   6w   �� 5Q      -   5        $
��Find��5Q      $��20��6%    �� IsCancel . 
������ $��75��6[   $��20q�6f   6r   �� 5R      -	   5        $��LogOut��5R      $��75��6&   $��20��61   
������ $��20q�6n   �� 5S      -
   5        $��Cancel��5S      $��20��6'    . 
������ $��75��6]   $��20q�6h   6t   5U      5W      5X      