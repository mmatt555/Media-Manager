using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MediaManager
{
    public static class ScreenManager
    {
        private static DependencyObject doCurrentScreen;
        private static Storyboard sbFadeIn;
        private static Storyboard sbFadeOut;

        
        public static void Initialize(DependencyObject FirstScreen, Storyboard FadeIn, Storyboard FadeOut)
        {
            doCurrentScreen = FirstScreen;
            sbFadeIn = FadeIn;
            sbFadeOut = FadeOut;
            (doCurrentScreen as UserControl).SetValue(Panel.ZIndexProperty, 1);
                       
        }



        public static void ChangeScreen(DependencyObject NewScreen)
        {
            (NewScreen as UserControl).SetValue(Panel.ZIndexProperty, 1);
            (doCurrentScreen as UserControl).SetValue(Panel.ZIndexProperty, 0);

            (NewScreen as UserControl).IsEnabled = true;
            (doCurrentScreen as UserControl).IsEnabled = false;

            Storyboard.SetTarget(sbFadeOut, doCurrentScreen);
            Storyboard.SetTarget(sbFadeIn, NewScreen);
            sbFadeOut.Begin();
            sbFadeIn.Begin();
			
            doCurrentScreen = NewScreen;
        }

        public static string GetName()
        {
            return ((doCurrentScreen as UserControl).Name);
        }
          
    }
}
