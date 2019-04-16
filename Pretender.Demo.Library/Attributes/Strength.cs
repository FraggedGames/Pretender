using System;
using Pretender.Entities.Attributes;

namespace Pretender.Demo.Library.Attributes
{
    public class Strength : EntityAttribute
    {
        public Strength(Int32 value)
        {
            SetBase(value);
        }
    }
}
