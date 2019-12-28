using System;
using System.Collections.Generic;
using System.Linq;
using WooliesX.Domain.Entities;

namespace WooliesX.Application
{
    public enum SortOptions { Low, High, Ascending, Descending, Recommended }
    public class SortManager : ISortManager
    {
        public ICollection<Product> StandardSort(ICollection<Product> products, SortOptions sortOption)
        {
            switch (sortOption)
            {
                case SortOptions.Low:
                    return products.OrderBy(p => p.Price).ToList();
                case SortOptions.High:
                    return products.OrderByDescending(p => p.Price).ToList();
                case SortOptions.Ascending:
                    return products.OrderBy(p => p.Name, StringComparer.OrdinalIgnoreCase).ToList();
                case SortOptions.Descending:
                    return products.OrderByDescending(p => p.Name, StringComparer.OrdinalIgnoreCase).ToList();
                default:
                    return products;
            }
        }
    }
}
