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

namespace Pretender.Entities.Players
{
    public class PlayerBuilder<T> : EntityBuilder<T, PlayerBuilder<T>>, IEntityBuilder<T>
        where T : IPlayer, new()
    {
        public PlayerBuilder()
        {
        }

        protected override PlayerBuilder<T> Builder => this;

        public override T Build()
        {
            var player = new T()
            {
                Wears = Material,
                Wields = WeaponType
            };

            // The order here matters as some attributes have dependencies
            Equipment.Each(item => player.Equipment.Equip(item));
            Abilities.Each(ability => { player.Abilities.Add(ability); });
            Attributes.Each(attribute => { attribute.SetEntity(player); player.Attributes.Add(attribute); });

            return player;
        }
    }
}
