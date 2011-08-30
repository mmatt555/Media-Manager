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
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace MediaManager
{
	/// <summary>
	/// Interaction logic for AddMovieScreen.xaml
	/// </summary>
	public partial class AddMovieScreen : System.Windows.Controls.UserControl
	{
		private Style ReturnBtUnfocused;
        private Style ReturnBtFocused;
		
		public AddMovieScreen()
		{
			this.InitializeComponent();
            BtAddFilm.Click += new RoutedEventHandler(BtAddFilm_Click);
			
			this.ReturnButton.MouseEnter += new System.Windows.Input.MouseEventHandler(ReturnButton_MouseEnter);
            this.ReturnButton.MouseLeave += new System.Windows.Input.MouseEventHandler(ReturnButton_MouseLeave);
            this.ReturnButton.Click += new RoutedEventHandler(ReturnButton_Click);

            ReturnBtFocused = (Style)FindResource("ReturnButtonFocused");
            ReturnBtUnfocused = (Style)FindResource("ReturnStyle1");

		}
		
		
		void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            ScreenManager.ChangeScreen(App.Mwindow.MMovieScreen);
        }

        void ReturnButton_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ReturnButton.Style = ReturnBtUnfocused;
        }

        void ReturnButton_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ReturnButton.Style = ReturnBtFocused;
        }

        void BtAddFilm_Click(object sender, RoutedEventArgs e)
        {

            Film fAddFilm = new Film();
            fAddFilm.Name = TxBoxName.Text;
            fAddFilm.Plot = TxBoxStory.Text;
            fAddFilm.Rating = TxBoxRating.Text;
            fAddFilm.ReleaseYear = Convert.ToInt16(TxBoxRelease.Text);
            fAddFilm.Genres = TxBoxGenres.Text;
            fAddFilm.Image = (BitmapImage)FilmImage.Source;



                Directory.CreateDirectory(Environment.CurrentDirectory + @"\Movies\" + DatabaseManager.MakeDirectorySafe(fAddFilm.Name));
                string directory = System.IO.Path.GetDirectoryName(TxBoxDirectory.Text);

                string extension = System.IO.Path.GetExtension(TxBoxDirectory.Text);
                System.Windows.MessageBox.Show("Media Manager will now copy the film file, and any .srt subtitle file found, the program _WILL_ freeze so please wait until a new message box appears.");
                foreach (string str in Directory.GetFiles(directory))
                {
                    if (System.IO.Path.GetExtension(str) == ".srt")
                    {
                        File.Move(str, Environment.CurrentDirectory + @"\Movies\" + DatabaseManager.MakeDirectorySafe(fAddFilm.Name) + @"\" + DatabaseManager.MakeDirectorySafe(fAddFilm.Name) + ".srt");

                    }
                }
                File.Move(TxBoxDirectory.Text, Environment.CurrentDirectory + @"\Movies\" + DatabaseManager.MakeDirectorySafe(fAddFilm.Name) + @"\" + DatabaseManager.MakeDirectorySafe(fAddFilm.Name) + extension);
                System.Windows.MessageBox.Show("File Copying has completed successfully!");

                fAddFilm.Directory = @"\Movies\" + DatabaseManager.MakeDirectorySafe(fAddFilm.Name) + @"\" + DatabaseManager.MakeDirectorySafe(fAddFilm.Name) + extension;
                DatabaseManager.AddFilm(fAddFilm);

                TxBoxDirectory.Clear();
                TxBoxGenres.Clear();
                TxBoxName.Clear();
                TxBoxRating.Clear();
                TxBoxRelease.Clear();
                TxBoxStory.Clear();
                FilmImage.Source = null;
            




        }

		private void BtLoadFile_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            System.Windows.Forms.OpenFileDialog ofdFile = new System.Windows.Forms.OpenFileDialog();
            ofdFile.AddExtension = true;
            ofdFile.ShowDialog();
            if (ofdFile.FileName != String.Empty)
            {
                TxBoxDirectory.Text = ofdFile.FileName;
            } 
		}

		private void BtIMDB_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            if (!TxBoxDirectory.Text.Contains("No File"))
            {
                try
                {

                    FilmSelector imdbWindow = new FilmSelector(System.IO.Path.GetFileNameWithoutExtension(TxBoxDirectory.Text));
                    imdbWindow.Show();
                    App.Mwindow.IsEnabled = false;
                    imdbWindow.Focus();
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
            }
		}

        public void WriteInfo(Film fFilm)
        {
            //IMAGEINFO.Text = "HEIGHT: " + fFilm.Image.PixelHeight + " WIDTH: " + fFilm.Image.PixelWidth + " OTHER INFO: " + fFilm.Image.Format;
            TxBoxName.Text = fFilm.Name;
            TxBoxRating.Text = fFilm.Rating;
            TxBoxRelease.Text = fFilm.ReleaseYear.ToString();
            TxBoxStory.Text = fFilm.Plot;
            TxBoxGenres.Text = fFilm.Genres;
            FilmImage.Source = fFilm.Image;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
            ofd.ShowDialog();
            if (ofd.CheckFileExists)
            {
                BitmapImage biImage = new BitmapImage();
                biImage.BeginInit();
                biImage.UriSource = new Uri(ofd.FileName);
                biImage.EndInit();
                FilmImage.Source = biImage;
            }
        }
	}
}