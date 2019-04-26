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

            health.Base.ShouldBe(100u);
            health.Total.ShouldBe(100u);
            health.Current.ShouldBe(100u);
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
