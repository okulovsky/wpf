using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;


class Runner
{
    [STAThread]
    public static void Main()
    {
        new Application().Run(new S04());
    }
}