using System;
using DTO;
using DAL.concrete;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BL;

namespace MainWF
{
    public partial class Login : Form
    {
        private StockManager StockManager;
        private UserDal userDal;
        private string connectionString = "Data Source=localhost;Initial Catalog=StockManager;Integrated Security=True";
        public Login()
        {
            InitializeComponent();
            userDal = new UserDal(connectionString);
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Really Quit?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                Application.Exit();

            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            uint isLogIn = 0;
            StockManagerDTO user = new StockManagerDTO();
            user.SM_login = txtUsername.Text;
            user.SM_password = txtPassword.Text;
            isLogIn = userDal.LogIn(user);

            if (isLogIn != 0)
            {
                if (isLogIn == 1)
                {
                    user.Email = connectionString;
                    StockManager = new stockManager(user);
                }
                else
                {
                    user.SM_email = connectionString;
                    StockManager = new AdminManager(user);
                }
                SList si = new SList(StockManager);
                this.Visible = false;
                si.Show();
            }
        }
    }
}
