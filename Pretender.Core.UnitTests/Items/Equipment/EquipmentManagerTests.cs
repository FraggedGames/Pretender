/*************************************************************************
 * Copyright © 2019 Fragged Games, Doug Wilson https://fragged.com
 * 
 * This file is part of Pretender
 *
 * Pretender is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Lesser General Public License as 
 * published by the Free Software Foundation, either version 3 of the 
 * License, or (at your option) any later version.
 * 
 * Pretender is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU Lesser General Public License for more details.
 * 
 * You should have received a copy of the GNU Lesser General Public 
 * License along with Pretender.  If not, please visit 
 * https://www.gnu.org/licenses/ to obtain a copy.
 *
 ************************************************************************/

using System;
using Pretender.Entities;
using Pretender.Items.Equipment.Armor;
using Pretender.Items.Equipment.Weapons;
using Shouldly;
using Xunit;

namespace Pretender.Items.Equipment
{
    public class EquipmentManagerTests
    {
        [Fact]
        public void Equipment_should_have_sensible_defaults()
        {
            var equipment = new EquipmentManager(new Entity());

            equipment.MainHand.ShouldBeSameAs(Weapon.Empty);
            equipment.OffHand.ShouldBeSameAs(Weapon.Empty);
        }

        [Fact]
        public void Equiping_a_Plate_item_on_a_Cloth_wearer_generates_an_error()
        {
            // Arrange
            var equipment = new EquipmentManager(new Entity());
            var gauntlets = new ArmorBuilder().For(EquipmentSlot.Hands).OutOf(Material.Plate).Build();

            // Act
            Assert.Throws<CantWearThatException>(() => equipment.Equip(gauntlets));
        }

        [Fact]
        public void Equiping_a_Plate_item_on_a_Cloth_and_Leather_wearer_generates_an_error()
        {
            // Arrange
            var equipment = new EquipmentManager(new Entity() { Wears = Material.Cloth | Material.Leather });
            var gauntlets = new ArmorBuilder().For(EquipmentSlot.Hands).OutOf(Material.Plate).Build();

            // Act
            Assert.Throws<CantWearThatException>(() => equipment.Equip(gauntlets));
        }

        [Fact]
        public void Can_Equip_Cloth_armor_on_a_Cloth_and_Leather_wearer()
        {
            // Arrange
            var equipment = new EquipmentManager(new Entity() { Wears = Material.Cloth | Material.Leather });
            var gloves = new ArmorBuilder().For(EquipmentSlot.Hands).OutOf(Material.Cloth).WithArmor(5).Build();

            // Act
            equipment.Equip(gloves);

            // Assert
            equipment.Hands.ShouldBeSameAs(gloves);
        }

        [Fact]
        public void Can_Equip_Leather_armor_on_a_Cloth_and_Leather_wearer()
        {
            // Arrange
            var equipment = new EquipmentManager(new Entity() { Wears = Material.Cloth | Material.Leather });
            var gauntlets = new ArmorBuilder().For(EquipmentSlot.Hands).OutOf(Material.Leather).WithArmor(5).Build();

            // Act
            equipment.Equip(gauntlets);

            // Assert
            equipment.Hands.ShouldBeSameAs(gauntlets);
        }

        [Fact]
        public void Can_Equip_Cloth_armor_on_a_Plate_wearer()
        {
            // Arrange
            var equipment = new EquipmentManager(new Entity() { Wears = Material.Cloth | Material.Leather | Material.Mail | Material.Plate });
            var gloves = new ArmorBuilder().For(EquipmentSlot.Hands).OutOf(Material.Leather).WithArmor(5).Build();

            // Act
            equipment.Equip(gloves);

            // Assert
            equipment.Hands.ShouldBeSameAs(gloves);
        }

        [Fact]
        public void Can_Equip_a_Dagger_in_MainHand()
        {
            // Arrange
            var equipment = new EquipmentManager(new Entity() { Wields = WeaponType.Dagger });
            var dagger = new WeaponBuilder().Dagger(10).Build();

            // Act
            var result = equipment.Equip(dagger);

            // Assert
            result.ShouldBe(true);
            equipment.MainHand.ShouldBeSameAs(dagger);
            equipment.OffHand.ShouldBeSameAs(Weapon.Empty);
        }

        [Fact]
        public void Can_Equip_a_Dagger_in_OffHand()
        {
            // Arrange
            var equipment = new EquipmentManager(new Entity() { Wields = WeaponType.Dagger });
            var dagger = new WeaponBuilder().Dagger(10).Build();

            // Act
            var result = equipment.Equip(dagger, EquipmentSlot.OffHand);

            // Assert
            result.ShouldBe(true);
            equipment.MainHand.ShouldBeSameAs(Weapon.Empty);
            equipment.OffHand.ShouldBeSameAs(dagger);
        }

        [Fact]
        public void Cannot_Equip_a_TwoHanded_weapon_in_the_OffHand()
        {
            // Arrange
            var equipment = new EquipmentManager(new Entity() { Wields = WeaponType.TwoHandedSword });
            var ths = new WeaponBuilder().TowHandedSword().Build();

            // Act
            var result = equipment.Equip(ths, EquipmentSlot.OffHand);

            // Assert
            result.ShouldBe(false);
            equipment.MainHand.ShouldBeSameAs(Weapon.Empty);
            equipment.OffHand.ShouldBeSameAs(Weapon.Empty);
        }
    }
}
