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
using System.Numerics;
using System.Threading.Tasks;
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
        public Int32 ID { get; set; }
        public IMap Map { get; set; }
        public Vector4 Position { get; set; }
        public Vector4 Orientation { get; set; }

        public event EventHandler<EventArgs> EquipmentChanged;

        public void OnEquipmentChanged() => EquipmentChanged?.Invoke(this, EventArgs.Empty);

        public event EventHandler<DamageEventArgs> DamageReceived;

        public void OnDamageReceived(IDamage damage) => DamageReceived?.Invoke(this, new DamageEventArgs(damage));
        public virtual Task Update(Double elapsed) => Task.CompletedTask;

        #region IDisposable Support
        private Boolean _disposed = false; // To detect redundant calls

        protected virtual void Dispose(Boolean disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                _disposed = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~Entity()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
