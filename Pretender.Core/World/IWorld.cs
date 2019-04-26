using Pretender.Entities.Players;
using System.Collections.Generic;

namespace Pretender.World
{
    public interface IWorld
    {
        ICollection<IPlayer> Players { get; }

        void AddPlayer(IPlayer player);
    }
}
