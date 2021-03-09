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
    class OrdersForm : BaseViewModel
    {
        public IEnumerable<Order> Orders { get; set; }

        public OrdersForm()
        {
            Orders = App.database.GetTable<Order>();
        }

        private Order _currentOrder;

        public Order CurrentOrder
        {
            get { return _currentOrder; }
            set
            {
                _currentOrder = value;
                OnPropertyChanged("CurrentOrder");

            }
        }

        //public RelayCommand SaveButton
        //{
        //    get
        //    {
        //        return new RelayCommand(
        //                obj =>
        //                {
        //                    App.database.SubmitChanges();
        //                }
        //            );
        //    }
        //}
    }
}
