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
using Pretender.Items.Attributes;

namespace Pretender.Items.Equipment.Armor
{
    public class ArmorBuilder
    {
        private EquipmentSlot _equipmentSlot;
        private BindsOn _bindsOn = BindsOn.Equip;
        private Material _material;
        private Int32 _armor;
        private Int32 _stamina;

        public IArmor Build()
        {
            var armor = new ArmorItem()
            {
                Material = _material,
                EquipmentSlot = _equipmentSlot,
                BindsOn = _bindsOn
            };

            if (_armor > 0) { armor.Attributes.Add(new ArmorItemAttribute(_armor)); }
            if (_stamina > 0) { armor.Attributes.Add(new StaminaItemAttribute(_stamina)); }

            return armor;
        }

        public ArmorBuilder BindsOnPickup()
        {
            _bindsOn = BindsOn.Pickup;
            return this;
        }

        public ArmorBuilder For(EquipmentSlot equipmentSlot)
        {
            _equipmentSlot = equipmentSlot;
            return this;
        }

        public ArmorBuilder OutOf(Material material)
        {
            _material = material;
            return this;
        }

        public ArmorBuilder WithStamina(Int32 stamina)
        {
            if (stamina < 0) { throw new ArgumentOutOfRangeException(nameof(stamina), "Stamina value must be 0 or larger."); }
            _stamina = stamina;
            return this;
        }

        public ArmorBuilder WithArmor(Int32 armor)
        {
            if (armor < 0) { throw new ArgumentOutOfRangeException(nameof(armor), "Armor value must be 0 or larger."); }
            _armor = armor;
            return this;
        }
    }
}
