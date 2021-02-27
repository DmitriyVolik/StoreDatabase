using Store.DataBaseModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.ViewModels
{
    class ProductsForm : BaseViewModel
    {
        public IEnumerable<Product> Products { get; set; }

        public ProductsForm()
        {
            Products = App.database.GetTable<Product>();
        }

        public RelayCommand SaveButton
        {
            get
            {
                return new RelayCommand(
                        obj =>
                        {
                            App.database.SubmitChanges();
                        }
                    );
            }
        }
    }
}
