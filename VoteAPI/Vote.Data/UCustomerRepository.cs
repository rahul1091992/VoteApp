using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vote.Data.Abstraction;
using Vote.Data.DB;
using Vote.Data.Helper;
using Vote.Model;
using Vote.Model.Models;

namespace Vote.Data
{

    public class UCustomerRepository : IUCustomerRepository
    {
        private VoteDBContext voteDBContext;
        public UCustomerRepository(VoteDBContext db)
        {
            voteDBContext = db;
        }
        public UCustomerModel Authentication(UCustomers uCustomers)
        {
            UCustomerModel statusResponse = new UCustomerModel();

            var result = voteDBContext.uCustomers.Where(x => x.Phone == uCustomers.Phone).FirstOrDefault();
            int code = SendOtp.SendOtpCode();
            if (code == 0)
            {
                statusResponse.Status = false; statusResponse.Message = "OTP not send";
            }


            if (result != null)
            {
                result.Otp = code;
                voteDBContext.SaveChanges();
                statusResponse.Status = true; statusResponse.Message = "OTP Send"; statusResponse.Data = result;
            }


            else
            {

                uCustomers.Otp = code;
                voteDBContext.uCustomers.Add(uCustomers);
                voteDBContext.SaveChanges();
                statusResponse.Status = true; statusResponse.Message = "OTP Send"; statusResponse.Data = uCustomers;
            }

            return statusResponse;
        }

        public UCustomerModel ResendOtp(UCustomers uCustomers)
        {
            UCustomerModel statusResponse = new UCustomerModel();

            var result = voteDBContext.uCustomers.Where(x => x.Id == uCustomers.Id).FirstOrDefault();
            int code = SendOtp.SendOtpCode();
            if (code == 0)
            {
                statusResponse.Status = false; statusResponse.Message = "OTP not send";
            }


            if (result != null)
            {
                result.Otp = code;
                voteDBContext.SaveChanges();
                statusResponse.Status = true; statusResponse.Message = "OTP Send"; statusResponse.Data = result;
            }


            else
            {

                statusResponse.Status = false; statusResponse.Message = "Invalid User";
            }

            return statusResponse;
        }
        public UCustomerModel VerifyOtp(UCustomers uCustomers)
        {
            UCustomerModel statusResponse = new UCustomerModel();

            var result = voteDBContext.uCustomers.Where(x => x.Id == uCustomers.Id && x.Otp == uCustomers.Otp).FirstOrDefault();


            if (result != null)
            {

                statusResponse.Status = true; statusResponse.Message = "OTP Verify"; statusResponse.Data = result;
            }


            else
            {

                statusResponse.Status = false; statusResponse.Message = "Invalid OTP";
            }

            return statusResponse;
        }
        public UCustomerModel GetProfile(int id)
        {
            UCustomerModel statusResponse = new UCustomerModel();

            var result = voteDBContext.uCustomers.Where(x => x.Id == id).FirstOrDefault();


            if (result != null)
            {

                statusResponse.Status = true; statusResponse.Message = "User details"; statusResponse.Data = result;
            }


            else
            {

                statusResponse.Status = false; statusResponse.Message = "Invalid user";
            }

            return statusResponse;
        }
        public UCustomerModel UpdateProfile(UCustomers uCustomers)
        {
            UCustomerModel statusResponse = new UCustomerModel();

            var result = voteDBContext.uCustomers.Where(x => x.Id == uCustomers.Id).FirstOrDefault();


            if (result != null)
            {
                result.FullName = uCustomers.FullName;
                result.Email = uCustomers.Email;
                voteDBContext.SaveChanges();
                statusResponse.Status = true; statusResponse.Message = "Profile updated"; statusResponse.Data = result;
            }


            else
            {

                statusResponse.Status = false; statusResponse.Message = "Invalid user";
            }

            return statusResponse;
        }
        public UCustomerModel PostOrder(UOrders uOrders)
        {
            UCustomerModel statusResponse = new UCustomerModel();

            var driver = voteDBContext.uDrivers.OrderBy(x => Guid.NewGuid()).FirstOrDefault();

            uOrders.DriverId = driver.Id;
            uOrders.CreatedOn = DateTime.Now;
            uOrders.OrderStatus = 1;
            voteDBContext.uOrders.Add(uOrders);
            voteDBContext.SaveChanges();
            statusResponse.Status = true; statusResponse.Message = "Ride created";


            return statusResponse;
        }
        public UOrdersList GetOrder(int id)
        {
            UOrdersList statusResponse = new UOrdersList();

            var result = voteDBContext.uOrders.Where(x => x.CustomerId == id).ToList();


            if (result.Count>0)
            {
                List<UOrdersCustomer> lst = new List<UOrdersCustomer>();
                foreach (var item in result)
                {
                    var driver = voteDBContext.uDrivers.Where(x => x.Id == item.DriverId).FirstOrDefault();
                    lst.Add(new UOrdersCustomer { CreatedOn = item.CreatedOn, CustomerId = item.CustomerId, DriverEmail = driver.Email, DriverFullName = driver.FullName, DriverId = item.DriverId, DriverLat = driver.Lat, DriverLng = driver.Lng, DriverPhone = driver.Phone, FromLat = item.FromLat, FromLng = item.FromLng, Id = item.Id, OrderStatus = item.OrderStatus, Price = item.Price, ToLat = item.ToLat, ToLng = item.ToLng });
                }
                statusResponse.Status = true; statusResponse.Message = "User details"; statusResponse.Data = lst;
            }


            else
            {

                statusResponse.Status = false; statusResponse.Message = "Order not found";
            }

            return statusResponse;
        }
        public UOrderModel GetOrderDetail(int id)
        {
            UOrderModel statusResponse = new UOrderModel();

            var result = voteDBContext.uOrders.Where(x => x.CustomerId == id).FirstOrDefault();


            if (result != null)
            {
                var driver = voteDBContext.uDrivers.Where(x => x.Id == result.DriverId).FirstOrDefault();
                UOrdersCustomer ob = new UOrdersCustomer();
                ob.CreatedOn = result.CreatedOn;
                ob.CustomerId = result.CustomerId;
                ob.DriverEmail = driver.Email;
                ob.DriverFullName = driver.FullName;
                ob.DriverId = result.DriverId;
                ob.DriverLat = driver.Lat;
                ob.DriverLng = driver.Lng;
                ob.DriverPhone = driver.Phone;
                ob.FromLat = result.FromLat;
                ob.FromLng = result.FromLng;
                ob.Id = result.Id;
                ob.OrderStatus = result.OrderStatus;
                ob.Price = result.Price;
                ob.ToLat = result.ToLat;
                ob.ToLng = result.ToLng;

                statusResponse.Status = true; statusResponse.Message = "Order details"; statusResponse.Data = ob;
            }


            else
            {

                statusResponse.Status = false; statusResponse.Message = "Order not found";
            }

            return statusResponse;
        }



        public UOrderModel DeleteOrder(int id)
        {
            UOrderModel statusResponse = new UOrderModel();

            var result = voteDBContext.uOrders.Where(x => x.Id == id).FirstOrDefault();


            if (result != null)
            {
                voteDBContext.Remove(result);
                voteDBContext.SaveChanges();
                statusResponse.Status = true; statusResponse.Message = "Order deleted";
            }


            else
            {

                statusResponse.Status = false; statusResponse.Message = "Order not found";
            }

            return statusResponse;
        }
    }
}
