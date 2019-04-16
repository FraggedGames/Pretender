/*************************************************************************
 * Copyright © 2019 Fragged Games, Doug Wilson https://fragged.com
 *
 * This file is part of Pretender
 *
 * Pretender is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Lesser General Public License as
 * published by the Free Software Foundation, either version 3 of the
 * License, or (at your option) any later version.
 *
 * Pretender is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public
 * License along with Pretender.  If not, please visit
 * https://www.gnu.org/licenses/ to obtain a copy.
 *
 ************************************************************************/

namespace Pretender
{
    using System;
    using System.Diagnostics;

    [DebuggerNonUserCode]
    public static class SystemGuid
    {
        private static Func<Guid> _getGuid = GetGuidInternal;

        [DebuggerNonUserCode]
        public static void GuidIs(Guid guid) => _getGuid = () => guid;

        [DebuggerNonUserCode]
        public static void GuidIs(String guid)
        {
            var g = Guid.Parse(guid);
            _getGuid = () => g;
        }

        [DebuggerNonUserCode]
        public static Guid NewGuid() => _getGuid?.Invoke() ?? GetGuidInternal();

        [DebuggerNonUserCode]
        public static void Reset() => _getGuid = GetGuidInternal;

        private static Guid GetGuidInternal() => CombGuid.NewGuid();
    }
}
