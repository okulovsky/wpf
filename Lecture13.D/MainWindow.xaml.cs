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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using Automation = System.Windows.Automation;
using System.Windows.Automation;
using System.Windows.Threading;
using System.Diagnostics;



namespace Lecture13.D
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



      
        private void btnStartAutomation_Click(object sender, RoutedEventArgs e)
        {
            var process = new Process();
            process.StartInfo.FileName = "Lecture13.C.exe";
            process.Start();
            Thread.Sleep(3000);

            var desktop = AutomationElement.RootElement;
            var mainWindow = desktop.FindFirst(TreeScope.Children,
                 new PropertyCondition(AutomationElement.NameProperty, "UI Automation Test Window"));
            
            if (mainWindow == null)
            {
                MessageBox.Show("Window is not found");
                return;
            }

            var textBox = mainWindow.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.AutomationIdProperty, "source"));
            var valuePattern= textBox.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
            valuePattern.SetValue("10");

            var button = mainWindow.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.AutomationIdProperty, "button"));
            var buttonPattern = button.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
            buttonPattern.Invoke();

            textBox = mainWindow.FindFirst(TreeScope.Descendants,
                 new PropertyCondition(AutomationElement.AutomationIdProperty, "incremented"));
            valuePattern = textBox.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
            var result = valuePattern.Current.Value;

            if (result != "11")
                MessageBox.Show("FAIL");
            else
                MessageBox.Show("SUCCESS");

        }

        ValuePattern GetValuePattern(AutomationElement window, string name, string value)
        {
            var textBox = window.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.AutomationIdProperty, name));
            return textBox.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
            
        }

        
    }
}
