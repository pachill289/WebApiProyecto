using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CapaTools {
    public class Encriptacion {

        protected Excepciones exs;
        public Encriptacion ()
        {
            exs = new Excepciones();
        }
        // Función para encriptar una cadena utilizando AES
        public string EncryptString(string plainText, string key) {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create()) {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream()) {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write)) {
                        using (StreamWriter streamWriter = new StreamWriter(cryptoStream)) {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }


        // Crear una instancia de RSACryptoServiceProvider
        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
        public byte[] Encriptar (string clave) {
            // Obtener la clave pública y privada
            string publicKey = rsa.ToXmlString(false);
            string privateKey = rsa.ToXmlString(true);

            // Cifrar un mensaje con la clave pública
            byte[] claveEncriptada = Encoding.UTF8.GetBytes(clave);
            byte[] encriptacionRSA = rsa.Encrypt(claveEncriptada, false);
            return encriptacionRSA;
        }
        public void CompararClaves (string clave, string key,string userPassword) {
            // Almacenar la contraseña encriptada en la base de datos
            string encryptedPassword = EncryptString(clave, key);
            string encryptedUserPassword = EncryptString(userPassword, key);

            // Comparar las contraseñas encriptadas
            if (encryptedPassword == encryptedUserPassword) {
                //Mandar mensaje de exito
            } else {
                //exs.Exception(new Exception());
            }
        }
        public void DesEncriptar(byte[] encryptedMessage) {
            // Obtener la clave pública y privada
            string publicKey = rsa.ToXmlString(false);
            string privateKey = rsa.ToXmlString(true);
            // Descifrar el mensaje con la clave privada
            byte[] decryptedMessage = rsa.Decrypt(encryptedMessage, false);
            string decryptedMessageString = Encoding.UTF8.GetString(decryptedMessage);
        }
    }
}
