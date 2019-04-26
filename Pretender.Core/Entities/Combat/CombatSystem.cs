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

namespace Pretender.Entities.Combat
{
    public class CombatSystem : ICombatSystem
    {
        private readonly IEventBus _eventBus;

        public CombatSystem(IEventBus eventBus)
        {
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        }

        public void Handle(AttackCommand command)
        {
            // Check Conditions
            foreach(var condition in command.Ability.Conditions)
            {
                if (!condition.IsStatisfied(command.Initiator, command.Target))
                {
                    _eventBus.Publish(new AttackFailed() { Initiator = command.Initiator });
                }
            }

            // Compute Attack


            // Apply Damage
            _eventBus.Publish(new AttackSucceeded() { Target = command.Target, Damage = command.Ability.Damage });
        }
    }

    public interface IEventBus
    {
        void Publish(AttackFailed attackFailed);
        void Publish(AttackSucceeded attackSucceeded);
    }
}
