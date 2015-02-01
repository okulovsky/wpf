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


public partial class L3S05 : Window
{
    class Agreement
    {
        public string Client { get; set; }
        public string Manager { get; set; }
    }
    public L3S05()
    {
        InitializeComponent();
        DataContext = new Agreement
        {
            Client = "Иванов И.И.",
            Manager = "Петров П.П."
        };
    }
}