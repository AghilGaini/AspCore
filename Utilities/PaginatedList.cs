using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class PaginatedList<T> : List<T>
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public bool HasNext => PageIndex < TotalPages;
        public int NextPage => PageIndex + 1;
        public int PervoisPage => PageIndex - 1;
        public bool HasPervious => PageIndex > 1;
        public PaginatedList(IEnumerable<T> source, int pageSize, int pageIndex)
        {
            PageSize = pageSize;
            PageIndex = pageIndex;
            TotalCount = source.Count();
            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);
            this.AddRange(source.Skip((PageIndex - 1) * pageSize).Take(pageSize).ToList());
        }

    }
}
