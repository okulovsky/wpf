using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Lecture13.C
{
    class Program
    {
        [STAThread]
        public static void Main()
        {
            new Application().Run(new TestWindow());
        }
    }
}
