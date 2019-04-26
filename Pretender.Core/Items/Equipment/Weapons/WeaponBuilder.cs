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
using Pretender.Entities.Combat;

namespace Pretender.Items.Equipment.Weapons
{
    public class WeaponBuilder
    {
        private EquipmentSlot _equipmentSlot;
        private IDamage _damage;
        private WeaponType _weaponType;

        public IWeapon Build()
        {
            return new Weapon()
            {
                EquipmentSlot = _equipmentSlot,
                WeaponType = _weaponType,
                Damage = _damage
            };
        }

        public WeaponBuilder For(EquipmentSlot equipmentSlot)
        {
            _equipmentSlot = equipmentSlot;
            return this;
        }

        public WeaponBuilder Dagger(UInt32 damage)
        {
            _weaponType = WeaponType.Dagger;
            _equipmentSlot = EquipmentSlot.MainHand | EquipmentSlot.OffHand;
            _damage = new Damage(damage);
            return this;
        }

        public WeaponBuilder TowHandedSword()
        {
            _weaponType = WeaponType.TwoHandedSword;
            _equipmentSlot = EquipmentSlot.MainHand;
            return this;
        }
    }
}
