namespace GildedRose
{
    public class Program
    {
        public static IList<Item> Items = new List<Item> {
            new NormalItem { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
            new BrieItem { Name = "Aged Brie", SellIn = 2, Quality = 0 },
            new NormalItem { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
            new LegendaryItem { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
            new LegendaryItem { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 },
            new BackstagePassItem { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 },
            new BackstagePassItem { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 49 },
            new BackstagePassItem { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 49 },
            new ConjuredItem { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
        };

        public static void Main(string[] args)
        {
            System.Console.Write("OMGHAI!\n");
            for (var i = 0; i < 31; i++)
            {
                Console.Write("-------- day " + i + " --------\n");
                Console.Write("name, sellIn, quality\n");
                for (var j = 0; j < Items.Count; j++)
                {
                    Console.Write(Items[j].Name + ", " + Items[j].SellIn + ", " + Items[j].Quality + "\n");
                }
                Console.Write("\n");
                UpdateQuality(Items);
            }
        }

        public static void UpdateQuality(IList<Item> items)
        {
            for (var i = 0; i < items.Count; i++)
            {
                if(items[i].Quality == 0) {
                    items.RemoveAt(i);
                } else {
                    items[i].UpdateQuality();
                }
            }
        }

        public abstract class Item
        {
            public string Name { get; set; } = default!;
            public int SellIn { get; set; }
            public int Quality { get; set; }
            public abstract void UpdateQuality();
        }

        public class NormalItem : Item
        {
            public override void UpdateQuality()
            {
                SellIn -= 1;
                Quality -= (SellIn > 0 ? 1 : 2);
                if(Quality < 0) { Quality = 0; }
            }
        }

        public class BrieItem : Item 
        {
            public override void UpdateQuality()
            {
                SellIn -= 1;
                Quality += (SellIn > 0 ? 1 : 2);
                if(Quality > 50){ Quality = 50; }
            }
        }

        public class LegendaryItem : Item
        {
            public override void UpdateQuality()
            {
                SellIn -= 0;
                Quality += 0;
            }
        }

        public class BackstagePassItem : Item 
        {
            public override void UpdateQuality()
            {
                SellIn -= 1;
                Quality += 1;
                if (SellIn < 10){ Quality += 1; }
                if (SellIn < 5){ Quality += 1; }
                if (Quality > 50){ Quality = 50; }
                if (SellIn < 0) {Quality = 0;}
            }
        }

        public class ConjuredItem : Item 
        {
            public override void UpdateQuality()
            {
                SellIn -= 1;
                Quality -= (SellIn > 0 ? 2 : 4);
                if (Quality < 0) { Quality = 0; }
            }
        }
    }
}