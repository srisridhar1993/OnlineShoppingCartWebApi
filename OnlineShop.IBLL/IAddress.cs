using OnlineShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.IBLL
{
    public interface IAddress
    {
        M_BillingAddress AddNewBillingAddress(M_BillingAddress address);
        M_ShippingAddress AddNewShippingAddress(M_ShippingAddress address);
        IEnumerable<M_BillingAddress> GetAllBillingAddress(long customerId, long? billingAddressId);
        IEnumerable<M_ShippingAddress> GetAllShippingAddress(long customerId, long? shippingAddressId);
    }
}
