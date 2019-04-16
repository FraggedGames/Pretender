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

namespace Pretender.Entities.Traits
{
    public abstract class BaseTrait : ITrait
    {
        public IEntity Entity { get; private set; }

        public Int32 Value { get; private set; }

        public Double Percentage { get; private set; }

        public ITrait SetEntity(IEntity entity)
        {
            Entity = entity ?? throw new ArgumentNullException(nameof(entity));
            return this;
        }

        public ITrait SetValue(Int32 value)
        {
            Value = value;
            Percentage = 0.0d;
            return this;
        }

        public ITrait SetValue(Double percentage)
        {
            Value = 0;
            Percentage = percentage;
            return this;
        }
    }
}
