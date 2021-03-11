using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Store.DataBaseModels;
using Store.Models;
using Store.Views;

namespace Store.ViewModels
{
    public class MainMenuViewModel : BaseViewModel
    {
        private readonly Window _window;

        

        public MainMenuViewModel(Window window)
        {
            //Order order = App.database.GetTable<Order>().First();
            //MessageBox.Show(order.OrderProducts[1].Id.ToString()); 


            _window = window;
        }

        //private bool _isVisible;

        //public bool IsVisible
        //{
        //    get => productsWindow == null;
        //}

        //public bool IsVisible
        //{
        //    get { return _isVisible; }
        //    set
        //    {
        //        _isVisible = value;
        //        OnPropertyChanged("IsVisible");
        //    }
        //}

        public Window subWindow;


        public RelayCommand ProductsButton
        {
            get
            {
                return new RelayCommand(
                    obj =>
                    {
                        subWindow = new ProductsWindow();
                        subWindow.Owner = Window.GetWindow(_window);
                        _window.Visibility = Visibility.Hidden;
                        subWindow.Show();
                    }
                );
            }
        }

        public RelayCommand OrdersButton
        {
            get
            {
                return new RelayCommand(
                    obj =>
                    {
                        subWindow = new OrdersWindow();
                        subWindow.Owner = Window.GetWindow(_window);
                        _window.Visibility = Visibility.Hidden;
                        subWindow.Show();
                    }
                );
            }
        }
    }
}