using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vote.Model
{
   public class UOrders
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int DriverId { get; set; }
        public string FromLat { get; set; }
        public string FromLng { get; set; }
        public string ToLat { get; set; }
        public string ToLng { get; set; }
        public decimal Price { get; set; }
        public int OrderStatus { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Img { get; set; }
    }


    public class UOrdersCustomer
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int DriverId { get; set; }
        public string FromLat { get; set; }
        public string FromLng { get; set; }
        public string ToLat { get; set; }
        public string ToLng { get; set; }
        public decimal Price { get; set; }
        public int OrderStatus { get; set; }
        public DateTime CreatedOn { get; set; }


        public string DriverFullName { get; set; }
        public string DriverEmail { get; set; }
        public string DriverPhone { get; set; }
        public string DriverLat { get; set; }
        public string DriverLng { get; set; }
    }

    public class UOrdersDriver
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int DriverId { get; set; }
        public string FromLat { get; set; }
        public string FromLng { get; set; }
        public string ToLat { get; set; }
        public string ToLng { get; set; }
        public decimal Price { get; set; }
        public int OrderStatus { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Img { get; set; }

        public string CustomerFullName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
      
    }

}
