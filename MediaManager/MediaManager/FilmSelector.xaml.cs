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
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace MediaManager
{
	/// <summary>
	/// Interaction logic for FilmSelector.xaml
	/// </summary>
	public partial class FilmSelector : Window
    {

        #region Variable Declaration
        #region Regex's
        Regex rgxRemoveHref = new Regex("/title/tt[0-9]+/");
        Regex rgxFindRating = new Regex(@"\|([0-9]\.[0-9])\|"); //GROUP[1] == RATING
        Regex rgxFindDate = new Regex("href=\"/year/([0-9]{4})"); //GROUP[1] == DATE
        Regex rgxFindGenres = new Regex("genre/([A-Za-z0-9]*)\""); //GROUP[1-X] == GENRE
        Regex rgxFindStoryline = new Regex(@"<h2>Storyline</h2>\n\n<p>(.*)\n\n<em"); //GROUP[1] == STORYLINE
        Regex rgxFindFilmName = new Regex("<meta name=\"title\" content=\"(.*) [(]"); //GROUP[1] == NAME
        Regex rgxGrabPicture = new Regex("primary/images.*(http://ia.media-imdb.com/images/.*jpg)");
        Regex rgxHTMLCODES = new Regex("&#x[0-9][0-9];");
        #endregion
        Label[] LbNames;
        Label[] LbRatings;
        Label[] LbReleases;
        System.Windows.Controls.Image[] MovImages;

        
        public static Film[] Films;
        public static BitmapImage noimage;
        #endregion

        public FilmSelector(string FirstSearchTerm)
		{
			this.InitializeComponent();
            TxBoxSearchTerm.Text = FirstSearchTerm;

           Btmov1.Click+=new RoutedEventHandler(Btmov1_Click);
           Btmov2.Click += new RoutedEventHandler(Btmov2_Click);
           Btmov3.Click += new RoutedEventHandler(Btmov3_Click);
           this.Window.Closed += new EventHandler(Window_Closed);

           Films = new Film[3];
           noimage = this.Resources["no_image"] as BitmapImage;

           #region Code access to window items
           LbNames = new Label[3];
           LbNames[0] = LbName;
           LbNames[1] = LbName1;
           LbNames[2] = LbName2;

           LbRatings = new Label[3];
           LbRatings[0] = LbRating;
           LbRatings[1] = LbRating1;
           LbRatings[2] = LbRating2;

           LbReleases = new Label[3];
           LbReleases[0] = LbRelease;
           LbReleases[1] = LbRelease1;
           LbReleases[2] = LbRelease2;

           MovImages = new System.Windows.Controls.Image[3];
           MovImages[0] = MovImage;
           MovImages[1] = MovImage1;
           MovImages[2] = MovImage2;
           #endregion


        }

        void Window_Closed(object sender, EventArgs e)
        {
            App.Mwindow.IsEnabled = true;

        }

        public StringBuilder GetHtml(string URL)
        {

           
            System.Net.WebClient myWebClient = new System.Net.WebClient();
            WebProxy myProxy = new WebProxy();
            string Ar =  myWebClient.DownloadString(URL);


            
            StringBuilder TheWebPage = new StringBuilder();/*
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(URL);
            HttpWebResponse res =(HttpWebResponse)req.GetResponse();
            //StreamReader sr = new StreamReader(res.GetResponseStream());
            string Ar = sr.ReadToEnd();
            */


            //REPLACING HTML CODES
            Ar = rgxHTMLCODES.Replace(Ar, delegate(Match match)
            {

                string v = match.ToString();
                if (v.Contains("22"))
                {
                    v = "\"";
                }
                if (v.Contains("27"))
                {
                    v = "'";
                }

                return v;
            });

            TheWebPage.Append(Ar);
            return TheWebPage;

        }

        public static BitmapImage GrabImage(string URL)
        {
            

           /* HttpWebRequest req = (HttpWebRequest)WebRequest.Create(URL);
            WebProxy myProxy = new WebProxy();
            myProxy.IsBypassed(new Uri(URL));
            req.Proxy = myProxy;
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
          */
            BitmapImage image = new BitmapImage();
            if (URL == string.Empty)
            {
                image.BeginInit();
                image.UriSource = new Uri(@"C:\NO-IMAGE-AVAILABLE.jpg");
                image.EndInit();
            }

            else
            {
                image.BeginInit();
                image.UriSource = new Uri(URL);
                image.EndInit();
            }
            return image;
        }
  
        private void BtSearch_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            string search = "http://www.imdb.com/find?s=all&q="; //Basic Search Link
            string temp = TxBoxSearchTerm.Text; //Take search term
            temp = temp.Replace(" ", "+"); //Remove spaces, replace with '+'
            search += temp; //Add to end of Base Search Link
            StringBuilder BaseSearch = GetHtml(search); //Get Basic Search Website
            string[] links;
            links = GetLinks(BaseSearch); //Take top 3 links of search page (3 most popular / mentioned)
            Films = new Film[links.Length];

            StringBuilder[] filmsites = new StringBuilder[3];
            Parallel.For(0, Films.Length,  i =>
            //For each link (each different movie)
            {
                
                filmsites[i] = GetHtml("http://www.imdb.com" + links[i]);


                //First get the HTML of the film page "filmsite" is now a string of entire website

                 //Use GrabImage function to download picture
                Films[i] = new Film();
                Films[i].Name = rgxFindFilmName.Match(filmsites[i].ToString()).Groups[1].Value; //Find the name of the film in the HTML
                Films[i].Rating = rgxFindRating.Match(filmsites[i].ToString()).Groups[1].Value; //Find the rating of the film in the HTML
                if ((rgxFindDate.Match(filmsites[i].ToString()).Groups[1].Value) == string.Empty)
                {
                    Films[i].ReleaseYear = 1000;
                }
                else
                {
                    Films[i].ReleaseYear = Convert.ToInt32(rgxFindDate.Match(filmsites[i].ToString()).Groups[1].Value); //Find the release year of the film in the HTML
                }


                List<string> lsGenres = new List<string>(); //Create a list of genres
                foreach (Match m in rgxFindGenres.Matches(filmsites[i].ToString()))
                {
                    lsGenres.Add(m.Groups[1].Value); //Foreach genre found add it to the list
                }
                for (int inte = 0; inte < lsGenres.Count; inte++) //For each value item of list
                {
                    for (int x = 0; x < lsGenres.Count; x++) //For each item of list
                    {
                        if (inte != x) //If the items are not the same index
                        {
                            if (lsGenres[inte] == lsGenres[x]) //If they have equal value, but not equal index
                            {
                                lsGenres.RemoveAt(x); //Remove copy
                            }
                        }
                    }
                }
                StringBuilder sbGenres = new StringBuilder();
                foreach (string s in lsGenres)
                {
                    sbGenres.Append(s + " ");
                }
                Films[i].Genres = sbGenres.ToString();

                Films[i].Plot = rgxFindStoryline.Match(filmsites[i].ToString()).Groups[1].Value;
            }
            );

            //Fill In Details

            for (int i = 0; i < Films.Length; i++)
            {
                LbNames[i].Content = "Name: " + Films[i].Name;
                LbRatings[i].Content = "Rating: " + Films[i].Rating;
                LbReleases[i].Content = "Release: " + Films[i].ReleaseYear;
                Films[i].Image = new BitmapImage();
                Films[i].Image.BeginInit();
            }

            Stream[] ms = new Stream[Films.Length];

            Parallel.For(0, Films.Length, i =>
                {
                    string ImageURL = rgxGrabPicture.Match(filmsites[i].ToString()).Groups[1].Value;
                    if (string.IsNullOrEmpty(ImageURL))
                    {
                        ms[i] = null;
                        
                    }
                    else
                    {

                        WebClient wc = new WebClient();
                        byte[] pic = wc.DownloadData(ImageURL);
                        ms[i] = new MemoryStream(pic);

                    }
                }
            );


            for (int i = 0; i < Films.Length; i++)
            {
                if (ms[i] == null)
                {
                    Films[i].Image.UriSource = noimage.UriSource;
                }
                else
                {
                    Films[i].Image.StreamSource = ms[i];
                }
                Films[i].Image.EndInit();

                MovImages[i].Source = Films[i].Image;   
            }
        }

        public string[] GetLinks(StringBuilder website)
        {
            

            Regex FindLink = new Regex("href=\"/title/tt[0-9]+/");
            List<Match> PossibleLines = new List<Match>();

            //For each link found, write it to console and add to lsit
            foreach (Match M in FindLink.Matches(website.ToString()))
            {
                PossibleLines.Add(M);

            }
            //Following removes duplicate entries
            for (int i = 0; i < PossibleLines.Count; i++)
            {
                for (int x = 0; x < PossibleLines.Count; x++)
                {
                    if (x != i)
                    {
                        if (PossibleLines[i].Value == PossibleLines[x].Value)
                        {
                            PossibleLines.RemoveAt(x);
                        }
                    }
                }
            }
            

            //Reduce list to top 3
            string[] Links;
            if (PossibleLines.Count >= 3)
            {
                Links = new string[3];
            }
            else
            {
                Links = new string[PossibleLines.Count];
            }
            for (int i = 0; (i < PossibleLines.Count) & (i < 3); i++)
            {
                Links[i] = PossibleLines[i].Value;
                Links[i] = rgxRemoveHref.Match(Links[i]).Value.ToString();
            }
            return Links;
        }

        #region PickMovieButtons

        void Btmov1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
			if (Films[0].Name != null)
			{
            App.Mwindow.AddMovScreen.WriteInfo(Films[0]);
			}
        }
        void Btmov2_Click(object sender, RoutedEventArgs e)
        {
			if (Films[1].Name != null)
			{
            App.Mwindow.AddMovScreen.WriteInfo(Films[1]);
			}
        }
        void Btmov3_Click(object sender, RoutedEventArgs e)
        {
			if (Films[2].Name != null)
			{
            App.Mwindow.AddMovScreen.WriteInfo(Films[2]);
			}
        }
        #endregion


    }
}