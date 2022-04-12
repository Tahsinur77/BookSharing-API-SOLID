using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Codefirst.Database
{
    public class OrderDetails
    {
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int BookId { get; set; }
        [Required]
        [Display(Name ="User")]
        public int SellerId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string price { get; set; }
        [Required]
        public int ShopId { get; set; }
        [Required]
        public string Status { set; get; }
        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }
        [ForeignKey("ShopId")]
        public virtual Shop Shop { get; set; }
        [ForeignKey("SellerId")]
        public virtual User User { get; set; }
    }
}
