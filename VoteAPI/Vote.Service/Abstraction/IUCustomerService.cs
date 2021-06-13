using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vote.Model;
using Vote.Model.Models;

namespace Vote.Service.Abstraction
{
    
    public interface IUCustomerService
    {

        UCustomerModel Authentication(UCustomers uCustomers);
        UCustomerModel ResendOtp(UCustomers uCustomers);
        UCustomerModel VerifyOtp(UCustomers uCustomers);
        UCustomerModel GetProfile(int id);
        UCustomerModel UpdateProfile(UCustomers uCustomers);
        UCustomerModel PostOrder(UOrders uOrders);
        UOrdersList GetOrder(int id);
        UOrderModel GetOrderDetail(int id);
        UOrderModel DeleteOrder(int id);
    }
}
