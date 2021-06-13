using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Vote.Data.Abstraction;
using Vote.Data.DB;
using Vote.Data.Helper;
using Vote.Model;
using Vote.Model.Models;

namespace Vote.Data
{

    public class UDriverRepository : IUDriverRepository
    {
        private VoteDBContext voteContext;
        public UDriverRepository(VoteDBContext db)
        {
            voteContext = db;
        }
        public UDriverModel ForgotPassword(string email)
        {
            UDriverModel statusResponse = new UDriverModel();
            var result = voteContext.uDrivers.Where(x => x.Email == email).FirstOrDefault();
            if (result != null)
            {
                string newPass = SendEmail.GenerateRandomPassword();
                bool passCheck = SendEmail.SendForgotPasswordMail(result.FullName, result.Email, newPass);
                if (passCheck)
                {
                    result.Password = EncryptPassword.EncodePasswordToBase64(newPass);
                    voteContext.SaveChanges();
                    statusResponse.Status = true; statusResponse.Message = "Password have been send on your email";
                }
                else
                {
                    statusResponse.Status = false; statusResponse.Message = "There are some problem in email please try again";
                }
            }
            else
            {
                statusResponse.Status = false; statusResponse.Message = "Invalid email";
            }

            return statusResponse;
        }
        public UDriverModel Login(UDrivers uDrivers)
        {
            UDriverModel statusResponse = new UDriverModel();
            uDrivers.Password = EncryptPassword.EncodePasswordToBase64(uDrivers.Password);
            var data = voteContext.uDrivers.Where(x => x.Email == uDrivers.Email && x.Password == uDrivers.Password).FirstOrDefault();
            if (data != null)
            {

                statusResponse.Status = true; statusResponse.Message = "Login successful"; statusResponse.Data = data;

            }
            else
            {
                statusResponse.Status = false; statusResponse.Message = "Invalid credentials";
            }

            return statusResponse;
        }
        public UDriverModel Register(UDrivers uDrivers)
        {
            UDriverModel statusResponse = new UDriverModel();
            var email = voteContext.uDrivers.Where(x => x.Email == uDrivers.Email).FirstOrDefault();
            if (email != null)
            {
                statusResponse.Status = false; statusResponse.Message = "Email already exists";
            }

            if (email == null)
            {


                uDrivers.Password = EncryptPassword.EncodePasswordToBase64(uDrivers.Password);
                voteContext.uDrivers.Add(uDrivers);
                voteContext.SaveChanges();
                statusResponse.Status = true; statusResponse.Message = "Driver Registered";
            }

            return statusResponse;
        }

        public UDriverModel UpdateLocation(UDrivers uDrivers)
        {
            UDriverModel statusResponse = new UDriverModel();
            var data = voteContext.uDrivers.Where(x => x.Id == uDrivers.Id).FirstOrDefault();
            if (data != null)
            {

                if (data.Lat != uDrivers.Lat && data.Lng != uDrivers.Lng)
                {
                    try
                    {
                        string Message = "Your Lat Lng is- " + uDrivers.Lat + " " + uDrivers.Lng;
                        string serverKey = string.Empty;
                        serverKey = "AAAALhOO1sU:APA91bGMKmKeWJs3D4XjWQRUQg1VruBc8CBSiesFmc_DacT6TQEBXrLJbDoze_fxGgqNKOcFom9hI8NS6nl59o79Jh9z9Lvu6ipszE0SumrO8DH_mCbPaOSzl9wNB4roFs0x0J6BEPpe";
                        var result21 = "-1";
                        var webAddr = "https://fcm.googleapis.com/fcm/send";
                        var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
                        httpWebRequest.ContentType = "application/json";
                        httpWebRequest.Headers.Add("Authorization:key=" + serverKey);
                        httpWebRequest.Method = "POST";
                        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                        {

                            string json = string.Empty;
                            if (data.DeviceType == 1)
                            {

                                json = "{\"to\": \"" + data.DeviceToken + "\",\"data\": {\"message\": \"" + Message + "\",}}";
                            }
                            else
                            {
                                json = "{\"to\": \"" + data.DeviceToken + "\",\"notification\": {\"body\": \"" + Message + "\",\"sound\": \"default\",\"content_available\": true}}";

                            }
                            streamWriter.Write(json);
                            streamWriter.Flush();
                        }
                        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                        {
                            result21 = streamReader.ReadToEnd();
                        }


                    }
                    catch (Exception)
                    {

                    }
                }

                data.Lat = uDrivers.Lat;
                data.Lng = uDrivers.Lng;
                voteContext.SaveChanges();
                statusResponse.Status = true; statusResponse.Message = "Location updated"; statusResponse.Data = data;

            }
            else
            {
                statusResponse.Status = false; statusResponse.Message = "User not found";
            }

            return statusResponse;
        }
        public UDriverModel Get(int id)
        {
            UDriverModel statusResponse = new UDriverModel();
            var data = voteContext.uDrivers.Where(x => x.Id == id).FirstOrDefault();
            if (data != null)
            {
                statusResponse.Status = true; statusResponse.Message = "Driver details"; statusResponse.Data = data;

            }
            else
            {
                statusResponse.Status = false; statusResponse.Message = "Driver not found";
            }

            return statusResponse;
        }
        public UDriverList GetAll()
        {
            UDriverList statusResponse = new UDriverList();
            var data = voteContext.uDrivers.ToList();
            if (data.Count > 0)
            {
                statusResponse.Status = true; statusResponse.Message = "Driver list"; statusResponse.Data = data;
            }
            else
            {
                statusResponse.Status = false; statusResponse.Message = "Drivers not found";
            }

            return statusResponse;
        }

