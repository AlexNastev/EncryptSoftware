using EncryptSoftware.EnigmaCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace EncryptSoftware.UserControls
{
    public partial class UC_Enigma : UserControl
    {
        List<char> chars;
        Dictionary<char, char> plugBoard;
        Dictionary<char, Guna.UI2.WinForms.Guna2CustomCheckBox> letterToButton;
public UC_Enigma()
        {
            InitializeComponent();
        }

        private void UC_Enigma_Load(object sender, EventArgs e)
        {
            plugBoard = new Dictionary<char, char>();
            chars = new List<char>();
            letterToButton = new Dictionary<char, Guna.UI2.WinForms.Guna2CustomCheckBox>()
            {
                {'a', ACheckBox}, {'b', BCheckBox}, {'c', CCheckBox}, {'d', DCheckBox}, {'e', ECheckBox},
                {'f', FCheckBox}, {'g', GCheckBox}, {'h', HCheckBox}, {'i', ICheckBox}, {'j', JCheckBox},
                {'k', KCheckBox}, {'l', LCheckBox}, {'m', MCheckBox}, {'n', NCheckBox}, {'o', OCheckBox},
                {'p', PCheckBox}, {'q', QCheckBox}, {'r', RCheckBox}, {'s', SCheckBox}, {'t', TCheckBox},
                {'u', UCheckBox}, {'v', VCheckBox}, {'w', WCheckBox}, {'x', XCheckBox}, {'y', YCheckBox},
                {'z', ZCheckBox}
            };
        }

        private void CheckBoxClick(object sender)
        {
            Guna.UI2.WinForms.Guna2CustomCheckBox checkBox = (Guna.UI2.WinForms.Guna2CustomCheckBox)sender; // Cast sender to CheckBox

            char letter = char.ToLower(checkBox.Name[0]);
            var workingButton = letterToButton[char.ToLower(letter)];
            if (workingButton.Checked)
            {
                chars.Add(letter);
                if (chars.Count == 2)
                {
                    plugBoard[chars[0]] = chars[1];
                    plugBoard[chars[1]] = chars[0];
                    chars.Clear();
                }
            }
            else
            {
                if (plugBoard.ContainsKey(letter))
                {
                    var value = plugBoard[letter];
                    letterToButton[value].Checked = false;
                    plugBoard.Remove(letter);
                    plugBoard.Remove(value);

                }
                chars.Remove(letter);
            }
        }
        int firstRotor = 0;
        int secondRotor = 0;
        int thirdRotor = 0;

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            int firstRotorValue = (int)guna2NumericUpDown1.Value;
            int secondRotorValue = (int)guna2NumericUpDown2.Value;
            int thirdRotorValue = (int)guna2NumericUpDown3.Value;
            firstRotor = firstRotorValue;
            secondRotor = secondRotorValue;
            thirdRotor = thirdRotorValue;

            //ToDo forfill plugboard dic
             
            Enigma enigma = new Enigma(firstRotorValue, secondRotorValue, thirdRotorValue, plugBoard);
            string messageToCrypt = InputTextBox.Text.ToLower();
            OutPutTextBox.Text = enigma.Crypt(messageToCrypt);
            guna2NumericUpDown1.Value = enigma.FirstRotor.Vlaue;
            guna2NumericUpDown2.Value = enigma.SecondRotor.Vlaue;
            guna2NumericUpDown3.Value = enigma.ThirdRotor.Vlaue;
            InputTextBox.Text = string.Empty;
            InputTextBox.Text = string.Empty;
            InputTextBox.Text = string.Empty;

        }

        private void QCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void WCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void RCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void ECheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void ICheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void TCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void ZCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void UCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void OCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void ACheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void SCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void DCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void FCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void GCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void HCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void JCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void KCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void PCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void YCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void XCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void CCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void VCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void BCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void NCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void MCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void LCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void GenerateFileButton_Click(object sender, EventArgs e)
        {
            int firstRotorValue = firstRotor;
            int secondRotorValue = secondRotor;
            int thirdRotorValue = thirdRotor;
            string text = OutPutTextBox.Text;
            string plugBoardName = string.Empty;
            int n = 0;
            foreach (var kvp in plugBoard)
            {
                if (n % 2 == 0)
                {
                    plugBoardName += $"{kvp.Key}={kvp.Value}_";
                }
                n++;
            }
            string fileName = $"{firstRotorValue}_{secondRotorValue}_{thirdRotorValue}";
            using(StreamWriter sr = new StreamWriter($"../../{fileName}_{plugBoardName}Crypted.txt"))
            {
                sr.WriteLine(text);
            }
          
        }

        private void FileDecrypterButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = fileDialog.FileName;
                string[] path = fileName.Split('/');
            }
            
            
        }
    }
}
