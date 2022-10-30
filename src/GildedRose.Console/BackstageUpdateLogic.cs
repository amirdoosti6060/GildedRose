using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console
{
    internal class BackstageUpdateLogic : IUpdateLogic
    {
        public void Update(Item item)
        {
            if (item.SellIn > 0)
                item.Quality = Helper.IncreaseQuality(item.Quality, 1);

            if (item.SellIn <= GildedRoseApp.BACKSTAGE_DAY_STEP1)
                item.Quality = Helper.IncreaseQuality(item.Quality, 1);

            if (item.SellIn <= GildedRoseApp.BACKSTAGE_DAY_STEP2)
                item.Quality = Helper.IncreaseQuality(item.Quality, 1);

            item.SellIn -= 1;

            if (item.SellIn < GildedRoseApp.BACKSTAGE_DAY_STEP3)
                item.Quality = 0;
        }
    }
}
