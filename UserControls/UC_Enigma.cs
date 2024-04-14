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
using EncryptSoftware.InfosForms;
using EncryptSoftware.ErrorForms;

namespace EncryptSoftware.UserControls
{
    public partial class UC_Enigma : UserControl
    {
        public string foldersPath = Environment.CurrentDirectory + "\\Crypted&DecryptedFiles";
        List<char> ENchars;
        List<char> BGchars;
        List<char> RUchars;
        Dictionary<char, char> ENplugBoard;
        Dictionary<char, char> BGplugBoard;
        Dictionary<char, char> RUplugBoard;
        Dictionary<char, Guna.UI2.WinForms.Guna2CustomCheckBox> ENletterToButton;
        Dictionary<char, Guna.UI2.WinForms.Guna2CustomCheckBox> BGletterToButton;
        Dictionary<char, Guna.UI2.WinForms.Guna2CustomCheckBox> RUletterToButton;

        public UC_Enigma()
        {
            InitializeComponent();
        }

        private void UC_Enigma_Load(object sender, EventArgs e)
        {
            BGplugBoard = new Dictionary<char, char>();
            ENplugBoard = new Dictionary<char, char>();
            RUplugBoard = new Dictionary<char, char>();
            ENchars = new List<char>();
            BGchars = new List<char>();
            RUchars = new List<char>();
            RUletterToButton = new Dictionary<char, Guna.UI2.WinForms.Guna2CustomCheckBox>()
            {
                {'а', АRUCheckBox}, {'б', БRUCheckBox}, {'в', ВRUCheckBox}, {'г', ГRUCheckBox}, {'д', ДRUCheckBox},
                {'е', ЕRUCheckBox}, {'ж', ЖRUCheckBox}, {'з', ЗRUCheckBox}, {'и', ИRUCheckBox}, {'й', ЙRUCheckBox},
                {'к', КRUCheckBox}, {'л', ЛRUCheckBox}, {'м', МRUCheckBox}, {'н', НRUCheckBox}, {'о', ОRUCheckBox},
                {'п', ПRUCheckBox}, {'р', РRUCheckBox}, {'с', СRUCheckBox}, {'т', ТRUCheckBox}, {'у', УRUCheckBox},
                {'ф', ФRUCheckBox}, {'х', ХRUCheckBox}, {'ц', ЦRUCheckBox}, {'ч', ЧRUCheckBox}, {'ш', ШRUCheckBox},
                {'щ', ЩRUCheckBox}, {'ъ', ЪRUCheckBox}, {'ь', ЬRUCheckBox}, {'ю', ЮRUCheckBox}, {'я', ЯRUCheckBox},
                {'ы', ЫRUCheckBox}, {'ё', ЁRUCheckBox}, {'Э', ЭRUCheckBox}
            };
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

            guna2NumericUpDown1.TabIndex = 1;
            guna2NumericUpDown2.TabIndex = 2;
            guna2NumericUpDown3.TabIndex = 3;

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
            else if (RURadioButton.Checked)
            {
                Guna.UI2.WinForms.Guna2CustomCheckBox checkBox = (Guna.UI2.WinForms.Guna2CustomCheckBox)sender; // Cast sender to CheckBox

                char letter = char.ToLower(checkBox.Name[0]);
                var workingButton = RUletterToButton[char.ToLower(letter)];
                if (workingButton.Checked)
                {
                    RUchars.Add(letter);
                    if (RUchars.Count == 2)
                    {
                        RUplugBoard[RUchars[0]] = RUchars[1];
                        RUplugBoard[RUchars[1]] = RUchars[0];
                        RUchars.Clear();
                    }
                }
                else
                {
                    if (RUplugBoard.ContainsKey(letter))
                    {
                        var value = RUplugBoard[letter];
                        RUletterToButton[value].Checked = false;
                        RUplugBoard.Remove(letter);
                        RUplugBoard.Remove(value);

                    }
                    RUchars.Remove(letter);
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
                try
                {
                    OutPutTextBox.Text = enigma.Crypt(messageToCrypt);
                }
                catch (Exception ex)
                {

                    WrongInputCheckLanguageEN somethingWentWrong = new WrongInputCheckLanguageEN();
                    somethingWentWrong.Show();
                }
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
                try
                {
                    OutPutTextBox.Text = enigma.Crypt(messageToCrypt);
                }
                catch (Exception ex)
                {

                    WrongInputBG somethingWentWrong = new WrongInputBG();
                    somethingWentWrong.Show();
                }
                BGFirstRotor.Value = enigma.FirstRotor.Vlaue;
                BGSecondRotor.Value = enigma.SecondRotor.Vlaue;
                BGThirdRotor.Value = enigma.ThirdRotor.Vlaue;
                InputTextBox.Text = string.Empty;
            }
            else if (RURadioButton.Checked)
            {
                int firstRotorValue = (int)RUFirstRotor.Value;
                int secondRotorValue = (int)RUSecondRotor.Value;
                int thirdRotorValue = (int)RUThirdRotor.Value;
                firstRotor = firstRotorValue;
                secondRotor = secondRotorValue;
                thirdRotor = thirdRotorValue;

                //ToDo forfill plugboard dic

                RUEnigma enigma = new RUEnigma(firstRotorValue, secondRotorValue, thirdRotorValue, RUplugBoard);
                string messageToCrypt = InputTextBox.Text.ToLower();
                try
                {
                    OutPutTextBox.Text = enigma.Crypt(messageToCrypt);
                }
                catch (Exception ex)
                {

                    WrongInputRU somethingWentWrong = new WrongInputRU();
                    somethingWentWrong.Show();
                }
                RUFirstRotor.Value = enigma.FirstRotor.Vlaue;
                RUSecondRotor.Value = enigma.SecondRotor.Vlaue;
                RUThirdRotor.Value = enigma.ThirdRotor.Vlaue;
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
                    using (StreamWriter sr = new StreamWriter($"{foldersPath}/{fileName}_{plugBoardName}Crypted.txt"))
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
                    SomethingWentWrongBG somethingWentWrong = new SomethingWentWrongBG();
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
                    using (StreamWriter sr = new StreamWriter($"{foldersPath}/{fileName}_{plugBoardName}Crypted.txt"))
                    {
                        sr.WriteLine(cryptedMessage);
                    }
                    InputTextBox.Text = string.Empty;
                    BGFirstRotor.Value = enigma.FirstRotor.Vlaue;
                    BGSecondRotor.Value = enigma.SecondRotor.Vlaue;
                    BGThirdRotor.Value = enigma.ThirdRotor.Vlaue;

                    BGInfoBox infoBox = new BGInfoBox();
                    infoBox.Show();
                }
            }
            else if(RURadioButton.Checked)
            {
                int firstRotorValue = (int)RUFirstRotor.Value;
                int secondRotorValue = (int)RUSecondRotor.Value;
                int thirdRotorValue = (int)RUThirdRotor.Value;
                string text = InputTextBox.Text;
                if (text == " ")
                {
                    SomethingWentWrongRU somethingWentWrong = new SomethingWentWrongRU();
                    somethingWentWrong.Show();
                }
                else
                {
                    string plugBoardName = string.Empty;
                    int n = 0;
                    foreach (var kvp in RUplugBoard)
                    {
                        if (n % 2 == 0)
                        {
                            plugBoardName += $"{kvp.Key}={kvp.Value}_";
                        }
                        n++;
                    }
                    RUEnigma enigma = new RUEnigma(firstRotorValue, secondRotorValue, thirdRotorValue, RUplugBoard);
                    string cryptedMessage = enigma.Crypt(text.ToLower());
                    string fileName = $"{firstRotorValue}_{secondRotorValue}_{thirdRotorValue}";
                    using (StreamWriter sr = new StreamWriter($"{foldersPath}/{fileName}_{plugBoardName}Crypted.txt"))
                    {
                        sr.WriteLine(cryptedMessage);
                    }
                    InputTextBox.Text = string.Empty;
                    RUFirstRotor.Value = enigma.FirstRotor.Vlaue;
                    RUSecondRotor.Value = enigma.SecondRotor.Vlaue;
                    RUThirdRotor.Value = enigma.ThirdRotor.Vlaue;

                    RUInfoBox infoBox = new RUInfoBox();
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
                        using (StreamWriter sr = new StreamWriter($"{foldersPath}/{sb}"))
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
                        using (StreamWriter sr = new StreamWriter($"{foldersPath}/{sb}"))
                        {
                            sr.WriteLine(decryptedMessage);
                        }
                        BGInfoBox infoBox = new BGInfoBox();
                        infoBox.Show();
                    }
                    else
                    {
                        SomethingWentWrongBG somethingWentWrong = new SomethingWentWrongBG();
                        somethingWentWrong.Show();
                    }

                }
                else
                {
                    SomethingWentWrongBG somethingWentWrong = new SomethingWentWrongBG();
                    somethingWentWrong.Show();
                }
            }
            else if (RURadioButton.Checked)
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

