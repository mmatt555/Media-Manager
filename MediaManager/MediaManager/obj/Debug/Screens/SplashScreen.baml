   M S B A M L   `   `   `  ����  MediaManager    MediaManager.SplashScreen   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      -   5          >�Name$  UserControl��5      $	��902��5	   +   $	��512��67    � 	Resources 5
         	MovButton �� 
TargetType �� Property �� Value �� 
TargetType ��Name J� SnapsToDevicePixels �� Triggers	 P� Property
 P� Value 
 BTFade g� 	BeginTime �� TargetProperty9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  BTUnfade  TVButton  TvButtonFocused �� RadiusX �� RadiusY  MovButtonFocused�� 5      %	  &	        &	     &	 �    &	 x    &	 x    &	 %    �� 5      " ��6   .�5      ��  � �� 5      �� 5      " ��6   .R�5   	   � .+�5   
   �� $ 	MovButton��6   $9��3/MediaManager;component/Screen1Images/MovButton.png��6#   �� 5   
   #��z��6   ��. # z 6y   #��z��6�   5   
    5   	   P� 5   
   	 �@J�	IsFocused
 . 6'   P� 5   
   	 �@��IsDefaulted
 . 6)   P� 5   
   	 �@J�IsMouseOver
 . 6)   P� 5   
   	 � ��
 . 6'   P� 5   
   	 � {�
 .  6'   5   	   5      5      �� 5      .��5       U� $ 00:00:00X�6$   $ Opacity�69   .\�5!        $ 00:00:00��6   $	 100Q�6/     5"      $ 00:00:02��6   $ 0Q�6/   5#      5$      �� 5%      .��5&      U� $ 00:00:00X�6$   $ Opacity�69   .\�5'        $ 00:00:00��6   $ 0Q�6/     5(      $ 00:00:00��6   $	 100Q�6/   5)      5*      �� 5,      " ��6   .�5-      ��  � �� 5.      �� 5/      " ��6   .R�50   	   � .+�51   
   �� $ TVButton��6   $8��2/MediaManager;component/Screen1Images/TVButton.png��6"   �� 52   
   #��z��6   ��. # z 6y   #��z��6�   53   
    54   	   P� 55   
   	 �@J�	IsFocused
 . 6'   P� 56   
   	 �@��IsDefaulted
 . 6)   P� 57   
   	 �@J�IsMouseOver
 . 6)   P� 58   
   	 � ��
 . 6'   P� 59   
   	 � {�
 .  6'   5;   	   5=      5>      �� 5?      " ��6#   .�5@      ��  � �� 5A      �� 5B      " ��6   .R�5C   	   � $	��291��6   $��98��6   .+�5D   
   �� $��Stretch=�6   $
��Auto��6.   $��0q�6<   $8��2/MediaManager;component/Screen1Images/TVButton.png��6G   $
��Fill=�6�   $��Stretch=�6�   $
��Auto��6�   �� 5E   
   
���  ��$��3��61   $ 5��6E   $ 5��6Q   ��6   Z� 6Q   5F   
   5G   	   5I      5J      �� 5K      " ��6$   .�5L      ��  � �� 5M      �� 5N      " ��6   .R�5O   	   � $	��291��6   $��98��6   .+�5P   
   �� $��Stretch=�6   $
��Auto��6.   $��0q�6<   $9��3/MediaManager;component/Screen1Images/MovButton.png��6G   $
��Fill=�6�   $��Stretch=�6�   $
��Auto��6�   �� 5Q   
   
���  ��$��3��61   $ 5��6E   $ 5��6Q   ��6   Z� 6Q   5R   
   5S   	   5U      5V      5W      .��5Z      � -   5         �Name$ 
LayoutRoot��5Z      .+�5[      �� -   5         ��Name$ MainArt��5[      }�. $
��Left=�60   $	��512��6K    � UseLayoutRounding .  $	��Top=�6r   $	��902��6�   .+�5\      �� -   5         ��Name$ 	MovButton��5\      $�� ��6   $��98��6*    �� Left$ 99��66   #���   6G   
 �� Top$	 210��6k   $	��291��6|   6�   �� 5]      -   5        $ MovBTShadow��5]      $��99��6    $ 11��6,   $;��5/MediaManager;component/Screen1Images/MovBTShadow.png��6=   $	 310��6|   $	��379��6�   �� 5^      -   5        $ MovBTShadOutline��5^      $��88��6%   $ 37��61   $@��:/MediaManager;component/Screen1Images/MovBTShadOutline.png��6B   $	 310��6�   $	��353��6�   $y�Hidden=�6�   �� 5_      -   5        $ TVBTShad��5_      $��85��6   $	 512��6)   $8��2/MediaManager;component/Screen1Images/TVBTShad.png��6;   $	 310��6w   $	��364��6�   �� 5`      -   5        $ TVBTShadOutline��5`      $��85��6$   $	 512��60   $?��9/MediaManager;component/Screen1Images/TVBTShadOutline.png��6B   $	 310��6�   $	��364��6�   $y�Hidden=�6�   �� 5a      -	   5        $ 	Underline��5a      $��3��6   $ 99��6)   $9��3/MediaManager;component/Screen1Images/Underline.png��6:   $	 104��6w   $	��412��6�    J� Effect 5b      3  -System.Windows.Media.Effects.DropShadowEffect  5c         
BlurRadius$ 5Q�6      Color$ 	#FF000000��6'      	Direction$	 -60Q�69      Opacity$
 0.75Q�6I      ShadowDepth$ 5Q�6X   5e      �� 5f      -
   5        $ MainText��5f      $��65��6   $ 99��6)   $8��2/MediaManager;component/Screen1Images/MainText.png��6:   $ 52��6v   $	��425��6�    5g        5h      $ 5Q�6   $ 	#FF000000��6'   $	 -60Q�69   $
 0.75Q�6I   $ 5Q�6X   5j      �� 5k      -   5        $ TvButton��5k      $�� ��6   $��98��6)   $	 513��65   #���  6G   $	 210��6j   $	��291��6{   $��30,96,42,82q�6�    � FocusVisualStyle# �  6�   ��6�   Z� ��5l      �� 5m       �� EndPoint$	 0,1&�6    �� 
StartPoint$	 0,0&�6*   .��5n      �   � Color$  	#FFF3F3F3��6   ! � Offset$! 0Q�6'   � 5o      $  	#FFEBEBEB��6   $	! 0.5Q�6'   � 5p      $  	#FFDDDDDD��6   $	! 0.5Q�6'   � 5q      $  	#FFCCCCCC��6   $! 1Q�6'   5r      5t      5u      5v      5w      