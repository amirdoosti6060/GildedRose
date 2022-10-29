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
            if (item.Quality < 50)
                item.Quality += 1;

            item.SellIn -= 1;

            if (item.SellIn < 0)
            {
                if (item.Quality < 50)
                    item.Quality += 1;
            }
        }
    }
}
