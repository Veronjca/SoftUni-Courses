using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    private HeroRepository heroRepository;
    private Hero hero;
    private const string HeroName = "Viksi";
    private const int HeroLevel = 12;

    [SetUp]

    public void SetUp()
    {
        this.heroRepository = new HeroRepository();
        this.hero = new Hero(HeroName, HeroLevel);
    }

    [Test]
    public void Constructor_ShouldWorkProperly()
    {
        Assert.IsNotNull(this.heroRepository.Heroes);
    }

    [Test]

    public void Create_ShouldThrowExceptionWhenHeroIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => this.heroRepository.Create(null));
    }

    [Test]

    public void Create_ShouldThrowExceptionWhenHeroAlreadyExist()
    {
        this.heroRepository.Create(this.hero);
        Assert.Throws<InvalidOperationException>(() => this.heroRepository.Create(this.hero));
    }

    [Test]

    public void Create_ShouldWorkProperly()
    {
        int expectedHeroCount = 1;

        string expectedMessage = $"Successfully added hero {HeroName} with level {HeroLevel}";
        string actualMessage = this.heroRepository.Create(this.hero);

        Assert.AreEqual(expectedHeroCount, this.heroRepository.Heroes.Count);
        Assert.AreEqual(expectedMessage, actualMessage);
    }

    [TestCase("")]
    [TestCase(null)]
    [TestCase(" ")]
    [TestCase("   ")]


    public void Remove_ShouldThrowExceptionWhenNameIsNullOrWhiteSpace(string name)
    {
        Assert.Throws<ArgumentNullException>(() => this.heroRepository.Remove(name));
    }

    [Test]

    public void Remove_ShouldReturnTrueWhenSucceeded()
    {
        this.heroRepository.Create(this.hero);
        Assert.IsTrue(this.heroRepository.Remove(HeroName));
    }

    [Test]

    public void Remove_ShouldReturnFalseWhenNotSucceeded()
    {
        Assert.IsFalse(this.heroRepository.Remove("Pesho"));
    }

    [Test]
    public void GetHeroWithHighestLevel_ShouldWorkProperly()
    {
        this.heroRepository.Create(this.hero);
        this.heroRepository.Create(new Hero("Emre", 16));
        this.heroRepository.Create(new Hero("Paf", 23));

        string expectedName = "Paf";
        int expectedLevel = 23;

        var heroWithHighestLevel = this.heroRepository.GetHeroWithHighestLevel();

        Assert.AreEqual(expectedName, heroWithHighestLevel.Name);
        Assert.AreEqual(expectedLevel, heroWithHighestLevel.Level);

    }

    [Test]

    public void GetHero_ShouldWorkCorrectly()
    {
        this.heroRepository.Create(this.hero);
        var hero = this.heroRepository.GetHero(HeroName);
        string expectedHeroName = HeroName;
        int expectedHeroLevel = HeroLevel;

        Assert.AreEqual(expectedHeroName, hero.Name);
        Assert.AreEqual(expectedHeroLevel, hero.Level);
    }

}