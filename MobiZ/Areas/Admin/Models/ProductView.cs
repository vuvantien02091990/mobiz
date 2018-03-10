using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobiZ.Areas.Admin.Models
{
    public class ProductView
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public decimal? Price { get; set; }
        public string CategoryName { get; set; }
        public string ManuName { get; set; }
      //  public 
    }
}