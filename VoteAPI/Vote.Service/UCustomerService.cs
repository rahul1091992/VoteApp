using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vote.Data.Abstraction;
using Vote.Model;
using Vote.Model.Models;
using Vote.Service.Abstraction;

namespace Vote.Service
{
    
    public class UCustomerService : IUCustomerService
    {
        IUCustomerRepository _uCustomerRepository;
        public UCustomerService(IUCustomerRepository uCustomerRepository)
        {
            _uCustomerRepository = uCustomerRepository;
        }
        public UCustomerModel Authentication(UCustomers uCustomers)
        {
            return _uCustomerRepository.Authentication(uCustomers);
        }
        public UCustomerModel ResendOtp(UCustomers uCustomers)
        {
            return _uCustomerRepository.ResendOtp(uCustomers);
        }
        public UCustomerModel VerifyOtp(UCustomers uCustomers)
        {
            return _uCustomerRepository.VerifyOtp(uCustomers);
        }
        public UCustomerModel GetProfile(int id)
        {
            return _uCustomerRepository.GetProfile(id);
        }
        public UCustomerModel UpdateProfile(UCustomers uCustomers)
        {
            return _uCustomerRepository.UpdateProfile(uCustomers);
        }
        public UCustomerModel PostOrder(UOrders uOrders)
        {
            return _uCustomerRepository.PostOrder(uOrders);
        }
        public UOrdersList GetOrder(int id)
        {
            return _uCustomerRepository.GetOrder(id);
        }
        public UOrderModel GetOrderDetail(int id)
        {
            return _uCustomerRepository.GetOrderDetail(id);
        }
        public UOrderModel DeleteOrder(int id)
        {
            return _uCustomerRepository.DeleteOrder(id);
        }
    }
}
