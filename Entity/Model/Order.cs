﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public partial class Order
    {
        public long ID { get; set; }
        public DateTime? CreateDate { get; set; }
        [StringLength(50)]
        public string ShipName { get; set; }
        [StringLength(50)]
        public string ShipAddress { get; set; }
        [StringLength(50)]
        public string ShipMobile { get; set; }
        [StringLength(50)]
        public string ShipMail { get; set; }
        public bool Status { get; set; }
    }
}
