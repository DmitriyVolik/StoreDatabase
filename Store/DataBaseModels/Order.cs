using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace Store.DataBaseModels
{
    [Table(Name = "Orders")]
    public class Order
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }
        [Column(Name = "Status")]
        public int Status { get; set; }
        [Column(Name = "ClosedDate")]
        public DateTime ClosedDate { get; set; }
        [Column(Name = "UpdatedAt")]
        public DateTime UpdatedAt { get; set; }

        public string StatusName
        {
            get
            {
                switch (Status)
                {
                    case 0:
                        return "Open";
                    case 1:
                        return "Closed";
                    default:
                        return Status.ToString();
                }
            }
        }

        private EntitySet<OrderProduct> _OrderProducts;
        [Association(Storage = "_OrderProducts", ThisKey = "Id", OtherKey = "OrderId")]
        public EntitySet<OrderProduct> OrderProducts
        {
            get { return this._OrderProducts; }
            set
            {
                this._OrderProducts.Assign(value);
            }
        }
    }
}
