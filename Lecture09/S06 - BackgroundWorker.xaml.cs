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

namespace Lecture09
{
    /// <summary>
    /// Interaction logic for S06.xaml
    /// </summary>
    public partial class S06 : Window
    {
        public S06()
        {
            InitializeComponent();
            start.Click += new RoutedEventHandler(start_Click);
            abort.Click += new RoutedEventHandler(abort_Click);
        }

        BackgroundWorker worker;

        void start_Click(object sender, RoutedEventArgs e)
        {
            start.IsEnabled = false;
            worker = new BackgroundWorker();
            
            worker.DoWork += Computation;
            
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;

            worker.ProgressChanged += ShowProgress;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync();
        }

        void Computation(object sender, DoWorkEventArgs e)
        {
            double a = 1;
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 1000000; j++)
                    a /= 1.001;
                (sender as BackgroundWorker).ReportProgress(i);
                if (worker.CancellationPending) break;
            }
        }

        
        void abort_Click(object sender, RoutedEventArgs e)
        {
            worker.CancelAsync();
        }


        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            start.IsEnabled = true;
        }

        void ShowProgress(object sender, ProgressChangedEventArgs e)
        {
            progress.Value = e.ProgressPercentage;       
        }



        

    }
}
