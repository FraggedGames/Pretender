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

namespace Pretender.Entities.Attributes
{
    public abstract class EntityAttribute : RpgAttribute, IEntityAttribute, IDisposable
    {
        protected IEntity Entity { get; private set; }
        private Boolean _disposed = false;

        public IEntityAttribute SetEntity(IEntity entity)
        {
            Entity = entity ?? throw new ArgumentNullException(nameof(entity));
            Subscribe();
            Current = Calculate();
            return this;
        }

        public IEntityAttribute SetBase(Int32 value)
        {
            Base = value;
            return this;
        }

        public virtual Int32 Calculate()
        {
            Total = Base;
            Current = Base;

            return Total;
        }

        protected virtual void Subscribe()
        {
        }

        protected virtual void Unsubscribe()
        {
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Unsubscribe();
                }

                _disposed = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~EntityAttribute()
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
    }
}
