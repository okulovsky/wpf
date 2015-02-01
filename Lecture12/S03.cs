using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace MyControls
{
    public class TablePanelSpannable : TablePanel
    {
        public static readonly DependencyProperty ColSpanProperty = DependencyProperty.RegisterAttached(
            "ColSpan",
            typeof(int),
            typeof(TablePanelSpannable),
            new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.AffectsRender)
            );

        public static void SetColSpan(UIElement element, int value)
        {
            element.SetValue(ColSpanProperty, value);
        }
        public static int GetColSpan(UIElement element)
        {
            return (int)element.GetValue(ColSpanProperty);
        }

        protected override List<TablePanelElement> GetMatrix()
        {
            var list=new List<TablePanelElement>();
            int current = 0;
            foreach (UIElement e in Children)
            {
                var data = new TablePanelElement();
                data.Element = e;
                data.Column = current % ColumnCount;
                data.Row = current / ColumnCount;
                data.ColumnSpan = GetColSpan(e);
                list.Add(data);
                current++;
                current += data.ColumnSpan;
            }
            return list;
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
            {
                var width = 0.0;
                for (int i = e.Column; i < Math.Min(grid.Widthes.Length, e.Column + e.ColumnSpan+1); i++) width += grid.Widthes[i];
                e.Element.Arrange(new Rect(
                          grid.Lefts[e.Column] * pX,
                          grid.Tops[e.Row] * pY,
                          width * pX,
                          grid.Heights[e.Row] * pY));
            }
            return finalSize;
        }
    }
}
