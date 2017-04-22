using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryptor
{
    class Program
    {
        static void Main(string[] args)
        {
            var encryptor = new Encryptor();

            var target = "あいうえお12345+-*/@.abcdef漢字カタカナ";
            Console.WriteLine($"Original:\t {target}");
            var encryptedString = encryptor.XorEncryption(target);
            Console.WriteLine($"Encrypted:\t {encryptedString}");

            var decryptedString = encryptor.XorDecryption(encryptedString);
            Console.WriteLine($"Decrypted:\t {decryptedString}");


            Console.ReadKey();
        }
    }
}
