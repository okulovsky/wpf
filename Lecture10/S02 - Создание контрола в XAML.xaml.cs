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


namespace MyControls1
{
    public partial class ColorBox : UserControl
    {
        public ColorBox()
        {
            InitializeComponent();
        }
    }
}

    public class S02 : Window
    {
        public S02()
        {
            Width = 100;
            Height = 100;
            var element = new MyControls1.ColorBox();
            element.DataContext = Colors.Beige;
            Content = element;
        }
    }