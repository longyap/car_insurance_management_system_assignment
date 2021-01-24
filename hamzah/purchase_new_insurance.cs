using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using Insurance_customer_management_system;
using System.Security.Cryptography;

namespace hamzah
{
    public partial class purchase_new_insurance : Form
    {
        public purchase_new_insurance()
        {
            InitializeComponent();
        }
        car test = new car();
        OleDbConnection con = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();

        car.price_counting price_count = new car.price_counting();
        
        
        //store the price for another button 
        public static double price;
        public static double total_purchase;
        public static string customer_name;
        public static string customer_id;



        private void purchase_new_insurance_Load(object sender, EventArgs e)
        {
            con.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = car_insurance_management_system_db.mdb;";
            con.Open();
        }

        private void search_button_Click(object sender, EventArgs e)
        {
            string customer_search = customerseatch_textbox.Text.ToString();
            try { 
                cmd.CommandText = "SELECT * FROM CUSTOMER_T WHERE (customer_name = '"+customer_search+"' OR customer_id= '"+customer_search+"')" ;
                cmd.Connection = con;
                OleDbDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                 {
                    //input the text if found in the database sschema
                    customerid_label.Text = "Customer ID: " + dr[0].ToString();
                    customer_name_label.Text = "Name: " + dr[1].ToString();
                    gender_label.Text ="Gender:"+ dr[2].ToString();
                    ic_no_label.Text ="I/C No:"+ dr[3].ToString();
                    customer_id= dr[0].ToString();
                    customer_name =  dr[1].ToString();
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

       

        private void insurance_type_combo_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            double price = Convert.ToDouble( market_value_textbox.Text);
            int selected_item = insurance_type_combo_box.SelectedIndex;
            double grosstotal = price_count.gross_total(selected_item,price) ;
            double sst = price_count.sst(grosstotal);
            total_purchase = price_count.total_premium( grosstotal, sst);

            insurance_premium_label.Text = "Insurance premium gross total: RM" + grosstotal;
            sst_label.Text = "SST (6%): RM" + sst;
            stamp_duty_label.Text = "Stamp Duty: RM10";
            total_annual_premium_label.Text = "Total Annual Premium: RM" + total_purchase;
        }


        private void Submit_button_Click(object sender, EventArgs e)
        {
            string pay ="";
            try
           { 
                //check payment method 
                if (cash_radio_button.Checked)
                
                     pay = "CASH";
                
                if (credit_card_radio_button.Checked )
                
                     pay = "CREDIT CARD";
                
                if (bank_cheque_radio_button.Checked)
                  
                     pay = "BANK CHEQUE";
                cmd.CommandText = "SELECT COUNT (*) FROM CAR_INSURANCE_T ";
                Int32 countinsurance = (Int32)cmd.ExecuteScalar();

                cmd.CommandText = "SELECT COUNT (*) FROM PAYMENT_T ";
                Int32 countpayment = (Int32)cmd.ExecuteScalar();


                string car_model = car_model_textbox.Text;
                string car_no = car_no_textbox.Text;
                string car_value = market_value_textbox.Text;
                string insurance_type = insurance_type_combo_box.Text;
                string start_date = datetimepicker.Value.ToString("dd/MM/yyyy");
                string end_date = datetimepicker.Value.AddDays(360).ToString("dd/MM/yyyy");
                int no_insurance_claimed = 1;
                string insurance_id = "IS"+ countinsurance.ToString("00000");
                string payment_id = "PY"+ countpayment.ToString("00000");
                string payment_method = pay;



            cmd.CommandText = "INSERT INTO CAR_INSURANCE_T (insurance_id,customer_id,car_model,market_value,insurance_type,insurance_start_date,insurance_end_date,No_insurance_claimed)" +
                               " VALUES('" + insurance_id + "','" + customer_id + "','" + car_model + "', '" + car_value + "','" + insurance_type + "', '" + start_date + "','" + end_date + "', " + no_insurance_claimed + ")";
                   cmd.CommandText = "INSERT INTO PAYMENT_T ( payment_id,customer_id,car_no,car_model,insurance_type,payment_method,payment_price)" +
                               " VALUES('" + payment_id + "','" + customer_id + "','" + car_no + "','" + car_model + "','" + insurance_type + "','" + payment_method + "'," +total_purchase+ ")";
              
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("insurance_id" + customer_name + "\t ID (" + customer_id + ")Account \n has been purchased "+insurance_type+" \nInvoice ID ("+payment_id+").");
                    

              }
           catch (Exception error)
           {
                MessageBox.Show(error.Message);
           }
          
        }

    }
}
