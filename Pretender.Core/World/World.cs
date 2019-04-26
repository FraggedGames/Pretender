using Pretender.Entities.Players;
using System;
using System.Collections.Generic;

namespace Pretender.World
{
    public class World : IWorld
    {
        private IDictionary<Int32, IPlayer> _players = new Dictionary<Int32, IPlayer>();

        public ICollection<IPlayer> Players => _players.Values;

        public void AddPlayer(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            _players.Add(player.ID, player);
        }
    }
}
