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
        throw new NotImplementedException();
    }

    [Fact]
    public void BackstagePassIncreasesBy1WhileSellinBiggerThan10() 
    {
        throw new NotImplementedException();
    }

    [Fact]
    public void BackstagePassIncreasesBy2WhileSellinBetween10And5() 
    {
        throw new NotImplementedException();
    }

    [Fact]
    public void BackstagePassIncreasesBy3WhileSellinSmallerThan5() 
    {
        throw new NotImplementedException();
    }

    [Fact]
    public void BackstagePassDropsTo0WhileSellinNegative() 
    {
        throw new NotImplementedException();
    }

    [Fact]
    public void BackstagePassQuality50UpdateShouldNotIncreaseQuality() 
    {
        throw new NotImplementedException();
    }

    [Fact]
    public void SulfurasQualityStaysAt80() 
    {
        throw new NotImplementedException();
    }

    [Fact]
    public void SulfurasSellinDoesNotChange() 
    {
        throw new NotImplementedException();
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