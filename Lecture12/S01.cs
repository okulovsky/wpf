using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using MyControls;

public class TablePanelElement
{
    public int Row;
    public int Column;
    public UIElement Element;
    public int ColumnSpan;
}

public class GridData
{
    public double[] Widthes;
    public double[] Heights;
    public double[] Lefts;
    public double[] Tops;
}

namespace MyControls
{

    public class TablePanel : Panel
    {

        protected int ColumnCount = 3;

        protected virtual List<TablePanelElement> GetMatrix()
        {
            var result = new List<TablePanelElement>();
            for (int i = 0; i < Children.Count; i++)
                result.Add(new TablePanelElement
                {
                    Element = Children[i],
                    Row = i / ColumnCount,
                    Column = i % ColumnCount
                });
            return result;
        }

        protected GridData CreateGridData(List<TablePanelElement> matrix)
        {
            if (matrix.Count == 0)
                return new GridData { Widthes = new double[] { 0 }, Heights = new double[] { 0 }, Lefts = new double[] { 0 }, Tops = new double[] { 0 } };
            var data = new GridData();
            data.Widthes = Enumerable
                            .Range(0, matrix.Max(x => x.Column) + 1)
                            .Select(z =>
                                        matrix
                                            .Where(x => x != null && x.Column == z)
                                            .Select(x => x.Element.DesiredSize.Width)
                                            .Max())
                            .ToArray();
            data.Heights = Enumerable
                            .Range(0, matrix.Max(x => x.Row) + 1)
                            .Select(z =>
                                        matrix
                                            .Where(x => x != null && x.Row == z)
                                            .Select(x => x.Element.DesiredSize.Height)
                                            .Max())
                            .ToArray();
            data.Lefts = Enumerable
                            .Range(0, data.Widthes.Length)
                            .Select(z => z == 0 ? 0 : data.Widthes.Take(z).Sum())
                            .ToArray();
            data.Tops = Enumerable
                            .Range(0, data.Heights.Length)
                            .Select(z => z == 0 ? 0 : data.Heights.Take(z).Sum())
                            .ToArray();
            return data;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            var matrix = GetMatrix();
            var grid = CreateGridData(matrix);
            var pX = finalSize.Width / grid.Widthes.Sum();
            if (double.IsInfinity(pX) || double.IsNaN(pX)) pX = 1;
            var pY = finalSize.Height / grid.Heights.Sum();
            if (double.IsInfinity(pY) || double.IsNaN(pY)) pY = 1;


            foreach (var e in matrix)
                e.Element.Arrange(new Rect(
                      grid.Lefts[e.Column] * pX,
                      grid.Tops[e.Row] * pY,
                      grid.Widthes[e.Column] * pX,
                      grid.Heights[e.Row] * pY));
            return finalSize;
        }

        protected override Size MeasureOverride(Size availableSize)
        {

            foreach (UIElement e in Children)
                e.Measure(availableSize);
            var matrix = GetMatrix();
            var grid = CreateGridData(matrix);
            return new Size(grid.Widthes.Sum(), grid.Heights.Sum());
        }




    }
}

public class S01 : Window
{
    public S01()
    {
        var panel = new TablePanel();
        for (int i=0;i<10;i++)
            panel.Children.Add(new Button { Content=i.ToString() } );
        Content = panel;
    }
}