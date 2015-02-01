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


public class MyControl : Control
{
    protected override void OnRender(DrawingContext drawingContext)
    {
        base.OnRender(drawingContext);
        drawingContext.DrawRectangle(Brushes.Red, new Pen(Brushes.Green, 5), new Rect(50, 50, 100, 100));
        
    }
}
    /// <summary>
    /// Interaction logic for S08.xaml
    /// </summary>
public partial class S08 : Window
{
    public S08()
    {
        InitializeComponent();
        Content = new MyControl();
        InvalidateVisual();
    }


}