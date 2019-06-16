using System;
using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        private Boolean IsUnderHighestQualityValue(Item item)
        {
            return item.Quality < 50;
        }

        private Boolean IsAboveLowestQualityValue(Item item)
        {
            return item.Quality > 0;
        }

        private void IncreaseQualityValue(Item item)
        {
            if (IsUnderHighestQualityValue(item))
            {
                item.Quality = item.Quality + 1;
            }
        }

        private void DecreaseQualityValue(Item item)
        {
            if (IsAboveLowestQualityValue(item))
            {
                item.Quality = item.Quality - 1;
            }
        }

        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {
                if (item.Name == "Sulfuras, Hand of Ragnaros")
                {
                    continue;
                }
                item.Quality = item.Quality - 1;
                if (item.Name == "Aged Brie")
                {
                    IncreaseQualityValue(item);
                    if (item.SellIn < 0)
                    {
                        IncreaseQualityValue(item);
                    }
                }
                else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    IncreaseQualityValue(item);

                    if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (item.SellIn < 10)
                        {
                            IncreaseQualityValue(item);
                        }
                        if (item.SellIn < 5)
                        {
                            IncreaseQualityValue(item);
                        }
                        if (item.SellIn < 0)
                        {
                            item.Quality = item.Quality - item.Quality;
                        }
                    }
                }
                else
                {
                    DecreaseQualityValue(item);
                    if (item.SellIn < 0)
                    {
                        DecreaseQualityValue(item);
                    }
                }
            }
        }
    }
}