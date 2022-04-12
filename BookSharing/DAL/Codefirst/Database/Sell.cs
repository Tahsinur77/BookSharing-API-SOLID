using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Codefirst.Database
{
    public class Sell
    {
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public string Status { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }
    }
}
