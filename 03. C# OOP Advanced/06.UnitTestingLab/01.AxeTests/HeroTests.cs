using Moq;
using NUnit.Framework;

[TestFixture]
public class HeroTests
{
    [Test]
    public void HeroGainsExperienceAfterAttackWhenTargetDies()
    {
        //Arrange
        Mock<ITarget> fakeTarget = new Mock<ITarget>();
        fakeTarget.Setup(ft => ft.Health).Returns(0);
        fakeTarget.Setup(ft => ft.GiveExperience()).Returns(20);
        fakeTarget.Setup(ft => ft.IsDead()).Returns(true);

        Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();
        Hero hero = new Hero("Pesho", fakeWeapon.Object);

        //Act
        hero.Attack(fakeTarget.Object);

        //Assert
        Assert.AreEqual(20, hero.Experience);
    }
}