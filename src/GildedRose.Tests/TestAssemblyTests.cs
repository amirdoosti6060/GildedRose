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
        [InlineData(10, 8, 2)] // Normal case
        [InlineData(GildedRoseApp.MAX_QUALITY, 49, 3)] // Higher limit test
        public void IncreaseQuality_Helper_IncreaseAndCheckWithMaxQuality(int expected_quality, int input_quality, int increment)
        {
            int quality = Helper.IncreaseQuality(input_quality, increment);

            Assert.Equal(expected_quality, quality);
        }

        [Theory]
        [InlineData(5, 8, 3)] // Normal case
        [InlineData(0, 1, 3)] // Lower limit test
        public void DecreaseQuality_Helper_DecreaseAndCheckWithMaxQuality(int expected_quality, int input_quality, int decrement)
        {
            int quality = Helper.DecreaseQuality(input_quality, decrement);

            Assert.Equal(expected_quality, quality);
        }

        [Theory]
        [InlineData(15, 20)] // Normal case
        [InlineData(15, 0)] // Min quality
        public void UpdateQuality_GeneralRule_EndOfTheDayLowerSellInAndQuality(int sellIn, int quality)
        {
            Item item = ProvideUpdatedItem("AnyItem", sellIn, quality);
            int expectedQality = Helper.DecreaseQuality(quality, 1);

            Assert.Equal(sellIn - 1, item.SellIn);
            Assert.Equal(expectedQality, item.Quality);
            Assert.InRange<int>(quality, 0, GildedRoseApp.MAX_QUALITY);
        }

        [Theory]
        [InlineData(0, 20)] // Normal Quality and Date pass
        [InlineData(0, 1)] // Near Min quality (1 > 0 but 1 - 2 < 0) and Date pass
        public void UpdateQuality_GeneralRule_SellDatePassedQualityDegradesTwiceAsFast(int sellIn, int quality)
        {
            Item item = ProvideUpdatedItem("AnyItem", sellIn, quality);
            int expectedQality = Helper.DecreaseQuality(quality, 2);

            Assert.Equal(expectedQality, item.Quality);
            Assert.InRange<int>(quality, 0, GildedRoseApp.MAX_QUALITY);
        }

        [Theory]
        [InlineData(15, 0)] // Normal Day and Lowest Quality
        [InlineData(-2, 0)] // Date pass and Lowest Quality
        public void UpdateQuality_GeneralRule_QualityNeverNegative(int sellIn, int quality)
        {
            Item item = ProvideUpdatedItem("AnyItem", sellIn, quality);
            Assert.Equal(0, item.Quality);
        }

        [Theory]
        [InlineData(15, 20)] // Normal case
        [InlineData(15, 50)] // Max Quality
        public void UpdateQuality_SpecificRule_AgedBrieIncreasesQuality(int sellIn, int quality)
        {
            Item item = ProvideUpdatedItem(ItemTypes.Aged_Brie, sellIn, quality);
            int expectedQality = Helper.IncreaseQuality(quality, 1);

            Assert.Equal(expectedQality, item.Quality);
            Assert.InRange<int>(quality, 0, GildedRoseApp.MAX_QUALITY);
        }

        [Theory]
        [InlineData(-5, 20)] // Normal quality and Date pass
        [InlineData(-5, 49)] // Near Max quality (49 < 50 but 49 + 2 > 50) and Date pass
        public void UpdateQuality_SpecificRule_AgedBrieDatePassedQualityStillIncrease(int sellIn, int quality)
        {
            Item item = ProvideUpdatedItem(ItemTypes.Aged_Brie, sellIn, quality);
            int expectedQality = Helper.IncreaseQuality(quality, 2);

            Assert.Equal(expectedQality, item.Quality);
            Assert.InRange<int>(quality, 0, GildedRoseApp.MAX_QUALITY);
        }

        [Theory]
        [InlineData(15, GildedRoseApp.MAX_QUALITY)] // Max Quality
        public void UpdateQuality_SpecificRule_AgedBrieQualityNeverMoreThan50(int sellIn, int quality)
        {
            Item item = ProvideUpdatedItem(ItemTypes.Aged_Brie, sellIn, quality);
            Assert.Equal(GildedRoseApp.MAX_QUALITY, item.Quality);
        }

        [Theory]
        [InlineData(15, GildedRoseApp.SULFURAS_QUALITY)] // Normal case
        [InlineData(-1, GildedRoseApp.SULFURAS_QUALITY)] // Date pass
        public void UpdateQuality_SpecificRule_SulfurasNeverSoldDecreasesQuality(int sellIn, int quality)
        {
            Item item = ProvideUpdatedItem(ItemTypes.Sulfuras, sellIn, quality);
            Assert.Equal(sellIn, item.SellIn);
            Assert.Equal(GildedRoseApp.SULFURAS_QUALITY, item.Quality);
        }

        [Theory]
        [InlineData(15, 20)] // Normal case
        [InlineData(15, 50)] // Max Quality
        public void UpdateQuality_SpecificRule_BackstageQualityIncrease(int sellIn, int quality)
        {
            Item item = ProvideUpdatedItem(ItemTypes.Backstage, sellIn, quality);
            int expectedQality = Helper.IncreaseQuality(quality, 1);

            Assert.Equal(expectedQality, item.Quality);
            Assert.InRange<int>(quality, 0, GildedRoseApp.MAX_QUALITY);
        }

        [Theory]
        [InlineData(GildedRoseApp.BACKSTAGE_DAY_STEP1, 20)] // Normal case
        [InlineData(GildedRoseApp.BACKSTAGE_DAY_STEP1, 49)] // Near Max quality (49 < 50 but 49 + 2 > 50)
        public void UpdateQuality_SpecificRule_BackstageQualityIncrease2When10DaysOrLess(int sellIn, int quality)
        {
            Item item = ProvideUpdatedItem(ItemTypes.Backstage, sellIn, quality);
            int expectedQality = Helper.IncreaseQuality(quality, 2);

            Assert.Equal(expectedQality, item.Quality);
            Assert.InRange<int>(quality, 0, GildedRoseApp.MAX_QUALITY);
        }

        [Theory]
        [InlineData(GildedRoseApp.BACKSTAGE_DAY_STEP2, 20)] // Normal case
        [InlineData(GildedRoseApp.BACKSTAGE_DAY_STEP2, 49)] // Near Max quality (49 < 50 but 49 + 3 > 50)
        public void UpdateQuality_SpecificRule_BackstageQualityIncrease3When5DaysOrLess(int sellIn, int quality)
        {
            Item item = ProvideUpdatedItem(ItemTypes.Backstage, sellIn, quality);
            int expectedQality = Helper.IncreaseQuality(quality, 3);

            Assert.Equal(expectedQality, item.Quality);
            Assert.InRange<int>(quality, 0, GildedRoseApp.MAX_QUALITY);
        }

        [Theory]
        [InlineData(GildedRoseApp.BACKSTAGE_DAY_STEP3, 20)] // After concert
        public void UpdateQuality_SpecificRule_BackstageQualityDropZeroAfterConcert(int sellIn, int quality)
        {
            Item item = ProvideUpdatedItem(ItemTypes.Backstage, sellIn, quality);

            Assert.Equal(0, item.Quality);
            Assert.InRange<int>(quality, 0, GildedRoseApp.MAX_QUALITY);
        }

        [Theory]
        [InlineData(15, 20)] // Normal Case
        public void UpdateQuality_SpecificRule_ConjuredQualityDegradeTwiceFast(int sellIn, int quality)
        {
            Item item = ProvideUpdatedItem(ItemTypes.Conjured, sellIn, quality);
            int expectedQality = Helper.DecreaseQuality(quality, 2);

            Assert.Equal(sellIn - 1, item.SellIn);
            Assert.Equal(expectedQality, item.Quality);
            Assert.InRange<int>(quality, 0, GildedRoseApp.MAX_QUALITY);
        }

        [Theory]
        [InlineData(-1, 3)] // Date Passed
        public void UpdateQuality_SpecificRule_ConjuredDatePassedQualityDegradeTwiceFast(int sellIn, int quality)
        {
            Item item = ProvideUpdatedItem(ItemTypes.Conjured, sellIn, quality);
            int expectedQality = Helper.DecreaseQuality(quality, 4);

            Assert.Equal(sellIn - 1, item.SellIn);
            Assert.Equal(expectedQality, item.Quality);
            Assert.InRange<int>(quality, 0, GildedRoseApp.MAX_QUALITY);
        }
    }
}