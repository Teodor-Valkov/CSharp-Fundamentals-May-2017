using NUnit.Framework;
using System;
using System.Collections.Generic;

[TestFixture]
public class HeroInventoryTest
{
    private IInventory heroInventory;

    [SetUp]
    public void TestInit()
    {
        this.heroInventory = new HeroInventory();
        this.heroInventory.AddCommonItem(new CommonItem("Axe", 11, 12, 13, 14, 15));
    }

    [Test]
    public void AddCommonItemToInventoryShouldAddStrength()
    {
        // Assert
        Assert.AreEqual(11, this.heroInventory.TotalStrengthBonus);
    }

    [Test]
    public void AddCommonItemToInventoryShouldAddAgility()
    {
        // Assert
        Assert.AreEqual(12, this.heroInventory.TotalAgilityBonus);
    }

    [Test]
    public void AddCommonItemToInventoryShouldAddIntelligence()
    {
        // Assert
        Assert.AreEqual(13, this.heroInventory.TotalIntelligenceBonus);
    }

    [Test]
    public void AddCommonItemToInventoryShouldAddHitPoints()
    {
        // Assert
        Assert.AreEqual(14, this.heroInventory.TotalHitPointsBonus);
    }

    [Test]
    public void AddCommonItemToInventoryShouldAddHitDamage()
    {
        // Assert
        Assert.AreEqual(15, this.heroInventory.TotalDamageBonus);
    }

    [Test]
    public void AddRecipeItemToInventoryWithExistingItemShouldAddStrength()
    {
        // Arrange
        IRecipe recipe = new RecipeItem("Sword", 101, 102, 103, 104, 105, new List<string> { "Axe" });

        // Act
        this.heroInventory.AddRecipeItem(recipe);

        // Assert
        Assert.AreEqual(101, this.heroInventory.TotalStrengthBonus);
    }

    [Test]
    public void AddRecipeItemToInventoryWithExistingItemShouldAddAgility()
    {
        // Arrange
        IRecipe recipe = new RecipeItem("Sword", 101, 102, 103, 104, 105, new List<string> { "Axe" });

        // Act
        this.heroInventory.AddRecipeItem(recipe);

        // Assert
        Assert.AreEqual(102, this.heroInventory.TotalAgilityBonus);
    }

    [Test]
    public void AddRecipeItemToInventoryWithExistingItemShouldAddIntelligence()
    {
        // Arrange
        IRecipe recipe = new RecipeItem("Sword", 101, 102, 103, 104, 105, new List<string> { "Axe" });

        // Act
        this.heroInventory.AddRecipeItem(recipe);

        // Assert
        Assert.AreEqual(103, this.heroInventory.TotalIntelligenceBonus);
    }

    [Test]
    public void AddRecipeItemToInventoryWithExistingItemShouldAddHitPoints()
    {
        // Arrange
        IRecipe recipe = new RecipeItem("Sword", 101, 102, 103, 104, 105, new List<string> { "Axe" });

        // Act
        this.heroInventory.AddRecipeItem(recipe);

        // Assert
        Assert.AreEqual(104, this.heroInventory.TotalHitPointsBonus);
    }

    [Test]
    public void AddRecipeItemToInventoryWithExistingItemShouldAddDamage()
    {
        // Arrange
        IRecipe recipe = new RecipeItem("Sword", 101, 102, 103, 104, 105, new List<string> { "Axe" });

        // Act
        this.heroInventory.AddRecipeItem(recipe);

        // Assert
        Assert.AreEqual(105, this.heroInventory.TotalDamageBonus);
    }

    [Test]
    public void AddRecipeItemToInventoryWithoutExistingItemShouldNotAddStrength()
    {
        // Arrange
        IRecipe recipe = new RecipeItem("Sword", 101, 102, 103, 104, 105, new List<string> { "Bow" });

        // Act
        this.heroInventory.AddRecipeItem(recipe);

        // Assert
        Assert.AreEqual(11, this.heroInventory.TotalStrengthBonus);
    }

    [Test]
    public void AddRecipeItemToInventoryWithoutExistingItemShouldNotAddAgility()
    {
        // Arrange
        IRecipe recipe = new RecipeItem("Sword", 101, 102, 103, 104, 105, new List<string> { "Bow" });

        // Act
        this.heroInventory.AddRecipeItem(recipe);

        // Assert
        Assert.AreEqual(12, this.heroInventory.TotalAgilityBonus);
    }

    [Test]
    public void AddRecipeItemToInventoryWithoutExistingItemShouldNotAddIntelligence()
    {
        // Arrange
        IRecipe recipe = new RecipeItem("Sword", 101, 102, 103, 104, 105, new List<string> { "Bow" });

        // Act
        this.heroInventory.AddRecipeItem(recipe);

        // Assert
        Assert.AreEqual(13, this.heroInventory.TotalIntelligenceBonus);
    }

    [Test]
    public void AddRecipeItemToInventoryWithoutExistingItemShouldNotAddHitPoints()
    {
        // Arrange
        IRecipe recipe = new RecipeItem("Sword", 101, 102, 103, 104, 105, new List<string> { "Bow" });

        // Act
        this.heroInventory.AddRecipeItem(recipe);

        // Assert
        Assert.AreEqual(14, this.heroInventory.TotalHitPointsBonus);
    }

    [Test]
    public void AddRecipeItemToInventoryWithoutExistingItemShouldNotAddDamage()
    {
        // Arrange
        IRecipe recipe = new RecipeItem("Sword", 101, 102, 103, 104, 105, new List<string> { "Bow" });

        // Act
        this.heroInventory.AddRecipeItem(recipe);

        // Assert
        Assert.AreEqual(15, this.heroInventory.TotalDamageBonus);
    }

    [Test]
    public void AddItemToInventoryWithNecessaryRecipeShouldAddStrength()
    {
        // Arrange
        IRecipe recipe = new RecipeItem("Sword", 101, 102, 103, 104, 105, new List<string> { "Ring", "Axe" });
        IItem item = new CommonItem("Ring", 21, 22, 23, 24, 25);

        // Act
        this.heroInventory.AddRecipeItem(recipe);
        this.heroInventory.AddCommonItem(item);

        // Assert
        Assert.AreEqual(101, this.heroInventory.TotalStrengthBonus);
    }

    [Test]
    public void AddItemToInventoryWithNecessaryRecipeShouldAddAgility()
    {
        // Arrange
        IRecipe recipe = new RecipeItem("Sword", 101, 102, 103, 104, 105, new List<string> { "Ring", "Axe" });
        IItem item = new CommonItem("Ring", 21, 22, 23, 24, 25);

        // Act
        this.heroInventory.AddRecipeItem(recipe);
        this.heroInventory.AddCommonItem(item);

        // Assert
        Assert.AreEqual(102, this.heroInventory.TotalAgilityBonus);
    }

    [Test]
    public void AddItemToInventoryWithNecessaryRecipeShouldAddIntelligence()
    {
        // Arrange
        IRecipe recipe = new RecipeItem("Sword", 101, 102, 103, 104, 105, new List<string> { "Ring", "Axe" });
        IItem item = new CommonItem("Ring", 21, 22, 23, 24, 25);

        // Act
        this.heroInventory.AddRecipeItem(recipe);
        this.heroInventory.AddCommonItem(item);

        // Assert
        Assert.AreEqual(103, this.heroInventory.TotalIntelligenceBonus);
    }

    [Test]
    public void AddItemToInventoryWithNecessaryRecipeShouldAddHitPoints()
    {
        // Arrange
        IRecipe recipe = new RecipeItem("Sword", 101, 102, 103, 104, 105, new List<string> { "Ring", "Axe" });
        IItem item = new CommonItem("Ring", 21, 22, 23, 24, 25);

        // Act
        this.heroInventory.AddRecipeItem(recipe);
        this.heroInventory.AddCommonItem(item);

        // Assert
        Assert.AreEqual(104, this.heroInventory.TotalHitPointsBonus);
    }

    [Test]
    public void AddItemToInventoryWithNecessaryRecipeShouldAddDamage()
    {
        // Arrange
        IRecipe recipe = new RecipeItem("Sword", 101, 102, 103, 104, 105, new List<string> { "Ring", "Axe" });
        IItem item = new CommonItem("Ring", 21, 22, 23, 24, 25);

        // Act
        this.heroInventory.AddRecipeItem(recipe);
        this.heroInventory.AddCommonItem(item);

        // Assert
        Assert.AreEqual(105, this.heroInventory.TotalDamageBonus);
    }

    [Test]
    public void AddCommonItemNullShouldThrowException()
    {
        // Assert
        Assert.Throws<NullReferenceException>(() => this.heroInventory.AddCommonItem(null));
    }

    [Test]
    public void AddRecipeItemNullShouldThrowException()
    {
        // Assert
        Assert.Throws<NullReferenceException>(() => this.heroInventory.AddRecipeItem(null));
    }
}