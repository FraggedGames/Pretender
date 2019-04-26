﻿/*************************************************************************
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

using Moq;
using Pretender.Entities.Combat.Abilities.Rogues;
using Pretender.Entities.Mobs;
using Pretender.Entities.Players;
using Xunit;

namespace Pretender.Entities.Combat
{
    public class ComabatSystemTests
    {
        [Fact]
        public void Player_can_attack_a_Mob()
        {
            // Arrange
            var player = new Mock<IPlayer>();
            var spell = new SinisterStrike();
            var damage = new Mock<IDamage>();

            var mob = new Mock<IMob>();

            var bus = new Mock<IEventBus>();

            ICombatSystem combatSystem = new CombatSystem(bus.Object);

            // Act
            combatSystem.Handle(new AttackCommand() { Initiator = player.Object, Target = mob.Object, Ability = spell });

            // Assert
            bus.Verify(b => b.Publish(It.IsAny<AttackSucceeded>()));

        }
    }
}
