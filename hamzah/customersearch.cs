using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hamzah
{
    public partial class customersearch : Form
    {
        public customersearch()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();


        private void customersearch_Load(object sender, EventArgs e)
        {
            //load database
            con.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = car_insurance_management_system_db.mdb;";
            con.Open();
        }

        private void customer_search_button_Click(object sender, EventArgs e)
            //SEARCH CUSTOMER DETAIL
        {
            string customersearch = customersearch_textbox.Text.ToString();
            try
            {
                //SHOW THE DATA DICTIONARY FROM CUSTOMER_T
                cmd.CommandText = "SELECT* FROM CUSTOMER_T c WHERE ((c.customer_name='"+customersearch+"') OR(c.customer_id='"+customersearch+"'))";
                cmd.Connection = con;
                //load the datatable
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                dataGridView1.DataSource = dt;
                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoResizeRows();

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}
