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
public partial class S04 : Window
{
    Queue<int> queue = new Queue<int>();

    public void StartTimer()
    {
        while(true)
        {
            lock (queue)
            {
                queue.Enqueue(1);
            }

            Dispatcher.BeginInvoke(new Action(UpdateTimer), new object[] { });
            Thread.Sleep(1);
        }
    }

    public S04()
    {
        InitializeComponent();
        new Thread(StartTimer).Start();
    }

    public void UpdateTimer()
    {
        lock (queue)
        {
            time.Text = queue.OrderBy(z=>z).Sum().ToString();
        }

    }

}
