using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vote.Model
{
   public class UBProduct
    {
        public int Id { get; set; }
        public string PName { get; set; }
      
    }
    public class UBProductData
    {
        public int Id { get; set; }
        public string PName { get; set; }
        public string PImg1 { get; set; }
        public string PImg2 { get; set; }
        public string PImg3 { get; set; }
        public string PImg4 { get; set; }
        public int TotalProduct { get; set; }
    }


    public class UBProductSave
    {
        public UBProductSave()
        {
            Data = new List<UBProductId>();
        }
        public string Name { get; set; }
        public List<UBProductId> Data { get; set; }
    }
    public class UBProductId
    {
        public int Id { get; set; }
    }
}
