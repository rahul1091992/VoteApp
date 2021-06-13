using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vote.Model;
using Vote.Model.Models;

namespace Vote.Service.Abstraction
{

    public interface IUDriverService
    {
        UDriverModel Get(int id);
        UDriverModel ForgotPassword(string email);
        UDriverModel Login(UDrivers uDrivers);
        UDriverModel Register(UDrivers uDrivers);
        UDriverModel UpdateLocation(UDrivers uDrivers);
        UDriverList GetAll();

        UDriverOrdersList GetOrder(int id, int size, int skip);
        UDriverOrderModel GetOrderDetail(int id);



        UProductList GetAllProduct();
        UDriverModel Notification(UDrivers uDrivers);
        UBProductList GetAllBProduct();
        UDriverModel SaveCollection(UBProduct uBProduct);
        UDriverModel SaveProduct(UBProductSave uBProductSave);
    }
}