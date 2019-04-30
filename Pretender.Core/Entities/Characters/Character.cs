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
using System.Threading.Tasks;
using Pretender.Entities.Attributes;

namespace Pretender.Entities.Characters
{
    public class Character : Entity, ICharacter
    {
        public Character()
        {
            Inventory = new InventoryManager(this);
        }

        public IInventoryManager Inventory { get; }

        public UInt32 Agility => Attributes.GetValue<Agility, UInt32>(a => a.Current);
        public UInt32 Armor => Attributes.GetValue<Armor, UInt32>(a => a.Current);
        public UInt32 Health => Attributes.GetValue<Health, UInt32>(a => a.Current);
        public UInt32 Intellect => Attributes.GetValue<Intellect, UInt32>(a => a.Current);
        public UInt32 Mana => Attributes.GetValue<Mana, UInt32>(a => a.Current);
        public UInt32 Stamina => Attributes.GetValue<Stamina, UInt32>(a => a.Current);
        public UInt32 Strength => Attributes.GetValue<Strength, UInt32>(a => a.Current);
    }
}
