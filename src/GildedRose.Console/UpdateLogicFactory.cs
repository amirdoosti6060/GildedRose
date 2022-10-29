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
            if (item.Name == ItemTypes.Aged_Brie)
                return new AgedBrieUpdateLogic();
            else if (item.Name == ItemTypes.Backstage)
                return new BackstageUpdateLogic();
            else if (item.Name == ItemTypes.Sulfuras)
                return new SulfurasUpdateLogic();
            else
                return new GeneralUpdateLogic();
        }
    }
}
