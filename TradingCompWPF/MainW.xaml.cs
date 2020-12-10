using System;
using DTO;
using BL;
using DAL.concrete;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TradingCompWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainW : Window
    {

        private StockManager stockManager;
        private UserDAL userDal;
        private string connectionString = "Data Source=localhost;Initial Catalog=StockManager;Integrated Security=True";
        public MainWindow()
        {   
            InitializeComponent();
            userDal = new UserDAL(connectionString);

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            for (int intCounter = App.Current.Windows.Count - 1; intCounter >= 0; intCounter--)
                App.Current.Windows[intCounter].Close();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            uint isLogIn = 0;
            UserDTO user = new UserDTO();
            user.Login = txt_Login.Text;
            user.Password = txt_Password.Text;
            isLogIn = userDal.LogIn(user);

            if (isLogIn != 0)
            {
                if (isLogIn == 1)
                {
                    user.Email = connectionString;
                    Userr = new userr(user);
                }
                else
                {
                    user.Email = connectionString;
                    Userr = new StockManager(user);
                }
                SList si = new SList(StockManager);
                this.Visibility = Visibility.Hidden;
                si.Show();
            }
        }

    }
}
