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
    public partial class modifyaccount : Form
    {
        public modifyaccount()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();

        private void modifyaccount_Load(object sender, EventArgs e)
        {
            //load database
            con.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = car_insurance_management_system_db.mdb;";
            con.Open();
        }

        private void search_button_Click(object sender, EventArgs e)
        {
            string customer_search = customer_search_textbox.Text.ToString();

            try
            {
                cmd.CommandText = "SELECT* FROM CUSTOMER_T c WHERE ((c.customer_id ='" + customer_search + "') OR (c.customer_name= '" + customer_search + "'))";
                cmd.Connection = con;
                OleDbDataReader dr = cmd.ExecuteReader();


                if (dr.Read())
                {
                    //input the text if found in the database sschema
                    customer_id_label.Text = "Customer ID: " + dr[0].ToString();
                    customer_name_label.Text = "Name: " + dr[1].ToString();
                    gender_combo_box.Text = dr[2].ToString();
                    ic_no_texbox.Text = dr[3].ToString();
                    dateTimePicker.Value = Convert.ToDateTime(dr[4].ToString());
                    city_textbox.Text = dr[6].ToString();
                    email_textbox.Text = dr[5].ToString();
                    phone_no_textbox.Text = dr[7].ToString();
                    carbrand_textbox.Text = dr[8].ToString();
                    car_no_textbox.Text = dr[9].ToString();
                    carprice_textbox.Text = dr[10].ToString();
                }
                else
                {
                    MessageBox.Show("Record Not Found");
                }
                dr.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }


        }

        private void edit_button_Click(object sender, EventArgs e)
        {
            //update info
            string customer_search = customer_search_textbox.Text.ToString();
            string gender = gender_combo_box.Text.ToString();
            string ic_no = ic_no_texbox.Text.ToString();
            string date = dateTimePicker.Value.ToString(("yyyy-MM-dd"));
            string city = city_textbox.Text.ToString();
            string email = email_textbox.Text.ToString();
            string phone = phone_no_textbox.Text.ToString();
            string car_brand = carbrand_textbox.Text.ToString();
            string car_no = car_no_textbox.Text.ToString();
            string car_price = carprice_textbox.Text.ToString();

            try
            {
                cmd.CommandText = "UPDATE CUSTOMER_T " +
                                "SET gender='" + gender + "',ic_no='" + ic_no + "',dob='" + date + "',city='" + city + "', email='" + email + "'," +
                                       "phone= '" + phone + "',car_brand ='" + car_brand + "',car_no='" + car_no + "',car_price='" + car_price + "'" +
                                       "WHERE (customer_name ='" + customer_search + "' OR customer_id = '" + customer_search + "')";
                cmd.ExecuteNonQuery();
                cmd.Connection = con;
                MessageBox.Show("Account ("+customer_search+") has been modified successfully");
            }

            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
            
        }

    }
}
