using System;
using Shouldly;
using Xunit;

namespace Pretender.Entities.Traits
{
    public class TraitTests
    {
        [Fact]
        public void Stat_test()
        {
            var strength = new Trait(10);

            strength.Total.ShouldBe(10);
        }

        [Fact]
        public void Stat_with_Bonus_test()
        {
            var strength = new Trait(10);
            strength.AddBonus(new TraitBonus(10));

            strength.Total.ShouldBe(20);
        }

        [Fact]
        public void Stat_with_positive_percentage_Bonus_test()
        {
            new Trait(10).AddBonus(new TraitBonus(0.2d)).Total.ShouldBe(12);
            new Trait(10).AddBonus(new TraitBonus(1.0d)).Total.ShouldBe(10);
            new Trait(10).AddBonus(new TraitBonus(1.5d)).Total.ShouldBe(15);
            new Trait(10).AddBonus(new TraitBonus(2.0d)).Total.ShouldBe(20);
        }

        [Fact]
        public void Stat_with_negative_percentage_Bonus_test()
        {
            new Trait(10).AddBonus(new TraitBonus(-0.2d)).Total.ShouldBe(8);
            new Trait(10).AddBonus(new TraitBonus(-1.0d)).Total.ShouldBe(0);
            new Trait(10).AddBonus(new TraitBonus(-1.5d)).Total.ShouldBe(0);
            new Trait(10).AddBonus(new TraitBonus(-2.0d)).Total.ShouldBe(0);
        }

        [Fact]
        public void TimedBonus_test()
        {
            var strength = new Trait(10);
            strength.Total.ShouldBe(10);

            strength.AddBonus(new TimedTraitBonus(TimeSpan.FromSeconds(5), 10));
        }
    }
}
