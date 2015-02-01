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


namespace MyControls2
{

    public partial class ColorBox : UserControl
    {
        public ColorBox()
        {
            InitializeComponent();
        }

     //   public Color Color { get; set; }

        #region

        public Color Color
        {
            get { return (Color)base.GetValue(ColorProperty); }
            set { base.SetValue(ColorProperty, value); }
        }
        public static readonly DependencyProperty ColorProperty =
          DependencyProperty.Register("Color", typeof(Color), typeof(ColorBox));


        #endregion
    }
}

    public class S03 : Window
    {
        public S03()
        {
            Width = 100;
            Height = 100;
            var element = new MyControls2.ColorBox();
            element.Color = Colors.Red;
            Content = element;
        }
    }

   
    