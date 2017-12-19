using System.Collections.Generic;

namespace Epons.Domain.Models
{
    public class Pagination<T>
    {
        public IList<T> Items { get; set; }
        public int Start { get; set; }
        public int End { get; set; }
        public int Count { get; set; }
    }
}
