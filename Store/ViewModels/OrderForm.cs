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

namespace Store.ViewModels
{
    class OrderForm : BaseViewModel
    {
        private Order _order;
        public Order Order { get => _order;
            set
            {
                _order = value;
                UpdateProductVariants();
                OnPropertyChanged("Order");
            } 
        }
        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();
        
        public void UpdateProductVariants()
        {
            OrderProducts.Clear();
            foreach (var op in Order.OrderProducts)
            {
                OrderProducts.Add(op);
            }
            
            Products.Clear();
            var products = Order.OrderProducts.Select(op => op.Product).ToList();
            foreach (var p in App.database.GetTable<Product>().Where(x => !products.Contains(x)))
            {
                Products.Add(p);
            }
        }
        
        public OrderForm()
        {
            
        }

        private Product _currentProduct;
        public Product CurrentProduct
        {
            get => _currentProduct;
            set
            {
                _currentProduct = value;
                OnPropertyChanged("CurrentProduct");
            }
        }
        private OrderProduct _currentOrderProduct;
        public OrderProduct CurrentOrderProduct
        {
            get => _currentOrderProduct;
            set
            {
                _currentOrderProduct = value;
                OnPropertyChanged("CurrentOrderProduct");
            }
        }

        public ObservableCollection<OrderProduct> OrderProducts { get; set; } = new ObservableCollection<OrderProduct>();

        public RelayCommand AddProductButton
        {
            get
            {
                return new RelayCommand(
                    obj =>
                    {
                        var op = new OrderProduct
                        {
                            Product = CurrentProduct,
                            Quantity = 1,
                            OrderId = Order.Id,
                            ProductId = CurrentProduct.Id
                        };
                        Order.OrderProducts.Add(op);
                        UpdateProductVariants();
                    },
                    x=> CurrentProduct != null
                );
            }
        }
        
        public RelayCommand RemoveProductButton
        {
            get
            {
                return new RelayCommand(
                    obj =>
                    {
                        App.database.GetTable<OrderProduct>().DeleteOnSubmit(CurrentOrderProduct);
                        Order.OrderProducts.Remove(CurrentOrderProduct);
                        UpdateProductVariants();
                    },
                    x => CurrentOrderProduct != null
                );
            }
        }
        
        
        
        
       
    }
}