                        RUEnigma enigma = new RUEnigma(firstRotorValue, secondRotorValue, thirdRotorValue, plugBoardHere);
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
                        using (StreamWriter sr = new StreamWriter($"{foldersPath}/{sb}"))
                        {
                            sr.WriteLine(decryptedMessage);
                        }
                        RUInfoBox infoBox = new RUInfoBox();
                        infoBox.Show();
                    }
                    else
                    {
                        SomethingWentWrongRU somethingWentWrong = new SomethingWentWrongRU();
                        somethingWentWrong.Show();
                    }
                }
                else
                {
                    SomethingWentWrongRU somethingWentWrong = new SomethingWentWrongRU();
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

        private void RURadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (RURadioButton.Checked)
            {
                RUControlPanel.Show();
            }
            else
            {
                RUControlPanel.Hide();
            }

            RotorsLabel.Text = "Роторы";
            RotorsLabel.Font = new Font(RotorsLabel.Font, FontStyle.Bold);

            InputLabel.Text = "Вход";
            InputLabel.Font = new Font(RotorsLabel.Font, FontStyle.Bold);

            OutputLabel.Text = "Выход";
            OutputLabel.Font = new Font(RotorsLabel.Font, FontStyle.Bold);

            GenerateFileButton.Text = "Сделать файл";
            GenerateFileButton.Font = new Font(RotorsLabel.Font.FontFamily, 13, FontStyle.Bold);

            FileDecrypterButton.Text = "Расшифровать файл";
            FileDecrypterButton.Font = new Font(RotorsLabel.Font.FontFamily, 13, FontStyle.Bold);

            ConvertButton.Text = "Трансформировать";
            ConvertButton.Font = new Font(RotorsLabel.Font.FontFamily, 13, FontStyle.Bold);

            InputTextBox.Font = new Font(RotorsLabel.Font.FontFamily, 13, FontStyle.Regular);
            OutPutTextBox.Font = new Font(RotorsLabel.Font.FontFamily, 13, FontStyle.Regular);
            InputTextBox.Text = string.Empty;
            OutPutTextBox.Text = string.Empty;
        }

        private void ЙRUCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void ЦRUCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void УRUCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void КRUCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void ЕRUCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void НRUCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void ГRUCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void ШRUCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void ЩRUCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void ЗRUCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void ХRUCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void ЪRUCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void ЁRUCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void ФRUCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void ЫRUCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void ВRUCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void АRUCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void ПRUCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void РRUCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void ОRUCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void ЛRUCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void ДRUCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void ЖRUCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void ЭRUCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void ЯRUCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void ЧRUCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void СRUCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void МRUCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void ИRUCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void ТRUCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void ЬRUCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void БRUCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void ЮRUCheckBox_Click(object sender, EventArgs e)
        {
            CheckBoxClick(sender);
        }

        private void InputLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
