using Pretender.Entities.Characters;
using System;

namespace Pretender.GameEngine
{
	public class Player : IPlayer
	{
		public ICharacter Character => throw new NotImplementedException();

		public Int32 ID { get; set; }

		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}

}
