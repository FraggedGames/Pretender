using System;
using Pretender.Demo.Library.Attributes;
using Pretender.Entities.Players;

namespace Pretender.Demo.Library
{
    public class PlayerCharacter : Player, IPlayerCharacter
    {
        public Int32 Agility => Attributes.GetValue<Agility, Int32>(a => a.Current);
        public Int32 Armor => Attributes.GetValue<Armor, Int32>(a => a.Current);
        public Int32 Health => Attributes.GetValue<Health, Int32>(a => a.Current);
        public Int32 Intellect => Attributes.GetValue<Intellect, Int32>(a => a.Current);
        public Int32 Mana => Attributes.GetValue<Mana, Int32>(a => a.Current);
        public Int32 Stamina => Attributes.GetValue<Stamina, Int32>(a => a.Current);
        public Int32 Strength => Attributes.GetValue<Strength, Int32>(a => a.Current);
    }
}
