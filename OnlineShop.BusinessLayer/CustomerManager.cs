using OnlineShop.IBLL;
using System;
using System.Collections.Generic;
using OnlineShop.Model;
using OnlineShop.DataAccessLayer.Repository;

namespace OnlineShop.BusinessLayer
{
    public class CustomerManager : ICustomer
    {
        ICustomerDA icustomer;
        public CustomerManager(ICustomerDA _icustomer)
        {
            icustomer = _icustomer;
        }
        M_Customer ICustomer.AddNewCustomer(M_Customer customer)
        {
            M_Customer obj = new M_Customer();
            obj = icustomer.AddNewCustomer(customer);
            return obj;
        }

        M_Customer ICustomer.CustomerLogin(M_Customer customer)
        {
            M_Customer obj = new M_Customer();
            obj = icustomer.CustomerLogin(customer);
            return obj;
        }
       
        List<M_BillingAddress> ICustomer.GetAllAddress(SearchAddress address)
        {
            try
            {
                return icustomer.GetAllAddress(address);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        M_BillingAddress ICustomer.AddNewAddress(M_BillingAddress address)
        {
            try
            {
                return icustomer.AddNewAddress(address);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        List<M_Customer> ICustomer.GetCustomer(long? customerId)
        {
            try
            {
                List<M_Customer> custList = icustomer.GetCustomer(customerId);
                return custList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        List<M_Country> ICustomer.GetAllCountry(int? countryId)
        {
            try
            {
                List<M_Country> country = icustomer.GetAllCountry(countryId);
                return country;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        List<M_State> ICustomer.GetAllState(int? countryId, int? stateId)
        {
            try
            {
                List<M_State> state = icustomer.GetAllState(countryId,stateId);
                return state;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
