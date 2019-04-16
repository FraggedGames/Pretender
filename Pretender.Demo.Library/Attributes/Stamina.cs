using System;
using Pretender.Entities.Attributes;

namespace Pretender.Demo.Library.Attributes
{
    public class Stamina : EntityAttribute
    {
        public Stamina(Int32 value)
        {
            SetBase(value);
        }
    }
}
