   M S B A M L   `   `   `  ����  NST_Test_Task    WpfApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Function Calculator��5   	   $	��450��6%   $	��600��62   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��10q�6;   .+�5      �� $��Коэффицент a: ��6   $��Center=�6.   �� 5      $	��100��6u   $��Center=�6�   ��6   �� *CoefficientA+ �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnDataErrors . 6�   �� 5      $��Коэффицент b: ��6   $��Center=�6.   $��20,0,0,0q�6I   �� 5      $	��100��6u   $��Center=�6�   ��6   �� *CoefficientB+$ PropertyChanged=� . 6�   5      �� 5   
   $��1��6   $ 
Horizontal=�6"   $��10q�6;   .+�5      �� $'��!Выберите функцию: ��6   $��Center=�62   �� 5      $	��150��6j   $��10,0,0,0q�6v   ��6   �� *FunctionTypes+ �� SelectedItem 6<   �� *SelectedFunctionType+5      �� 5      $��Коэффицент c: ��6   $��Center=�6.   $��20,0,0,0q�6I   �� 5      $	��121��6p   $��10,0,0,0q�6|   $��28��6�   ��6   �� *CoefficientCValues+ 6B   �� *SelectedCoefficientC+6�   5      &   System.Windows.Controls.DataGrid  5   
   $��2��6   $��10q�6H      AutoGenerateColumns .     CanUserAddRows . ��6    �� *FunctionResults+   Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn	   Header$	 X��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 6F   1  +System.Windows.Controls.DataGridBoundColumn   Binding 60   �� *X+6F     5"      $	 Y��6%   $
 * 6F    60   �� *Y+6F     5#      $	 f(x,y)��6%   $
 * 6P      
IsReadOnly .  65   �� *Result+6Z   5%      �� 5'   
   $��3��6   $#��Добавить строку��6   $	��100��68   $��10q�6D   ��5(      �� *AddRowCommand+5)      5*      