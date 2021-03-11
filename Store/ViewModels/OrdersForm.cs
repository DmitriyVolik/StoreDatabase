using Store.DataBaseModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Store.Views;

namespace Store.ViewModels
{
    class OrdersForm : BaseViewModel
    {
        public ObservableCollection<Order> Orders { get; set; } = new ObservableCollection<Order>();
        
        public ObservableCollection<OrderProduct> CurrentOrderProducts { get; set; } = new ObservableCollection<OrderProduct>();

        public OrdersForm()
        {
            App.database.GetTable<Order>().ToList().ForEach(x => Orders.Add(x));
        }

        private Order _currentOrder;

        public Order CurrentOrder
        {
            get { return _currentOrder; }
            set
            {
                _currentOrder = value;
                if (_currentOrder != null)
                {
                    CurrentOrderProducts.Clear();
                    CurrentOrder.OrderProducts.ToList().ForEach(x => CurrentOrderProducts.Add(x));
                }
                OnPropertyChanged("CurrentOrder");
            }
        }

        public RelayCommand EditButton
        {
            get
            {
                return new RelayCommand(
                        obj =>
                        {
                            var o = new OrderWindow();
                            o.DataContext = new OrderForm()
                            {
                                Order = CurrentOrder
                            };
                            o.ShowDialog();
                            App.database.SubmitChanges();
                            Orders.Clear();
                            App.database.GetTable<Order>().ToList().ForEach(x => Orders.Add(x));
                            CurrentOrder = null;
                            CurrentOrderProducts.Clear();
                           
                        },
                        x => CurrentOrder  != null && CurrentOrder.Status == 0
                );
            }
        }
        
        public RelayCommand AddButton
        {
            get
            {
                return new RelayCommand(
                    obj =>
                    {
                        Order temp = new Order();

                        Orders.Add(temp);
                    }
                );
            }
        }
        
        public RelayCommand CloseButton
        {
            get
            {
                return new RelayCommand(
                    obj =>
                    {
                        var r = MessageBox.Show("Закрытие заказа", "Подтверждение", MessageBoxButton.OKCancel);
                        if (r == MessageBoxResult.OK)
                        {
                            App.database.ExecuteCommand("CloseOrder {0}, {1}", new Object[] {CurrentOrder.Id, DateTime.Now});
                            CurrentOrder.Status = 1;
                            Orders.Clear();
                            App.database.GetTable<Order>().
                                ToList().ForEach(x => Orders.Add(x));
                            CurrentOrder = null;
                            CurrentOrderProducts.Clear();
                        }
                        
                    },
                    x => CurrentOrder!= null && CurrentOrder.Status != 1
                );
            }
        }
        
    }
}
