using Pretender.Entities.Players;
using Pretender.World;
using System;
using System.Collections.Generic;

namespace Pretender.GameEngine
{
    public interface IGame : IDisposable
    {
        ICollection<IPlayer> Players { get; }
        void AddPlayer(IPlayer player);
    }

}
