namespace PEngine
{
    /// <summary>
    /// Define the SKU. 
    /// </summary>
    public struct Sku
    {
        private readonly char _currentValue;

        public Sku(char value)
        {
            _currentValue = value;
        }
        //
        public Sku(Sku sku)
        {
            _currentValue = sku._currentValue;
        }
        //
        public static implicit operator Sku(char value)
        {
            return new Sku(value);
        }
        //
        public static explicit operator char(Sku value)
        {
            return value._currentValue;
        }
        //
        public static bool operator ==(Sku valueX, Sku valueY)
        {
            return valueX.Equals(valueY);
        }
        //
        public static bool operator !=(Sku valueX, Sku valueY)
        {
            return !valueX.Equals(valueY);
        }
        //
        public override bool Equals(object equalityObject)
        {
            //base case.
            if (equalityObject == null)return false;
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
        /// <summary>
        /// get the hashcode.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return _currentValue.GetHashCode();
        }
    }
}
