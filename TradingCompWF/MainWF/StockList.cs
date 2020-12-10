using BL
using DTO;
using DAL.concrete;
using DAL.interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MainWF
{
    public partial class StockList : Form
    {
        private StockManager StockManager;

        public SList(StockManager user)
        {
            InitializeComponent();
            StockManager = user;
            btnDelete.Visible = btnAdd.Visible =  StockManager.addRemovePermitions;
            updateTable(StockManager.GetAll());
        }
        private void updateTable(List<(item_id, string Name, string StockItem, string Stock)> ls)
        {
            dataGridView1.Rows.Clear();
            foreach (var row in ls)
            {
                int rowNumber = dataGridView1.Rows.Add();
                dataGridView1.Rows[rowNumber].Cells["columnID"].Value = row.SM_id;
                dataGridView1.Rows[rowNumber].Cells["columnName"].Value = row.SM_name;
                dataGridView1.Rows[rowNumber].Cells["columnStockItem"].Value = row.StockItem;
                dataGridView1.Rows[rowNumber].Cells["columnStock"].Value = row.Stock;
            }
        }

        private void LoadData()
        {
            string connectionString = "Data Source=localhost;Initial Catalog=StockManager;Integrated Security=True";

            SqlConnection myConnection = new SqlConnection(connectionString);

            myConnection.Open();

            string query = "SELECT * FROM Items ORDER BY item_id";
            SqlCommand command = new SqlCommand(query, myConnection);

            SqlDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[3]);
                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
            }

            reader.Close();
            myConnection.Close();

            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string input_stockitem = Microsoft.VisualBasic.Interaction.InputBox("Input StockItem", "Add", "Item");
            string input_stock = Microsoft.VisualBasic.Interaction.InputBox("Input StockItem", "Add", "Stock");
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string input_comment = Microsoft.VisualBasic.Interaction.InputBox("What do you want to find? Input Title!", "Find", "Smth from Title");
            if (!string.IsNullOrEmpty(input_comment))
            {
                updateTable(userManager.Find(input_comment));
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string input_id = Microsoft.VisualBasic.Interaction.InputBox("Input Stock Item Id!", "Delete", "item_id");

            if (!string.IsNullOrEmpty(input_item_id))
            {
                try
                {
                    if (userManager.DeleteTopic(Convert.ToInt64(input_item_id)) >= 0)
                    {
                        updateTable(StockManager.GetAll());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Incorrect input data!\n" + ex.Message.ToString(), "Error", MessageBoxButtons.OK,
                                                 MessageBoxIcon.Error);
                }
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Really LogOut?", "LogOut", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                Application.Restart();

            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Really Quit?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                Application.Exit();

            }
        }

    }
}
