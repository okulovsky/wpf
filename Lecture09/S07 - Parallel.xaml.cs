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
using System.ComponentModel;
using System.Threading.Tasks;

public partial class S07 : Window
{
    public S07()
    {
        InitializeComponent();
        start.Click += new RoutedEventHandler(start_Click);
    }

    void start_Click(object sender, RoutedEventArgs e)
    {
        new Action(Computation).BeginInvoke(null, null);
    }



    void Computation()
    {
        //for (int i = 0; i < 10; i++) DoWork(i);
        Parallel.For(0, 10, DoWork);
    }

    void DoWork(int job)
    {
        double a = 0;
        for (int i = 0; i < 1000; i++)
            for (int j = 0; j < 1000000; j++)
                a /= 1.001;
        Dispatcher.BeginInvoke(
            new Action(delegate
            {
                jobs.Items.Add(string.Format("Job {0} completed", job));
            }), new object[] { });
    }
}