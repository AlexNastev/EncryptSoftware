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

namespace EncryptSoftware.UserControls
{
    public partial class UC_Enigma : UserControl
    {
        public UC_Enigma()
        {
            InitializeComponent();
        }

        private void UC_Enigma_Load(object sender, EventArgs e)
        {

        }
        private void ConvertButton_Click(object sender, EventArgs e)
        {
            int firstRotorValue = (int)guna2NumericUpDown1.Value;
            int secondRotorValue = (int)guna2NumericUpDown2.Value;
            int thirdRotorValue = (int)guna2NumericUpDown3.Value;

            //ToDo forfill plugboard dic
            Dictionary<char, char> plugBoard = new Dictionary<char, char>();
            Enigma enigma = new Enigma(firstRotorValue, secondRotorValue, thirdRotorValue, plugBoard);
            string messageToCrypt = InputTextBox.Text.ToLower();
            OutPutTextBox.Text = enigma.Crypt(messageToCrypt);
            guna2NumericUpDown1.Value = enigma.FirstRotor.Vlaue;
            guna2NumericUpDown2.Value = enigma.SecondRotor.Vlaue;
            guna2NumericUpDown3.Value = enigma.ThirdRotor.Vlaue;

        }
    }
}
