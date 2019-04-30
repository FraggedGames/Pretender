using Pretender.Entities.Characters;
using System;

namespace Pretender.GameEngine
{
	public interface IPlayer : IDisposable
	{
		ICharacter Character { get; }
		Int32 ID { get; }
	}

}
