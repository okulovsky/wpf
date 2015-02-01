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
using System.Windows.Forms.Integration;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


public partial class L2S02 : Window
{
    public L2S02()
    {
        InitializeComponent();
        var X = Enumerable.Range(0, 100).Select(z => z / 100.0).ToArray();
        var Y = X.Select(z => z * z).ToArray();

        var chart = new Chart();
        var chartArea = new ChartArea();
        chart.ChartAreas.Add(chartArea);

        var expSeries = new Series();
        for (int i = 0; i < X.Length; i++)
            expSeries.Points.AddXY(X[i], Y[i]);
        expSeries.ChartType = SeriesChartType.FastLine;

        chart.Series.Add(expSeries);
        
        var host = new WindowsFormsHost();
        host.Child = chart;
        Content = host;
        
    }
}