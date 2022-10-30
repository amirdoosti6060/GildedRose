using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console
{
    internal class AgedBrieUpdateLogic : IUpdateLogic
    {
        public void Update(Item item)
        {
            item.Quality = Helper.IncreaseQuality(item.Quality, 1);

            item.SellIn -= 1;

            if (item.SellIn < 0)
                item.Quality = Helper.IncreaseQuality(item.Quality, 1);
        }
    }
}
