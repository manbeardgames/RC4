using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text;

namespace RC4Cryptography.Test
{
    [TestClass]
    public class EncryptionTests
    {
        /// <summary>
        ///     This is a known correct cipher which is the result of encrypting
        ///     the string "Plaintext" using the string "Key" as the encryption
        ///     key
        /// </summary>
        /// <remarks>
        ///     https://en.wikipedia.org/wiki/RC4#Test_vectors
        /// </remarks>
        private static readonly byte[] CIPHER_PLAINTEXT = new byte[]
        {
            0xBB, 0xF3, 0x16, 0xE8, 0xD9, 0x40, 0xAF, 0x0A, 0xD3
        };

        /// <summary>
        ///     This is a known correct cipher which is the result of encrypting
        ///     the string "pedia" using the string "Wiki" as the encryption
        ///     key
        /// </summary>
        /// <remarks>
        ///     https://en.wikipedia.org/wiki/RC4#Test_vectors
        /// </remarks>
        private static readonly byte[] CIPHER_PEDIA = new byte[]
        {
            0x10, 0x21, 0xBF, 0x04, 0x20
        };

        /// <summary>
        ///     This is a known correct cipher which is the result of encrypting
        ///     the string "Attack at dawn" using the string "Secret" as the encryption
        ///     key
        /// </summary>
        /// <remarks>
        ///     https://en.wikipedia.org/wiki/RC4#Test_vectors
        /// </remarks>
        private static readonly byte[] CIPHER_ATTACKATDAWN = new byte[]
        {
            0x45, 0xA0, 0x1F, 0x64, 0x5F, 0xC3, 0x5B, 0x38, 0x35, 0x52,
            0x54, 0x4B, 0x9B, 0xF5
        };

        /// <summary>
        ///     Tests validates encrypting the string "Plaintext" using the key "Key"
        /// </summary>
        /// <remarks>
        ///     Values for test, including text, key, and cipher are derived from known
        ///     test vectors as found on the RC4 wikipedia page
        ///     https://en.wikipedia.org/wiki/RC4#Test_vectors
        /// </remarks>
        [TestMethod]
        public void Encrypt_Plaintext()
        {
            //  Get the bytes of the string "Plaintext". This will be the data
            //  that we are encoding.
            byte[] data = Encoding.ASCII.GetBytes("Plaintext");

            //  Get the bytes of the string "Key". This will be the encryption key
            //  that we use.
            byte[] key = Encoding.ASCII.GetBytes("Key");

            //  Encrypt the data using the key
            byte[] encrypted = RC4.Apply(data, key);

            //  Validate that the encrypted data is the same as the cipher data
            Assert.IsTrue(encrypted.SequenceEqual(CIPHER_PLAINTEXT));
        }

        /// <summary>
        ///     Tests validates decrypting the known encrpted data using the key value "Key"
        ///     to derive the string "Plaintext"
        /// </summary>
        /// <remarks>
        ///     Values for test, including text, key, and cipher are derived from known
        ///     test vectors as found on the RC4 wikipedia page
        ///     https://en.wikipedia.org/wiki/RC4#Test_vectors
        /// </remarks>
        [TestMethod]
        public void Decrypt_Plaintext()
        {
            //  Get the bytes of the string "Key". This will be the decryption key
            //  that we use.
            byte[] key = Encoding.ASCII.GetBytes("Key");

            //  Decrypt the cipher using the key
            byte[] decrypted = RC4.Apply(CIPHER_PLAINTEXT, key);

            //  Decode the decrypted array
            string decoded = Encoding.ASCII.GetString(decrypted);

            //  Validate the decoded string
            Assert.AreEqual(decoded, "Plaintext");
        }

        /// <summary>
        ///     Tests validates encrypting the string "pedia" using the key "Wiki"
        /// </summary>
        /// <remarks>
        ///     Values for test, including text, key, and cipher are derived from known
        ///     test vectors as found on the RC4 wikipedia page
        ///     https://en.wikipedia.org/wiki/RC4#Test_vectors
        /// </remarks>
        [TestMethod]
        public void Encrypt_Pedia()
        {
            //  Get the bytes of the string "pedia". This will be the data
            //  that we are encoding.
            byte[] data = Encoding.ASCII.GetBytes("pedia");

            //  Get the bytes of the string "Wiki". This will be the encryption key
            //  that we use.
            byte[] key = Encoding.ASCII.GetBytes("Wiki");

            //  Encrypt the data using the key
            byte[] encrypted = RC4.Apply(data, key);

            //  Validate that the encrypted data is the same as the cipher data
            Assert.IsTrue(encrypted.SequenceEqual(CIPHER_PEDIA));
        }

        /// <summary>
        ///     Tests validates decrypting the known encrpted data using the key value "Wiki"
        ///     to derive the string "pedia"
        /// </summary>
        /// <remarks>
        ///     Values for test, including text, key, and cipher are derived from known
        ///     test vectors as found on the RC4 wikipedia page
        ///     https://en.wikipedia.org/wiki/RC4#Test_vectors
        /// </remarks>
        [TestMethod]
        public void Decrypt_Pedia()
        {
            //  Get the bytes of the string "Key". This will be the decryption key
            //  that we use.
            byte[] key = Encoding.ASCII.GetBytes("Wiki");

            //  Decrypt the cipher using the key
            byte[] decrypted = RC4.Apply(CIPHER_PEDIA, key);

            //  Decode the decrypted array
            string decoded = Encoding.ASCII.GetString(decrypted);

            //  Validate the decoded string
            Assert.AreEqual(decoded, "pedia");
        }

        /// <summary>
        ///     Tests validates encrypting the string "Attack at dawn" using the key "Secret"
        /// </summary>
        /// <remarks>
        ///     Values for test, including text, key, and cipher are derived from known
        ///     test vectors as found on the RC4 wikipedia page
        ///     https://en.wikipedia.org/wiki/RC4#Test_vectors
        /// </remarks>
        [TestMethod]
        public void Encrypt_AttactAtDawn()
        {
            //  Get the bytes of the string "Attack at dawn". This will be the data
            //  that we are encoding.
            byte[] data = Encoding.ASCII.GetBytes("Attack at dawn");

            //  Get the bytes of the string "Secret". This will be the encryption key
            //  that we use.
            byte[] key = Encoding.ASCII.GetBytes("Secret");

            //  Encrypt the data using the key
            byte[] encrypted = RC4.Apply(data, key);

            //  Validate that the encrypted data is the same as the cipher data
            Assert.IsTrue(encrypted.SequenceEqual(CIPHER_ATTACKATDAWN));
        }

        /// <summary>
        ///     Tests validates decrypting the known encrpted data using the key value "Secret"
        ///     to derive the string "Attack at dawn"
        /// </summary>
        /// <remarks>
        ///     Values for test, including text, key, and cipher are derived from known
        ///     test vectors as found on the RC4 wikipedia page
        ///     https://en.wikipedia.org/wiki/RC4#Test_vectors
        /// </remarks>
        [TestMethod]
        public void Decrypt_AttackAtDawn()
        {
            //  Get the bytes of the string "Key". This will be the decryption key
            //  that we use.
            byte[] key = Encoding.ASCII.GetBytes("Secret");

            //  Decrypt the cipher using the key
            byte[] decrypted = RC4.Apply(CIPHER_ATTACKATDAWN, key);

            //  Decode the decrypted array
            string decoded = Encoding.ASCII.GetString(decrypted);

            //  Validate the decoded string
            Assert.AreEqual(decoded, "Attack at dawn");
        }


    }
}
