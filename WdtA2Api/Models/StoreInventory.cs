using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WdtA2Api.Models
{
    public class StoreInventory
    {
        public long StoreId { get; set; }
        public Store Store { get; set; }

        public long ProductId { get; set; }
        public Product Product { get; set; }

        public int StockLevel { get; set; }
    }
}
