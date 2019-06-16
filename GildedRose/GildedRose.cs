using System;
using System.Collections.Generic;
using System.Linq;

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
        private bool IsUnderHighestQualityValue(Item item)
        {
            return item.Quality < 50;
        }
        private bool IsAboveLowestQualityValue(Item item)
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

        private void IncreaseQualityAmount(Item item, int timesToIncrease)
        {
            for (int i = 0; i < timesToIncrease; i++)
            {
                IncreaseQualityValue(item);
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

        private int BackstageUpdate(Item item, int timesToIncreaseQuality)
        {
            if (item.SellIn < 5)
            {
                timesToIncreaseQuality += 2;
            }
            else if (item.SellIn < 10)
            {
                timesToIncreaseQuality++;
            }
            return timesToIncreaseQuality;
        }

        public void IncreasingItemsUpdate(Item item)
        {
            int timesToIncreaseQuality = 1;
            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                timesToIncreaseQuality = BackstageUpdate(item, timesToIncreaseQuality);
                if (item.SellIn < 0)
                {
                    item.Quality = 0;
                    return;
                }
            }
            IncreaseQualityAmount(item, timesToIncreaseQuality);
        }

        public void UpdateQuality()
        {
            var itemsThatGetOlder = Items.Where(item => !ItemsThatDoesntGetOlder.Contains(item.Name)).ToList();

            itemsThatGetOlder.ForEach(item =>
            {
                item.SellIn--;
                if (ItemsThatIncreaseQuality.Contains(item.Name))
                {
                    IncreasingItemsUpdate(item);
                }
                else
                {
                    NormalUpdate(item);
                }
            });
        }
    }
}