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
using System.Text.RegularExpressions;
using System.ComponentModel;


public partial class S07 : Window
{
    public class Book : IDataErrorInfo
    {
        static Regex ISBNPattern = new Regex("^[0-9-]*$");
        public string Authors { get; set; }
        public string Title { get; set; }
        public bool InStock { get; set; }
        public string ISBN { get; set; }


        public string Error
        {
            get { return ""; }
        }

        public string this[string columnName]
        {
            get
            {

                switch (columnName)
                {
                    case "ISBN":
                        if (!ISBNPattern.Match(ISBN).Success)
                            return "ISBN должен состоять из цифр и дефисов";
                        break;

                }
                return "";
            }

        }
    }

    Book book;

    public S07()
    {
        InitializeComponent();
        book = new Book();
        book.Authors = "George Martin";
        book.Title = "Game of Thrones";
        book.InStock = true;
        book.ISBN="123-456-789";
        this.DataContext = book;
    }

    void CmOk(object sender, RoutedEventArgs args)
    {

        if (!IsValid(this))
        {
            MessageBox.Show("При заполнении формы допущены ошибки", "L1S06", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            return;
        }
        MessageBox.Show(string.Format("{0}\n{1}\n{2}", book.Authors, book.Title, book.InStock));
    }

    private bool IsValid(DependencyObject obj)
    {
        return !Validation.GetHasError(obj) &&
            LogicalTreeHelper.GetChildren(obj)
            .OfType<DependencyObject>()
            .All(child => IsValid(child));
    }
    
}
