using System.Collections.Generic;
using Xunit;
using GildedRose.Console;

namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {
        private Item ProvideUpdatedItem(string name, int sellIn, int quality)
        {
            IList<Item> items = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
            var app = new GildedRoseApp() { Items = items };
            app.UpdateQuality();
            return items[0];
        }

        [Theory]
        [InlineData(15, 20)]
        public void UpdateQuality_GeneralRule_EndOfTheDayLowerSellInAndQuality(int sellIn, int quality)
        {
            Item item = ProvideUpdatedItem("AnyItem", sellIn, quality);
            Assert.Equal(sellIn - 1, item.SellIn);
            Assert.Equal(quality - 1, item.Quality);
        }

        [Theory]
        [InlineData(0, 20)]
        public void UpdateQuality_GeneralRule_SellDatePassedQualityDegradesTwiceAsFast(int sellIn, int quality)
        {
            Item item = ProvideUpdatedItem("AnyItem", sellIn, quality);
            Assert.Equal(quality - 2, item.Quality);
        }

        [Theory]
        [InlineData(15, 0)]
        public void UpdateQuality_GeneralRule_QualityNeverNegative(int sellIn, int quality)
        {
            Item item = ProvideUpdatedItem("AnyItem", sellIn, quality);
            Assert.Equal(0, item.Quality);
        }

        [Theory]
        [InlineData(15, 20)]
        public void UpdateQuality_SpecificRule_AgedBrieIncreasesQuality(int sellIn, int quality)
        {
            Item item = ProvideUpdatedItem(ItemTypes.Aged_Brie, sellIn, quality);
            Assert.Equal(quality + 1, item.Quality);
        }

        [Theory]
        [InlineData(-5, 20)]
        public void UpdateQuality_SpecificRule_AgedBrieDatePassedQualityStillIncrease(int sellIn, int quality)
        {
            Item item = ProvideUpdatedItem(ItemTypes.Aged_Brie, sellIn, quality);
            Assert.Equal(quality + 2, item.Quality);
        }

        [Theory]
        [InlineData(15, GildedRoseApp.MAX_QUALITY)]
        public void UpdateQuality_SpecificRule_QualityNeverMoreThan50(int sellIn, int quality)
        {
            Item item = ProvideUpdatedItem(ItemTypes.Aged_Brie, sellIn, quality);
            Assert.Equal(GildedRoseApp.MAX_QUALITY, item.Quality);
        }

        [Theory]
        [InlineData(15, GildedRoseApp.SULFURAS_QUALITY)]
        public void UpdateQuality_SpecificRule_SulfurasNeverSoldDecreasesQuality(int sellIn, int quality)
        {
            Item item = ProvideUpdatedItem(ItemTypes.Sulfuras, sellIn, quality);
            Assert.Equal(sellIn, item.SellIn);
            Assert.Equal(GildedRoseApp.SULFURAS_QUALITY, item.Quality);
        }

        [Theory]
        [InlineData(15, 20)]
        public void UpdateQuality_SpecificRule_BackstageQualityIncrease(int sellIn, int quality)
        {
            Item item = ProvideUpdatedItem(ItemTypes.Backstage, sellIn, quality);
            Assert.Equal(quality + 1, item.Quality);
        }

        [Theory]
        [InlineData(GildedRoseApp.BACKSTAGE_DAY_STEP1, 20)]
        public void UpdateQuality_SpecificRule_BackstageQualityIncrease2When10DaysOrLess(int sellIn, int quality)
        {
            Item item = ProvideUpdatedItem(ItemTypes.Backstage, sellIn, quality);
            Assert.Equal(quality + 2, item.Quality);
        }

        [Theory]
        [InlineData(GildedRoseApp.BACKSTAGE_DAY_STEP2, 20)]
        public void UpdateQuality_SpecificRule_BackstageQualityIncrease3When5DaysOrLess(int sellIn, int quality)
        {
            Item item = ProvideUpdatedItem(ItemTypes.Backstage, sellIn, quality);
            Assert.Equal(quality + 3, item.Quality);
        }

        [Theory]
        [InlineData(GildedRoseApp.BACKSTAGE_DAY_STEP3, 20)]
        public void UpdateQuality_SpecificRule_BackstageQualityDropZeroAfterConcert(int sellIn, int quality)
        {
            Item item = ProvideUpdatedItem(ItemTypes.Backstage, sellIn, quality);
            Assert.Equal(0, item.Quality);
        }
    }
}