using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

class S01
{
    static Form form;

    public static void MainX()
    {
        form = new Form();

        var label = new Label();
        label.Top = 10;
        label.Left = 10;
        label.Width = 200;
        label.Height = 20;
        label.Text = "Hello, Windows Forms!";
        form.Controls.Add(label);

        var button = new Button();
        button.Top = label.Bottom + 15;
        button.Left = label.Left;
        button.Width = label.Width;
        button.Height = 30;
        button.Text = "OK";
        button.Click += ButtonClicked;
        form.Controls.Add(button);

        form.ClientSize = new System.Drawing.Size(button.Right + 10, button.Bottom + 10);
        Application.Run(form);
    }

    static void ButtonClicked(object sender, EventArgs e)
    {
        form.Close();

    }
}
//! Windows Forms - устаревающая технология. Тем не менее, в свое время она была настоящим прорывом
//! Она является оберткой над User32, которая содержит WinAPI для контролов. И таких оберток было множество: MFC, OWL от борланд, и т.д.
//! Но WF стало очень популярно. Одна из причин - события, каллбэки к действиям пользователя: легко пользоваться (в отличие от OWL), типобезопасно (в отличие от C++)