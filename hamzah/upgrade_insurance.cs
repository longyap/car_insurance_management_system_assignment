using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hamzah
{
    public partial class upgrade_insurance : Form
    {
        public upgrade_insurance()
        {
            InitializeComponent();
        }

        private void Submit_button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Insurance has been upgraded Successfully");
        }


    }
}
