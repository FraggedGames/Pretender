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
using System.Collections;
using System.Collections.Generic;
using Pretender.Entities;
using Pretender.Items.Equipment.Armor;
using Pretender.Items.Equipment.Weapons;

namespace Pretender.Items.Equipment
{
    public class EquipmentManager : IEquipmentManager
    {
        private readonly IDictionary<EquipmentSlot, IEquipableItem> _equipment = new Dictionary<EquipmentSlot, IEquipableItem>();
        private readonly IEntity _entity;

        public EquipmentManager(IEntity entity)
        {
            _entity = entity ?? throw new ArgumentNullException(nameof(entity));
        }

        public IArmor Head => GetArmor(EquipmentSlot.Head);
        public IArmor Neck => GetArmor(EquipmentSlot.Neck);
        public IArmor Shoulders => GetArmor(EquipmentSlot.Shoulders);
        public IArmor Back => GetArmor(EquipmentSlot.Back);
        public IArmor Chest => GetArmor(EquipmentSlot.Chest);
        public IArmor Shirt => GetArmor(EquipmentSlot.Shirt);
        public IArmor Tabbard => GetArmor(EquipmentSlot.Tabbard);
        public IArmor Wrist => GetArmor(EquipmentSlot.Wrist);
        public IArmor Hands => GetArmor(EquipmentSlot.Hands);
        public IArmor Waist => GetArmor(EquipmentSlot.Waist);
        public IArmor Legs => GetArmor(EquipmentSlot.Legs);
        public IArmor Feet => GetArmor(EquipmentSlot.Feet);
        public IWeapon MainHand => GetWeapon(EquipmentSlot.MainHand);
        public IWeapon OffHand => GetWeapon(EquipmentSlot.OffHand);

        public Int32 Count => _equipment.Count;

        public Boolean Equip(IEquipableItem item, EquipmentSlot equipmentSlot = EquipmentSlot.Default)
        {
            var slot = Determine(item, equipmentSlot);
            if (CannotBeEquipedInSlot(item, slot))
            {
                return false;
            }

            if (item is IArmor armor && CannotWear(armor))
            {
                throw new CantWearThatException();
            }
            else if (item is IWeapon weapon && CannotWield(weapon))
            {
                throw new CantUseThatException();
            }

            _equipment[slot] = item;
            _entity.OnEquipmentChanged();
            return true;

            Boolean CannotBeEquipedInSlot(IEquipableItem i, EquipmentSlot s) => !i.EquipmentSlot.HasFlag(s);
            Boolean CannotWear(IArmor a) => a.Material == Material.Unspecified || !_entity.Wears.HasFlag(a.Material);
            Boolean CannotWield(IWeapon w) => w.WeaponType == WeaponType.Unspecified || !_entity.Wields.HasFlag(w.WeaponType);
        }

        private static EquipmentSlot Determine(IEquipableItem item, EquipmentSlot slot)
        {
            if (slot == EquipmentSlot.Default)
            {
                slot = item.EquipmentSlot;
            }

            if (slot.HasFlag(EquipmentSlot.MainHand | EquipmentSlot.OffHand))
            {
                slot = EquipmentSlot.MainHand;
            }
            else if (slot.HasFlag(EquipmentSlot.MainHandRing | EquipmentSlot.OffHandRing))
            {
                slot = EquipmentSlot.MainHandRing;
            }
            else if (slot.HasFlag(EquipmentSlot.MainHandTrinket | EquipmentSlot.OffHandTrinket))
            {
                slot = EquipmentSlot.MainHandTrinket;
            }

            return slot;
        }

        private IArmor GetArmor(EquipmentSlot slot) => _equipment.ContainsKey(slot) ? _equipment[slot] as IArmor : ArmorItem.Empty;

        private IWeapon GetWeapon(EquipmentSlot slot) => _equipment.ContainsKey(slot) ? _equipment[slot] as IWeapon : Weapon.Empty;

        public IEnumerator<IEquipableItem> GetEnumerator() => _equipment.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _equipment.Values.GetEnumerator();
    }
}
