using Pretender.Entities.Characters;
using System;
using System.Collections.Generic;

namespace Pretender.World
{
    public class World : IWorld
    {
        private IDictionary<Int32, ICharacter> _players = new Dictionary<Int32, ICharacter>();

        public ICollection<ICharacter> Characters => _players.Values;

        public void AddCharacter(ICharacter character)
        {
            if (character == null)
            {
                throw new ArgumentNullException(nameof(character));
            }

            _players.Add(character.ID, character);
        }
    }
}
