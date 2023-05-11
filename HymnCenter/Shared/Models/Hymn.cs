using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace HymnCenter.Shared.Models
{
    public class Hymn
    {
        public int HymnId { get; set; }
        public string Title { get; set;}
        public string Scale { get; set; }
        public string Lyrics { get; set; }
        public bool IsDeleting { get; set; }
        public ICollection<Listing> Listings { get; set; } = new List<Listing>();
        public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
    }
}
