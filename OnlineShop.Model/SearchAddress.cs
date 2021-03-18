using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Model
{
    public class SearchAddress
    {
        public long AddressId { get; set; }
        public long CustomerId { get; set; }
        public string AddressType { get; set; }
        public bool? IsDefault { get; set; }

    }
}
