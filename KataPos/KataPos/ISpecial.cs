using System;
using System.Collections.Generic;

namespace KataPos
{
    public interface ISpecial
    {
        decimal CalculateDiscount(IEnumerable<Item> items);
    }
}
