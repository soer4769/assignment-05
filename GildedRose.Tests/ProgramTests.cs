namespace GildedRose.Tests;

public class ProgramTests
{
    IList<Item> _items;
    
    public ProgramTests() {
        _items = new List<Item>();
    }

    [Fact]
    public void ItemsListShouldContainAfterConstructorCalled()
    {
        // Arrange
        IList<Item> ItemsList = new List<Program.Item>{
            new LegendaryItem { Name = "Sulfuras, Hand of Ragnaros", Quality = 80, SellIn = 0 }, 
            new LegendaryItem { Name = "Sulfuras, Hand of Ragnaros", Quality = 80, SellIn = -1 }
        };

        // Act

        // Assert
        Assert.Equivalent(ItemsList,Program.Items);
    }

    [Fact]
    public void MainMethodShouldPrint()
    {
        // Arrange
        string MainOut = File.ReadAllText(Environment.CurrentDirectory + @"\WriteText.txt");
        StringWriter sw = new StringWriter();

        // Act
        Console.SetOut(sw);
        Program.Main(new string[]{});

        // Assert
        sw.ToString().Should().Be(MainOut);
    }

    [Fact]
    public void QualityDecreasesBy1WhileSellinPositive() 
    {
        // Arrange
        _items.Add(new NormalItem{ Name = "Test Item", SellIn = 10, Quality = 20 });

        // Act
        Program.UpdateQuality(_items);

        // Assert
        _items.ElementAt(0).Quality.Should().Be(19);
    }

    [Fact]
    public void QualityDecreasesBy2WhileSellinNegative() 
    {
        // Arrange
        _items.Add(new NormalItem{ Name = "Test Item", SellIn = -10, Quality = 20 });

        // Act
        Program.UpdateQuality(_items);

        // Assert
        _items.ElementAt(0).Quality.Should().Be(18);
    }

    [Fact]
    public void QualityShouldBeRemovedWhenQualityIs0() 
    {
        // Arrange
        _items.Add(new NormalItem{ Name = "Test Item", SellIn = 10, Quality = 0 });

        // Act
        Program.UpdateQuality(_items);

        // Assert
        _items.Count().Should().Be(0);
    }

    [Fact]
    public void QualityShouldBe0WhileSellinNegative() 
    {
        // Arrange
        _items.Add(new NormalItem{ Name = "Test Item 2", SellIn = -1, Quality = 1 });

        // Act
        Program.UpdateQuality(_items);

        // Assert
        _items.ElementAt(0).Quality.Should().Be(0);
    }

    [Fact]
    public void BrieQualityIncreasesBy1WhileSellinPositive() 
    {
        // Arrange
        _items.Add(new BrieItem{ Name = "Aged Brie", SellIn = 10, Quality = 20 });

        // Act
        Program.UpdateQuality(_items);

        // Assert
        _items.ElementAt(0).Quality.Should().Be(21);
    }

    [Fact]
    public void BrieQualityIncreasesBy2WhileSellinNegative() 
    {
        // Arrange
        _items.Add(new BrieItem{ Name = "Aged Brie", SellIn = -10, Quality = 20 });

        // Act
        Program.UpdateQuality(_items);

        // Assert
        _items.ElementAt(0).Quality.Should().Be(22);
    }

    [Fact]
    public void BrieQuality50UpdateShouldNotIncreaseQuality() 
    {
         // Arrange
        _items.Add(new BrieItem{ Name = "Aged Brie", SellIn = 10, Quality = 50 });

        // Act
        Program.UpdateQuality(_items);

        // Assert
        _items.ElementAt(0).Quality.Should().Be(50);
    }

    [Fact]
    public void BackstagePassIncreasesBy1WhileSellinBiggerThan10() 
    {
         // Arrange
        _items.Add(new BackstagePassItem{ Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 20 });

        // Act
        Program.UpdateQuality(_items);

        // Assert
        _items.ElementAt(0).Quality.Should().Be(21);
    }

