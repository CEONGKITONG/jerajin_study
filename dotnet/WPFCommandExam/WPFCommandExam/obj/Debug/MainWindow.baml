   M S B A M L   `   `   `  ����I  EWPFCommandExam, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WPFCommandExamWPFCommandExam  5   	       WPFCommandExam.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:WPFCommandExam     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � DataContext 5
      (  "WPFCommandExam.MainWindowViewModel  5   
   .��5      �� .+�5   
   �� " 사원 이름을 입력하세요6"   �� 5   
   -   5         ��Name$ txtName��5      ��6#   �� *SelectedEmp.Ename+�� 5   
   ��6   �� *AddEmpCommand+��5      �� *Text+ �� ElementName$ txtName��.��6H   Add6M   �� 5   
   -   5         ��Name$ 
empListBox��5       �� DisplayMemberPath$ Ename��5      ��5      �� *Emps+ �� SelectedItem 5      �� *SelectedEmp+5      �� 5   
   -   5         ��Name$ label��5      $��Center=�5      $��40��5      $��10,0,0,0q�5      $	��137��6"   ��5      �� *SelectedEmp+$ 
empListBox��5   "   5      5      