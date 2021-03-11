using Store.DataBaseModels;
using Store.Views;
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
using System.Windows.Forms;

namespace Store.ViewModels
{
    class ProductsForm : BaseViewModel
    {
        private ProductViewModel _currentProduct;
        public ProductViewModel CurrentProduct
        {
            get => _currentProduct;
            set
            {
                _currentProduct = value;
                OnPropertyChanged("CurrentProduct");
            }
        }

        public ObservableCollection<ProductViewModel> Products { get; set; } = new ObservableCollection<ProductViewModel>();

        public ObservableCollection<Category> Categories { get; set; } = new ObservableCollection<Category>();

        public ProductsForm()
        {
            foreach (var item in App.database.GetTable<Product>())
            {
                Products.Add(new ProductViewModel(item));
            }

            IEnumerable<Category> temp = App.database.GetTable<Category>().ToList();

            foreach (var item in temp)
            {
                Categories.Add(item);
            }
            //MessageBox.Show(Categories[0].Title.ToString());

        }

    

        public RelayCommand EditButton
        {
            get
            {
                return new RelayCommand(
                        obj =>
                        {
                            var f = new ProductWindow(CurrentProduct);
                            f.ShowDialog();
                            


                        },
                        x => CurrentProduct != null
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
                            var p = new Product();

                            var f = new ProductWindow(new ProductViewModel(p));
                            f.ShowDialog();
                            Products.Clear();
                            foreach (var item in App.database.GetTable<Product>())
                            {
                                Products.Add(new ProductViewModel(item));
                            }
                            
                            
                            

                        }
                    );
            }
        }

        
    }
}
