using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Codefirst.Database
{
    public class Order
    {
        public Order()
        {
            this.OrderDetails = new HashSet<OrderDetails>();
            this.Sells = new HashSet<Sell>();
        }
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Status { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        public virtual ICollection<Sell> Sells { get; set; }
    }
}
