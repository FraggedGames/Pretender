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

            pc.Agility.ShouldBe(14);
            pc.Armor.ShouldBe(8);
            pc.Health.ShouldBe(100);
            pc.Intellect.ShouldBe(0);
            pc.Mana.ShouldBe(0);
            pc.Stamina.ShouldBe(12);
            pc.Strength.ShouldBe(10);
        }
    }
}
