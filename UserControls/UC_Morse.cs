using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncryptSoftware.UserControls
{
    public partial class playSoundButton_Morse : UserControl
    {
        public playSoundButton_Morse()
        {
            InitializeComponent();
        }

        private void inputTextBox_TextChanged(object sender, EventArgs e)
        {
            MorseTranslator translator = new MorseTranslator();

            if (!guna2ToggleSwitch1.Checked)
            {
                outputTextBox.Text = translator.ConvertToMorse(inputTextBox.Text);
            }
            else
            {
                outputTextBox.Text = translator.ConvertFromMorse(inputTextBox.Text);
            }
        }

        private void outputTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            MorseTranslator morseTranslator = new MorseTranslator();
            string temp;
            if (guna2ToggleSwitch1.Checked)
            {
                label1.Text = "Morse";
                label2.Text = "Text";
                temp = outputTextBox.Text;
                outputTextBox.Text = morseTranslator.ConvertFromMorse(inputTextBox.Text);
                inputTextBox.Text = temp;
            }
            else
            {
                label1.Text = "Text";
                label2.Text = "Morse";
                temp = outputTextBox.Text;
                inputTextBox.Text = temp;
                outputTextBox.Text = morseTranslator.ConvertToMorse(temp);
            }
        }

        private void UC_Morse_Load(object sender, EventArgs e)
        {
            label1.Text = "Text";
            label2.Text = "Morse";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async void PlaySoundButton_Click(object sender, EventArgs e)
        {
            MorseTranslator morseTranslator = new MorseTranslator();
            await Task.Run(() => morseTranslator.PlaySound(outputTextBox.Text, GetSpeed()));
        }

        private string GetSpeed()
        {
            string speed = "";
            soundSpeedComboBox1.Invoke((MethodInvoker)delegate
            {
                speed = soundSpeedComboBox1.Text;
            });
            return speed;
        }

        private void soundSpeedComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            inputTextBox.Text = string.Empty;
            outputTextBox.Text = string.Empty;
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void outputTextBox_TextChanged_1(object sender, EventArgs e)
        {

        }
    }

}
