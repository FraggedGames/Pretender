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
using Pretender.Items.Equipment;
using Pretender.Items.Equipment.Armor;
using Pretender.Items.Equipment.Weapons;

namespace Pretender.Entities
{
    public class Entity : IEntity
    {
        public Entity()
        {
            Wears = Material.Cloth;
            Wields = WeaponType.Dagger;

            Attributes = new TypedCollection<IEntityAttribute>();
            Traits = new TypedCollection<ITrait>();
            Enhancements = new TypedCollection<IEntityEnhancement>();
            Abilities = new TypedCollection<IAbility>();
            Equipment = new EquipmentManager(this);
        }

        public ITypedCollection<IEntityAttribute> Attributes { get; }

        public ITypedCollection<IAbility> Abilities { get; }

        public ITypedCollection<ITrait> Traits { get; }
        public ITypedCollection<IEntityEnhancement> Enhancements { get; }
        public ITypedCollection<IEffect> Effects { get; }
        public IEquipmentManager Equipment { get; }

        public IEntity CurrentTarget { get; }

        public Material Wears { get; set; }
        public WeaponType Wields { get; set; }
        public IPetEntity Pet { get; }

        public event EventHandler<EventArgs> EquipmentChanged;

        public void OnEquipmentChanged() => EquipmentChanged?.Invoke(this, EventArgs.Empty);

        public event EventHandler<DamageEventArgs> DamageReceived;

        public void OnDamageReceived(IDamage damage) => DamageReceived?.Invoke(this, new DamageEventArgs(damage));
    }
}
