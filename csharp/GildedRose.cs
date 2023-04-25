using System.Collections.Generic;
using System;

namespace csharp
{
    public class GildedRose
    {
        private const int MaxQuality = 50;
        private const int MinQuality = 0;

        private readonly IList<Item> _items;

        public GildedRose(IList<Item> items)
        {
            _items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in _items)
            {
                if (item.Name == "Sulfuras, Hand of Ragnaros")
                {
                    continue;
                }

                item.SellIn--;

                if (item.Name == "Aged Brie")
                {
                    item.Quality += item.SellIn < 0 ? 2 : 1;
                }
                else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (item.SellIn < 0)
                    {
                        item.Quality = MinQuality;
                    }
                    else if (item.SellIn < 5)
                    {
                        item.Quality += 3;
                    }
                    else if (item.SellIn < 10)
                    {
                        item.Quality += 2;
                    }
                    else
                    {
                        item.Quality++;
                    }
                }
                else
                {
                    var qualityChange = item.SellIn < 0 ? -2 : -1;
                    item.Quality = Math.Max(MinQuality, item.Quality + qualityChange);
                }

                item.Quality = Math.Min(MaxQuality, item.Quality);
            }
        }
    }

}
