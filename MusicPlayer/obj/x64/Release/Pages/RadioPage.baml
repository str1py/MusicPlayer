   M S B A M L   `   `   `  ���� F  BMusicPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MusicPlayer.PagesMusicPlayer.Pages  !    MusicPlayer.Pages.RadioPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     1localclr-namespace:MusicPlayer.Pages     J FWpfAnimatedGif, Version=1.4.17.0, Culture=neutral, PublicKeyToken=null,gif"http://wpfanimatedgif.codeplex.com    N� Title$  	RadioPage�� � 	Resources    PlaylistItemTemplateRadio � RowDefinitions � ColumnDefinitions  RadioItemTemplate  sbRadioListShow �� TargetProperty t� From	 t� To g� DecelerationRatio g� Duration  sbRadioListHide	 g� AccelerationRatio��%�  &	        &	 9    &	 
    &	 Z    �� .R�� $	��219��$��70�� �� �� ��  �� �� �� �� �� �� �� �� �� �� .+��� $��0��$��3��$��0��$��3��$��Uniform=����� *
RadioPic+�� $��4��$��9��$��3��$��0��$��Center=�$��Arial Rounded MT Bold)�$
��Bold"�$��14(�
����������� *	RadioName+�� .R�� $	��145��$��30�� ��  �� .+��� $��0��$��9��$��3��$��1��$��Center=�$	��Top=�$��Arial Rounded MT Bold)�$
��Bold"�$��15(�
����������� *RadioNameFromCategories+�� .��t� $ Margin�$ 0,695,0,-695X�$ 0,0,0,0X�$ .9Q�$ 0:0:1D��� .��t� $ Margin�$ 0,0,0,0X�$ 0,695,0,-695X�$	 .9Q�$ 0:0:1D�.��� .+��  �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� ��  �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� .+��� 
�������$��1��$��3��$��Bottom=�$��23(�$��Arial Rounded MT Bold)�$
��Bold"�.��Radio�� $��1��$��1��$	��top=�$��1q�$��24�����#681b6b$��2���� 
 J� Opacity$
 1Q�$��1��$��2��$��6��$��23��$y�Hidden=�$��1q����#681b6b J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 40Q�   ShadowDepth$ 5Q�   Color$ Black���� -    ��Name$ RadioLogoLow��$
 1Q�$��9��$��3��$��7��$��7��$��5,5,0,0q����#681b6b   $ 20Q�$	 red��$ 0Q��� -   $ RadioLogoHigh��$
 1Q�$��9��$��3��$��7��$��7��$��0,0,5,5q����#681b6b$y�Visible=�   $ 20Q�$	 red��$ 0Q��� -    ��Name$ 	RadioLogo��$��UniformToFill=�$��9��$��3��$��7��$��7��$,��&/Resources/Radio/Categories/record.jpg��$y�Visible=��� -   $ PlayGif��$
��Fill=�$��6��$��13��$��4��$��6��$��11.334,17.112,10,17.509q�$y�Hidden=��� -    ��Name$ 	PlayRadio��$	��▶��$��14��$��8��$��2��
�������$��2��  MainButtonTemplatePlayPause#���  �� -   $ 	StopRadio��$	��◼��$��14��$��8��$��2��
�������$��2��$y�Hidden=�#���  �� -    ��Name$ 	RedioName��$��7��$��1��$��2��$��11��
�������$��Center=�$��Center=�$��20(�$��Arial Rounded MT)��� -   $ RadioArtist��$��7��$��10��$��2��$��11��
�������$��Center=�$��Bottom=�$��20(�$��Arial Rounded MT)��� -	   $ RadioSongName��$��7��$��12��$��2��$��11��
�������$��20(�$��Center=�$��Arial Narrow)��� -
   $ 	RadioInfo��$��7��$��13��$��2��$��11��
�������$��13(�$��Center=�$��Arial Narrow)�(� $��12��$��3��$��14��$��2��.���� -    ��Name$ RadioVolume�� � Minimum$ 0Q� � Maximum$	 100Q� � Value$ 50Q�$	��200��  Horizontal_Slider#���  �� $
��Fill=�$��10��$��14��$��2��$��2��$"��/Resources/Player/Volume.png��$��25��$��25��$��Right=�	� -    	�Name$
 LowQ��$��17��$��15�� 	� 	GroupName$ Quality��$��LQ�� d� 	IsChecked$ FalseY�$	��Top=�
�������	� -   $ HighQ��$��17��$��14��$ Quality��$��HQ��
�������$��Bottom=�$ FalseY�� -    �Name$ RadioListsGrid��$��0,695,0,-695q� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� ��  �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� .+��� $	
 0.8Q�$��1��$��19��$��25������  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FF363745�� � Offset$ 0.374Q�� $ Black��$ 1Q�   $ 40Q�$ 5Q�$ Black���� -   $ UpRadioList��$��11��$��3��$��30(�  MenuButtonStyle#���  $	��Top=�.��Show�� -   $ DownRadioList��$��11��$��3��$y�Hidden=�$��30(�#���  .��Hide�� -    ��Name$ RadioCategoriesList��$��2��$��23��$��1��$��2��
������ $��0q�
�������$��Arial Rounded MT Bold)�$��16(�#���     ListViewItemStyle#���    ListViewStylePlaylist#���  ���� .R�� ���� * (FrameworkElement.ActualWidth)+  �� RelativeSource  �� ! �� AncestorType$! ScrollContentPresenterL�" � 	ItemWidth" �� *(ListView.View).ItemWidth+  �� $! ListViewL����� *	ItemWidth+  �� *Self+# � 
ItemHeight# �� *(ListView.View).ItemHeight+  �� $! ListViewL��� -   $ RadioListView��$��14��$��23��$��1��$��5��
������ $��0q�
�������$��Arial Rounded MT Bold)�$��16(�#���  #���  #���  ���� .R�� ���� * (FrameworkElement.ActualWidth)+  �� $! ScrollContentPresenterL�" �� *(ListView.View).ItemWidth+  �� $! ListViewL����� *	ItemWidth+  �� *Self+# �� *(ListView.View).ItemHeight+  �� $! ListViewL�� -   $ 
ErrorRadio��$y�Hidden=� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� ��  �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� .+��� $��1��$��1��$	��top=�$��1q�$��25�����#681b6b$��2���� $	
 0.8Q�$��0��$��0��$��19��$��25��$y�Visible=�$��0q����	#FF2B2525 -  'System.Windows.Media.Effects.BlurEffect  $   Radius$$ 50Q��� $��2��$��0�����	#FFAB4343$��2��$��25��$��Center=�$��40(�$��Arial Rounded MT Bold)�$
��Bold"�.��Ошибка�� $��4��$��1��
�������$��3��$��Center=�$��23��$
��Wrap=�% �� TextAlignment$% Center=�$��Center=�$��25(�$��Arial Rounded MT Bold)�$
��Bold"���Похоже, что слушать интернет радио без интернета нельзя... Странно... Сейчас попробую найти интернет на вашем комьютере.� -   & �Name$& ErrorBar��$ 25Q�$	 100Q�$	��100��$	��100��$y�Hidden=� 	 RoundProgressBarStyle#��� 	 ' � IsIndeterminate' . ���	#FF681B6B
������ 
������ $��5��$��10��$��5��$��8��$��Center=��� -   $ 
ErrorLabel��
�������$��Center=�$��Center=�$��20(�$��Arial Rounded MT Bold)�$y�Visible=�$��2��$��9��$��6��$��12��.��" Поиск интернета...