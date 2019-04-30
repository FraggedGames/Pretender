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
using Pretender.Entities.Combat.Costs;
using Pretender.Entities.Combat.Effects;

namespace Pretender.Entities.Combat.Abilities
{
    public abstract class Ability : IAbility
    {
        private readonly ICollection<ICondition> _conditions = new List<ICondition>();

        public ISchool School { get; }
        public ICost Cost { get; set; }
        public Int32 Charges { get; } = 1;
        public Int32 Range { get; }
        public TimeSpan CastTime { get; }
        public TimeSpan Duration { get; set; }
        public TimeSpan CoolDown { get; }
        public IDispel Dispel { get; }
        public IEffect Effect { get; }
        public AbilityFlags Flags { get; set; }
        public IDamage Damage { get; set; }
        public IDamage DamageOverTime { get; set; }

        public ICollection<ICondition> Conditions => _conditions;

        protected void AddCondition(ICondition condition)
        {
            if (condition == null)
            {
                throw new ArgumentNullException(nameof(condition));
            }

            _conditions.Add(condition);
        }
    }

    public abstract class InstantAbility : Ability
    {

    }

    public abstract class ChanneledAbility : Ability
    {

    }

    public abstract class CastAbility : Ability
    {

    }
}
