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
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;

namespace EncryptSoftware.UserControls
{
    public partial class UC_Enigma : UserControl
    {
        List<char> ENchars;
        List<char> BGchars;
        Dictionary<char, char> ENplugBoard;
        Dictionary<char, char> BGplugBoard;
        Dictionary<char, Guna.UI2.WinForms.Guna2CustomCheckBox> ENletterToButton;
        Dictionary<char, Guna.UI2.WinForms.Guna2CustomCheckBox> BGletterToButton;

        public UC_Enigma()
        {
            InitializeComponent();
        }

        private void UC_Enigma_Load(object sender, EventArgs e)
        {
            BGplugBoard = new Dictionary<char, char>();
            ENplugBoard = new Dictionary<char, char>();
            ENchars = new List<char>();
            BGchars = new List<char>();
            BGletterToButton = new Dictionary<char, Guna.UI2.WinForms.Guna2CustomCheckBox>()
            {
                {'а', АCheckBox}, {'б', БCheckBox}, {'в', ВCheckBox}, {'г', ГCheckBox}, {'д', ДCheckBox},
                {'е', ЕCheckBox}, {'ж', ЖCheckBox}, {'з', ЗCheckBox}, {'и', ИCheckBox}, {'й', ЙCheckBox},
                {'к', КCheckBox}, {'л', ЛCheckBox}, {'м', МCheckBox}, {'н', НCheckBox}, {'о', ОCheckBox},
                {'п', ПCheckBox}, {'р', РCheckBox}, {'с', СCheckBox}, {'т', ТCheckBox}, {'у', УCheckBox},
                {'ф', ФCheckBox}, {'х', ХCheckBox}, {'ц', ЦCheckBox}, {'ч', ЧCheckBox}, {'ш', ШCheckBox},
                {'щ', ЩCheckBox}, {'ъ', ЪCheckBox}, {'ь', ЬCheckBox}, {'ю', ЮCheckBox}, {'я', ЯCheckBox}
            };
            ENletterToButton = new Dictionary<char, Guna.UI2.WinForms.Guna2CustomCheckBox>()
            {
                {'a', ACheckBox}, {'b', BCheckBox}, {'c', CCheckBox}, {'d', DCheckBox}, {'e', ECheckBox},
                {'f', FCheckBox}, {'g', GCheckBox}, {'h', HCheckBox}, {'i', ICheckBox}, {'j', JCheckBox},
                {'k', KCheckBox}, {'l', LCheckBox}, {'m', MCheckBox}, {'n', NCheckBox}, {'o', OCheckBox},
                {'p', PCheckBox}, {'q', QCheckBox}, {'r', RCheckBox}, {'s', SCheckBox}, {'t', TCheckBox},
                {'u', UCheckBox}, {'v', VCheckBox}, {'w', WCheckBox}, {'x', XCheckBox}, {'y', YCheckBox},
                {'z', ZCheckBox}
            };
            ENRadioButton.Checked = true;

            
        }
        private void CheckBoxClick(object sender)
        {
            if (ENRadioButton.Checked)
            {
                Guna.UI2.WinForms.Guna2CustomCheckBox checkBox = (Guna.UI2.WinForms.Guna2CustomCheckBox)sender; // Cast sender to CheckBox

                char letter = char.ToLower(checkBox.Name[0]);
                var workingButton = ENletterToButton[char.ToLower(letter)];
                if (workingButton.Checked)
                {
                    ENchars.Add(letter);
                    if (ENchars.Count == 2)
                    {
                        ENplugBoard[ENchars[0]] = ENchars[1];
                        ENplugBoard[ENchars[1]] = ENchars[0];
                        ENchars.Clear();
                    }
                }
                else
                {
                    if (ENplugBoard.ContainsKey(letter))
                    {
                        var value = ENplugBoard[letter];
                        ENletterToButton[value].Checked = false;
                        ENplugBoard.Remove(letter);
                        ENplugBoard.Remove(value);

                    }
                    ENchars.Remove(letter);
                }
            }
            else if (BGRadioButton.Checked)
            {
                Guna.UI2.WinForms.Guna2CustomCheckBox checkBox = (Guna.UI2.WinForms.Guna2CustomCheckBox)sender; // Cast sender to CheckBox

                char letter = char.ToLower(checkBox.Name[0]);
                var workingButton = BGletterToButton[char.ToLower(letter)];
                if (workingButton.Checked)
                {
                    BGchars.Add(letter);
                    if (BGchars.Count == 2)
                    {
                        BGplugBoard[BGchars[0]] = BGchars[1];
                        BGplugBoard[BGchars[1]] = BGchars[0];
                        BGchars.Clear();
                    }
                }
                else
                {
                    if (BGplugBoard.ContainsKey(letter))
                    {
                        var value = BGplugBoard[letter];
                        BGletterToButton[value].Checked = false;
                        BGplugBoard.Remove(letter);
                        BGplugBoard.Remove(value);

                    }
                    BGchars.Remove(letter);
                }
            }
            
        }
        int firstRotor = 1;
        int secondRotor = 1;
        int thirdRotor = 1;

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            if (ENRadioButton.Checked)
            {
                int firstRotorValue = (int)guna2NumericUpDown1.Value;
                int secondRotorValue = (int)guna2NumericUpDown2.Value;
                int thirdRotorValue = (int)guna2NumericUpDown3.Value;
                firstRotor = firstRotorValue;
                secondRotor = secondRotorValue;
                thirdRotor = thirdRotorValue;

                //ToDo forfill plugboard dic

                Enigma enigma = new Enigma(firstRotorValue, secondRotorValue, thirdRotorValue, ENplugBoard);
                string messageToCrypt = InputTextBox.Text.ToLower();
                OutPutTextBox.Text = enigma.Crypt(messageToCrypt);
                guna2NumericUpDown1.Value = enigma.FirstRotor.Vlaue;
                guna2NumericUpDown2.Value = enigma.SecondRotor.Vlaue;
                guna2NumericUpDown3.Value = enigma.ThirdRotor.Vlaue;
                InputTextBox.Text = string.Empty;
            }
            else if (BGRadioButton.Checked)
            {
                int firstRotorValue = (int)BGFirstRotor.Value;
                int secondRotorValue = (int)BGSecondRotor.Value;
                int thirdRotorValue = (int)BGThirdRotor.Value;
                firstRotor = firstRotorValue;
                secondRotor = secondRotorValue;
                thirdRotor = thirdRotorValue;

                //ToDo forfill plugboard dic

                BGEnigma enigma = new BGEnigma(firstRotorValue, secondRotorValue, thirdRotorValue, BGplugBoard);
                string messageToCrypt = InputTextBox.Text.ToLower();
                OutPutTextBox.Text = enigma.Crypt(messageToCrypt);
                BGFirstRotor.Value = enigma.FirstRotor.Vlaue;
                BGSecondRotor.Value = enigma.SecondRotor.Vlaue;
                BGThirdRotor.Value = enigma.ThirdRotor.Vlaue;
                InputTextBox.Text = string.Empty;
            }
            
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
            if (ENRadioButton.Checked)
            {
                int firstRotorValue = (int)guna2NumericUpDown1.Value;
                int secondRotorValue = (int)guna2NumericUpDown2.Value;
                int thirdRotorValue = (int)guna2NumericUpDown3.Value;
                string text = InputTextBox.Text;
                if (text == " ")
                {
                    SomethingWentWrong somethingWentWrong = new SomethingWentWrong();
                    somethingWentWrong.Show();
                }
                else
                {
                    string plugBoardName = string.Empty;
                    int n = 0;
                    foreach (var kvp in ENplugBoard)
                    {
                        if (n % 2 == 0)
                        {
                            plugBoardName += $"{kvp.Key}={kvp.Value}_";
                        }
                        n++;
                    }
                    Enigma enigma = new Enigma(firstRotorValue, secondRotorValue, thirdRotorValue, ENplugBoard);
                    string cryptedMessage = enigma.Crypt(text.ToLower());
                    string fileName = $"{firstRotorValue}_{secondRotorValue}_{thirdRotorValue}";
                    using (StreamWriter sr = new StreamWriter($"../../Crypted&DecryptedFiles/{fileName}_{plugBoardName}Crypted.txt"))
                    {
                        sr.WriteLine(cryptedMessage);
                    }
                    InputTextBox.Text = string.Empty;
                    guna2NumericUpDown1.Value = enigma.FirstRotor.Vlaue;
                    guna2NumericUpDown2.Value = enigma.SecondRotor.Vlaue;
                    guna2NumericUpDown3.Value = enigma.ThirdRotor.Vlaue;

                    InfoBox infoBox = new InfoBox();
                    infoBox.Show();
                }
            }
            else if (BGRadioButton.Checked)
            {
                int firstRotorValue = (int)BGFirstRotor.Value;
                int secondRotorValue = (int)BGSecondRotor.Value;
                int thirdRotorValue = (int)BGThirdRotor.Value;
                string text = InputTextBox.Text;
                if (text == " ")
                {
                    SomethingWentWrong somethingWentWrong = new SomethingWentWrong();
                    somethingWentWrong.Show();
                }
                else
                {
                    string plugBoardName = string.Empty;
                    int n = 0;
                    foreach (var kvp in BGplugBoard)
                    {
                        if (n % 2 == 0)
                        {
                            plugBoardName += $"{kvp.Key}={kvp.Value}_";
                        }
                        n++;
                    }
                    BGEnigma enigma = new BGEnigma(firstRotorValue, secondRotorValue, thirdRotorValue, BGplugBoard);
                    string cryptedMessage = enigma.Crypt(text.ToLower());
                    string fileName = $"{firstRotorValue}_{secondRotorValue}_{thirdRotorValue}";
                    using (StreamWriter sr = new StreamWriter($"../../Crypted&DecryptedFiles/{fileName}_{plugBoardName}Crypted.txt"))
                    {
                        sr.WriteLine(cryptedMessage);
                    }
                    InputTextBox.Text = string.Empty;
                    BGFirstRotor.Value = enigma.FirstRotor.Vlaue;
                    BGSecondRotor.Value = enigma.SecondRotor.Vlaue;
                    BGThirdRotor.Value = enigma.ThirdRotor.Vlaue;

                    InfoBox infoBox = new InfoBox();
                    infoBox.Show();
                }
            }
            
        }

