using EncryptSoftware.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncryptSoftware
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            UC_Home home = new UC_Home();
            addUserControl(home);
        }

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            UC_Enigma enigma = new UC_Enigma();
            addUserControl(enigma);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            UC_Home home = new UC_Home();
            addUserControl(home);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            UC_File file = new UC_File();
            addUserControl(file);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            UC_Morse morse = new UC_Morse();
            addUserControl(morse);
        }
    }
}
