﻿using System;
using System.Runtime.CompilerServices;

namespace PrtSharp.Values
{
    [Serializable]
    public readonly struct PrtBool : IPrtValue
    {
        private readonly bool value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private PrtBool(bool value)
        {
            this.value = value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IPrtValue Clone()
        {
            return this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool(in PrtBool val)
        {
            return val.value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator PrtBool(bool val)
        {
            return new PrtBool(val);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator true(in PrtBool pValue)
        {
            return pValue;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator false(in PrtBool pValue)
        {
            return !pValue;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PrtBool operator !(in PrtBool pValue)
        {
            return new PrtBool(!pValue.value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PrtBool operator &(in PrtBool pValue1, in PrtBool pValue2)
        {
            return new PrtBool(pValue1.value && pValue2.value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PrtBool operator |(in PrtBool pValue1, in PrtBool pValue2)
        {
            return new PrtBool(pValue1.value || pValue2.value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(IPrtValue obj)
        {
            return obj is PrtBool other && value == other.value;
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
    }
}