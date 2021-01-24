using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace Insurance_customer_management_system
{
    class experimental_sql
    { 
        OleDbConnection con = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();

        public experimental_sql()
        {
            con.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = car_insurance_management_system_db.mdb;";
            con.Open();
        }
       
        public string table;
        public string name;
        public string TABLE
        {
            get { return table; }
            set { table = value; }
        }
        public string  NAME
        {
            get { return name; }
            set { name = value; }
        }

       public experimental_sql(string tb)
       {
                table = tb;
       }
        public experimental_sql(string nm, string tb)
        {
            name = nm;
            table = tb;
        }

        public void display_all ( string tb, ref DataGridView dgv )
        {
            try
            {
                cmd.CommandText = "SELECT * FROM "+tb+" ";
                cmd.Connection = con;
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                dgv.DataSource = dt;
                
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }          
        }
        //search from 2 database 
        public void search_payment(string nm, string tb, ref DataGridView dgv)
        {
              try
              {
                cmd.CommandText = "SELECT * FROM " + tb + " WHERE((payment_id='" + nm + "') OR (customer_id='" + nm + "'))  ";
                cmd.Connection = con;
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                dgv.DataSource = dt;
                

               }
              catch (Exception error)
              {
                MessageBox.Show(error.Message);
               }
        }
        public void search_customer_update(string nm, string tb)
        {
            try
            {
                cmd.CommandText = "SELECT * FROM " + tb + " WHERE((insurance_id='" + nm + "') OR (customer_id='" + nm + "'))  ";
                cmd.Connection = con;
                OleDbDataReader dr = cmd.ExecuteReader();
                //list the data reader and save it into string
               //  List<string> list = dr.GetValues<string>;





            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            
        }
        public void update(string nm,string tb )
        {
            try
            {
                cmd.CommandText = "UPDATE FROM " + tb + " SET no_insurance_claimed WHERE (car_no= '" + nm + "') OR (insurance_id= '" + nm + "')";
                cmd.ExecuteNonQuery();
                cmd.Connection = con;
            }
            catch(Exception er)
            {
                MessageBox.Show(er.Message);
            }
            
        }
        public class
    }
}
