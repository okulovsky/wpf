﻿using System;
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
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Hello WPF again!");
    }

    [STAThread]
    public static void MainX()
    {
        new Application().Run(new S02());
    }
}

//!XAML - Это язык для описания объектов, со вложенными полями. Можно описывать произвольные объекты, но чаще всего мы будем описывать элементы УИ.