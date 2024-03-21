namespace Lab6
{
    public class InventoryItem
    {
        public int ItemNo { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        
        public InventoryItem()
        {
        }

        public InventoryItem(int itemNo, string description, decimal price)
        {
            ItemNo = itemNo;
            Description = description;
            Price = price;
        }

        public override string ToString()
        {
            return $"{ItemNo}|{Description}|{Price}";
        }
    }
}