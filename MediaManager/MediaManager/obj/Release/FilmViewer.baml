   M S B A M L   `   `   `  ���� a  ]PresentationFramework.Aero, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35gJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.AeroMicrosoft.Windows.Themes   MediaManager   MediaManager.FilmViewer   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     oMicrosoft_Windows_ThemesJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -     �Name$  Window�� � Title$ 
FilmViewer��$	��640��$	��480�� � AllowsTransparency .  � WindowStyle$
 None=���Z� ��Z�  � 	Resources    FilmViewerTitleEntry �� TargetProperty �� 
TargetName8  2System.Windows.Media.Animation.EasingColorKeyFrame �� KeyTime �� Value9  3System.Windows.Media.Animation.EasingDoubleKeyFrame	 O� KeyTime
 O� Value  TextBoxBorder �� EndPoint � MappingMode �� 
StartPoint � Color � Offset  TextBoxStyle �� 
TargetType �� BasedOn �� Property �� Value �� 
TargetType,   &Microsoft.Windows.Themes.ListBoxChrome  Name   BorderThickness J� IsMouseOver   RenderMouseOver J� IsKeyboardFocusWithin   RenderFocused J� SnapsToDevicePixels   
Background J� Opacity ��Name �� Triggers  P� Property! P� Value" �� 
TargetName  FilmViewerAllElse  ButtonFocusVisual# �� StrokeDashArray  ButtonNormalBackground  ButtonNormalBorder$ �� Color  ButtonClose+   %Microsoft.Windows.Themes.ButtonChrome%  Name&   BorderBrush'   
Background(   RenderMouseOver)   RenderPressed* �� IsDefaulted+   RenderDefaulted  ClosebtnStyle 	 ClosebtnFocusStyle 
 btnWatchFilmStyle, ��Name  btnUpdateFilmStyle  btnDeleteFilmStyle  btnDeleteFilmFocussedStyle  btnWatchFilmFocussedStyle  btnUpdateFilmFocussedStyle��%_  &	        &	 �    &	 $    7  &	 X    &	 �    &	     &	 �    &	 �    7  7  7  &	 �    &		 �    &	
 Z    &	 ^    &	 `    &	 �    &	 X    &	 0    �� .���� $T N(TextElement.Foreground).(GradientBrush.GradientStops)[0].(GradientStop.Color)�$ txTitle��.g�  $ 0��$ Transparent��  $ 0:0:0.3��$ sc#0.36, 1, 1, 1��  $ 0:0:0.6��$ sc#0.655, 1, 1, 1��  $ 0:0:0.9��$ White���� $T N(TextElement.Foreground).(GradientBrush.GradientStops)[1].(GradientStop.Color)�$ txTitle��.g�  $ 0��$ Transparent��  $ 0:0:0.3��$ Transparent��  $ 0:0:0.6��$ Transparent��  $ 0:0:0.9��$ Transparent��  $ 0:0:1.2��$ 	#15FFFFFF��  $ 0:0:1.4��$ 	#15FFFFFF��  $ 0:0:1.7��$ 	#85FFFFFF��  $ 0:0:2��$ 	#E2FFFFFF���� $T N(TextElement.Foreground).(GradientBrush.GradientStops)[2].(GradientStop.Color)�$ txTitle��.g�  $ 0��$ Transparent��  $ 0:0:0.3��$ sc#0.07, 1, 1, 1��  $ 0:0:0.6��$ sc#0.445, 1, 1, 1��  $ 0:0:0.9��$ sc#0.725, 1, 1, 1��  $ 0:0:1.2��$ White���� $T N(TextElement.Foreground).(GradientBrush.GradientStops)[3].(GradientStop.Color)�$ txTitle��.g�  $ 0��$ Transparent��  $ 0:0:0.3��$ Transparent��  $ 0:0:0.6��$ 	#18FFFFFF��  $ 0:0:0.9��$ 	#60FFFFFF��  $ 0:0:1.2��$ 	#90FFFFFF��  $ 0:0:1.4��$ White��U� $U O(TextElement.Foreground).(GradientBrush.GradientStops)[4].(GradientStop.Offset)�$ txTitle��.\�  $	 0��$
 0.431Q�  $	 0:0:0.3��$
 0.405Q�U� $U O(TextElement.Foreground).(GradientBrush.GradientStops)[5].(GradientStop.Offset)�$ txTitle��.\�  $	 0��$

 0.56Q��� $T N(TextElement.Foreground).(GradientBrush.GradientStops)[5].(GradientStop.Color)�$ txTitle��.g�  $ 0��$ Transparent��  $ 0:0:0.3��$ Transparent��  $ 0:0:0.6��$ 	#08FFFFFF��  $ 0:0:0.9��$ 	#21FFFFFF��  $ 0:0:1.2��$ 	#64FFFFFF��  $ 0:0:1.4��$ 	#95FFFFFF��  $ 0:0:1.7��$ White���� $T N(TextElement.Foreground).(GradientBrush.GradientStops)[4].(GradientStop.Color)�$ txTitle��.g�  $ 0��$ Transparent��  $ 0:0:0.3��$ Transparent��  $ 0:0:0.6��$ 	#0AFFFFFF��  $ 0:0:0.9��$ 	#48FFFFFF��  $ 0:0:1.2��$ 	#89FFFFFF��  $ 0:0:1.4��$ White��U� $U O(TextElement.Foreground).(GradientBrush.GradientStops)[6].(GradientStop.Offset)�$ txTitle��.\�  $	 0��$
 0.716Q�  $	 0:0:0.3��$

 0.75Q��� $T N(TextElement.Foreground).(GradientBrush.GradientStops)[6].(GradientStop.Color)�$ txTitle��.g�  $ 0��$ Transparent��  $ 0:0:0.3��$ Transparent��  $ 0:0:0.6��$ Transparent��  $ 0:0:0.9��$ 	#07FFFFFF��  $ 0:0:1.2��$ 	#61FFFFFF��  $ 0:0:1.4��$ 	#9BFFFFFF��  $ 0:0:1.7��$ 	#D9FFFFFF��  $ 0:0:2��$ White��U� $U O(TextElement.Foreground).(GradientBrush.GradientStops)[7].(GradientStop.Offset)�$ txTitle��.\�  $	 0��$
 0.858Q��� $T N(TextElement.Foreground).(GradientBrush.GradientStops)[7].(GradientStop.Color)�$ txTitle��.g�  $ 0��$ Transparent��  $ 0:0:0.3��$ Transparent��  $ 0:0:0.9��$ Transparent��  $ 0:0:1.2��$ 	#14FFFFFF��  $ 0:0:1.4��$ 	#53FFFFFF��  $ 0:0:1.7��$ 	#9FFFFFFF��  $ 0:0:2��$ White���� $
 0,20&�$ Absolute=�$	 0,0&�.��� $ #ABADB3��$
 0.05Q�� $ #E2E3EA��$
 0.07Q�� $ #E3E9EF��$ 1Q��� " �� Z� .���  � ��# � ����  � ��# � ����  � ��8   ��  � ��$ 1q���  � ��$ 1q���  �@J�	AllowDrop . ��  �@�FocusVisualStyle Z� ��  �@��PanningMode$ VerticalFirst=���  �@��IsFlicksEnabled .  ��  � �� �� " ��.R�  $ Bd��# z��# z # z  .  �	#2A626262$ 1Q�$��	16,0,20,0q�._��� $ PART_ContentHost��# z ���	#00000000
