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
using Pretender.Collections.Generic;
using Pretender.Entities.Attributes;
using Pretender.Entities.Combat;
using Pretender.Entities.Combat.Abilities;
using Pretender.Entities.Combat.Effects;
using Pretender.Entities.Enhancements;
using Pretender.Entities.Pets;
using Pretender.Entities.Traits;
using Pretender.GameEngine;
using Pretender.Items.Equipment;
using Pretender.Items.Equipment.Armor;
using Pretender.Items.Equipment.Weapons;

namespace Pretender.Entities
{
    public interface IEntity : IGameObject
    {
        ITypedCollection<IEntityAttribute> Attributes { get; }
        ITypedCollection<IAbility> Abilities { get; }
        ITypedCollection<ITrait> Traits { get; }
        ITypedCollection<IEntityEnhancement> Enhancements { get; }
        ITypedCollection<IEffect> Effects { get; }
        IEquipmentManager Equipment { get; }
        Material Wears { get; }
        WeaponType Wields { get; }

        IEntity CurrentTarget { get; }

        IPetEntity Pet { get; }

        void OnEquipmentChanged();

        event EventHandler<EventArgs> EquipmentChanged;

        void OnDamageReceived(IDamage damage);

        event EventHandler<DamageEventArgs> DamageReceived;
    }
}