        public UDriverOrdersList GetOrder(int id, int size, int skip)
        {
            UDriverOrdersList statusResponse = new UDriverOrdersList();
            if (skip != 0)
                skip = skip * size;
            var result = voteContext.uOrders.OrderByDescending(x => x.CreatedOn).Skip(skip).Take(size).ToList();


            if (result.Count > 0)
            {
                List<UOrdersDriver> lst = new List<UOrdersDriver>();
                foreach (var item in result)
                {
                    var customer = voteContext.uCustomers.Where(x => x.Id == item.CustomerId).FirstOrDefault();
                    lst.Add(new UOrdersDriver { Img = item.Img, CreatedOn = item.CreatedOn, CustomerId = item.CustomerId, CustomerEmail = customer.Email, CustomerFullName = customer.FullName, DriverId = item.DriverId, CustomerPhone = customer.Phone, FromLat = item.FromLat, FromLng = item.FromLng, Id = item.Id, OrderStatus = item.OrderStatus, Price = item.Price, ToLat = item.ToLat, ToLng = item.ToLng });
                }
                statusResponse.Status = true; statusResponse.Message = "Orders details"; statusResponse.Data = lst;
            }


            else
            {

                statusResponse.Status = false; statusResponse.Message = "Order not found";
            }

            return statusResponse;
        }
        public UDriverOrderModel GetOrderDetail(int id)
        {
            UDriverOrderModel statusResponse = new UDriverOrderModel();

            var result = voteContext.uOrders.Where(x => x.Id == id).FirstOrDefault();


            if (result != null)
            {
                var customer = voteContext.uCustomers.Where(x => x.Id == result.CustomerId).FirstOrDefault();
                UOrdersDriver ob = new UOrdersDriver();
                ob.CreatedOn = result.CreatedOn;
                ob.CustomerId = result.CustomerId;
                ob.CustomerEmail = customer.Email;
                ob.CustomerFullName = customer.FullName;
                ob.DriverId = result.DriverId;
                ob.CustomerPhone = customer.Phone;
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


        public UProductList GetAllProduct()
        {
            UProductList statusResponse = new UProductList();
            var data = voteContext.uProduct.ToList();
            if (data.Count > 0)
            {
                statusResponse.Status = true; statusResponse.Message = "Product List"; statusResponse.Data = data; statusResponse.TotalProduct = data.Count; statusResponse.ProductName = voteContext.uProduct.FirstOrDefault().Name;
            }
            else
            {
                statusResponse.Status = false; statusResponse.Message = "Product not found";
            }

            return statusResponse;
        }


        public UDriverModel Notification(UDrivers uDrivers)
        {
            UDriverModel statusResponse = new UDriverModel();
            var data = voteContext.uDrivers.Where(x => x.Id == uDrivers.Id).FirstOrDefault();
            if (data != null)
            {
                data.DeviceType = uDrivers.DeviceType;
                data.DeviceToken = uDrivers.DeviceToken;
                voteContext.SaveChanges();
                statusResponse.Status = true; statusResponse.Message = "Token updated"; statusResponse.Data = data;

            }
            else
            {
                statusResponse.Status = false; statusResponse.Message = "User not found";
            }

            return statusResponse;
        }


        public UBProductList GetAllBProduct()
        {
            UBProductList statusResponse = new UBProductList();
            var data = voteContext.uBProduct.ToList();
            if (data.Count > 0)
            {
                List<UBProductData> lst = new List<UBProductData>();
                foreach (var item in data)
                {
                    string p1 = "";
                    var sunProduct1 = voteContext.uProduct.Where(x => x.Name == item.PName).FirstOrDefault();
                    if (sunProduct1 != null)
                    {
                        p1 = sunProduct1.Image;
                    }
                    string p2 = "";
                    var sunProduct2 = voteContext.uProduct.Where(x => x.Name == item.PName).Skip(1).FirstOrDefault();
                    if (sunProduct2 != null)
                    {
                        p2 = sunProduct2.Image;
                    }
                    string p3 = "";
                    var sunProduct3 = voteContext.uProduct.Where(x => x.Name == item.PName).Skip(2).FirstOrDefault();
                    if (sunProduct3 != null)
                    {
                        p3 = sunProduct3.Image;
                    }
                    string p4 = "";
                    var sunProduct4 = voteContext.uProduct.Where(x => x.Name == item.PName).Skip(3).FirstOrDefault();
                    if (sunProduct4 != null)
                    {
                        p4 = sunProduct4.Image;
                    }
                    var totalProduct = voteContext.uProduct.Where(x => x.Name == item.PName).Count();
                    lst.Add(new UBProductData { TotalProduct = totalProduct, PName = item.PName, Id = item.Id, PImg1 = p1, PImg2 = p2, PImg3 = p3, PImg4 = p4 });
                }
                statusResponse.Status = true; statusResponse.Message = "Product List"; statusResponse.Data = lst;
            }
            else
            {
                statusResponse.Status = false; statusResponse.Message = "Product not found";
            }

            return statusResponse;
        }


        public UDriverModel SaveCollection(UBProduct uBProduct)
        {
            UDriverModel statusResponse = new UDriverModel();
            var data = voteContext.uBProduct.Where(x => x.PName == uBProduct.PName).FirstOrDefault();
            if (data == null)
            {
                voteContext.uBProduct.Add(uBProduct);
                voteContext.SaveChanges();
                statusResponse.Status = true; statusResponse.Message = "Collection Saved";

            }
            else
            {
                statusResponse.Status = false; statusResponse.Message = "Collection name already exists";
            }

            return statusResponse;
        }
        public UDriverModel SaveProduct(UBProductSave uBProductSave)
        {
            UDriverModel statusResponse = new UDriverModel();
            var data = voteContext.uProduct.Where(x => x.Name == uBProductSave.Name).ToList();
            foreach (var item in data)
            {
                voteContext.uProduct.Remove(item);
                voteContext.SaveChanges();
            }
            foreach (var item in uBProductSave.Data)
            {
                var cn = voteContext.uProduct.Where(x => x.Id == item.Id).FirstOrDefault();
                cn.Name = uBProductSave.Name;
                voteContext.SaveChanges();
            }

            statusResponse.Status = true; statusResponse.Message = "Product Saved";



            return statusResponse;
        }
    }
}