        private void FileDecrypterButton_Click(object sender, EventArgs e)
        {
            if (ENRadioButton.Checked)
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] path = fileDialog.FileName.Split('\\');
                    string fileName = path[path.Length - 1];
                    string pattern = @"Crypted\.";
                    Regex regex = new Regex(pattern);
                    if (regex.IsMatch(fileName))
                    {
                        string[] args = fileName.Split('_');
                        int firstRotorValue = int.Parse(args[0]);
                        int secondRotorValue = int.Parse(args[1]);
                        int thirdRotorValue = int.Parse(args[2]);
                        Dictionary<char, char> plugBoardHere = new Dictionary<char, char>();
                        for (int i = 3; i < args.Length - 1; i++)
                        {
                            string[] letters = args[i].Split('=');
                            plugBoardHere[char.Parse(letters[0])] = char.Parse(letters[1]);
                            plugBoardHere[char.Parse(letters[1])] = char.Parse(letters[0]);
                        }

                        firstRotor = firstRotorValue;
                        secondRotor = secondRotorValue;
                        thirdRotor = thirdRotorValue;

                        //ToDo forfill plugboard dic

                        Enigma enigma = new Enigma(firstRotorValue, secondRotorValue, thirdRotorValue, plugBoardHere);
                        StreamReader streamReader = new StreamReader(fileDialog.FileName);
                        string messageToCrypt = streamReader.ReadToEnd();
                        streamReader.Close();
                        string decryptedMessage = enigma.Crypt(messageToCrypt.ToLower());
                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < args.Length - 1; i++)
                        {
                            sb.Append(args[i] + '_');
                        }
                        sb.Append("Decrypted.txt");
                        using (StreamWriter sr = new StreamWriter($"../../Crypted&DecryptedFiles/{sb}"))
                        {
                            sr.WriteLine(decryptedMessage);
                        }
                        InfoBox infoBox = new InfoBox();
                        infoBox.Show();
                    }
                    else
                    {
                        SomethingWentWrong somethingWentWrong = new SomethingWentWrong();
                        somethingWentWrong.Show();
                    }

                }
                else
                {
                    SomethingWentWrong somethingWentWrong = new SomethingWentWrong();
                    somethingWentWrong.Show();
                }
            }
            else if (BGRadioButton.Checked)
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] path = fileDialog.FileName.Split('\\');
                    string fileName = path[path.Length - 1];
                    string pattern = @"Crypted\.";
                    Regex regex = new Regex(pattern);
                    if (regex.IsMatch(fileName))
                    {
                        string[] args = fileName.Split('_');
                        int firstRotorValue = int.Parse(args[0]);
                        int secondRotorValue = int.Parse(args[1]);
                        int thirdRotorValue = int.Parse(args[2]);
                        Dictionary<char, char> plugBoardHere = new Dictionary<char, char>();
                        for (int i = 3; i < args.Length - 1; i++)
                        {
                            string[] letters = args[i].Split('=');
                            plugBoardHere[char.Parse(letters[0])] = char.Parse(letters[1]);
                            plugBoardHere[char.Parse(letters[1])] = char.Parse(letters[0]);
                        }

                        firstRotor = firstRotorValue;
                        secondRotor = secondRotorValue;
                        thirdRotor = thirdRotorValue;

                        //ToDo forfill plugboard dic

                        BGEnigma enigma = new BGEnigma(firstRotorValue, secondRotorValue, thirdRotorValue, plugBoardHere);
                        StreamReader streamReader = new StreamReader(fileDialog.FileName);
                        string messageToCrypt = streamReader.ReadToEnd();
                        streamReader.Close();
                        string decryptedMessage = enigma.Crypt(messageToCrypt.ToLower());
                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < args.Length - 1; i++)
                        {
                            sb.Append(args[i] + '_');
                        }
                        sb.Append("Decrypted.txt");
                        using (StreamWriter sr = new StreamWriter($"../../Crypted&DecryptedFiles/{sb}"))
                        {
                            sr.WriteLine(decryptedMessage);
                        }
                        InfoBox infoBox = new InfoBox();
                        infoBox.Show();
                    }
                    else
                    {
                        SomethingWentWrong somethingWentWrong = new SomethingWentWrong();
                        somethingWentWrong.Show();
                    }

                }
                else
                {
                    SomethingWentWrong somethingWentWrong = new SomethingWentWrong();
                    somethingWentWrong.Show();
                }
            }
            
        }

        private void ENRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (ENRadioButton.Checked)
            {
                ENControlsPanel.Show();
            }
            else
            {
                ENControlsPanel.Hide();
            }
            
            RotorsLabel.Text = "Rotors";
            InputLabel.Text = "Input";
            OutputLabel.Text = "Output";
            GenerateFileButton.Text = "File Generator";
            FileDecrypterButton.Text = "File Decryptor";
            ConvertButton.Text = "Convert";
            InputTextBox.Text = string.Empty;
            OutPutTextBox.Text = string.Empty;

            InputTextBox.Font = new Font("Stencil", 10.2f);
            OutPutTextBox.Font = new Font("Stencil", 10.2f);

            RotorsLabel.Font = new Font(RotorsLabel.Font, FontStyle.Regular);

            InputLabel.Font = new Font(RotorsLabel.Font, FontStyle.Regular);

            OutputLabel.Font = new Font(RotorsLabel.Font, FontStyle.Regular);

            GenerateFileButton.Font = new Font(RotorsLabel.Font.FontFamily, 13, FontStyle.Regular);

            FileDecrypterButton.Font = new Font(RotorsLabel.Font.FontFamily, 13, FontStyle.Regular);

            ConvertButton.Font = new Font(RotorsLabel.Font.FontFamily, 13, FontStyle.Regular);

        }

        private void guna2NumericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void GenerateFileButton_Click_1(object sender, EventArgs e)
        {

        }

        private void ConvertButton_Click_1(object sender, EventArgs e)
        {

        }
        private void FileDecrypterButton_Click_1(object sender, EventArgs e)
        {

        }

        private void BGRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (BGRadioButton.Checked)
            {
                BGControlPanel.Show();
            }
            else
            {
                BGControlPanel.Hide();
            }

            
            RotorsLabel.Text = "Ротори";
            RotorsLabel.Font = new Font(RotorsLabel.Font, FontStyle.Bold);

            InputLabel.Text = "Вход";
            InputLabel.Font = new Font(RotorsLabel.Font, FontStyle.Bold);

            OutputLabel.Text = "Изход";
            OutputLabel.Font = new Font(RotorsLabel.Font, FontStyle.Bold);

            GenerateFileButton.Text = "Направи файл";
            GenerateFileButton.Font = new Font(RotorsLabel.Font.FontFamily, 13, FontStyle.Bold);

            FileDecrypterButton.Text = "Декриптирай файл";
            FileDecrypterButton.Font = new Font(RotorsLabel.Font.FontFamily, 13, FontStyle.Bold);

            ConvertButton.Text = "Преобразувай";
            ConvertButton.Font = new Font(RotorsLabel.Font.FontFamily, 13, FontStyle.Bold);

            InputTextBox.Font = new Font(RotorsLabel.Font.FontFamily, 13, FontStyle.Regular);
            OutPutTextBox.Font = new Font(RotorsLabel.Font.FontFamily, 13, FontStyle.Regular);
            InputTextBox.Text = string.Empty;
            OutPutTextBox.Text = string.Empty;
        }

        private void УCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void ЕCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void ИCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void ШCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void ЩCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void КCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void СCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void ДCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void ЗCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void ЦCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void ЬCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void ЯCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void АCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void ОCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void ЖCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void ГCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void ТCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void НCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void ВCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void МCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void ЧCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void ЮCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void ЙCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void ЪCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void ФCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void ХCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void ПCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void РCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void ЛCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void БCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }
    }
}
