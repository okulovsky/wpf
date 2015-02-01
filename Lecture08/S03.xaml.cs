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


public partial class L3S03 : Window
{
    public L3S03()
    {
        InitializeComponent();
        var row = new TableRow();
        row.Cells.Add(new TableCell(new Paragraph(new Run("Санкт-Петербург"))));
        row.Cells.Add(new TableCell(new Paragraph(new Run("1500 кв.км"))));
        row.Cells.Add(new TableCell(new Paragraph(new Run("3 млн."))));
        rows.Rows.Add(row);
    }
}