using System;
using Pretender.Entities.Attributes;

namespace Pretender.Demo.Library.Attributes
{
    public class Agility : EntityAttribute
    {
        public Agility(Int32 value)
        {
            SetBase(value);
        }
    }
}
