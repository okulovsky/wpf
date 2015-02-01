using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;

public class ScrollableTextBox : TextBox
{
    protected override void OnMouseWheel(System.Windows.Input.MouseWheelEventArgs e)
    {
        int value=0;
        try
        {
            value = int.Parse(Text);
        }
        catch { }
        if (e.Delta < 0) value--;
        else value++;
        Text = value.ToString();
    }
}

public class S01 : Window
{
    public S01()
    {
        Content = new ScrollableTextBox { Text = "45" };
    }
}