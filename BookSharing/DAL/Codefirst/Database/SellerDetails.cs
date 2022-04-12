using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Codefirst.Database
{
    public class SellerDetails
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "User")]
        public int SellerId { get; set; }
        [Required]
        public string Nid { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string ShopNumber { get; set; }
        [Required]
        public string ShopDocuments { get; set; }
        [ForeignKey("SellerId")]
        public virtual User User { get; set; }
    }
}
