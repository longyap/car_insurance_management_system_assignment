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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }


        string username = "admin";
        string password = "password";
        main_menu mainmenu = new main_menu();
       
        private void login_Load(object sender, EventArgs e)
        {
           
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            mainmenu.Show();
       /*    if ((user_textbox.Text == username )&& (password_textbox.Text ==password))
                {
                
                mainmenu.Show();
                this.Hide();
                 }
           else
            {
                MessageBox.Show("invalid username or password");
            }*/
        }

 
    }
    
}
