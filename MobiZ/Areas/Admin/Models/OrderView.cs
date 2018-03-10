using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MobiZ.Areas.Admin.Models
{
    public class OrderView
    {
        public long OrderId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal? Price { get; set; }
        public DateTime? CreateDate { get; set; }
        [StringLength(50)]
        public string ShipName { get; set; }
        [StringLength(50)]
        public string ShipAddress { get; set; }
        [StringLength(50)]
        public string ShipMobile { get; set; }
        [StringLength(50)]
        public string ShipMail { get; set; }
    }
}