using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace Store.DataBaseModels
{
    [Table(Name = "Products")]
    public class Product
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }
        [Column(Name = "Title")]
        public string Title { get; set; }
        [Column(Name = "Price")]
        public decimal Price { get; set; }
        [Column(Name = "CategoryId")]
        public int CategoryId { get; set; }
        private EntityRef<Category> _Category;
        [Association(Storage = "_Category", ThisKey = "CategoryId")]
        public Category Category
        {
            get { return this._Category.Entity; }
            set { 
                this._Category.Entity = value; 
            }
        }
    }
}
