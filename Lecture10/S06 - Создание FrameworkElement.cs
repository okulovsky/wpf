using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace MyControls
{
    public class Star : FrameworkElement
    {
        public int EdgeCount
        {
            get { return (int)base.GetValue(EdgeCountProperty); }
            set { base.SetValue(EdgeCountProperty, value); }
        }
        public static readonly DependencyProperty EdgeCountProperty =
          DependencyProperty.Register("EdgeCount", typeof(int), typeof(Star));

        public Brush Fill
        {
            get { return (Brush)base.GetValue(FillProperty); }
            set { base.SetValue(FillProperty, value); }
        }
        public static readonly DependencyProperty FillProperty =
          DependencyProperty.Register("Fill", typeof(Brush), typeof(Star));

        public Brush Stroke
        {
            get { return (Brush)base.GetValue(StrokeProperty); }
            set { base.SetValue(StrokeProperty, value); }
        }
        public static readonly DependencyProperty StrokeProperty =
          DependencyProperty.Register("Stroke", typeof(Brush), typeof(Star));


        protected override HitTestResult HitTestCore(PointHitTestParameters hitTestParameters)
        {
            return base.HitTestCore(hitTestParameters);
        }
        protected override void OnRender(System.Windows.Media.DrawingContext drawingContext)
        {
            double R = Math.Min(this.Width/2, this.Height / 2);
            double r = R / 2;
            double da = 2* Math.PI / EdgeCount;
            var f=new PathFigure{ StartPoint=new Point(Width/2+R,Height/2)} ;
            double a=0;
            for (int i = 0; i < EdgeCount; i++)
            {
                f.Segments.Add(new LineSegment(new Point(Width/2+r * Math.Cos(a + da / 2), Height/2+r * Math.Sin(a + da / 2)), true));
                f.Segments.Add(new LineSegment(new Point(Width / 2 + R * Math.Cos(a + da), Height / 2 + R * Math.Sin(a + da)), true));
                a += da;
            }
            drawingContext.DrawGeometry(Fill, new Pen(Stroke,1), new PathGeometry { Figures = new PathFigureCollection { f } });
        }
    }
}

