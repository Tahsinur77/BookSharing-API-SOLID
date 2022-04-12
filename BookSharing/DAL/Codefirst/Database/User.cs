using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Codefirst.Database
{
    public class User
    {
        public User()
        {
            this.Shops = new HashSet<Shop>();
            this.BookDetails = new HashSet<BookDetails>();
            this.TokenAccesses = new HashSet<TokenAccess>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public string Picture { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Password { get; set; }
        public virtual ICollection<Shop> Shops { get; set; }
        public virtual ICollection<BookDetails> BookDetails { get; set; }
        public virtual ICollection<TokenAccess> TokenAccesses { get; set; }
    }
}
