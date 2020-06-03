using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class PasswordManager
    {

        static byte[] key;
        static byte[] IV;

        public string Encrypt(string value)
        {
            // Create a new instance of the RC2CryptoServiceProvider class
            // and automatically generate a Key and IV.
            RC2CryptoServiceProvider rc2CSP = new RC2CryptoServiceProvider();

            //MessageBox.Show("Effective key size is {0} bits." + rc2CSP.EffectiveKeySize);

            GenerateKays();
            // Get the key and IV.
            rc2CSP.Key = key;
            rc2CSP.IV = IV;

            // Get an encryptor.
            ICryptoTransform encryptor = rc2CSP.CreateEncryptor(key, IV);

            // Encrypt the data as an array of encrypted bytes in memory.
            MemoryStream msEncrypt = new MemoryStream();
            CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);

            // Convert the data to a byte array.
            string original = value;
            byte[] toEncrypt = Encoding.ASCII.GetBytes(original);

            // Write all data to the crypto stream and flush it.
            csEncrypt.Write(toEncrypt, 0, toEncrypt.Length);
            csEncrypt.FlushFinalBlock();

            // Get the encrypted array of bytes.
            byte[] encrypted = msEncrypt.ToArray();

            return Convert.ToBase64String(encrypted);
            // Display the original data and the decrypted data.

        }
        
        private static void GenerateKays()
        {
            key = new byte[] { 42, 0, 173, 131, 7, 39, 96, 74, 141, 13, 153, 252, 182, 45, 19, 224 };
            IV = new byte[] { 132, 4, 246, 11, 61, 160, 16, 202 };

        }
        public string Decrypt(string value)
        {
            // Create a new instance of the RC2CryptoServiceProvider class
            // and automatically generate a Key and IV.
            RC2CryptoServiceProvider rc2CSP = new RC2CryptoServiceProvider();

            GenerateKays();
            // Get the key and IV.
            rc2CSP.Key = key;
            rc2CSP.IV = IV;

            byte[] toDecrypt = null;

            // Convert the data to a byte array.
            try
            {
                toDecrypt = Convert.FromBase64String(value);
            }
            catch (Exception)
            {
                return value;
            }

            //Get a decryptor that uses the same key and IV as the encryptor.
            ICryptoTransform decryptor = rc2CSP.CreateDecryptor(key, IV);

            // Now decrypt the previously encrypted message using the decryptor
            // obtained in the above step.
            MemoryStream msDecrypt = new MemoryStream(toDecrypt);
            CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);

            // Read the decrypted bytes from the decrypting stream
            // and place them in a StringBuilder class.

            StringBuilder roundtrip = new StringBuilder();

            int b = 0;

            do
            {
                b = csDecrypt.ReadByte();

                if (b != -1)
                {
                    roundtrip.Append((char)b);
                }

            } while (b != -1);


            // Display the original data and the decrypted data.
            return roundtrip.ToString();

        }
      


        public String GeneratePassword()
        {


            int PasswordLength = 4;// 8;

            string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*{}[],.<>;:‘“?/|`~()_-+=";
            var randNum = new Random();
            char[] chars = new char[PasswordLength];

            for (int i = 0; i < PasswordLength; i++)
            {
                chars[i] = allowedChars[randNum.Next(0, allowedChars.Length)];
            }
            //ComparePassword(new string(chars));
            return new string(chars);
        }

        //public void ComparePassword(string tempPassword)
        //{
            
        //    string EncryptPasswordGenarated = objEncrypt(tempPassword);
        //    DBHelper objDBHelper = new DBHelper();
        //    string fetchQuery = "Select PasswordResetDate from PasswordHistory Where LastPassword='" + EncryptPasswordGenarated + "'";
        //    DataSet dsUsers = new DataSet();
        //    dsUsers = objDBHelper.Fetch(fetchQuery);
        //    if (dsUsers.Tables["Table"].Rows.Count > 0)
        //    {
        //        GeneratePassword();
        //    }
        //}



    }
}
