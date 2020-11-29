using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Specifications
{
    public class PhotoOfferSpecParams
    {
        private const int MaxPageSize = 50;
        public int PageIndex { get; set; } = 1;
        private int pageSize = 6;
        public int PageSize 
        {
            get => pageSize;
            set => pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public int? CategoryId { get; set; }
        public int? TypeId { get; set; }
        public string Sort { get; set; }
        private string search;
        public string Search
        {
            get => this.search;
            set => search = value.ToLower();
        }
    }
}
