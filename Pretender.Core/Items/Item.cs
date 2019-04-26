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
using Pretender.Entities.Combat;
using Pretender.GameEngine;
using Pretender.Items.Attributes;
using Pretender.Spells;

namespace Pretender.Items
{
    public class Item : IItem
    {
        public Item()
        {
            Attributes = new List<IItemAttribute>();
        }

        public Int32 ID { get; set; }

        public ICollection<IItemAttribute> Attributes { get; }
        public String Name { get; set; }
        public Quality Quality { get; set; }
        public Int32 BuyCount { get; set; }
        public Int32 BuyPrice { get; set; }
        public Int32 SellPrice { get; set; }
        public InventoryType InventoryType { get; set; }
        public Class AllowableClass { get; set; }
        public Race AllowableRace { get; set; }
        public UInt16 ItemLevel { get; set; }
        public UInt16 RequiredLevel { get; set; }
        public UInt32 RequiredSkill { get; set; }
        public UInt32 RequiredSkillRank { get; set; }
        public ISpell RequiredSpell { get; set; }
        public UInt16 RequiredHonorRank { get; set; }
        public UInt16 RequiredCityRank { get; set; }
        public UInt16 RequiredReputationFaction { get; set; }
        public UInt16 RequiredReputationRank { get; set; }
        public UInt16 MaxCount { get; set; }
        public UInt16 Stackable { get; set; }
        public UInt16 ContainerSlots { get; set; }
        public ICollection<IStat> Stats { get; }
        public ICollection<IDamage> Damages { get; }
        public virtual UInt32 Armor { get; set; }
        public ICollection<IResistance> Resistances { get; }
        public UInt16 Delay { get; set; }
        public IAmmo Ammo { get; set; }
        public String Description { get; set; }
        public String PageText { get; set; }
        public IMap Map { get; set; }
        public IScript Script { get; set; }
    }
}
