using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace HymnCenter.Shared.Models
{
    public class Listing
    {
        public int ListingId { get; set; }

        public string Header { get; set; }

        public DateTime? Date { get; set; }
        public ICollection<Hymn> Hymns { get; set; } = new List<Hymn>();

        public string Footer { get; set; }
        public bool IsDeleting { get; set; }

    }
}
