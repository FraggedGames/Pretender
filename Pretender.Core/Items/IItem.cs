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
    public interface IItem
    {
        Int32 ID { get; set; }
        String Name { get; set; }
        Quality Quality { get; set; }
        Int32 BuyCount { get; set; }
        Int32 BuyPrice { get; set; }
        Int32 SellPrice { get; set; }
        InventoryType InventoryType { get; set; }

        Class AllowableClass { get; set; }

        Race AllowableRace { get; set; }

        UInt16 ItemLevel { get; set; }
        UInt16 RequiredLevel { get; set; }
        UInt32 RequiredSkill { get; set; }
        UInt32 RequiredSkillRank { get; set; }

        ISpell RequiredSpell { get; set; }
        UInt16 RequiredHonorRank { get; set; }
        UInt16 RequiredCityRank { get; set; }
        UInt16 RequiredReputationFaction { get; set; }
        UInt16 RequiredReputationRank { get; set; }
        UInt16 MaxCount { get; set; }
        UInt16 Stackable { get; set; }
        UInt16 ContainerSlots { get; set; }

        ICollection<IStat> Stats { get; }

        ICollection<IDamage> Damages { get; }

        UInt32 Armor { get; set; }

        ICollection<IResistance> Resistances { get; }

        UInt16 Delay { get; set; }

        IAmmo Ammo { get; set; }


        String Description { get; set; }
        String PageText { get; set; }
        IMap Map { get; set; }
        IScript Script { get; set; }
        ICollection<IItemAttribute> Attributes { get; }
    }


    [Flags]
    public enum InventoryType
    {
    }

    [Flags]
    public enum Quality
    {
    }

}
