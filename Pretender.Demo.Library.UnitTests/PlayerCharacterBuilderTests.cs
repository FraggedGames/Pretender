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
using Pretender.Demo.Library.Attributes;
using Pretender.Entities.Combat.Abilities.Rogues;
using Pretender.Entities.Players;
using Pretender.Items.Equipment.Armor;
using Pretender.Items.Equipment.Weapons;
using Shouldly;
using Xunit;

namespace Pretender.Demo.Library
{
    public class PlayerCharacterBuilderTests
    {
        [Fact]
        public void Can_build_a_PlayerCharacter()
        {
            var pc = new PlayerBuilder<PlayerCharacter>()
                .WithAttributes(new Agility(14), new Stamina(12), new Strength(10))

                .Attribute<Armor>()
                .Attribute<Health>()

                .Ability<SinisterStrike>()
                .Ability<Stealth>()

                .Wears(Material.Cloth | Material.Leather)
                .Wields(WeaponType.Dagger | WeaponType.FistWeapon | WeaponType.OneHandedSword)

                .Equip(new Shirt(), new Pants(), new Boots())
                .Build();

            pc.Agility.ShouldBe(14u);
            pc.Armor.ShouldBe(8u);
            pc.Health.ShouldBe(100u);
            pc.Intellect.ShouldBe(0u);
            pc.Mana.ShouldBe(0u);
            pc.Stamina.ShouldBe(12u);
            pc.Strength.ShouldBe(10u);
        }
    }
}
