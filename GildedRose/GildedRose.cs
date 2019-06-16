using System;
using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        IList<string> ItemsThatDoesntGetOlder;
        IList<string> ItemsThatIncreaseQuality;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
            ItemsThatIncreaseQuality = new List<string>
            {
                "Aged Brie",
                "Backstage passes to a TAFKAL80ETC concert"
            };
            ItemsThatDoesntGetOlder = new List<string>
            {
                "Sulfuras, Hand of Ragnaros"
            };
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
                item.Quality += GetBaseQuality(item);
            }
        }
        private void DecreaseQualityValue(Item item)
        {
            if (IsAboveLowestQualityValue(item))
            {
                item.Quality -= GetBaseQuality(item);
            }
        }

        private int GetBaseQuality(Item item)
        {
            return (item.SellIn >= 0) ? 1 : 2;
        }

        private void NormalUpdate(Item item)
        {
            DecreaseQualityValue(item);
        }

        private void BackstageUpdate(Item item)
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
                item.Quality = 0;
            }
        }

        public void IncreasingItemsUpdate(Item item)
        {
            IncreaseQualityValue(item);
            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                BackstageUpdate(item);
            }
        }

        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {
                if (!ItemsThatDoesntGetOlder.Contains(item.Name))
                {
                    item.SellIn = item.SellIn - 1;
                }

                if (ItemsThatIncreaseQuality.Contains(item.Name))
                {
                    IncreasingItemsUpdate(item);
                }
                else
                {
                    NormalUpdate(item);
                }
            }
        }
    }
}