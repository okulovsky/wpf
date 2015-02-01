using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;


class Runner
{
    [STAThread]
    public static void MainX()
    {
        new Application().Run(new S09());
    }
}