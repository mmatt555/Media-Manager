using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace AniScrollViewerExample
{
    public class AniScrollViewer : ScrollViewer
    {
        //Register a DependencyProperty which has a onChange callback
        public static DependencyProperty CurrentVerticalOffsetProperty = DependencyProperty.Register("CurrentVerticalOffset", typeof(double), typeof(AniScrollViewer), new PropertyMetadata(new PropertyChangedCallback(OnVerticalChanged)));
        public static DependencyProperty CurrentHorizontalOffsetProperty = DependencyProperty.Register("CurrentHorizontalOffsetOffset", typeof(double), typeof(AniScrollViewer), new PropertyMetadata(new PropertyChangedCallback(OnHorizontalChanged)));

        //When the DependencyProperty is changed change the vertical offset, thus 'animating' the scrollViewer
        private static void OnVerticalChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AniScrollViewer viewer = d as AniScrollViewer;
            viewer.ScrollToVerticalOffset((double)e.NewValue);
        }

        //When the DependencyProperty is changed change the vertical offset, thus 'animating' the scrollViewer
        private static void OnHorizontalChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AniScrollViewer viewer = d as AniScrollViewer;
            viewer.ScrollToHorizontalOffset((double)e.NewValue);
        }
        
        
        public double CurrentHorizontalOffset
        {
            get { return (double)this.GetValue(CurrentHorizontalOffsetProperty); }
            set { this.SetValue(CurrentHorizontalOffsetProperty, value); }
        }

        public double CurrentVerticalOffset
        {
            get { return (double)this.GetValue(CurrentVerticalOffsetProperty); }
            set { this.SetValue(CurrentVerticalOffsetProperty, value); }
        }
        public void ScrollTo(double x, double y,AniScrollViewer scv)
        {
            Storyboard sb = new Storyboard();
            DoubleAnimation vertAnim = new DoubleAnimation();
            vertAnim.From = scv.VerticalOffset;
            vertAnim.To = y;
            vertAnim.DecelerationRatio = 1.0;
            vertAnim.Duration = new Duration(TimeSpan.FromMilliseconds(1000));
            DoubleAnimation horzAnim = new DoubleAnimation();
            horzAnim.From = this.HorizontalOffset;
            horzAnim.To = x;
            horzAnim.DecelerationRatio = 1;
            horzAnim.Duration = new Duration(TimeSpan.FromMilliseconds(1000));
            sb = new Storyboard();
            sb.Children.Add(vertAnim);
            sb.Children.Add(horzAnim);
            Storyboard.SetTarget(vertAnim, scv);
            Storyboard.SetTargetProperty(vertAnim, new PropertyPath(AniScrollViewer.CurrentVerticalOffsetProperty));
            Storyboard.SetTarget(horzAnim, scv);
            Storyboard.SetTargetProperty(horzAnim, new PropertyPath(AniScrollViewer.CurrentHorizontalOffsetProperty));
            sb.Begin();
        }

    }
}
