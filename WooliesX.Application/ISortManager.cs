using System.Collections.Generic;
using WooliesX.Domain.Entities;

namespace WooliesX.Application
{
    public interface ISortManager
    {
        public ICollection<Product> StandardSort(ICollection<Product> product, SortOptions sortOption);
    }
}