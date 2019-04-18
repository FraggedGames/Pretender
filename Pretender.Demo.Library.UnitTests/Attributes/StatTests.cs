/*******************************************************************************
 * Copyright © 2019 Doug Wilson https://dkw.io
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a 
 * copy of this software and associated documentation files (the "Software"),
 * to deal in the Software without restriction, including without limitation
 * the rights to use, copy, modify, merge, publish, distribute, sublicense,
 * and/or sell copies of the Software, and to permit persons to whom the 
 * Software is furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING 
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
 * DEALINGS IN THE SOFTWARE.
 *
 ************************************************************************/

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
