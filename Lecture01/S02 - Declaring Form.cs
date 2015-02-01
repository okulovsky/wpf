using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


public class S02 : Form
{
    Label label;
    Button button;

    public string Message
    {
        get { return label.Text; }
        set { label.Text = value; }
    }

    public event EventHandler Clicked
    {
        add { button.Click += value; }
        remove { button.Click -= value; }
    }


    public S02()
    {
        label = new Label();
        label.Top = 10;
        label.Left = 10;
        label.Width = 200;
        label.Height = 20;
        Controls.Add(label);

        button = new Button();
        button.Top = label.Bottom + 15;
        button.Left = label.Left;
        button.Width = label.Width;
        button.Height = 30;
        button.Text = "OK";
        button.Click += (sender, args) =>
            {
                MessageBox.Show("You clicked button");
            };
        Controls.Add(button);
    }

    public static void MainX()
    {
        var form = new S02();
        form.Message = "Hello, Windows Forms!";
        form.Click += (sender, args) => { form.Close(); };

    }
}

//!Часто все контролы заворачивают в класс, производный от Form. 
//!Обратите внимание, что событие теперь обрабатывается двумя обработчиками