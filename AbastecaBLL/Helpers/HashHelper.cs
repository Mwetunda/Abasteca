using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AbastecaBLL.Helpers
{
    public static class HashHelper
    {
        public static string ToSha512Hash(this string value)
        {
            using SHA512 sha256Hash = SHA512.Create();
            // ComputeHash - returns byte array  
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(value));

            // Convert byte array to a string   
            StringBuilder builder = new StringBuilder();

            foreach (var t in bytes)
            {
                builder.Append(t.ToString("x2"));
            }

            return builder.ToString();
        }
    }
}
