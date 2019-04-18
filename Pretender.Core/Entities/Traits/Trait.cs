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
    public class Trait : BaseTrait
    {
        private readonly IList<BaseTrait> _fixed = new List<BaseTrait>();
        private readonly IList<BaseTrait> _timed = new List<BaseTrait>();

        protected Int32 Accumulator;

        public Trait()
        {
        }

        public Trait(Int32 value)
        {
            SetValue(value);
        }

        public Trait AddBonus(TraitBonus bonus)
        {
            _fixed.Add(bonus);
            Calculate();
            return this;
        }

        public Trait AddBonus(TimedTraitBonus bonus)
        {
            _timed.Add(bonus);
            bonus.StartTime(this);
            Calculate();
            return this;
        }

        public void RemoveBonus(TraitBonus bonus)
        {
            _fixed.Remove(bonus);
        }

        public void RemoveBonus(TimedTraitBonus bonus)
        {
            _timed.Remove(bonus);
        }

        protected virtual void ApplyFixedBonuses()
        {
            ApplyBonuses(_fixed);
        }

        protected virtual void ApplyTimedBonuses()
        {
            ApplyBonuses(_timed);
        }

        private void ApplyBonuses(IList<BaseTrait> list)
        {
            foreach (var bonus in list)
            {
                if (bonus.Value != 0)
                {
                    Accumulator += bonus.Value;
                }
                else if (bonus.Percentage >= -1.0d && bonus.Percentage < 1.0d)
                {
                    Accumulator += Convert.ToInt32(bonus.Percentage * Accumulator);
                }
                else
                {
                    Accumulator = Convert.ToInt32(bonus.Percentage * Accumulator);
                }
            }
        }

        public virtual Int32 Calculate()
        {
            Accumulator = Value;

            ApplyFixedBonuses();
            ApplyTimedBonuses();

            return Accumulator < 0 ? 0 : Accumulator;
        }

        public Int32 Total => Calculate();
    }
}
