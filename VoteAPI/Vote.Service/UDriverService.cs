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
    
    public class UDriverService : IUDriverService
    {
        IUDriverRepository _uDriverRepository;
        public UDriverService(IUDriverRepository uDriverRepository)
        {
            _uDriverRepository = uDriverRepository;
        }
        public UDriverModel Get(int id)
        {
            return _uDriverRepository.Get(id);
        }
        public UDriverModel ForgotPassword(string email)
        {
            return _uDriverRepository.ForgotPassword(email);
        }
        public UDriverModel Login(UDrivers uDrivers)
        {
            return _uDriverRepository.Login(uDrivers);
        }
        public UDriverModel Register(UDrivers uDrivers)
        {
            return _uDriverRepository.Register(uDrivers);
        }
        public UDriverModel UpdateLocation(UDrivers uDrivers)
        {
            return _uDriverRepository.UpdateLocation(uDrivers);
        }
        public UDriverList GetAll()
        {
            return _uDriverRepository.GetAll();
        }

        public UDriverOrdersList GetOrder(int id, int size, int skip)
        {
            return _uDriverRepository.GetOrder(id,   size,   skip);
        }
        public UDriverOrderModel GetOrderDetail(int id)
        {
            return _uDriverRepository.GetOrderDetail(id);
        }


        public UProductList GetAllProduct()
        {
            return _uDriverRepository.GetAllProduct();
        }

        public UDriverModel Notification(UDrivers uDrivers)
        {
            return _uDriverRepository.Notification(uDrivers);
        }
        public UBProductList GetAllBProduct()
        {
            return _uDriverRepository.GetAllBProduct();
        }

        public UDriverModel SaveCollection(UBProduct uBProduct)
        {
            return _uDriverRepository.SaveCollection(uBProduct);
        }
        public UDriverModel SaveProduct(UBProductSave uBProductSave)
        {
            return _uDriverRepository.SaveProduct(uBProductSave);
        }
    }
}
