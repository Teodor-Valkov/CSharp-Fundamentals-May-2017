using NUnit.Framework;
using System;

[TestFixture]
public class DummyTests
{
    private const int AxeAttack = 10;
    private const int AxeDurability = 10;
    private const int DummyHealth = 10;
    private const int DummyExperiance = 10;

    private Axe axe;
    private Dummy dummy;
    private Hero hero;

    [SetUp]
    public void TestInitialize()
    {
        //Arrange
        this.axe = new Axe(AxeAttack, AxeDurability);
        this.dummy = new Dummy(DummyHealth, DummyExperiance);
    }

    [Test]
    public void DummyLosesHealthWhenItIsAttacked()
    {
        //Act
        this.axe.Attack(this.dummy);

        //Assert
        Assert.AreEqual(0, dummy.Health, "Dummy health doesn't update!");
    }

    [Test]
    public void DeadDummyThrowsExceptionWhenItIsAttacked()
    {
        //Act
        this.axe.Attack(this.dummy);

        //Assert
        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => this.axe.Attack(this.dummy));
        Assert.AreEqual("Dummy is dead!", exception.Message);
    }

    [Test]
    public void DeadDummyCanGiveExperience()
    {
        //Act
        this.dummy = new Dummy(0, 10);
        int experience = dummy.GiveExperience();

        //Assert
        Assert.AreEqual(10, experience, "Dummy doesn't give experience!");
    }

    [Test]
    public void AliveDummyCannotGiveExperience()
    {
        //Act

        //Assert
        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => this.dummy.GiveExperience());
        Assert.AreEqual("Target is not dead!", exception.Message);
    }
}