    [Fact]
    public void BackstagePassIncreasesBy2WhileSellinBetween10And5() 
    {
           // Arrange
        _items.Add(new BackstagePassItem{ Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 6, Quality = 20 });

        // Act
        Program.UpdateQuality(_items);

        // Assert
        _items.ElementAt(0).Quality.Should().Be(22);
    }

    [Fact]
    public void BackstagePassIncreasesBy3WhileSellinSmallerThan5() 
    {
        // Arrange
        _items.Add(new BackstagePassItem{ Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 2, Quality = 20 });

        // Act
        Program.UpdateQuality(_items);

        // Assert
        _items.ElementAt(0).Quality.Should().Be(23);
    }

    [Fact]
    public void BackstagePassDropsTo0WhileSellinNegative() 
    {
           // Arrange
        _items.Add(new BackstagePassItem{ Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 });

        // Act
        Program.UpdateQuality(_items);

        // Assert
        _items.ElementAt(0).Quality.Should().Be(0);
    }

    [Fact]
    public void BackstagePassQuality50UpdateShouldNotIncreaseQuality() 
    {
           // Arrange
        _items.Add(new BackstagePassItem{ Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 50 });

        // Act
        Program.UpdateQuality(_items);

        // Assert
        _items.ElementAt(0).Quality.Should().Be(50);
    }
    
    [Fact]
    public void BackstagePassIsRemovedWhenQuality0() 
    {
        // Arrange
        _items.Add(new BackstagePassItem{ Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 0 });

        // Act
        Program.UpdateQuality(_items);

        // Assert
        _items.Count().Should().Be(0);
    }

      [Fact]
    public void BackstagePassQulityStaysAt50() 
    {
           // Arrange
        _items.Add(new BackstagePassItem{ Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 2, Quality = 50 });

        // Act
        Program.UpdateQuality(_items);

        // Assert
        _items.ElementAt(0).Quality.Should().Be(50);
    }

    [Fact]
    public void SulfurasQualityStaysAt80() 
    {
        // Arrange
        _items.Add(new LegendaryItem{ Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 });

        // Act
        Program.UpdateQuality(_items);

        // Assert
        _items.ElementAt(0).Quality.Should().Be(80);
    }

    [Fact]
    public void SulfurasSellinDoesNotChange() 
    {
        // Arrange
        _items.Add(new LegendaryItem{ Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 });

        // Act
        Program.UpdateQuality(_items);

        // Assert
        _items.ElementAt(0).SellIn.Should().Be(10);
    }

    [Fact]
    public void ConjuredDecreasesBy2WhileSellinPositive() 
    {
        // Arrange
        _items.Add(new ConjuredItem { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 });

        // Act
        Program.UpdateQuality(_items);

        // Assert
        _items.ElementAt(0).Quality.Should().Be(4);
    }

    [Fact]
    public void ConjuredDecreasesBy4WhileSellinNegative() 
    {
        // Arrange
        _items.Add(new ConjuredItem { Name = "Conjured Mana Cake", SellIn = -3, Quality = 6 });

        // Act
        Program.UpdateQuality(_items);

        // Assert
        _items.ElementAt(0).Quality.Should().Be(2);
    }

    [Fact]
    public void ConjuredIsRemovedWhenQualityIs0() 
    {
        // Arrange
        _items.Add(new ConjuredItem { Name = "Conjured Mana Cake", SellIn = -5, Quality = 0 });

        // Act
        Program.UpdateQuality(_items);

        // Assert
        _items.Count().Should().Be(0);
    }
    
    [Fact]
    public void ConjuredDoesntBecomeNegative() 
    {
        // Arrange
        _items.Add(new ConjuredItem { Name = "Conjured Mana Cake", SellIn = -5, Quality = 1 });

        // Act
        Program.UpdateQuality(_items);

        // Assert
        _items.ElementAt(0).Quality.Should().Be(0);
    }
}