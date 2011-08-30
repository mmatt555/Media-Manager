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
using System.IO;
using System.Diagnostics;
using System.Threading;


namespace MediaManager
{
	/// <summary>
	/// Interaction logic for FilmViewer.xaml
	/// </summary>
	public partial class FilmViewer : Window
	{
		public Film mainfilm;
		public FilmViewer(Film filminfo)
		{
			this.InitializeComponent();
			RecTitleBar.MouseDown +=new System.Windows.Input.MouseButtonEventHandler(FilmViewer_MouseDown);
			
            mainfilm = filminfo;

			film_Release.Text = mainfilm.ReleaseYear.ToString();
			film_Name.Text = mainfilm.Name;
			film_Image.Source = mainfilm.Image;
			film_Plot.Text = mainfilm.Plot;
			film_Rating.Text = mainfilm.Rating.ToString();
			film_Genres.Text = mainfilm.Genres;
			
			cmdWatchFilm.MouseEnter +=new System.Windows.Input.MouseEventHandler(cmdWatchFilm_MouseEnter);
			cmdWatchFilm.MouseLeave +=new System.Windows.Input.MouseEventHandler(cmdWatchFilm_MouseLeave);
            cmdWatchFilm.Click += new RoutedEventHandler(cmdWatchFilm_Click);
			
			cmdUpdateFilm.MouseEnter +=new System.Windows.Input.MouseEventHandler(cmdUpdateFilm_MouseEnter);
			cmdUpdateFilm.MouseLeave +=new System.Windows.Input.MouseEventHandler(cmdUpdateFilm_MouseLeave);
            cmdUpdateFilm.Click += new RoutedEventHandler(cmdUpdateFilm_Click);
			
			cmdDeleteFilm.MouseEnter += new System.Windows.Input.MouseEventHandler(cmdDeleteFilm_MouseEnter);
			cmdDeleteFilm.MouseLeave +=new System.Windows.Input.MouseEventHandler(cmdDeleteFilm_MouseLeave);
			cmdDeleteFilm.Click += new System.Windows.RoutedEventHandler(cmdDeleteFilm_Click);
		}

        void cmdWatchFilm_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(Environment.CurrentDirectory + mainfilm.Directory);
			
        }

        void cmdUpdateFilm_Click(object sender, RoutedEventArgs e)
        {
            mainfilm.Name = film_Name.Text;
            mainfilm.Image = (BitmapImage)film_Image.Source;
            mainfilm.Plot = film_Plot.Text;
            mainfilm.Rating = film_Rating.Text;
            mainfilm.ReleaseYear = Convert.ToInt32(film_Release.Text);
            mainfilm.Genres = film_Genres.Text;

            DatabaseManager.UpdateFilm(mainfilm);
        }


		private void FilmViewer_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
            if (e.RightButton == MouseButtonState.Released && e.MiddleButton == MouseButtonState.Released)
            {
                DragMove();
            }
		}

		private void cmdClose_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			this.Close();
            App.Mwindow.WindowState = WindowState.Normal;
            
		}

		private void cmdClose_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
		{
            cmdClose.Style = (FindResource("ClosebtnFocusStyle") as Style);
		}

		private void cmdClose_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
		{
            cmdClose.Style = (FindResource("ClosebtnStyle") as Style);
		}

		private void cmdWatchFilm_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
		{
			cmdWatchFilm.Style = (FindResource("btnWatchFilmFocussedStyle") as Style);
		}

		private void cmdWatchFilm_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
		{
			cmdWatchFilm.Style = (FindResource("btnWatchFilmStyle") as Style);
		}

		private void cmdUpdateFilm_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
		{
			cmdUpdateFilm.Style = (FindResource("btnUpdateFilmFocussedStyle") as Style);
		}

		private void cmdUpdateFilm_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
		{
			cmdUpdateFilm.Style = (FindResource("btnUpdateFilmStyle") as Style);
		}

		private void cmdDeleteFilm_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
		{
			cmdDeleteFilm.Style = (FindResource("btnDeleteFilmFocussedStyle") as Style);
		}

		private void cmdDeleteFilm_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
		{
			cmdDeleteFilm.Style = (FindResource("btnDeleteFilmStyle") as Style);
		}

		private void cmdDeleteFilm_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this film?", "Media Manager",MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
				File.Delete(mainfilm.Directory);
                Directory.Delete(System.IO.Path.GetDirectoryName(mainfilm.Directory));
                DatabaseManager.DeleteFilm(mainfilm);
                MessageBox.Show("Film Deleted");
                this.Close();
            }
				
		}


	}
}