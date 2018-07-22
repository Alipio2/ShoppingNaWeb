using System;

namespace ShoppingNaWeb.Shared.Validation
{
    public static class AssertionConcern
    {
        public static void AssertArgumentNotEmpty(string stringValue, string message)
        {
            if (stringValue == null || stringValue.Trim().Length == 0)
            {
                throw new InvalidOperationException(message);
            }
        }
        
        public static void AssertArgumentLength(string stringValue, int minimum, int maximum, string message)
        {
            if (String.IsNullOrEmpty(stringValue))
                stringValue = String.Empty;

            int length = stringValue.Trim().Length;
            if (length < minimum || length > maximum)
            {
                throw new InvalidOperationException(message);
            }
        }

        public static void AssertArgumentMaxLength(string stringValue,  int maximum, string message)
        {
            if (String.IsNullOrEmpty(stringValue))
                stringValue = String.Empty;

            int length = stringValue.Trim().Length;
            if ( length > maximum)
            {
                throw new InvalidOperationException(message);
            }
        }

        public static void AssertArgumentMinLength(string stringValue, int minimum, string message)
        {
            if (String.IsNullOrEmpty(stringValue))
                stringValue = String.Empty;

            int length = stringValue.Trim().Length;
            if (length < minimum)
            {
                throw new InvalidOperationException(message);
            }
        }
        public static void AssertArgumentRange(int value, int minimum, int maximum, string message)
        {
            if (value < minimum || value > maximum)
            {
                throw new InvalidOperationException(message);
            }
        }

        public static void AssertArgumentIsBiggerThan(int value, int minimum, string message)
        {
            if (value < minimum )
            {
                throw new InvalidOperationException(message);
            }
        }
        public static void AssertArgumentIsBiggerThan(decimal value, int minimum, string message)
        {
            if (value < minimum)
            {
                throw new InvalidOperationException(message);
            }
        }

    }
}
