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
    public static class SystemDateTime
    {
        private static Func<DateTime> _getTime = GetUtc;

        [DebuggerNonUserCode]
        public static DateTime UtcNow => _getTime();

        [DebuggerNonUserCode]
        public static void DateIs(DateTime time) => _getTime = () => new DateTime(time.Ticks, DateTimeKind.Unspecified);

        [DebuggerNonUserCode]
        public static void DateIs(Int32 year, Int32 month = 1, Int32 day = 1) => DateIs(new DateTime(year, month, day));

        [DebuggerNonUserCode]
        public static void Reset() => _getTime = GetUtc;

        private static DateTime GetUtc() => new DateTime(DateTime.UtcNow.Ticks, DateTimeKind.Unspecified);

        public static Int64 ToSerial(this in DateTime d) => (d.Year * 10000000000L) + (d.Month * 100000000L) + (d.Day * 1000000L) + (d.Hour * 10000L) + (d.Minute * 100L) + d.Second;
    }
}
