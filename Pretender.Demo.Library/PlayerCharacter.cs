/*******************************************************************************
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
        public Int32 Agility => Attributes.GetValue<Agility, Int32>(a => a.Current);
        public Int32 Armor => Attributes.GetValue<Armor, Int32>(a => a.Current);
        public Int32 Health => Attributes.GetValue<Health, Int32>(a => a.Current);
        public Int32 Intellect => Attributes.GetValue<Intellect, Int32>(a => a.Current);
        public Int32 Mana => Attributes.GetValue<Mana, Int32>(a => a.Current);
        public Int32 Stamina => Attributes.GetValue<Stamina, Int32>(a => a.Current);
        public Int32 Strength => Attributes.GetValue<Strength, Int32>(a => a.Current);
    }
}
