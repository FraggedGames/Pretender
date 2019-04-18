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
using System.Collections.Generic;
using Pretender.Items.Equipment.Armor;
using Pretender.Items.Equipment.Weapons;

namespace Pretender.Items.Equipment
{
    public interface IEquipmentManager : IEnumerable<IEquipableItem>
    {
        IArmor Head { get; }
        IArmor Neck { get; }
        IArmor Shoulders { get; }
        IArmor Back { get; }
        IArmor Chest { get; }
        IArmor Shirt { get; }
        IArmor Tabbard { get; }
        IArmor Wrist { get; }
        IArmor Hands { get; }
        IArmor Waist { get; }
        IArmor Legs { get; }
        IArmor Feet { get; }
        IWeapon MainHand { get; }
        IWeapon OffHand { get; }
        Int32 Count { get; }

        Boolean Equip(IEquipableItem item, EquipmentSlot equipmentSlot = EquipmentSlot.Default);
    }
}
