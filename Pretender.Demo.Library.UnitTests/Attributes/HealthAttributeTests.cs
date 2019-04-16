using Pretender.Demo.Library.Attributes;
using Pretender.Entities;
using Pretender.Entities.Combat;
using Pretender.Items.Equipment;
using Pretender.Items.Equipment.Armor;
using Shouldly;
using Xunit;

namespace Pretender.Demo.Library
{
    public class HealthAttributeTests
    {
        [Fact]
        public void HealthAttribute_has_sensible_defaults()
        {
            var health = new Health().SetEntity(new Entity());

            health.Base.ShouldBe(100);
            health.Total.ShouldBe(100);
            health.Current.ShouldBe(100);
        }

        [Fact]
        public void Health_Total_is_increased_when_Armor_with_Stamina_is_equipped()
        {
            // Arrange
            IEntity entity = new Entity();
            var health = new Health().SetEntity(entity);
            var starting = health.Total;

            var chest = new ArmorBuilder().For(EquipmentSlot.Chest).OutOf(Material.Cloth).WithStamina(100).Build();

            // Act
            entity.Equipment.Equip(chest);

            // Assert
            health.Total.ShouldBeGreaterThan(starting);
        }

        [Fact]
        public void Current_Health_is_reduced_when_Entity_takes_damage()
        {
            // Arrange
            IEntity entity = new Entity();
            var health = new Health().SetEntity(entity);
            var starting = health.Current;

            // Act
            entity.OnDamageReceived(new Damage(10));

            // Assert
            health.Current.ShouldBe(starting - 10);
        }
    }
}
