using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductCost { get; set; }

        //[Display(Name = "Category_model")]
        //public virtual int CategoryID { get; set; }

        //[ForeignKey("CategoryID")]
        //public virtual Category Category { get; set; }

    }
}
