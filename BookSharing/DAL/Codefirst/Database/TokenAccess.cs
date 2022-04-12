using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Codefirst.Database
{
    public class TokenAccess
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Token { set; get; }
        [Required]
        public DateTime Createdat { set; get; }
        public DateTime Expiredat { set; get; }
        [ForeignKey("UserId")]
        public virtual User User { set; get; }
    }
}
