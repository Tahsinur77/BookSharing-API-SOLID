using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Codefirst.Database
{
    public class Book
    {
        public Book()
        {
            this.BookDetails = new HashSet<BookDetails>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public string Price { get; set; }
        [Required]
        public string Edition { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Language { get; set; }
        [Required]
        public string NumberOfPages { get; set; }
        [Required]
        public string Picture { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Status { get; set; }
        [ForeignKey("AuthorId")]
        public virtual Author Author { get; set; }
        public virtual ICollection<BookDetails> BookDetails { get; set; }
    }
}
