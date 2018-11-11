namespace KataPos
{
    public abstract class Item
    {
        public string Barcode { get; set; }
        public abstract decimal Value { get; }
    }

    public class IndividualItem : Item
    {
        public IndividualItem(CatalogEntry catalogEntry)
        {
            EachesPrice = catalogEntry.Price;
            Barcode = catalogEntry.Barcode;
        }

        public override decimal Value { get => EachesPrice; }
        public decimal EachesPrice { get; set; }
    }

    public class ItemWithWeight : Item
    {
        public ItemWithWeight(CatalogEntry catalogEntry, decimal weight)
        {
            PerUnitPrice = catalogEntry.Price;
            Barcode = catalogEntry.Barcode;
            Weight = weight;
        }

        public decimal Weight { get; set; }
        public decimal PerUnitPrice { get; set; }
        public override decimal Value { get => Weight * PerUnitPrice; }
    }
}