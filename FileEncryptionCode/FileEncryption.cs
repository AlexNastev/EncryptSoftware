using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncryptSoftware.FileEncryptionCode
{
    public class FileEncryption
    {
        public string foldersPath = Environment.CurrentDirectory + "\\Crypted&DecryptedFiles";
        public string GetFileName()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Files (*.*)|*.*";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog.FileName;
            }
            throw new ArgumentException("Failed to select a file.\nPlease try again...");
        }

        public void EncryptFile(string fileName, string num)
        {
            int n = 0;
            foreach (var item in num)
            {
                n += Convert.ToInt32(item);
            }
            
            FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate);
            byte[] data = new byte[stream.Length];
            stream.Read(data, 0, data.Length);
           
            //Going through each byte and applying the modifier(password)
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (byte)(data[i] ^ n);
            }
            //Writing the file with the modified bytes
            stream.Seek(0, SeekOrigin.Begin);
            stream.Write(data, 0, data.Length);
            stream.Close();
            
        }

        public void CreatePasswordFile()
        {
            StreamWriter writer = new StreamWriter($"{foldersPath}/LogFile.txt");
            writer.Close();

        }

        public void AddPasswordToFile(string filePath, string password)
        {
            StreamWriter writer = new StreamWriter($"{foldersPath}/LogFile.txt", true);
            writer.WriteLine($"{filePath}?{password}?#LOCKED#");

            writer.Close();
        }

        public void FileUnclock(string filePath, string password)
        {
            StreamWriter writer = new StreamWriter($"{foldersPath}/LogFile.txt", true);

            writer.WriteLine($"{filePath}?{password}?#UNLOCKED#");
            writer.Close();
        }

        public bool CheckPassword(string filePath, string password)
        {
            Dictionary<string, string> passwordDictionary = new Dictionary<string, string>();

            string[] lines = File.ReadAllLines($"{foldersPath}/LogFile.txt");


            for (int i = lines.Length - 1; i >= 0; i--)
            {
                var parts = lines[i].Split('?').ToArray();

                string key = parts[0].Trim();
                string value = parts[parts.Length - 2].Trim();
                passwordDictionary[key] = value;
                if (passwordDictionary.ContainsKey(filePath))
                {
                    if (passwordDictionary[filePath] == password)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool IsFileLocked(string filePath)
        {
            int count = 0;
            string[] lines = File.ReadAllLines($"{foldersPath}/LogFile.txt");
            if (lines.Length < 1)
            {
                return false;
            }
            foreach (string line in lines)
            {
                if (line.Contains(filePath))
                {
                    count++;
                }
            }
            if (count == 0)
            {
                return false;
            }
            else if (count % 2 != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
