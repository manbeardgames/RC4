using System;
using System.Text;
using RC4Cryptography;

namespace RC4Cryptography.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Let's say we had the phrase "The one ring"
            string phrase = "The one ring";

            //  And we wanted to encrypt it, using the phrase "Keep it secret. Keep it safe."
            string key_phrase = "Keep it secret. Keep it safe.";

            //  First, let's get the byte data of the phrase
            byte[] data = Encoding.UTF8.GetBytes(phrase);

            //  Next, let's get the byte data of the key phrase
            byte[] key = Encoding.UTF8.GetBytes(key_phrase);

            //  We can encrypt it like so
            byte[] encrypted_data = RC4.Apply(data, key);

            //  Now, RC4 is a symetric algorithm, meaning, if we encrypt something
            //  with a given key, we can run the encrypted data through the same
            //  method with the same key to decrypt it.
            //  Let's do that
            byte[] decrypted_data = RC4.Apply(encrypted_data, key);

            //  Decode the decrypted data
            string decrypted_phrase = Encoding.UTF8.GetString(decrypted_data);


            //  Let's output the data created above to the console so we can see the results
            Console.WriteLine("Phrase:\t\t\t{0}", phrase);
            Console.WriteLine("Phrase Bytes:\t\t{0}", BitConverter.ToString(data));
            Console.WriteLine("Key Phrase:\t\t{0}", key_phrase);
            Console.WriteLine("Key Bytes:\t\t{0}", BitConverter.ToString(key));
            Console.WriteLine("Encryption Result:\t{0}", BitConverter.ToString(encrypted_data));
            Console.WriteLine("Decryption Result:\t{0}", BitConverter.ToString(decrypted_data));
            Console.WriteLine("Decrypted Phrase:\t{0}", decrypted_phrase);

            Console.WriteLine(Environment.NewLine + "Press enter to close");
            Console.ReadLine();

        }
    }
}
