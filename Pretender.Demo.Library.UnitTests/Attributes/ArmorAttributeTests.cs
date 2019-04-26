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

            armor.Base.ShouldBe(0u);
            armor.Total.ShouldBe(0u);
            armor.Current.ShouldBe(0u);
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
