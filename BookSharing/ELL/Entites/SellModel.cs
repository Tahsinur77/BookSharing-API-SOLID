using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELL.Entites
{
    public class SellModel
    {
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
