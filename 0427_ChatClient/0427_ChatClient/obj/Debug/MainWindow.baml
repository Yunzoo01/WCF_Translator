   M S B A M L   `   `   `  ����J  F0427_ChatClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:_0427_ChatClient_0427_ChatClient  5   	   !    _0427_ChatClient.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:_0427_ChatClient     5   	   -   5        $��
mainwindow��5   	     � Title$  	채팅창��5	   	   $	��550��6   $	��400��6"    � 
ResizeMode$ NoResize=�6.   .��5
      ]� .+�5   
   �� $
��Left=�6   .+�5      ��  �� Orientation$ 
Horizontal=�6   
�������$
��Left=�6J   $	��400��6e   .+�5      �� $��5q�6   $��80��6#   .��60   my name(_N):6>   �� 5      -   5        $��nickname��5      $	��140��6*   $��5q�66   �� 5      -   5        $
��Join��5      $��	로그인��6%   $��5q�63   $��60��6>   6I   �� 5      -   5        $��Leave��5      $��로그아웃��6&   $��5q�65   $��60��6@   6K   5      �� 5      $ 
Horizontal=�6   
�������$
��Left=�6J   $	��400��6e   .+�5      �� $��5q�6   $��80��6#   .��61   send to(_N):6?   �� 5      -   5        $��sendto_name��5      $	��140��6-   $��5q�69   �� 5      -   5        $
��File��5      $��파일전송��6%   $��5q�64   $��60��6?   6J   �� 5      -   5        $��	translate��5      $��번역 기능��6*   $��5q�6:   $��60��6E   6P   5      �� 5      -   5        $��chatlist��5      $	��400��6&   $	��390��63   $��5q�6?   $
��Left=�6J   �� 5      $ 
Horizontal=�6   
�������$
��Left=�6J   $	��400��6e   .+�5      �� -	   5        $��msgbox��5      $��5q�6(   $	��310��63   �� 5      -
   5        $
��send��5      $��전송��6%   $��5q�62   $��60��6=   6H   5       5!      � 5#   
   $��Right=�6   5(      5.      51      