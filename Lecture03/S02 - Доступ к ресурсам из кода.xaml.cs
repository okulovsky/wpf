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


public partial class S02 : Window
{
    public S02()
    {
        InitializeComponent();
        Resources.Add("brush", new SolidColorBrush(Colors.Green));
        label.SetResourceReference(Label.BackgroundProperty, "brush");
        textbox.Background = Resources["brush"] as Brush;
        button.Background = FindResource("brush") as Brush;

    }
}

//!Можно сослаться из кода: либо установить ссылку, либо непосредственно взять и присвоить объект