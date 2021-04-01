namespace Vending_Machine
{
    public class Item
    {
        public string id;
        public string name;
        public int price;
        public int supply;

        public Item(string id, string name, int price, int supply)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.supply = supply;
        }
    }
}