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
using System.Threading;

    /// <summary>
    /// Interaction logic for S01.xaml
    /// </summary>
public partial class S02 : Window
{

    public void StartTimer()
    {
        var count = 0;
        while (true)
        {
            count++;
            Dispatcher.BeginInvoke(new Action<int>(z=>time.Text=z.ToString()), new object[] { count });
            Thread.Sleep(1000);
        }
    }

    public S02()
    {
        InitializeComponent();
        new Thread(StartTimer).Start();
    }

    public void UpdateTimer(int count)
    {
        time.Text = count.ToString();
    }

}
