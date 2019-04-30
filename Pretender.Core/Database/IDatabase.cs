using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pretender.Database.DTO;
using Pretender.Entities.Characters;
using Pretender.GameEngine;

namespace Pretender.Database
{
    public interface IDatabase
    {
        Task<IEnumerable<CharacterDTO>> ListCharactersForPlayerAsync(Int32 playerID);
        Task<ICharacter> LoadCharacterAsync(Int32 characterID);
        Task<Int32> BeginSessionAsync(IPlayer player);
    }
}