���   �$��Center=�$��Center=� P�   � {�! .  . ��� $" Bd��# � �� �@ 
Background�� # � �� � ���� .��U� $ (UIElement.Opacity)�$ 
film_Image��.\��� $	 0��$
 0Q��� $	 0:0:2��$
 0Q��� $	 0:0:2.5��$
 1Q�U� $ (UIElement.Opacity)�$ 	film_Name��.\�  $	 0��$
 0Q�  $	 0:0:2��$
 0Q�  $	 0:0:2.5��$
 1Q�U� $ (UIElement.Opacity)�$ film_Release��.\�  $	 0��$
 0Q�  $	 0:0:2��$
 0Q�  $	 0:0:2.5��$
 1Q�U� $ (UIElement.Opacity)�$ film_Rating��.\�  $	 0��$
 0Q�  $	 0:0:2��$
 0Q�  $	 0:0:2.5��$
 1Q�U� $ (UIElement.Opacity)�$ 	film_Plot��.\�  $	 0��$
 0Q�  $	 0:0:2��$
 0Q�  $	 0:0:2.5��$
 1Q�U� $ (UIElement.Opacity)�$ film_Genres��.\�  $	 0��$
 0Q�  $	 0:0:2��$
 0Q�  $	 0:0:2.5��$
 1Q�U� $ (UIElement.Opacity)�$ RecReflection��.\�  $	 0��$
 0Q�  $	 0:0:2��$
 0Q�  $	 0:0:2.5��$
 1Q��� .���  � �� �� .R��� $��2q� . #��� ��$��1��$	# 1 2R��� $	 0,1&�$	 0,0&�.��� $ #F3F3F3��$ 0Q�� $ #EBEBEB��$	 0.5Q�� $ #DDDDDD��$	 0.5Q�� $ #CDCDCD��$ 1Q��� $$ 	#FF707070���� " ��.���  �@�FocusVisualStyle8   ��  � ��8  ��  � ��8  ��  � ��$ 1q���  � ��# � ����  � ��$ Center=���  � ��$ Center=���  � ��$ 1q���  � �� �� " ��.R�  $% Chrome��#& z��#' z��#( z #) z��#+ z*  . ._��� #��z��#��z����. # z #��z�� P�   �@J�IsKeyboardFocused! . . ��� $" Chrome�� �@ RenderDefaulted . P�   �@d�	IsChecked$
! trueY�. ��� $" Chrome�� �@ RenderPressed . P�   � {�! .  . ���  � �� �#ADADAD�� " ��.���  � �� �� " ��.R�� .+��� $ ��Screen1Images/CloseBtn.png��$
��Fill=� P�   �@J�	IsFocused! . P�   �@��IsDefaulted! . P�   �@J�IsMouseOver! . P�   � ��! . P�   � {�! .  �� " ��.���  � �� �� " ��.R�� .+��� $��0,0,-1.996,-1.996q�$(��"Screen1Images/CloseBtnFocussed.png��$
��Fill=��� " ��.���  � �� �� " ��.R�� .+��� $, cmdWatchFilm��$#��ButtonImages/Watchfilmbtn.png��$
��Fill=� P�   �@J�	IsFocused! . P�   �@��IsDefaulted! . P�   �@J�IsMouseOver! . P�   � ��! . P�   � {�! .  �� " ��.���  � �� �� " ��.R�� .+��� $, cmdUpdateFilm��$ ��ButtonImages/Updatebtn.png��$
��Fill=� P�   �@J�	IsFocused! . P�   �@��IsDefaulted! . P�   �@J�IsMouseOver! . P�   � ��! . P�   � {�! .  �� " ��.���  � �� �� " ��.R�� .+��� $, cmdDeleteFilm��$ ��ButtonImages/Deletebtn.png��$
��Fill=��� " ��.���  � �� �� " ��.R�� .+��� $, cmdDeleteFilm��$(��"ButtonImages/Deletebtnfocussed.png��$
��Fill=��� " ��.���  � �� �� " ��.R�� $	��175��$��30��.+��� $+��%ButtonImages/WatchfilmbtnFocussed.png��$
��Fill=� P�   �@J�	IsFocused! . P�   �@J�IsMouseOver! . P�   � {�! .  �� " ��.���  � �� �� " ��.R�� $	��175��$��30��.+��� $(��"ButtonImages/Updatebtnfocussed.png��$
��Fill=�- � Triggers- :� . :� RoutedEvent$. FrameworkElement.Loaded��.[��� -   / ��Name$*/ $FilmViewerTitleEntry_BeginStoryboard��#��[  �� -   $'/ !FilmViewerAllElse_BeginStoryboard��#��[ .��� -   0 �Name$0 
LayoutRoot��1 � ColumnDefinitions1 �� .+��� -   2 ��Name$2 RecMainBackground��3 �� RadiusY$3 30��4 �� RadiusX$4 30��$��6�����	#FF1B1B1B���� $ 0.5,1&�$ 0.5,0&�.��� $ Black��$ 0Q�� $ 	#FF4E4E4E��$ 1Q�� $ Black��$ 0.642Q�� $ 	#FFA3A3A3��$ 0.806Q����� $ 0.034,0.152&�$ 0.025,0.152&�.��� $ White��$ 0Q�� $ 1Q��� -   5 ��Name$5 txTitle��$��63��$��
31,48,31,0q�$
��Wrap=�$	��Top=�$��48(�$��Sony Sketch EF)�
���   ����� $ 0.994,0.365&�$ 0.003,0.365&�.��� $ 0Q�$ White��� $ 1Q�$ 	#A1FFFFFF��� $ White��$ 0.159Q�� $ White��$ 0.289Q�� $ White��$ 0.496Q�� $ White��$ 0.591Q�� $ White��$ 0.763Q�� $ White��$ 0.849Q��� 6 � Language$6 en-gb�$!�Media Manager - Film Viewer���� -   $, 
film_Image��$��238,145,238,105q�$
��Fill=��� -   7 ��Name$7 	film_Name��$��26��$��100,111,0,0q�8 �� TextWrapping$
8 Wrap=�$*��$Harry Potter And the something stone��$	��Top=�#���  
���   ����	#FFFBFBFB$��Verdana)�$��13.333(�$
��Left=�$	��449��.������ $
 0,20&�$ Absolute=�$	 0,0&�.��� $ 	#FFABADB3��$
 0.05Q�� $ 	#FFE2E3EA��$
 0.07Q�� $ White��$ 1Q�.���� -	   $7 film_Release��$��26��$��517,157,0,0q�$
8 Wrap=�$
��2007��$	��Top=�#���  
����������	#FFFBFBFB$��Verdana)�$��13.333(�$
��Left=�$	��115��.������ $
 0,20&�$ Absolute=�$	 0,0&�.��� $ 	#FFABADB3��$
 0.05Q�� $ 	#FFE2E3EA��$
 0.07Q�� $ White��$ 1Q�.���� -
   $7 film_Rating��$��26��$��406,157,0,0q�$
8 Wrap=�$	��9.0��$	��Top=�#���  
����������	#FFFBFBFB$��Verdana)�$��13.333(�$
��Left=�$	��111��.������ $
 0,20&�$ Absolute=�$	 0,0&�.��� $ 	#FFABADB3��$
 0.05Q�� $ 	#FFE2E3EA��$
 0.07Q�� $ White��$ 1Q�.���� -   $7 	film_Plot��$��22,157,0,218q�$
8 Wrap=�$7��1Harry Potter and the Philosopher's Stone Poster  ��#���  
����������	#FFFBFBFB$��Verdana)�$��13.333(�$
��Left=�$	��203��.������ $
 0,20&�$ Absolute=�$	 0,0&�.��� $ 	#FFABADB3��$
 0.05Q�� $ 	#FFE2E3EA��$
 0.07Q�� $ White��$ 1Q�.���� -   $7 film_Genres��$��	22,0,0,95q�$
8 Wrap=�$7��1Harry Potter and the Philosopher's Stone Poster  ��#���  
����������	#FFFBFBFB$��Verdana)�$��13.333(�$
��Left=�$	��203��$	��100��$��Bottom=�.������ $
 0,20&�$ Absolute=�$	 0,0&�.��� $ 	#FFABADB3��$
 0.05Q�� $ 	#FFE2E3EA��$
 0.07Q�� $ White��$ 1Q�.���� -   $2 RecTitleBar��$��68��$3 30��$4 30��$	��Top=����� $ 0.5,1&�$ 0.5,0&�.��� $ Black��� $ 	#FFC4C4C4��$	 0.5Q�� $ 	#00000000��$ 1Q�� $ 	#009B9B9B��$ 0.603Q�� $ 	#009B9B9B��$ 0.586Q��� -   9 ��Name$9 cmdClose��$��Button��$��Right=�$��30��$��0,4,31,0q�#���  $	��Top=�$��32��: � FocusVisualStyle#: � 	 ���	#FFAFAFAF�� -   $2 RecReflection��$��94.334��$��197.702,0,278.035,10q����	#643F3F3F$��Bottom=�; J� RenderTransformOrigin$; 0.5,0.5&�< J� OpacityMask< �� $ 0.5,1&�$ 0.5,0&�.��� $ 	#02000000��$ 0Q�� $ 	#9BFFFFFF��$ 1Q�z�V� .~��� = �� ScaleY$= -1Q��� > �� AngleX$	> -40Q��� T� ��!� ? !� Visual? �� @ �� ElementName$@ 
film_Image���� -   $9 cmdUpdateFilm��$��Button��$��Right=�$��30��$��	0,0,28,20q�#���  $��Bottom=�$	��175��#: �  �� -   $9 cmdWatchFilm��$��Button��$��Right=�$��30��$��	0,0,28,67q�#��� 
 $��Bottom=�$	��175��#: �  �� -   $9 cmdDeleteFilm��$��Button��$��Right=�$��30��$��
0,0,28,114q�#���  $��Bottom=�$	��175��#: �  