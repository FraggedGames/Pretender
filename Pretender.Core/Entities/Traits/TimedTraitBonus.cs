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
using System.Timers;

namespace Pretender.Entities.Traits
{
    public class TimedTraitBonus : BaseTrait
    {
        private readonly Timer _timer;
        private Trait _parent;

        public TimedTraitBonus(TimeSpan duration, Int32 value) : this(duration, value, 0.0d)
        {
        }

        public TimedTraitBonus(TimeSpan duration, Double percentage) : this(duration, 0, percentage)
        {
        }

        private TimedTraitBonus(TimeSpan duration, Int32 value = 0, Double percentage = 0.0d)
        {
            _timer = new Timer(duration.TotalMilliseconds);
            _timer.Elapsed += OnTimerElapsed;
            SetValue(value);
            SetValue(percentage);
        }

        public void StartTime(Trait parent)
        {
            _parent = parent ?? throw new ArgumentNullException(nameof(parent));
            _timer.Start();
        }

        private void OnTimerElapsed(Object sender, ElapsedEventArgs e)
        {
            _timer.Stop();
            _parent.RemoveBonus(this);
        }
    }
}
