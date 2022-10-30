using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console
{
    internal class ConjuredUpdateLogic : IUpdateLogic
    {
        public void Update(Item item)
        {
            item.Quality = Helper.DecreaseQuality(item.Quality, 2);

            item.SellIn -= 1;

            if (item.SellIn < 0)
                item.Quality = Helper.DecreaseQuality(item.Quality, 2);
        }
    }
}
