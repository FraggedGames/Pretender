﻿using System;
using Pretender.Entities.Attributes;

namespace Pretender.Demo.Library.Attributes
{
    public class Mana : EntityAttribute
    {
        public Mana(Int32 value)
        {
            SetBase(value);
        }
    }
}
