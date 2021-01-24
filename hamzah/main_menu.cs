using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using hamzah;
using Insurance_customer_management_system;

namespace hamzah
{
    public partial class main_menu : Form
    {
        public main_menu()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)

        {
            //logout and go back to the login
            login login = new login();
            this.Close();
            login.Show();
            

        }

        private void new_customer_registration_button_Click(object sender, EventArgs e)
        {
            registration register = new registration();
            register.Show();
        }

        private void modify_customer_account_button_Click(object sender, EventArgs e)
        {
            modifyaccount modify = new modifyaccount();
            modify.Show();
        }

        private void customer_search_Click(object sender, EventArgs e)
        {
            customersearch search = new customersearch();
            search.Show();
        }

        private void renew_insurance_button_Click(object sender, EventArgs e)
        {
            renew_insurance renew = new renew_insurance();
            renew.Show();
        }

        private void purchase_new_insurance_button_Click(object sender, EventArgs e)
        {
            purchase_new_insurance purchase = new purchase_new_insurance();
            purchase.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            upgrade_insurance upgrade = new upgrade_insurance();
            upgrade.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            check_insurance check = new check_insurance();
            check.Show();
        }

        private void history_button_Click(object sender, EventArgs e)
        {
            payment_history pay = new payment_history();
            pay.Show();
        }

        private void claim_nsurance_button_Click(object sender, EventArgs e)
        {
            claim_insurance claim = new claim_insurance();
            claim.Show();
        }
    }
}
