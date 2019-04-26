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

using Moq;
using Pretender.Entities.Players;
using Shouldly;
using System;
using Xunit;
namespace Pretender.GameEngine
{
    public class GameTests
    {
        [Fact]
        public void Can_instantiate_a_Game()
        {
            using (IGame game = new Game(new GameOptions()))
            {
                game.ShouldNotBeNull();
            }
        }

        [Fact]
        public void Can_add_a_Player_to_a_Game()
        {
            var mock = new Mock<IPlayer>();

            using (IGame game = new Game(new GameOptions()))
            {
                game.AddPlayer(mock.Object);

                game.Players.Count.ShouldBe(1);
            }
        }

        [Fact]
        public void Player_are_disposed_when_the_Game_is_disposed()
        {
            var mock = new Mock<IPlayer>();
            mock.Setup(m => m.Dispose()).Verifiable();

            using (IGame game = new Game(new GameOptions()))
            {
                game.AddPlayer(mock.Object);

                game.Players.Count.ShouldBe(1);
            }

            mock.Verify();
        }
    }
}
