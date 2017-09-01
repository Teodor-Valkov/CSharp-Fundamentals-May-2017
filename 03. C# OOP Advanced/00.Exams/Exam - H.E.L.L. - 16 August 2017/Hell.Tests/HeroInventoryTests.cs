using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;

[TestFixture]
public class HeroInventoryTests
{
    private HeroInventory heroInventory;

    [SetUp]
    public void Initialize()
    {
        this.heroInventory = new HeroInventory();
    }

    [Test]
    public void TestInitailInventoryStats()
    {
        //Arrange
        long totalStatsBonus = this.heroInventory.TotalAgilityBonus + this.heroInventory.TotalStrengthBonus + this.heroInventory.TotalIntelligenceBonus + this.heroInventory.TotalHitPointsBonus + this.heroInventory.TotalDamageBonus;

        //Assert
        Assert.AreEqual(0, totalStatsBonus);
    }

    [Test]
    public void TestAddNullItemThrowsException()
    {
        //Arrange
        IItem item = null;

        //Assert
        Assert.Throws<NullReferenceException>(() => this.heroInventory.AddCommonItem(item));
    }

    [Test]
    public void TestAddValidItemStrengthStats()
    {
        //Arrange
        IItem item = new CommonItem("Axe", 1000, 20, 30, 40, 50);

        //Act
        this.heroInventory.AddCommonItem(item);

        //Assert
        Assert.AreEqual(1000, this.heroInventory.TotalStrengthBonus);
    }

    [Test]
    public void TestAddValidItemAgilityStats()
    {
        //Arrange
        IItem item = new CommonItem("Axe", 10, 2000, 30, 40, 50);

        //Act
        this.heroInventory.AddCommonItem(item);

        //Assert
        Assert.AreEqual(2000, this.heroInventory.TotalAgilityBonus);
    }

    [Test]
    public void TestAddValidItemIntelligenceStats()
    {
        //Arrange
        IItem item = new CommonItem("Axe", 10, 20, 3000, 40, 50);

        //Act
        this.heroInventory.AddCommonItem(item);

        //Assert
        Assert.AreEqual(3000, this.heroInventory.TotalIntelligenceBonus);
    }

    [Test]
    public void TestAddValidItemHitPointsStats()
    {
        //Arrange
        IItem item = new CommonItem("Axe", 10, 20, 30, 4000, 50);

        //Act
        this.heroInventory.AddCommonItem(item);

        //Assert
        Assert.AreEqual(4000, this.heroInventory.TotalHitPointsBonus);
    }

    [Test]
    public void TestAddValidItemDamageStats()
    {
        //Arrange
        IItem item = new CommonItem("Axe", 10, 20, 30, 40, 5000);

        //Act
        this.heroInventory.AddCommonItem(item);

        //Assert
        Assert.AreEqual(5000, this.heroInventory.TotalDamageBonus);
    }

    [Test]
    public void TestAddValidItemTotalStats()
    {
        //Arrange
        IItem item = new CommonItem("Axe", 10, 20, 30, 40, 50);

        //Act
        this.heroInventory.AddCommonItem(item);
        long totalStatsBonus = this.heroInventory.TotalAgilityBonus + this.heroInventory.TotalStrengthBonus + this.heroInventory.TotalIntelligenceBonus + this.heroInventory.TotalHitPointsBonus + this.heroInventory.TotalDamageBonus;

        //Assert
        Assert.AreEqual(150, totalStatsBonus);
    }

    [Test]
    public void TestAddSameItemThrowsException()
    {
        //Arrange
        IItem item = new CommonItem("Axe", 10, 20, 30, 40, 50);

        //Act
        this.heroInventory.AddCommonItem(item);

        //Assert
        Assert.Throws<ArgumentException>(() => this.heroInventory.AddCommonItem(item));
    }

    [Test]
    public void TestAddNullRecipeThrowsException()
    {
        //Arrange
        IRecipe recipe = null;

        //Assert
        Assert.Throws<NullReferenceException>(() => this.heroInventory.AddRecipeItem(recipe));
    }

    [Test]
    public void TestCraftRecipeItemStrengthStats()
    {
        //Arrange
        IItem firstItem = new CommonItem("Axe", 10, 20, 30, 40, 50);
        IItem secondItem = new CommonItem("Sword", 60, 70, 80, 90, 0);
        List<string> requiredItems = new List<string> { "Axe", "Sword" };

        IRecipe recipe = new RecipeItem("Bow", 100, 200, 300, 400, 500, requiredItems);

        //Act
        heroInventory.AddCommonItem(firstItem);
        heroInventory.AddCommonItem(secondItem);
        heroInventory.AddRecipeItem(recipe);

        //Assert
        Assert.AreEqual(100, heroInventory.TotalStrengthBonus);
    }

    [Test]
    public void TestCraftRecipeItemAgilityStats()
    {
        //Arrange
        IItem firstItem = new CommonItem("Axe", 10, 20, 30, 40, 50);
        IItem secondItem = new CommonItem("Sword", 60, 70, 80, 90, 0);
        List<string> requiredItems = new List<string> { "Axe", "Sword" };

        IRecipe recipe = new RecipeItem("Bow", 100, 200, 300, 400, 500, requiredItems);

        //Act
        heroInventory.AddCommonItem(firstItem);
        heroInventory.AddCommonItem(secondItem);
        heroInventory.AddRecipeItem(recipe);

        //Assert
        Assert.AreEqual(200, heroInventory.TotalAgilityBonus);
    }

    [Test]
    public void TestCraftRecipeItemIntelligenceStats()
    {
        //Arrange
        IItem firstItem = new CommonItem("Axe", 10, 20, 30, 40, 50);
        IItem secondItem = new CommonItem("Sword", 60, 70, 80, 90, 0);
        List<string> requiredItems = new List<string> { "Axe", "Sword" };

        IRecipe recipe = new RecipeItem("Bow", 100, 200, 300, 400, 500, requiredItems);

        //Act
        heroInventory.AddCommonItem(firstItem);
        heroInventory.AddCommonItem(secondItem);
        heroInventory.AddRecipeItem(recipe);

        //Assert
        Assert.AreEqual(300, heroInventory.TotalIntelligenceBonus);
    }

    [Test]
    public void TestCraftRecipeItemHitPointsStats()
    {
        //Arrange
        IItem firstItem = new CommonItem("Axe", 10, 20, 30, 40, 50);
        IItem secondItem = new CommonItem("Sword", 60, 70, 80, 90, 0);
        List<string> requiredItems = new List<string> { "Axe", "Sword" };

        IRecipe recipe = new RecipeItem("Bow", 100, 200, 300, 400, 500, requiredItems);

        //Act
        heroInventory.AddCommonItem(firstItem);
        heroInventory.AddCommonItem(secondItem);
        heroInventory.AddRecipeItem(recipe);

        //Assert
        Assert.AreEqual(400, heroInventory.TotalHitPointsBonus);
    }

    [Test]
    public void TestCraftRecipeItemDamageStats()
    {
        //Arrange
        IItem firstItem = new CommonItem("Axe", 10, 20, 30, 40, 50);
        IItem secondItem = new CommonItem("Sword", 60, 70, 80, 90, 0);
        List<string> requiredItems = new List<string> { "Axe", "Sword" };

        IRecipe recipe = new RecipeItem("Bow", 100, 200, 300, 400, 500, requiredItems);

        //Act
        this.heroInventory.AddCommonItem(firstItem);
        this.heroInventory.AddCommonItem(secondItem);
        this.heroInventory.AddRecipeItem(recipe);

        //Assert
        Assert.AreEqual(500, this.heroInventory.TotalDamageBonus);
    }

    [Test]
    public void TestCraftRecipeItemTotalStatsBeforeReceivedCommonItems()
    {
        //Arrange
        IItem firstItem = new CommonItem("Axe", 10, 20, 30, 40, 50);
        IItem secondItem = new CommonItem("Sword", 60, 70, 80, 90, 0);

        List<string> requiredItems = new List<string> { "Axe", "Sword" };
        IRecipe recipe = new RecipeItem("Bow", 100, 200, 300, 400, 500, requiredItems);

        //Act
        this.heroInventory.AddRecipeItem(recipe);
        this.heroInventory.AddCommonItem(firstItem);
        this.heroInventory.AddCommonItem(secondItem);

        long totalStatsBonus = this.heroInventory.TotalAgilityBonus + this.heroInventory.TotalStrengthBonus + this.heroInventory.TotalIntelligenceBonus + this.heroInventory.TotalHitPointsBonus + this.heroInventory.TotalDamageBonus;

        //Assert
        Assert.AreEqual(1500, totalStatsBonus);
    }

    [Test]
    public void TestCraftRecipeItemTotalStatsAfterReceivedCommonItems()
    {
        //Arrange
        IItem firstItem = new CommonItem("Axe", 10, 20, 30, 40, 50);
        IItem secondItem = new CommonItem("Sword", 60, 70, 80, 90, 0);
        List<string> requiredItems = new List<string> { "Axe", "Sword" };

        IRecipe recipe = new RecipeItem("Bow", 100, 200, 300, 400, 500, requiredItems);

        //Act
        this.heroInventory.AddCommonItem(firstItem);
        this.heroInventory.AddCommonItem(secondItem);
        this.heroInventory.AddRecipeItem(recipe);

        long totalStatsBonus = this.heroInventory.TotalAgilityBonus + this.heroInventory.TotalStrengthBonus + this.heroInventory.TotalIntelligenceBonus + this.heroInventory.TotalHitPointsBonus + this.heroInventory.TotalDamageBonus;

        //Assert
        Assert.AreEqual(1500, totalStatsBonus);
    }

    [Test]
    public void TestAddSameRecipeThrowsException()
    {
        //Arrange
        List<string> requiredItems = new List<string> { "Axe", "Sword" };
        IRecipe recipe = new RecipeItem("Axe", 10, 20, 30, 40, 50, requiredItems);

        //Act
        this.heroInventory.AddRecipeItem(recipe);

        //Assert
        Assert.Throws<ArgumentException>(() => this.heroInventory.AddRecipeItem(recipe));
    }

    [Test]
    public void TestCountAfterAddingItem()
    {
        //Arrange
        IItem item = new CommonItem("Axe", 10, 20, 30, 40, 50);

        //Act
        this.heroInventory.AddCommonItem(item);

        Type typeOfHeroInventory = typeof(HeroInventory);
        FieldInfo commonItemsField = typeOfHeroInventory.GetField("commonItems", BindingFlags.Instance | BindingFlags.NonPublic);

        Dictionary<string, IItem> commonItems = (Dictionary<string, IItem>)commonItemsField.GetValue(this.heroInventory);

        //Assert
        Assert.AreEqual(1, commonItems.Count);
    }

    [Test]
    public void TestCountAfterAddingRecipe()
    {
        //Arrange
        List<string> requiredItems = new List<string> { "Axe", "Sword" };
        IRecipe recipe = new RecipeItem("Axe", 10, 20, 30, 40, 50, requiredItems);

        //Act
        this.heroInventory.AddRecipeItem(recipe);

        Type typeOfHeroInventory = typeof(HeroInventory);
        FieldInfo recipeItemsField = typeOfHeroInventory.GetField("recipeItems", BindingFlags.Instance | BindingFlags.NonPublic);

        Dictionary<string, IRecipe> recipeItems = (Dictionary<string, IRecipe>)recipeItemsField.GetValue(this.heroInventory);

        //Assert
        Assert.AreEqual(1, recipeItems.Count);
    }
}