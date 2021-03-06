﻿using System;
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
using System.Windows.Media.Animation;
using System.Timers;

namespace MediaManager
{
	/// <summary>
	/// Interaction logic for ViewFilmsScreen.xaml
	/// </summary>
	public partial class ViewFilmsScreen : UserControl
	{
        public static AniScrollViewerExample.AniScrollViewer Scroller;


		public ViewFilmsScreen()
		{
            try
            {
                this.InitializeComponent();
                cmdWORK.Click += new RoutedEventHandler(cmdWORK_Click);
                //lbFilms.SetValue(ScrollViewer.HorizontalScrollBarVisibilityProperty, ScrollBarVisibility.Hidden);
                lbFilms.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(lbFilms_MouseDoubleClick);
                cmdAddCondition.Click += new RoutedEventHandler(cmdAddCondition_Click);

                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); };
		}





        void Scroller_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            txboxCommand.Text = Scroller.HorizontalOffset.ToString();
        }


        void cmdAddCondition_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder command = new StringBuilder();
            if (txboxCommand.Text.ToLower().Contains("where"))
            {
                command.Append("AND ");
            }
            else
            {
                command.Append("WHERE ");
            }

            if (ConditionColumn.SelectedValue.ToString() == "Film Name") { command.Append("film_Name "); }
            else if (ConditionColumn.SelectedValue.ToString() == "Film Rating") { command.Append("film_Rating "); }
            else if (ConditionColumn.SelectedValue.ToString() == "Film Release Year") { command.Append("film_ReleaseYear "); }
            else if (ConditionColumn.SelectedValue.ToString() == "Film Genres") { command.Append("film_Genres "); }
            else if (ConditionColumn.SelectedValue.ToString() == "Film Plot") { command.Append("film_Plot "); }


            if (ConditionOperator.SelectedValue.ToString() == "Is Equal To") { command.Append("= "); }
            else if (ConditionOperator.SelectedValue.ToString() == "Is Greater Than Or Equal To") { command.Append("> "); }
            else if (ConditionOperator.SelectedValue.ToString() == "Is Less Than Or Equal To") { command.Append("< "); }
            else if (ConditionOperator.SelectedValue.ToString() == "Contains") { command.Append("LIKE "); }


            if (command.ToString().Contains("LIKE"))
            {
                command.Append("'" + "%" + ConditionValue.Text + "%" + "'" );
            }
            else
            {
                command.Append("'" + ConditionValue.Text + "'");
            }

            txboxCommand.Text = txboxCommand.Text + "\n" + command.ToString();




        }


        void cmdWORK_Click(object sender, RoutedEventArgs e)
        {
		    
            List<Film> Filmlist = DatabaseManager.GetFilmList(txboxCommand.Text);
            if (Filmlist != null)
			{
				lbFilms.Items.Clear();
			
			foreach (Film f in Filmlist)
            {
                lbFilms.Items.Add(f);
            }
			}
        }

        private void lbFilms_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {

                FilmViewer f = new FilmViewer((Film)lbFilms.SelectedValue);
                f.Show();
                App.Mwindow.WindowState = WindowState.Minimized;
            }
            catch (Exception ex) { };
			
        }

        private void ReturnButton_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
        	ReturnButton.Style = (Style)FindResource("ReturnButtonFocused");
        }

        private void ReturnButton_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
        	ReturnButton.Style = (Style)FindResource("ReturnStyle1");
        }

        private void ReturnButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	ScreenManager.ChangeScreen(App.Mwindow.MMovieScreen);
        }

        private void cmdReset_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            txboxCommand.Text = "SELECT * FROM [tbl_Maintable]";
        }

        private void cmdRightLeft_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (Scroller == null)
            {
                Scroller = (AniScrollViewerExample.AniScrollViewer)lbFilms.Template.FindName("ScrollViewer", lbFilms);
                Scroller.ScrollChanged += new ScrollChangedEventHandler(Scroller_ScrollChanged);

            }

            double xoffset = Scroller.HorizontalOffset;
            if (sender.Equals(cmdRight))
            {
                
                xoffset += 680;
                double multiplier = xoffset / 170;
                Math.Ceiling(multiplier);
                xoffset = 170 * multiplier;
                if (xoffset > 170 * lbFilms.Items.Count)
                {
                    xoffset = 170 * lbFilms.Items.Count;
                }
                double spacingaddition = xoffset / 680;
                spacingaddition = Math.Floor(spacingaddition);
                MessageBox.Show(spacingaddition.ToString());
                if (spacingaddition >= 0)
                {
                    xoffset += spacingaddition*4;
                }
            }
            else
            {

                xoffset -= 680;
                double multiplier = xoffset / 170;
                Math.Floor(multiplier);
                xoffset = 170 * multiplier;
                if (xoffset < 0)
                {
                    xoffset = 0;
                }
                double spacingaddition = xoffset / 680;
                spacingaddition = Math.Floor(spacingaddition);
                MessageBox.Show(spacingaddition.ToString());
                if (spacingaddition >= 0)
                {
                    xoffset += spacingaddition*4;
                }
            }
            double yoffset = Scroller.VerticalOffset;
            Scroller.ScrollTo(xoffset, yoffset, Scroller);
        }
	}
}