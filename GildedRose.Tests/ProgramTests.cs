namespace GildedRose.Tests;

public class ProgramTests
{
    IList<GildedRose.Item> _items;
    public ProgramTests() {
        _items = new List<Item>();

    }

    [Fact]
    public void QualityDecreasesBy1WhileSellinPositive() 
    {
        // Arrange
        _items.Add(new Item{ Name = "Test Item", SellIn = 10, Quality = 20 });

        // Act
        Program.UpdateQuality(_items);

        // Assert
        _items.ElementAt(0).Quality.Should().Be(19);
    }

    [Fact]
    public void QualityDecreasesBy2WhileSellinNegative() 
    {
        // Arrange
        _items.Add(new Item{ Name = "Test Item", SellIn = -10, Quality = 20 });

        // Act
        Program.UpdateQuality(_items);

        // Assert
        _items.ElementAt(0).Quality.Should().Be(18);
    }

    [Fact]
    public void BrieQualityIncreasesBy1WhileSellinPositive() 
    {
        // Arrange
        _items.Add(new Item{ Name = "Aged Brie", SellIn = 10, Quality = 20 });

        // Act
        Program.UpdateQuality(_items);

        // Assert
        _items.ElementAt(0).Quality.Should().Be(21);
    }

    [Fact]
    public void BrieQualityIncreasesBy2WhileSellinNegative() 
    {
        // Arrange
        _items.Add(new Item{ Name = "Aged Brie", SellIn = -10, Quality = 20 });

        // Act
        Program.UpdateQuality(_items);

        // Assert
        _items.ElementAt(0).Quality.Should().Be(22);
    }

    [Fact]
    public void BrieQuality50UpdateShouldNotIncreaseQuality() 
    {
         // Arrange
        _items.Add(new Item{ Name = "Aged Brie", SellIn = 10, Quality = 50 });

        // Act
        Program.UpdateQuality(_items);

        // Assert
        _items.ElementAt(0).Quality.Should().Be(50);
    }

    [Fact]
    public void BackstagePassIncreasesBy1WhileSellinBiggerThan10() 
    {
         // Arrange
        _items.Add(new Item{ Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 20 });

        // Act
        Program.UpdateQuality(_items);

        // Assert
        _items.ElementAt(0).Quality.Should().Be(21);
    }

    [Fact]
    public void BackstagePassIncreasesBy2WhileSellinBetween10And5() 
    {
           // Arrange
        _items.Add(new Item{ Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 6, Quality = 20 });

        // Act
        Program.UpdateQuality(_items);

        // Assert
        _items.ElementAt(0).Quality.Should().Be(22);
    }

    [Fact]
    public void BackstagePassIncreasesBy3WhileSellinSmallerThan5() 
    {
           // Arrange
        _items.Add(new Item{ Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 2, Quality = 20 });

        // Act
        Program.UpdateQuality(_items);

        // Assert
        _items.ElementAt(0).Quality.Should().Be(23);
    }

    [Fact]
    public void BackstagePassDropsTo0WhileSellinNegative() 
    {
           // Arrange
        _items.Add(new Item{ Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 });

        // Act
        Program.UpdateQuality(_items);

        // Assert
        _items.ElementAt(0).Quality.Should().Be(0);
    }

    [Fact]
    public void BackstagePassQuality50UpdateShouldNotIncreaseQuality() 
    {
           // Arrange
        _items.Add(new Item{ Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 50 });

        // Act
        Program.UpdateQuality(_items);

        // Assert
        _items.ElementAt(0).Quality.Should().Be(50);
    }

    [Fact]
    public void SulfurasQualityStaysAt80() 
    {
        // Arrange
        _items.Add(new Item{ Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 });

        // Act
        Program.UpdateQuality(_items);

        // Assert
        _items.ElementAt(0).Quality.Should().Be(80);
    }

    [Fact]
    public void SulfurasSellinDoesNotChange() 
    {
        // Arrange
        _items.Add(new Item{ Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 });

        // Act
        Program.UpdateQuality(_items);

        // Assert
        _items.ElementAt(0).SellIn.Should().Be(10);
    }

    [Fact]
    public void ConjuredDecreasesBy2WhileSellinPositive() 
    {
        throw new NotImplementedException();
    }

    [Fact]
    public void ConjuredDecreasesBy4WhileSellinNegative() 
    {
        throw new NotImplementedException();
    }
}