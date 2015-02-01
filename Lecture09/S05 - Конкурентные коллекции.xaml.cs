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
using System.Collections.Concurrent;

    /// <summary>
    /// Interaction logic for S01.xaml
    /// </summary>
public partial class S05 : Window
{
    
    ConcurrentQueue<int> queue = new ConcurrentQueue<int>();

    public void StartTimer()
    {
        while(true)
        {
            queue.Enqueue(1);
            Dispatcher.BeginInvoke(new Action(UpdateTimer), new object[] { });
            Thread.Sleep(1);
        }
    }

    public S05()
    {
        InitializeComponent();
//        for (int i = 0; i < 8000; i++) queue.Enqueue(1);

        new Thread(StartTimer).Start();
    }

    public void UpdateTimer()
    {
        time.Text = queue.OrderBy(z=>z).Sum().ToString();
        if (queue.Count > 1000)
        {
            int value;
            queue.TryDequeue(out value);
        }
    }

}
