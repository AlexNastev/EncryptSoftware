using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncryptSoftware.InfosForms
{
    public partial class BGInfoBox : Form
    {
        public BGInfoBox()
        {
            InitializeComponent();
        }

        

        private void OKButton_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
