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
            if (item.Quality > 0)
                item.Quality -= 2;

            item.SellIn -= 1;

            if (item.SellIn < 0)
            {
                if (item.Quality > 0)
                    item.Quality -= 2;
            }
        }
    }
}
