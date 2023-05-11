using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HymnCenter.Shared.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        [NotMapped]
        public bool IsSelected { get; set; }
        public virtual ICollection<Hymn> Hymns { get; set; } = new List<Hymn>();
    }
}
