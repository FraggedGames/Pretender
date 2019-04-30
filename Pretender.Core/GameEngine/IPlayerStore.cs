using System;
using System.Threading.Tasks;

namespace Pretender.GameEngine
{
	public interface IPlayerStore
	{
		Task<IPlayer> LoadPlayerAsync(Int32 playerID);
	}
}
