using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryptor
{
    public class Encryptor
    {
        public string XorEncryption(string target)
        {
            var sb = new StringBuilder();
            var length = Encoding.GetEncoding(932).GetByteCount(target);

            var decryptKey = GenerateDecryptKey(length);
            var targetArray = Encoding.GetEncoding(932).GetBytes(target);
            var decryptKeyArray = Encoding.GetEncoding(932).GetBytes(decryptKey);

            for (int i = 0; i < length; i++)
            {
                var xor = targetArray[i] ^ decryptKeyArray[i];
                var hexString = Convert.ToString(xor, 16);
                sb.Append(hexString.PadLeft(2, '0'));
            }

            return sb.ToString();
        }

        public string XorDecryption(string target)
        {
            var targetArrary = StringToBytes(target);
            var length = targetArrary.Length;

            var decryptKey = GenerateDecryptKey(length);
            var decryptKeyArray = Encoding.GetEncoding(932).GetBytes(decryptKey);

            var decryptionArray = new byte[length];
            for (int i = 0; i < length; i++)
            {
                var xor = (byte)(targetArrary[i] ^ decryptKeyArray[i]);
                decryptionArray[i] = xor;
            }
            
            return Encoding.GetEncoding(932).GetString(decryptionArray);
        }

        public byte[] StringToBytes(string target)
        {
            var list = new List<byte>();
            for (int i = 0; i < (target.Length / 2); i++)
            {
                var hexString = target.Substring(i * 2, 2);
                list.Add(Convert.ToByte(hexString, 16));
            }

            return list.ToArray();
        }

        public string GenerateDecryptKey(int length)
        {
            var sb = new StringBuilder();
            int j = 0;

            var decryptKey = "TEST";

            for (int i = 0; i < length; i++)
            {
                if (j > decryptKey.Length - 1)
                {
                    j = 0;
                }
                sb.Append(decryptKey.Substring(j, 1));
                j++;
            }

            return sb.ToString();
        }
    }
}
