using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class OrderDetail
    {
        [Key]
        [Column(Order=0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ProductId { get; set; }
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long OrderId { get; set; }
        public int Quantity { get; set; }
        public decimal? Price { get; set; }
    }
}
