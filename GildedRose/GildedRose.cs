using System;
using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        IList<string> ItemsThatDoesntGetOlder;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
            ItemsThatDoesntGetOlder = new List<string>
            {
                "Sulfuras, Hand of Ragnaros"
            };
        }
        private Boolean isUnderHighestQualityValue(Item item)
        {
            return item.Quality < 50;
        }
        private Boolean isAboveLowestQualityValue(Item item)
        {
            return item.Quality > 0;
        }
        private void IncreaseQualityValue(Item item)
        {
            if (isUnderHighestQualityValue(item))
            {
                item.Quality = item.Quality + 1;
            }
        }
        private void DecreaseQualityValue(Item item)
        {
            if (isAboveLowestQualityValue(item))
            {
                item.Quality = item.Quality - 1;
            }
        }

        private void NormalUpdate(Item item)
        {
            DecreaseQualityValue(item);
            if (item.SellIn < 0)
            {
                DecreaseQualityValue(item);
            }
        }

        private void BrieUpdate(Item item)
        {
            IncreaseQualityValue(item);
            if (item.SellIn < 0)
            {
                IncreaseQualityValue(item);
            }
        }

        private void SulfurasUpdate(Item item)
        {

        }

        private void BackstageUpdate(Item item)
        {
            IncreaseQualityValue(item);

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

        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {

                if (!ItemsThatDoesntGetOlder.Contains(item.Name))
                {
                    item.SellIn = item.SellIn - 1;
                }

                if (item.Name == "Sulfuras, Hand of Ragnaros")
                {
                    SulfurasUpdate(item);
                }
                else if (item.Name == "Aged Brie")
                {
                    BrieUpdate(item);
                }
                else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    BackstageUpdate(item);
                }
                else
                {
                    NormalUpdate(item);
                }
            }
        }
    }
}