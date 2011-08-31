using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Net;
using System.IO;


namespace MediaManager
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
    /// 
    
	public partial class App : Application
	{
        public static MainWindow Mwindow;
        void App_Startup(object sender, StartupEventArgs e)
        {
            try
            {
                Mwindow = new MainWindow();
                Mwindow.Title = "Media Manager";
                Mwindow.Show();
                DatabaseManager.InitializeManager();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }
        }
	}


    
}