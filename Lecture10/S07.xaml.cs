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


    /// <summary>
    /// Interaction logic for S07.xaml
    /// </summary>
    public partial class S07 : Window
    {
        public S07()
        {
            InitializeComponent();
            this.star.MouseEnter += (o, e) => star.Fill = Brushes.Blue;
        }
    }
