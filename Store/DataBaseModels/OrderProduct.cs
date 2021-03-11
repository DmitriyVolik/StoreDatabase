using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace Store.DataBaseModels
{
    [Table(Name = "OrderProducts")]
    public class OrderProduct
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }
        [Column(Name = "ProductId")]
        public int? ProductId { get; set; }
        [Column(Name = "OrderId")]
        public int OrderId { get; set; }
        [Column(Name = "Quantity")]
        public int Quantity { get; set; }

        private EntityRef<Product> _Product;
        [Association(Storage = "_Product", ThisKey = "ProductId", OtherKey = "Id", IsForeignKey = true)]
        public Product Product
        {
            get { return this._Product.Entity; }
            set
            {
                this._Product.Entity = value;
            }
        }
        
        private EntityRef<Order> _Order;
        [Association(Storage = "_Order", ThisKey = "OrderId", OtherKey = "Id", IsForeignKey = true)]
        public Order Order
        {
            get { return this._Order.Entity; }
            set
            {
                this._Order.Entity = value;
            }
        }
    }
}
