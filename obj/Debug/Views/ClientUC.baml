   M S B A M L   `   `   `  ����L  HChatAppServerSide, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:ChatAppServerSide.ViewsChatAppServerSide.Views  5      &     ChatAppServerSide.Views.ClientUC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:ChatAppServerSide.Views     5      $	��0,4q�5        � Cursor$
  Hand��5	       J� InputBindings 5
      d� 5   
    d� Gesture$ 	LeftClicka�6    �� Command 6+   �� *MessageToClientCommand+6X   .��5      ��  �� Padding$	 0 8q�6   ��5   
   �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value$ 4q�5      �� 5       � ��
 ���� 5       �� Triggers 5      P� 5      	 P� Property	 �@J�IsMouseOver
 P� Value
 . . �5      ��  � �� �#F1EFFB5   !   �� 5       � �� �#6F52F95   !   5      �� 5       �� Binding 6"   �� *Client.Connected+ �� Value True5    "   .a�5!      ��  � �� �#F1EFFB5"   !   �� 5#       � ��
 � � �5$   !   5%      �� 5'       6"   �� *Client.Connected+	 False5(   "   .a�5)      ��  � �� �#F1EFFB5*   !   �� 5+       � ��
 �  ��5,   !   5-      5/      ._�52   
   �  � ColumnDefinitions 53      �� 54      $
��auto �6#   �� 55      $	��180 �6#   �� 56      $��* �6#   .+�59      �� 
������� �� CornerRadius$ 50��5:      $��43��5;      $��43��5<      $��0 0 0 0q�5=      ._�5?      � .+�5@      A� ��5A      �� 5B       �� ImageSource$ \Assets\user.jpeg��6)    j� Stretch$ Uniform=�6I   5D      5E      5F      �� 5H      $��Center=�6   $��1��5I      $��5 0 0 0q�5J      .+�5K      �� ���#212121$
��Wrap=�5M      $��14(�5N      $��SemiBold"�5O      ��5K      �� *ClientHostName+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5P      5Q      �� 5S      $ 50��6   $��20��5T      $��20��5U      $��2��5V      y�5W      ��  �� Path$ Visible� �� ElementName$
 item����5X      �� $ Color�$
 item��._�5Y      �� $��Center=�5Z      $��Center=�5[      ���#ffffff��5Y      �� $ MessageCount�$
 item��5\      5]      5_      5`      5a      