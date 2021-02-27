using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace Store.DataBaseModels
{
    [Table(Name = "Categories")]
    public class Category
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }
        [Column(Name = "Title")]
        public string Title { get; set; }
    }
}
