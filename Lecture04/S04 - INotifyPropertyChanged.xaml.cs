﻿using System;
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
using System.ComponentModel;


public partial class S04 : Window
{
    public class Book : INotifyPropertyChanged
    {
        public string Authors { get; set; }
        public string Title { get; set; }
        bool inStock;
        public bool InStock
        {
            get { return inStock; }
            set
            {
                inStock = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("InStock"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    Book book;

    public S04()
    {
        InitializeComponent();
        book = new Book();
        book.Authors = "George Martin";
        book.Title = "Game of Thrones";
        book.InStock = true;
        this.DataContext = book;
    }

    void CmOk(object sender, RoutedEventArgs args)
    {
        MessageBox.Show(string.Format("{0}\n{1}\n{2}", book.Authors, book.Title, book.InStock));
    }

    void DeleteFromStock(object sender, RoutedEventArgs args)
    {
        book.InStock = false;
    }
    
}

//!Мы сообщаем об изменении поля с помощью интерфейса INotifyPropertyChanged