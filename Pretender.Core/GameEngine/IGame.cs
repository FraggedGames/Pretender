using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pretender.GameEngine
{
    public interface IGame : IDisposable
    {
        ICollection<IPlayer> Players { get; }
        Task<Int32> AddPlayerAsync(IPlayer player);
    }
}
