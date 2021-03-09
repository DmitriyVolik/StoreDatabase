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
    public class ProductViewModel:BaseViewModel
    {
        private Product _product;
        private Product _initialProduct;

        public void UpdateInitial()
        {
            _initialProduct = _product.Clone();
        }

        public void ResetChanges()
        {
            _product.Title = _initialProduct.Title;
            _product.Price = _initialProduct.Price;
            _product.Category = _initialProduct.Category;
            //_product.CategoryId = _initialProduct.CategoryId;
            OnPropertyChanged("Title");
            OnPropertyChanged("Price");
            OnPropertyChanged("Category");
            OnPropertyChanged("CategoryTitle");
        }

        public ProductViewModel(Product product)
        {
            _product = product;
            UpdateInitial();
        }

        public string Title
        {
            get => _product.Title;
            set
            {
                _product.Title = value;
                OnPropertyChanged("Title");
            }
        }

        public decimal Price
        {
            get => _product.Price;
            set
            {
                _product.Price = value;
                OnPropertyChanged("Price");
            }
        }

        public string CategoryTitle
        {
            get => _product.Category.Title;
        }

        public Category Category
        {
            get => _product.Category;
            set { 
                _product.Category = value;
                OnPropertyChanged("CategoryTitle");
            }
        }
    }
}
