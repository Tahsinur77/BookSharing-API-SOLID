using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELL.Entites
{
    public class OrderDetailsModel
    {
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int BookId { get; set; }
        [Required]
        public int SellerId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string price { get; set; }
        [Required]
        public int ShopId { get; set; }
        [Required]

        public string Status { set; get; }

        //public BookModel Book { get; set; }
        //public ShopModel Shop { get; set; }
        //public UserModel User { get; set; }
    }
}
