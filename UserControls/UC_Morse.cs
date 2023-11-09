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
    public partial class UC_Morse : UserControl
    {
        public UC_Morse()
        {
            InitializeComponent();
        }

        private void inputTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!guna2ToggleSwitch1.Checked)
            {
                outputTextBox.Text = ToMorse(inputTextBox.Text);
            }
            else
            {
                outputTextBox.Text = FromMorse(inputTextBox.Text);
            }
        }

        private void outputTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            string temp;
            if (guna2ToggleSwitch1.Checked)
            {
                label1.Text = "Morse";
                label2.Text = "Text";
                temp = outputTextBox.Text;
                outputTextBox.Text = FromMorse(inputTextBox.Text);
                inputTextBox.Text = temp;
            }
            else
            {
                label1.Text = "Text";
                label2.Text = "Morse";
                temp = outputTextBox.Text;
                inputTextBox.Text = temp;
                outputTextBox.Text = ToMorse(temp);
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

        //------------------------------------------------------------      Logic       ----------------------------------------------------------------
        //Convert to morse code
        static string ToMorse(string input)
        {
            var morseAlphabet = new Dictionary<char, string>()
            {
                 {'a', ".-"},
                 {'b', "-..."},
                 {'c', "-.-."},
                 {'d', "-.."},
                 {'e', "."},
                 {'f', "..-."},
                 {'g', "--."},
                 {'h', "...."},
                 {'i', ".."},
                 {'j', ".---"},
                 {'k', "-.-"},
                 {'l', ".-.."},
                 {'m', "--"},
                 {'n', "-."},
                 {'o', "---"},
                 {'p', ".--."},
                 {'q', "--.-"},
                 {'r', ".-."},
                 {'s', "..."},
                 {'t', "-"},
                 {'u', "..-"},
                 {'v', "...-"},
                 {'w', ".--"},
                 {'x', "-..-"},
                 {'y', "-.--"},
                 {'z', "--.."},
                 {' ', "/"},
                 {'1', ".----"},
                 {'2', "..---"},
                 {'3', "...--"},
                 {'4', "....-"},
                 {'5', "....."},
                 {'6', "-...."},
                 {'7', "--..."},
                 {'8', "---.."},
                 {'9', "----."},
                 {'0', "-----"},
                 {'.', ".-.-.-"},
                 {',', "--..--"},
                 {'?', "..--.."},
             };
            string newString = "";
            input = input.ToLower();
            foreach (char letter in input)
            {
                if (morseAlphabet.ContainsKey(letter))
                    newString += morseAlphabet[letter] + " ";
            }
            return newString.ToUpper();
        }

        //Convert from morse code
        static string FromMorse(string input)
        {
            var newInput = input.Split().ToArray();
            var morseAlphabet = new Dictionary<string, char>()
            {
                {".-"  ,'a'},
                {"-...",'b'},
                {"-.-.",'c'},
                {"-.." ,'d'},
                {"."   ,'e'},
                {"..-.",'f'},
                {"--." ,'g'},
                {"....",'h'},
                {".."  ,'i'},
                {".---",'j'},
                {"-.-" ,'k'},
                {".-..",'l'},
                {"--"  ,'m'},
                {"-."  ,'n'},
                {"---" ,'o'},
                {".--.",'p'},
                {"--.-",'q'},
                {".-." ,'r'},
                {"..." ,'s'},
                {"-"   ,'t'},
                {"..-" ,'u'},
                {"...-",'v'},
                {".--" ,'w'},
                {"-..-",'x'},
                {"-.--",'y'},
                {"--..",'z'},
                {"/"   ,' '},
                {".----",'1'},
                {"..---",'2'},
                {"...--",'3'},
                {"....-",'4'},
                {".....",'5'},
                {"-....",'6'},
                {"--...",'7'},
                {"---..",'8'},
                {"----.",'9'},
                {"-----",'0'},
                {".-.-.-",'.'},
                {"--..--",','},
                {"..--..",'?'},
            };
            string newString = "";
            input = input.ToLower();
            foreach (var letter in newInput)
            {
                if (morseAlphabet.ContainsKey(letter))
                    newString += morseAlphabet[letter];
            }
            return newString.ToUpper();
        }
    }

}
