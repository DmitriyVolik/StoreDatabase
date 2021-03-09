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
    class ProductForm : BaseViewModel
    {
        public Window Window;

        public ProductViewModel Product { get; set; }

        public ObservableCollection<Category> Categories { get; set; } = new ObservableCollection<Category>();

        public ProductForm(ProductViewModel product)
        {
            Product = product;

            foreach (var item in App.database.GetTable<Category>())
            {
                Categories.Add(item);
            }
        }
        
        public RelayCommand SaveButton
        {
            get
            {
                return new RelayCommand(
                        obj =>
                        {
                            SaveChanges = true;
                            App.database.SubmitChanges();
                            Window.Close();
                        }
                    );
            }
        }

        public bool SaveChanges = false;

        public RelayCommand ResetButton
        {
            get
            {
                return new RelayCommand(
                        obj =>
                        {
                            Product.ResetChanges();
                        }
                    );
            }
        }

        public RelayCommand CancelButton
        {
            get
            {
                return new RelayCommand(
                        obj =>
                        {
                            Product.ResetChanges();
                            Window.Close();
                        }
                    );
            }
        }

        public RelayCommand CloseWindowCommand
        {
            get
            {
                return new RelayCommand(
                        obj =>
                        {
                            Product.ResetChanges();
                        },
                        x => SaveChanges == false
                    );
            }
        }

        
    }
}
