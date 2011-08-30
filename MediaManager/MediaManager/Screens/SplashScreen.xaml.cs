using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace MediaManager
{
	/// <summary>
	/// Interaction logic for SplashScreen.xaml
	/// </summary>
	public partial class SplashScreen : UserControl
	{
		public SplashScreen()
		{
			this.InitializeComponent();            
		}



		private void TvButton_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
		{
			TvButton.Style = (Style)TryFindResource("TvButtonFocused");
            TVBTShadOutline.Visibility = Visibility.Visible;
		}

		private void TvButton_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
		{
			TvButton.Style = (Style)FindResource("TVButton");
            TVBTShadOutline.Visibility = Visibility.Hidden;
		}
		
		
		

		private void MovButton_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
		{
			MovButton.Style = (Style)FindResource("MovButtonFocused");
            MovBTShadOutline.Visibility = Visibility.Visible;
		}

		private void MovButton_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
		{
			MovButton.Style = (Style)FindResource("MovButton");
            MovBTShadOutline.Visibility = Visibility.Hidden;
		}

        private void MovButton_Click(object sender, RoutedEventArgs e)
        {
            ScreenManager.ChangeScreen(App.Mwindow.MMovieScreen);
        }
		
	}
}