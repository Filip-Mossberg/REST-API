using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingTeknikModels
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public DateTime OrderPlaced { get; set; }
        public int CustomerID { get; set; }
        public Customer Cus { get; set; }
    }
}
