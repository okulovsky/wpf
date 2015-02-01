using System;
using System.Collections.Generic;
using System.Linq;
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


namespace MyControls3
{

    public partial class ColorBox : UserControl
    {
        public ColorBox()
        {
            InitializeComponent();
        }

        public Color Color
        {
            get { return (Color)base.GetValue(ColorProperty); }
            set { base.SetValue(ColorProperty, value); }
        }
        public static readonly DependencyProperty ColorProperty =
          DependencyProperty.Register("Color", typeof(Color), typeof(ColorBox));


    }
}

    public class S04 : Window
    {
        public S04()
        {
            Width = 100;
            Height = 100;
            var element = new MyControls3.ColorBox();
            element.Color = Colors.Azure;
            Content = element;
        }
    }

   
    