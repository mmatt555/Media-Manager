   M S B A M L   `   `   `  ����   MediaManager    MediaManager.SplashScreen   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -     >�Name$  UserControl��$	��902��$	��512�� � 	Resources    	MovButton �� 
TargetType �� Property �� Value �� 
TargetType ��Name J� SnapsToDevicePixels �� Triggers	 P� Property
 P� Value 
 BTFade g� 	BeginTime �� TargetProperty9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  BTUnfade  TVButton  TvButtonFocused �� RadiusX �� RadiusY  MovButtonFocused�� %W  &	        &	 -    &	 �    &	 �    &	 &    &	      �� " ��.���  � �� �� " ��.R�� .+��� $ 	MovButton��$9��3/MediaManager;component/Screen1Images/MovButton.png���� #��z����. # z #��z�� P� 	 �@J�	IsFocused
 . P� 	 �@��IsDefaulted
 . P� 	 �@J�IsMouseOver
 . P� 	 � ��
 . P� 	 � {�
 .  �� .��U� $ 00:00:00X�$ Opacity�.\�  $ 00:00:00��$	 100Q�  $ 00:00:02��$ 0Q��� .��U� $ 00:00:00X�$ Opacity�.\�  $ 00:00:00��$ 0Q�  $ 00:00:00��$	 100Q��� " ��.���  � �� �� " ��.R�� .+��� $ TVButton��$8��2/MediaManager;component/Screen1Images/TVButton.png���� #��z����. # z #��z�� P� 	 �@J�	IsFocused
 . P� 	 �@��IsDefaulted
 . P� 	 �@J�IsMouseOver
 . P� 	 � ��
 . P� 	 � {�
 .  �� " ��.���  � �� �� " ��.R�� $	��291��$��98��.+��� $��Stretch=�$
��Auto��$��0q�$8��2/MediaManager;component/Screen1Images/TVButton.png��$
��Fill=�$��Stretch=�$
��Auto���� 
���  ��$��3��$ 5��$ 5����Z� �� " ��.���  � �� �� " ��.R�� $	��291��$��98��.+��� $��Stretch=�$
��Auto��$��0q�$9��3/MediaManager;component/Screen1Images/MovButton.png��$
��Fill=�$��Stretch=�$
��Auto���� 
���  ��$��3��$ 5��$ 5����Z� .��� -    �Name$ 
LayoutRoot��.+��� -    ��Name$ MainArt��}�. $
��Left=�$	��512�� � UseLayoutRounding .  $	��Top=�$	��902��.+��� -    ��Name$ 	MovButton��$�� ��$��98�� �� Left$ 99��#���   
 �� Top$	 210��$	��291���� -   $ MovBTShadow��$��99��$ 11��$;��5/MediaManager;component/Screen1Images/MovBTShadow.png��$	 310��$	��379���� -   $ MovBTShadOutline��$��88��$ 37��$@��:/MediaManager;component/Screen1Images/MovBTShadOutline.png��$	 310��$	��353��$y�Hidden=��� -   $ TVBTShad��$��85��$	 512��$8��2/MediaManager;component/Screen1Images/TVBTShad.png��$	 310��$	��364���� -   $ TVBTShadOutline��$��85��$	 512��$?��9/MediaManager;component/Screen1Images/TVBTShadOutline.png��$	 310��$	��364��$y�Hidden=��� -	   $ 	Underline��$��3��$ 99��$9��3/MediaManager;component/Screen1Images/Underline.png��$	 104��$	��412�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 5Q�   Color$ 	#FF000000��   	Direction$	 -60Q�   Opacity$
 0.75Q�   ShadowDepth$ 5Q��� -
   $ MainText��$��65��$ 99��$8��2/MediaManager;component/Screen1Images/MainText.png��$ 52��$	��425��   $ 5Q�$ 	#FF000000��$	 -60Q�$
 0.75Q�$ 5Q��� -   $ TvButton��$�� ��$��98��$	 513��#���  $	 210��$	��291��$��30,96,42,82q� � FocusVisualStyle# �  ��Z� ����  �� EndPoint$	 0,1&� �� 
StartPoint$	 0,0&�.���   � Color$  	#FFF3F3F3��! � Offset$! 0Q�� $  	#FFEBEBEB��$	! 0.5Q�� $  	#FFDDDDDD��$	! 0.5Q�� $  	#FFCCCCCC��$! 1Q