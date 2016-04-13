using System.Linq;

namespace FactorioModMan
{
    public static class Extensions
    {
        /// <summary>
        ///     Takes out bytes from the left of array and returns them.
        /// </summary>
        /// <param name="allBytes">input byte array</param>
        /// <param name="wantedByteCount">count of bytes wanted</param>
        /// <param name="leftBytes">left-over bytes</param>
        /// <returns>The taken out bytes</returns>
        public static byte[] Takeout(this byte[] allBytes, int wantedByteCount, out byte[] leftBytes)
        {
            byte[] wanted = allBytes.Take(wantedByteCount).ToArray();
            leftBytes = allBytes.Skip(wantedByteCount).ToArray();
            return wanted;
        }

        /// <summary>
        ///     Takes out bytes from the left of array and returns them.
        ///     ATTENTION: this overload drops the left-overs of the input
        /// </summary>
        /// <param name="allBytes">input byte array</param>
        /// <param name="wantedByteCount">count of bytes wanted</param>
        /// <returns>The taken out bytes</returns>
        public static byte[] Takeout(this byte[] allBytes, int wantedByteCount)
        {
            byte[] justDrop;
            return Takeout(allBytes, wantedByteCount, out justDrop);
        }
    }
}