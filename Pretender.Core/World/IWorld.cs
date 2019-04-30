using Pretender.Entities.Characters;
using System.Collections.Generic;

namespace Pretender.World
{
    public interface IWorld
    {
        ICollection<ICharacter> Characters { get; }

        void AddCharacter(ICharacter character);
    }
}
