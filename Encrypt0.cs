using System;
using System.Security.Cryptography;
using System.Text;
using Library.Utils;

namespace Library
{
    public static class Encrypt0
    {
        private static byte[] secretkey = Encoding.UTF8.GetBytes("SecretKey");
        public static string Decrypt(byte[] toEncryptArray, byte[] key)
        {
            string results = "";
            try
            {
                AesManaged aes = new AesManaged();
                
                aes.Key = key;
                
                aes.Mode = CipherMode.ECB;
                
                aes.Padding = PaddingMode.PKCS7;
                ICryptoTransform cTransform = aes.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
           
                aes.Clear();
                
                results = Encoding.UTF8.GetString(resultArray);
            }
            catch
            {
                throw new Exception("Failed : key invalid");
            }
            return results;
        }
        public static string Decrypt(byte[] toEncryptArray)
        {
            return Decrypt(toEncryptArray, secretkey);
        }
        public static string Decrypt(string str)
        {
            return Decrypt(StringUtils.hexToBytes(str), secretkey);
        }
        public static string Decrypt(string str,string key)
        {
            return Decrypt(StringUtils.hexToBytes(str), Encoding.UTF8.GetBytes(key));
        }
        public static string Decrypt(string str, byte[] key)
        {
            return Decrypt(StringUtils.hexToBytes(str), key);
        }

        public static byte[] Encrypt(byte[] toEncrypt, byte[] key)
        {
            byte[] results = new byte[0];
            try
            {
                AesManaged tdes = new AesManaged();

                tdes.Key = key;

                tdes.Mode = CipherMode.ECB;

                tdes.Padding = PaddingMode.PKCS7;
                ICryptoTransform cTransform = tdes.CreateEncryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncrypt, 0, toEncrypt.Length);
               
                tdes.Clear();

                results = resultArray;
            }
            catch
            {
                throw new Exception("Failed : key invalid");
            }
            return results;

        }

        public static byte[] Encrypt(string msg)
        {
            return Encrypt(StringUtils.GetBytes(msg), secretkey);
        }

        public static byte[] Encrypt(string msg,byte[] key)
        {
            return Encrypt(StringUtils.GetBytes(msg), key);
        }
        public static string EncryptToHex(string msg)
        {
            return StringUtils.BytesArrayToHexString(StringUtils.ConvertArrayBytesToSbyte(Encrypt(StringUtils.GetBytes(msg), secretkey)));
        }

    }
}
