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
using System.Windows.Shapes;


public partial class S03 : Window
{
    public S03()
    {
        InitializeComponent();
    }

    private void Static_Click(object sender, RoutedEventArgs e)
    {
        var brush = Resources["brush"] as SolidColorBrush;
        brush.Color = Colors.Red; ;
    }

    private void Dynamic_Click(object sender, RoutedEventArgs e)
    {
        Resources["brush"] = new SolidColorBrush(Colors.Blue);
    }
}

//!Разница между статическими и динамическими ресурсами