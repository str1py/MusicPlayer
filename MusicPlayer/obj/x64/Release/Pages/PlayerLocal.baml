   M S B A M L   `   `   `  ���� F  BMusicPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MusicPlayer.PagesMusicPlayer.Pages  #    MusicPlayer.Pages.PlayerLocal   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     1localclr-namespace:MusicPlayer.Pages       N� Title$  PlayerLocal�� � 	Resources    PlaylistItemTemplate � RowDefinitions � ColumnDefinitions �� Path��%-  &	        �� .R�� $	��293��$��70�� �� �� �� �� �� �� ��  �� $	��23* ��� $	��23* ��� $	��23* ��� $��9* ��� $	��37* ��� $	��23* ��� $	��23* ��� $	��23* ��� $	��23* ��� $	��23* ��� $	��23* ��� $	��23* ��� $	��23* �.+��� $��1��$��2��$��1��$��5��$��Uniform=����� $ SongPict��� $��4��$��9��$��3��$��0��$��Arial Rounded MT Bold)�$
��Bold"�$��13(�
����������� *
SongName+�� $��4��$��9��$��2��$��3��$��
Album song��$��12(�$��Arial Rounded MT Bold)�
��������� $��4��$��7��$��4��$��3��$��Arial Rounded MT Bold)�$
��Bold"�
�������$��11(����� *	ArtName+�� $��11��$��2��$��7��$��2��$��Arial Rounded MT Bold)�$
��Bold"�
�������$��10(����� *
SongTime+.���  �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� ��  �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� .+��� 
�������$��1��$��3��$��Bottom=�$��23(�$��Arial Rounded MT Bold)�$
��Bold"�.��Player�� $��1��$��1��$	��top=�$��1q�$��24�����#681b6b$��2����  J� Opacity$	 0.7Q�$��1��$��2��$��16��$��8������  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FF363745��	 � Offset$	 0.374Q�� $ Black��$	 1Q�
 J� Effect
 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 40Q�   ShadowDepth$ 5Q�   Color$ Black���� -    ��Name$ PlayList��$��2��$��16��$��8��$��1��$��Arial Rounded MT Bold)�
������ $��0q�#���     ListViewItemStyle#���    ListViewStylePlaylist#���  ��Z� �� $
��Fill=�$��21��$��15��$"��/Resources/Player/Volume.png��$��25��$��25���� -    ��Name$ MusicSongPicturePlayer��$
��Fill=�$��14��$��6��$��6��$��6���� -    ��Name$ 
PlayerNext��$��▶▶��$��15��$��18��$��2��  MainButtonTemplate#���  �� -   $ 
PlayerPrev��$��◀◀��$��15��$��14��$��2��#���  �� -   $ 
PlayerPlay��$	��▶��$��14��$��16��$��2��
�������$��2��  MainButtonTemplatePlayPause#���  �� -   $ PlayerPause��$	��◼��$y�Hidden=�$��14��$��16��$��2��$��2��#���  �� -    ��Name$ AllTimePlayer��$��17��$��20��$��2��$��Bottom=�$��Right=�
�������$��Arial Rounded MT Bold)�$��10(��� -   $ TimeNowPlayer��$��17��$��12��$��2��
�������$��Arial Rounded MT Bold)�$��10(�$��Bottom=�$
��Left=��� -	   $ MusicArtistPlayer��
�������$��13��$��2��$	��Top=�$��12��$��10��$��18(�$��Arial Rounded MT Bold)�$
��Bold"�$��Center=��� -
   $ SongNamePlayer��
�������$��12��$��12��$��10��$��21(�$��Arial Rounded MT Bold)�$
��Bold"�$��Center=�(� $��22��$��3��$��15��.���� -   $��SliderVolume�� � Minimum$ 0Q� � Maximum$	 100Q� � Value$ 50Q�$	��200��  Horizontal_Slider#���  �� -    ��Name$ SliderTrackPlayer��$ 0Q�$��12��$��10��$��17��#���  $	��Top=