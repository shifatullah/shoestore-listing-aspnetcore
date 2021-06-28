using Azure.Search.Documents.Indexes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shoestore_listing_aspnetcore.Indexes
{
    public class Product
    {
        [SearchableField()]
        public string id { get; set; }

        [SearchableField]
        public string Name { get; set; }
        
        [SearchableField(IsFilterable = true)]
        public string Code { get; set; }

        [SearchableField(IsSortable = true)]
        public int Rank { get; set; }

        [SearchableField]
        public string ShortDescription { get; set; }

        [SearchableField]
        public string LongDescription { get; set; }

        [SearchableField(IsFacetable = true)]
        public string Category { get; set; }

        [SearchableField(IsFacetable = true)]
        public string Brand { get; set; }

        [SearchableField(IsFacetable = true)]
        public string Size { get; set; }
        
        [SearchableField(IsFacetable = true)]
        public string Gender { get; set; }

        [SearchableField(IsFacetable = true)]
        public string AgeGroup { get; set; }

        [SearchableField(IsFacetable = true)]
        public string Colour { get; set; }

        [SearchableField(IsFacetable = true, IsSortable = true)]
        public decimal Price { get; set; }
    }
}
