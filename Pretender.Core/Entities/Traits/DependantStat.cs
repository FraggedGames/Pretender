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

namespace Pretender.Entities.Traits
{
    public class DependantTrait : Trait
    {
        protected IList<Trait> Stats = new List<Trait>();

        public DependantTrait()
        {
        }

        public DependantTrait(Int32 value)
        {
            SetValue(value);
        }

        public void AddAttribute(Trait attribute)
        {
            if (attribute == null)
            {
                throw new ArgumentNullException(nameof(attribute));
            }

            Stats.Add(attribute);
        }

        public void RemoveAttribute(Trait attribute)

        {
            if (attribute == null)
            {
                throw new ArgumentNullException(nameof(attribute));
            }
            Stats.Remove(attribute);
        }
    }
}
