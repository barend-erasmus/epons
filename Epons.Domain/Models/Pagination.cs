using System.Collections.Generic;

namespace Epons.Domain.Models
{
    public class Pagination<T>
    {
        public IList<T> Items { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
        public int Count { get; set; }
    }
}
