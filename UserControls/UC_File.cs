using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EncryptSoftware.FileEncryptionCode;




namespace EncryptSoftware.UserControls
{
    public partial class UC_File : UserControl
    {
        public string foldersPath = Environment.CurrentDirectory + "\\Crypted&DecryptedFiles";
        public UC_File()
        {
            InitializeComponent();
            guna2TextBox1.KeyDown += PasswordTextBox_KeyDown;
            guna2TextBox3.Text = "Waiting for password...";
        }

        private void UC_File_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void PasswordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            FileEncryption fileEncryption = new FileEncryption();
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrWhiteSpace(guna2TextBox1.Text))
                {
                    try
                    {
                        guna2TextBox3.Text = $"Selected file:{fileEncryption.GetFileName()}";
                    }
                    catch (ArgumentException ex)
                    {
                        guna2TextBox3.Text = ex.Message;
                    }
                }
                else
                {
                    guna2TextBox3.Text = "Please enter a password...";
                }
            }
            else
            {
                guna2TextBox3.Text = "Click Enter to select a file";
            }
        }

        private void guna2TextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }


        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {


        }

        private void convertButton_Click(object sender, EventArgs e)
        {
            FileEncryption fileEncryption = new FileEncryption();
            string filePath = guna2TextBox3.Text.Remove(0, 14);
            string password = guna2TextBox1.Text;
            if (!password.Any(x => char.IsNumber(x)))
            {
                InvalidPassword invalidPassword = new InvalidPassword();
                invalidPassword.Show();
            }
            else
            {
                if (!File.Exists($"{foldersPath}/LogFile.txt"))
                {
                    fileEncryption.CreatePasswordFile();
                }

                if (guna2TextBox3.Text.Contains("Selected file:"))
                {
                    if (fileEncryption.IsFileLocked(filePath))
                    {
                        if (fileEncryption.CheckPassword(filePath, password))
                        {
                            fileEncryption.EncryptFile(filePath, password);
                            fileEncryption.FileUnclock(filePath, password);
                            guna2TextBox3.Text = "File successfully unlocked!";
                        }
                        else
                        {
                            guna2TextBox3.Text = "Wrong password!";
                        }
                    }
                    else
                    {
                        fileEncryption.EncryptFile(filePath, password);
                        fileEncryption.AddPasswordToFile(filePath, guna2TextBox1.Text);
                        guna2TextBox3.Text = "File successfully locked!\n\nDon't forget your password!";
                    }

                }
                else if (!string.IsNullOrWhiteSpace(guna2TextBox1.Text))
                {
                    guna2TextBox3.Text = "Click Enter to select a file";
                }
                else
                {
                    guna2TextBox3.Text = "Please enter a password...";
                }
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            guna2TextBox1.Text = string.Empty;
        }
    }
}
