using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WdtA2Api.Models
{
    public class OwnerInventory
    {   
        // foreign key for Product, disable auto increment
        [Key, ForeignKey("Product"), 
         Display(Name = "Product ID"), 
         DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ProductId { get; set; }
        public Product Product { get; set; }

        [Display(Name = "Stock Level")]
        public int StockLevel { get; set; }
    }
}
