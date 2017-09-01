using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    private const int AxeAttack = 1;
    private const int AxeDurability = 1;
    private const int DummyHealth = 10;
    private const int DummyExperience = 10;

    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void TestInitialize()
    {
        //Arrange
        this.axe = new Axe(AxeAttack, AxeDurability);
        this.dummy = new Dummy(DummyHealth, DummyExperience);
    }

    [Test]
    public void AxeLosesDurabilityAfterAttack()
    {
        //Act
        this.axe.Attack(this.dummy);

        //Assert
        Assert.AreEqual(0, this.axe.DurabilityPoints, "Axe durability doesn't change after attack!");
    }

    [Test]
    public void AxeAttackWhenItIsBroken()
    {
        //Act
        this.axe.Attack(this.dummy);

        //Assert
        InvalidOperationException exeption = Assert.Throws<InvalidOperationException>(() => this.axe.Attack(this.dummy));
        Assert.AreEqual("Axe is broken!", exeption.Message);
    }
}