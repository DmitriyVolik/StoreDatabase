using Store.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Store
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static DataContext database =
            new DataContext(@"Data Source=.\SQLEXPRESS;Initial Catalog=Shop;Integrated Security=True");
    }
}
