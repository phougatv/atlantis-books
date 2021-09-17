namespace Atlantis.WebApi.Shared.Extensions
{
    using System;

    public static class CommonExtension
    {
        #region Guid Extension Methods
        public static bool IsEmpty(this Guid guid) => guid == Guid.Empty;
        #endregion Guid Extension Methods

        #region Int Extension Methods
        public static bool IsNegative(this int int32) => int32 < 0;
        public static bool IsPositive(this int int32) => int32 > 0;
        public static bool IsZero(this int int32) => int32 == 0;
        #endregion Int Extension Methods

        #region String Extension Methods
        public static bool IsNullOrEmpty(this string str) => string.IsNullOrEmpty(str);
        #endregion String Extension Methods
    }
}
