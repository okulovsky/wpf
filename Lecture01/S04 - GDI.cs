using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;


public class S04 : Form
{
    public S04()
    {
        ResizeRedraw = true;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        var g = e.Graphics;
        //e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

        if (false)
        {
            e.Graphics.TranslateTransform(ClientSize.Width / 2, ClientSize.Height / 2);
            e.Graphics.ScaleTransform(0.7f, 0.7f);
            e.Graphics.RotateTransform(10);
            e.Graphics.TranslateTransform(-ClientSize.Width / 2, -ClientSize.Height / 2);
        }

        g.DrawLine(
            new Pen(Color.Black, 10),
            10, 10, ClientSize.Width - 10, 40);
        g.DrawLine(
            new Pen(Color.DarkGreen, 10) { EndCap = LineCap.ArrowAnchor },
            new Point(10, 30),
            new Point(ClientSize.Width - 10, 60));
        g.FillRectangle(
            new SolidBrush(Color.DarkCyan),
            new Rectangle(10, 90, ClientSize.Width - 20, 30));
    }

    public static void Main()
    {
        Application.Run(new S04());
    }
}

//!GDI+ - другая библиотека WinAPI
//!Позволяет делать множество всяких штук, связанных с графикой, т.ж. содержит графические примитивы