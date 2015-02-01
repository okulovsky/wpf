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


public partial class S04 : Window
{
    public S04()
    {
        InitializeComponent();

        button.Click += (sender, args) => { button.Background = Brushes.Azure; };
    }
}

//!Элемент Window принимает Content. Когда я описываю тэг Window, я описывают, что будет присвоено Content.
//!Content - Это ОДИН элемент. Если я хочу много, нужно взять компоновщик, который будет принимать коллекцию объектов, я беру StackPanel
//!У Button тоже есть Content. Я могу написать его в атрибуте, или в виде содержимого тэга.
//!Важно, что Content Button - это, как и Content у окна, все что угодно. Например, StackPanel. Обратите внимание, как я пишу графику в XAML
//!Другие поля класса тоже могут быть определены: Background
//!Чудес не бывает, все это компилируется на лету в шарповый код, который просто создает классы и метод InitializeComponents, где свойства
//!Все, что можно сделать XAML, можно сделать и без него, но это самый популярный вопрос: как сделать нечто без XAML
//!А вот так можно поименовать элемент (только это не всегда стоит делать!), подписаться на событие.
//!Но на самом деле, на события тоже следует подписываться не всегда. Огромное количество действий можно делать в XAML, и в основном мы будем заниматься именно этим.