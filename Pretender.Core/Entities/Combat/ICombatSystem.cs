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

using Pretender.Entities.Combat.Abilities;

namespace Pretender.Entities.Combat
{
    public interface ICombatSystem
    {
        void Handle(AttackCommand attackCommand);
    }

    public class AttackCommand : ICommand
    {
        public AttackCommand()
        {
        }

        public IEntity Target { get; set; }
        public IAbility Ability { get; set; }
        public IEntity Initiator { get; set; }
    }

    public interface ICommand
    {
        IEntity Initiator { get; }
    }

    public class AttackInterupted : IEvent
    {

    }

    public class AttackFailed : IEvent
    {
        public IEntity Initiator { get; set; }
    }

    public class AttackSucceeded : IEvent
    {
        public IEntity Target { get; set; }
        public IDamage Damage { get; set; }
    }

    public interface IEvent
    {
    }
}
