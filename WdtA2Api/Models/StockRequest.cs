using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WdtA2Api.Models
{
    public class StockRequest
    {
        public long StockRequestId { get; set; }

        public long StoreId { get; set; }
        public Store Store { get; set; }

        public long ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
