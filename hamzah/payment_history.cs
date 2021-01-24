using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Insurance_customer_management_system
{
    public partial class payment_history : Form
    {
        
        public payment_history()
        {
            InitializeComponent();
        }
        experimental_sql test = new experimental_sql();
       

        private void payment_Load(object sender, EventArgs e)
        {
            test.display_all("PAYMENT_T" ,ref dataGridView1);
            dataGridView1.AutoResizeColumns();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            test.display_all("PAYMENT_T", ref dataGridView1);
            dataGridView1.AutoResizeColumns();

        }

        private void search_textbox_TextChanged(object sender, EventArgs e)
        {
            string name = search_textbox.Text;
            test.search_payment(name, "PAYMENT_T", ref dataGridView1);
            dataGridView1.AutoResizeColumns();
        }
    }
}
