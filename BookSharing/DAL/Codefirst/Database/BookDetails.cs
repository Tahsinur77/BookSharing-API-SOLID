using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Codefirst.Database
{
    public class BookDetails
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="User")]
        public int SellerId { get; set; }
        [Required]
        public int BookId { get; set; }
        [Required]
        public int ShopId { get; set; }
        [Required]
        public string BookQuantity { get; set; }
        //[Required]
        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }
        //[Required]
        [ForeignKey("ShopId")]
        public virtual Shop Shop { get; set; }
        //[Required]
        [ForeignKey("SellerId")]
        public virtual User User { get; set; }
    }
}
