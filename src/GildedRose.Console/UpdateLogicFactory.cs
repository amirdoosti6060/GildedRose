using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console
{
    internal class UpdateLogicFactory
    {
        public IUpdateLogic Create(Item item)
        {
            if (item.Name == "Aged Brie")
                return new AgedBrieUpdateLogic();
            else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                return new BackstageUpdateLogic();
            else if (item.Name == "Sulfuras, Hand of Ragnaros")
                return new SulfurasUpdateLogic();
            else
                return new GeneralUpdateLogic();
        }
    }
}
