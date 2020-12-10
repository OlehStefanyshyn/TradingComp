using System;
using DTO;
using TradingCompWPF.View;
using BL;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data;
using System.Configuration;
using System.Windows.Documents;
using System.Windows.Input;
using Microsoft.VisualBasic;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Drawing;

namespace TradingCompWPF
{
    /// <summary>
    /// Interaction logic for SList.xaml
    /// </summary>
    public class Item
    {
        public int item_id { get; set; }
        public string Name { get; set; }
        public string StockItem { get; set; }
        public string Stock { get; set; }
    }
    public partial class SList : Window
    {

        private StockManager stockManager;

        public SList(StockManager user)
        {
            InitializeComponent();
            StockManager = user;

            btnDelete.Visibility = btnAdd.Visibility = (stockManager.addRemovePermitions ? Visibility.Visible : Visibility.Hidden);
            updateTable(userManager.GetAll());
        }
        private void updateTable(List<(long ID, string FullName, string Title, string Text)> ls)
        {
            dataGridView1.Items.Clear();
            foreach (var row in ls)
            {
                Item it = new Item();
                it.item_id = row.ID;
                it.name = row.Name;
                it.StockItem = row.StockItem;
                it.Stock = row.Stock;
                dataGridView1.Items.Add(it);
            }
        }

        private void btnAddTopic_Click(object sender, EventArgs e)
        {
            string input_stockitem = Microsoft.VisualBasic.Interaction.InputBox("Input StockItem", "Add", "Item");
            string input_stock = Microsoft.VisualBasic.Interaction.InputBox("Input StockItem", "Add", "Stock");

            if (!string.IsNullOrEmpty(input_stockitem) &&
                !string.IsNullOrEmpty(input_stockitem) &&
                stockManager.AddTopic(input_stockitem, input_stock))
            {
                updateTable(stockManager.GetAll());
            }

        }


        private void dataGridView1_MouseRightButtonDown(object sender, EventArgs e)
        {
            updateTable(stockManager.GetAll());

        }
        private void btnDeleteTopic_Click(object sender, EventArgs e)
        {
            string input_id = Microsoft.VisualBasic.Interaction.InputBox("Input stockitem id!", "Delete", "item_id");

            if (!string.IsNullOrEmpty(input_id))
            {
                try
                {
                    if (userManager.DeleteTopic(Convert.ToInt64(input_id)) >= 0)
                    {
                        updateTable(userManager.GetAll());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Incorrect input data!\n" + ex.Message.ToString(), "Error");
                }
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            var mw = new MainW();
            mw.Show();
            this.Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            for (int intCounter = App.Current.Windows.Count - 1; intCounter >= 0; intCounter--)
                App.Current.Windows[intCounter].Close();
        }

        private void dataGridView1_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
