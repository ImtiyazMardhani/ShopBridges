using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridgeModelLayer
{
    public class Inventory
    {
        public Guid id { get; set; }
        [Required]
        [MaxLength(50,ErrorMessage ="Please Enter less than 50 characters")]
        public string name { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Please Enter less than 50 characters")]
        public string description { get; set; }
       
        [Required]
        public int price { get; set; }
    }
}
