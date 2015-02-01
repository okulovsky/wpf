﻿using System;
using System.Collections;
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
using Shop;


namespace Shop
{
    public class Category
    {
        public string Name { get; set; }
        public ArrayList Content { get; set; }
    }

    public class Ware
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
    }
}

public partial class S06 : Window
{
    public S06()
    {
        InitializeComponent();
        var shop = new Category
        {
            Name = "Продукты",
            Content = new ArrayList
            {
                new Category
                {
                    Name="Овощи",
                    Content=new ArrayList
                    {
                        new Ware { Name="Картофель", Quantity=100},
                        new Ware { Name="Морковь", Quantity=150 }
                    }
                },
                new Category
                {
                    Name="Фрукты",
                    Content=new ArrayList
                    {
                        new Ware { Name="Бананы", Quantity=50 },
                        new Ware { Name="Морковь", Quantity=70 }
                    }
                }
            }
        };
        tree.ItemsSource = new object[] { shop };



    }

}