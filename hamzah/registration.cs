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
    public partial class registration : Form
    {
        OleDbConnection con = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();
        public registration()
        {
            InitializeComponent();
        }

        private void registration_Load(object sender, EventArgs e)
        {
            con.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = car_insurance_management_system_db.mdb;";
            con.Open();
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            string customer_id = customer_id_textbox.Text;
            string customer_name = customer_name_textbox.Text;
            string gender = gender_combo_box.Text;
            string ic_no = ic_textbox.Text;
            string dob = dateTimePicker1.Value.ToString(("dd/MM/yyyy"));
            string city = city_textbox.Text;
            int phone = int.Parse(phone_no_textbox.Text);
            string email = email_textbox.Text;
            try
            {
                cmd.CommandText = "INSERT INTO CUSTOMER_T (customer_id,customer_name,gender,ic_no,dob,city,email,phone)" +
                                 " VALUES("+customer_id+",'"+customer_name+"','"+gender+"', '"+ic_no+"','"+dob+"', '"+city+"','"+email+"', "+phone+")";
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                MessageBox.Show(""+customer_name+"\t ID ("+customer_id+")\nAccount has been Created Successfully.");

            }
            catch ( Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

    }
}
