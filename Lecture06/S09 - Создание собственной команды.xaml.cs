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
using Utils;

namespace Utils
{

    public static class MyCommands
    {
        public static RoutedUICommand Do = new RoutedUICommand("Сделать действие", "Do", typeof(MyCommands));
    }
}

    public partial class S09 : Window
    {
        public S09()
        {
            InitializeComponent();
            var binding = new CommandBinding(MyCommands.Do);
            binding.CanExecute += new CanExecuteRoutedEventHandler(binding_CanExecute);
            binding.Executed += new ExecutedRoutedEventHandler(binding_Executed);
            CommandBindings.Add(binding);
        }

        void binding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            list.Items.RemoveAt(list.SelectedIndex);
        }

        void binding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = list.SelectedIndex != -1;
        }
    }
