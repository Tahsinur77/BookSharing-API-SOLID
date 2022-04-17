using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELL.Entites
{
    public class BookDetailModel
    {
        public int Id { get; set; }
        [Required]
        public int SellerId { get; set; }
        [Required]
        public int BookId { get; set; }
        [Required]
        public int ShopId { get; set; }
        [Required]
        public string BookQuantity { get; set; }
    }
}
