using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Codefirst.Database
{
    public class Shop
    {
        public Shop()
        {
            this.BookDetails = new HashSet<BookDetails>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string ShopNumber { get; set; }
        [Required]
        public string Location { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public virtual ICollection<BookDetails> BookDetails { get; set; }
    }
}
