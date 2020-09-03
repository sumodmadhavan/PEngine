using System;
using System.Collections.Generic;
using System.Text;
namespace PEngine
{
    public struct Sku
    {
        private readonly char _currentValue;

        public Sku(char value)
        {
            _currentValue = value;
        }

        public Sku(Sku sku)
        {
            _currentValue = sku._currentValue;
        }

        public static implicit operator Sku(char value)
        {
            return new Sku(value);
        }

        public static explicit operator char(Sku value)
        {
            return value._currentValue;
        }

        public static bool operator ==(Sku sku1, Sku sku2)
        {
            return sku1.Equals(sku2);
        }

        public static bool operator !=(Sku sku1, Sku sku2)
        {
            return !sku1.Equals(sku2);
        }

        public override bool Equals(object equalityObject)
        {
            if (equalityObject == null) { return false; }

            Sku sku;
            try
            {
                sku = (Sku)equalityObject;
            }
            catch
            {
                return false;
            }

            return _currentValue == (char)sku;
        }

        public override int GetHashCode()
        {
            return _currentValue.GetHashCode();
        }
    }
}
