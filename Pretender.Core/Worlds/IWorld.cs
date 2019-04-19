using Pretender.Entities.Players;
using System.Collections.Generic;

namespace Pretender.Worlds
{
    public interface IWorld
    {
        ICollection<IPlayer> Players { get; }

        void AddPlayer(IPlayer player);
    }
}
