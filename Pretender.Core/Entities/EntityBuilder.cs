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
using Pretender.Entities.Attributes;
using Pretender.Entities.Combat.Abilities;
using Pretender.Items.Equipment;
using Pretender.Items.Equipment.Armor;
using Pretender.Items.Equipment.Weapons;

namespace Pretender.Entities
{
    public abstract class EntityBuilder<TEntity, TBuilder> : IEntityBuilder<TEntity>
        where TEntity : IEntity
        where TBuilder : IEntityBuilder<TEntity>
    {
        private IList<IEntityAttribute> _attributes = new List<IEntityAttribute>();
        private IList<IAbility> _abilities = new List<IAbility>();
        private IList<IEquipableItem> _equipment = new List<IEquipableItem>();

        protected abstract TBuilder Builder { get; }

        protected Material Material { get; set; }
        protected WeaponType WeaponType { get; set; }

        protected ICollection<IAbility> Abilities => _abilities;

        protected ICollection<IEntityAttribute> Attributes => _attributes;

        protected ICollection<IEquipableItem> Equipment => _equipment;

        public abstract TEntity Build();

        public TBuilder Wears(Material material)
        {
            Material = material;
            return Builder;
        }

        public TBuilder Wields(WeaponType weaponType)
        {
            WeaponType = weaponType;
            return Builder;
        }

        public TBuilder Ability<T>() where T : IAbility, new() => Ability(new T());

        public TBuilder Ability(params IAbility[] abilities)
        {
            if (abilities == null)
            {
                throw new ArgumentNullException(nameof(abilities));
            }

            foreach (var ability in abilities)
            {
                _abilities.Add(ability);
            }

            return Builder;
        }

        public TBuilder Attribute<T>() where T : IEntityAttribute, new()
        {
            return WithAttributes(new T());
        }

        public TBuilder WithAttributes(params IEntityAttribute[] attributes)
        {
            if (attributes == null)
            {
                throw new ArgumentNullException(nameof(attributes));
            }

            foreach (var attribute in attributes)
            {
                _attributes.Add(attribute);
            }

            return Builder;
        }

        public TBuilder Equip<T>() where T : IEquipableItem, new() => Equip(new T());

        public TBuilder Equip(params IEquipableItem[] items)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            foreach (var ability in items)
            {
                _equipment.Add(ability);
            }

            return Builder;
        }
    }
}
