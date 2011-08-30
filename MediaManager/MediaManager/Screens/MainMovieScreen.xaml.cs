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
	/// Interaction logic for MainMovieScreen.xaml
	/// </summary>
	public partial class MainMovieScreen : UserControl
	{
        private Style AddNBtUnfocused;
        private Style AddNBtFocused;

        private Style ViewMBtUnfocused;
        private Style ViewMBtFocused;

        private Style ReturnBtUnfocused;
        private Style ReturnBtFocused;

		public MainMovieScreen()
		{
			this.InitializeComponent();

            this.AddNBt.MouseEnter += new MouseEventHandler(AddNBt_MouseEnter);
            this.AddNBt.MouseLeave += new MouseEventHandler(AddNBt_MouseLeave);
            this.AddNBt.Click += new RoutedEventHandler(AddNBt_Click);

            AddNBtUnfocused = (Style)FindResource("AddNBt");
            AddNBtFocused = (Style)FindResource("AddNBtFocused");
            

            this.ViewMBt.MouseEnter += new MouseEventHandler(ViewMBt_MouseEnter);
            this.ViewMBt.MouseLeave += new MouseEventHandler(ViewMBt_MouseLeave);
            this.ViewMBt.Click += new RoutedEventHandler(ViewMBt_Click);

            ViewMBtUnfocused = (Style)FindResource("ViewMBt");
            ViewMBtFocused = (Style)FindResource("ViewMBtFocused");

            this.ReturnButton.MouseEnter += new MouseEventHandler(ReturnButton_MouseEnter);
            this.ReturnButton.MouseLeave += new MouseEventHandler(ReturnButton_MouseLeave);
            this.ReturnButton.Click += new RoutedEventHandler(ReturnButton_Click);

            ReturnBtFocused = (Style)FindResource("ReturnButtonFocused");
            ReturnBtUnfocused = (Style)FindResource("ReturnStyle1");
        }

        void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            ScreenManager.ChangeScreen(App.Mwindow.SScreen);
        }

        void ReturnButton_MouseLeave(object sender, MouseEventArgs e)
        {
            ReturnButton.Style = ReturnBtUnfocused;
        }

        void ReturnButton_MouseEnter(object sender, MouseEventArgs e)
        {
            ReturnButton.Style = ReturnBtFocused;
        }




        void ViewMBt_Click(object sender, RoutedEventArgs e)
        {
			ScreenManager.ChangeScreen(App.Mwindow.ViewMovScreen);
        }

        void ViewMBt_MouseLeave(object sender, MouseEventArgs e)
        {
            ViewMBt.Style = ViewMBtUnfocused;
            LftOutline.Visibility = Visibility.Hidden;
        }

        void ViewMBt_MouseEnter(object sender, MouseEventArgs e)
        {
            ViewMBt.Style = ViewMBtFocused;
            LftOutline.Visibility = Visibility.Visible;
        }


          
      
        void AddNBt_Click(object sender, RoutedEventArgs e)
        { 
			ScreenManager.ChangeScreen(App.Mwindow.AddMovScreen);
        } 

        void AddNBt_MouseLeave(object sender, MouseEventArgs e)
        {
            AddNBt.Style = AddNBtUnfocused;
            RtOutline.Visibility = Visibility.Hidden;
        }

        void AddNBt_MouseEnter(object sender, MouseEventArgs e)
        {
            AddNBt.Style = AddNBtFocused;
            RtOutline.Visibility = Visibility.Visible;
        }
	}
}