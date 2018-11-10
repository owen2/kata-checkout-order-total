using System;
using System.Collections.Generic;

namespace KataPos
{
    public interface IPromotion
    {
        decimal CalculateDiscount(IEnumerable<Item> items);
    }
}
