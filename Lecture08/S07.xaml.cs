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
using System.Windows.Forms.DataVisualization.Charting;

public static class TableRowExtensions
{
    public static void AddTextCell(this TableRow row, string text)
    {
        row.Cells.Add(new TableCell(new Paragraph(new Run(text))));
    }

    public static void AddTextRow(this TableRowGroup group, params string[] text)
    {
        var tr=new TableRow();
        foreach (var e in text)
            tr.AddTextCell(e);
        group.Rows.Add(tr);
    }
}

public partial class L3S07 : Window
{
    public static Chart CreateChart()
    {
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

        var fd = new FlowDocument();
        
        return chart;
    }


    public L3S07()
    {
        InitializeComponent();
        doc.DataContext = "binded value";

        var tg = new TableRowGroup();
        var tr = new TableRow();
        tr.Add
    }

    private void Diagram_Click(object sender, RoutedEventArgs e)
    {
        var chart= CreateChart();
        chart.Width=100;
        chart.Height=100;
        var host = new WindowsFormsHost();
        host.Child = chart;
        diagram.Child = host;
    }

    private void Print_Click(object sender, RoutedEventArgs e)
    {
        
        PrintDialog pd = new PrintDialog();
        var result=pd.ShowDialog();
        if (!result.HasValue || !result.Value) return;
        IDocumentPaginatorSource dps = doc;
        pd.PrintDocument(dps.DocumentPaginator, "my documtent");
    }


}