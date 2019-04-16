using System;
using Pretender.Entities.Players;

namespace Pretender.Demo.Library
{
    public interface IPlayerCharacter : IPlayer
    {
        Int32 Agility { get; }
        Int32 Armor { get; }
        Int32 Health { get; }
        Int32 Intellect { get; }
        Int32 Mana { get; }
        Int32 Stamina { get; }
        Int32 Strength { get; }
    }
}
