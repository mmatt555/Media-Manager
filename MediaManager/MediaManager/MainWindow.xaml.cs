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
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace MediaManager
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		public MainWindow()
		{
			this.InitializeComponent();
            try
            {
                ScreenManager.Initialize(SScreen, (Storyboard)FindResource("ScreenFIn"), (Storyboard)FindResource("ScreenFOut"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
           
            
            // Insert code required on object creation below this point.
		}
	}
}