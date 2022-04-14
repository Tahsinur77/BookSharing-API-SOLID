using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELL.Entites
{
    public class SellerDetailsModel
    {
        public int Id { get; set; }
        [Required]
        public int SellerId { get; set; }
        [Required]
        public string Nid { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string ShopNumber { get; set; }
        [Required]
        public string ShopDocuments { get; set; }
    }
}
