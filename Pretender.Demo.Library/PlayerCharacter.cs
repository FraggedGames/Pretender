﻿/*******************************************************************************
 * Copyright © 2019 Doug Wilson https://dkw.io
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a 
 * copy of this software and associated documentation files (the "Software"),
 * to deal in the Software without restriction, including without limitation
 * the rights to use, copy, modify, merge, publish, distribute, sublicense,
 * and/or sell copies of the Software, and to permit persons to whom the 
 * Software is furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING 
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
 * DEALINGS IN THE SOFTWARE.
 *
 ************************************************************************/

using System;
using Pretender.Demo.Library.Attributes;
using Pretender.Entities.Players;

namespace Pretender.Demo.Library
{
    public class PlayerCharacter : Player, IPlayerCharacter
    {
        public UInt32 Agility => Attributes.GetValue<Agility, UInt32>(a => a.Current);
        public UInt32 Armor => Attributes.GetValue<Armor, UInt32>(a => a.Current);
        public UInt32 Health => Attributes.GetValue<Health, UInt32>(a => a.Current);
        public UInt32 Intellect => Attributes.GetValue<Intellect, UInt32>(a => a.Current);
        public UInt32 Mana => Attributes.GetValue<Mana, UInt32>(a => a.Current);
        public UInt32 Stamina => Attributes.GetValue<Stamina, UInt32>(a => a.Current);
        public UInt32 Strength => Attributes.GetValue<Strength, UInt32>(a => a.Current);
    }
}
