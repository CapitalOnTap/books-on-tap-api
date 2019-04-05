using System;
using System.Security.Cryptography;

namespace Helpers
{
    public class IsbnGenerator
    {
        public static string Get13Digits()
        {
            var bytes = new byte[4];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(bytes);
            uint random = BitConverter.ToUInt32(bytes, 0) % 100000000;
            return String.Format("{0:D13}", random);
        }

    }
}