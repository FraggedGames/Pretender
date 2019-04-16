using System;
using Pretender.Entities.Attributes;

namespace Pretender.Demo.Library.Attributes
{
    public class Intellect : EntityAttribute
    {
        public Intellect(Int32 value)
        {
            SetBase(value);
        }
    }
}
