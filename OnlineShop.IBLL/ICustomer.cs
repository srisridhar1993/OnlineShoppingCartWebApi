using OnlineShop.Model;
using System.Collections.Generic;

namespace OnlineShop.IBLL
{
    public interface ICustomer
    {
        M_Customer AddNewCustomer(M_Customer customer);
        List<M_Customer> GetCustomer(long? customerId);
        M_Customer CustomerLogin(M_Customer customer);
        M_BillingAddress AddNewAddress(M_BillingAddress address);
        List<M_BillingAddress> GetAllAddress(SearchAddress address);
        List<M_Country> GetAllCountry(int? countryId);
        List<M_State> GetAllState(int? countryId,int? stateId);
    }
}
