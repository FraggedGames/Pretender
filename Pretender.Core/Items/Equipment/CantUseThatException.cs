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

using System;
using System.Runtime.Serialization;

namespace Pretender.Items.Equipment
{
    public class CantUseThatException : Exception
    {
        public CantUseThatException()
        {
        }

        public CantUseThatException(String message) : base(message)
        {
        }

        public CantUseThatException(String message, Exception innerException) : base(message, innerException)
        {
        }

        protected CantUseThatException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
