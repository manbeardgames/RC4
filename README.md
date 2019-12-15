[![AppVeyor](https://img.shields.io/appveyor/ci/manbeardgames/RC4)](https://ci.appveyor.com/project/manbeardgames/rc4)
[![AppVeyor tests](https://img.shields.io/appveyor/tests/manbeardgames/RC4)](https://ci.appveyor.com/project/manbeardgames/rc4)

# RC4
An implementation of the RC4 algorithm in C#.  More information on RC4 can be found on Wikipedia at https://en.wikipedia.org/wiki/RC4

# Disclaimer
This project was created as an experiment to see if I could implement the RC4 algorithm in C# using the documented information found on Wikipedia.  While the repository includes an MS Test Project to test the encryption and decryption of the known test vectors found in the Wikipedia article, no claims or guarantees are made on the accuracy of this implementation.  Use at your own risk.

# Usage
Download the RC4Cryptography.dll found on the releases page of this repo and add it as a reference to your project.  

Add the RC4Cryptography namespace
```cs
using RC4Cryptography
```

The following is an example of usage as found in the RC4Cryptography.Example project in this repo
```cs
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

//  Now, RC4 is a symmetric algorithm, meaning, if we encrypt something
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
```

This would give the following output in the console
```
Phrase:                 The one ring
Phrase Bytes:           54-68-65-20-6F-6E-65-20-72-69-6E-67
Key Phrase:             Keep it secret. Keep it safe.
Key Bytes:              4B-65-65-70-20-69-74-20-73-65-63-72-65-74-2E-20-4B-65-65-70-20-69-74-20-73-61-66-65-2E
Encryption Result:      EF-24-46-59-34-A1-54-AC-E0-72-07-A8
Decryption Result:      54-68-65-20-6F-6E-65-20-72-69-6E-67
Decrypted Phrase:       The one ring
```




