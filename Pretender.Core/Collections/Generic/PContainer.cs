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
using System.Collections;
using System.Collections.Generic;

namespace Pretender.Collections.Generic
{
    public interface ITypedCollection<T> : ICollection<T>
         where T : class
    {
        TValue GetValue<TKey, TValue>(Func<T, TValue> func, TValue defaultValue = default);
    }

    public class TypedCollection<T> : ITypedCollection<T>
         where T : class
    {
        private IDictionary<Type, T> _dictionary = new Dictionary<Type, T>();

        public Int32 Count => _dictionary.Count;
        public Boolean IsReadOnly => _dictionary.IsReadOnly;

        public TValue GetValue<TKey, TValue>(Func<T, TValue> func, TValue defaultValue = default)
        {
            return _dictionary.ContainsKey(typeof(TKey)) ? func(_dictionary[typeof(TKey)]) : default;
        }

        public void Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            _dictionary[item.GetType()] = item;
        }

        public void Clear() => _dictionary.Clear();

        public Boolean Contains(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            return _dictionary.ContainsKey(item.GetType());
        }

        public void CopyTo(T[] array, Int32 arrayIndex)
        {
            _dictionary.Values.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator() => _dictionary.Values.GetEnumerator();

        public Boolean Remove(T item)
        {
            if (item == null)
            {
                return false;
            }

            return _dictionary.Remove(item.GetType());
        }

        IEnumerator IEnumerable.GetEnumerator() => _dictionary.Values.GetEnumerator();
    }
}
