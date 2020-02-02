﻿using System;
using Omu.ValueInjecter;

namespace Agl.Puzzle.Models
{
    public static class ValueInjecterExtensions
    {
        public static T BasicConvertTo<T>(this object obj) where T : new()
        {
            if (obj == null)
                return default(T);
            var target = Activator.CreateInstance(typeof(T));
            target.InjectFrom(obj);
            return (T)target;
        }
    }
}
