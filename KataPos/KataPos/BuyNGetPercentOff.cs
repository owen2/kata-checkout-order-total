using System;
using System.Collections.Generic;

namespace KataPos
{
    public class BuyNGetPercentOff :ISpecial
    {

        public string Barcode
        {
            get;
            set;
        }

        public int TriggerQuantity
        {
            get;
            set;
        }

        public decimal PercentOff
        {
            get;
            set;
        }

        public decimal CalculateDiscount(IEnumerable<Item> items)
        {
            throw new NotImplementedException();
        }
    }
}
