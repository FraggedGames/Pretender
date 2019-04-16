using System;
using Pretender.Demo.Library.Attributes;
using Pretender.Entities;
using Pretender.Items.Equipment;
using Pretender.Items.Equipment.Armor;
using Shouldly;
using Xunit;

namespace Pretender.Demo.Library
{
    public class ArmorAttributeTests
    {
        [Fact]
        public void ArmorAttribute_has_sensible_defaults()
        {
            var entity = new Entity();
            var armor = new Armor().SetEntity(entity);

            armor.Base.ShouldBe(0);
            armor.Total.ShouldBe(0);
            armor.Current.ShouldBe(0);
        }

        [Fact]
        public void Armor_Total_is_increased_when_Armor_is_equipped()
        {
            // Arrange
            IEntity entity = new Entity();
            var armor = new Armor().SetEntity(entity);
            var starting = armor.Total;

            var chest = new ArmorBuilder().For(EquipmentSlot.Chest).OutOf(Material.Cloth).WithArmor(100).Build();

            // Act
            entity.Equipment.Equip(chest);

            // Assert
            armor.Total.ShouldBe(starting + chest.Armor);
        }
    }
}
