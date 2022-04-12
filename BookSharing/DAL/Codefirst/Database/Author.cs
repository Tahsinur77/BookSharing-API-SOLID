using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Codefirst.Database
{
    public class Author
    {
        public Author()
        {
            this.Books = new HashSet<Book>();
        }
        
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Picture { get; set; }
        [Required]
        public string Details { get; set; }
        [Required]
        public string Email { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
