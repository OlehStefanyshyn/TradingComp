using BL;
using DTO;
using System;
using System.Windows.Forms;

namespace MainWF
{
    public partial class NewStockItemForm : Form
    {
        private readonly IUser _shipper;
        public NewStockItemForm(IUser shipper)
        {
            _shipper = shipper;
            InitializeComponent();
        }

        private void newItemForm_Load(object sender, EventArgs e)
        {

        }

        private void newItemConfirmButton_Click(object sender, EventArgs e)
        {
          

            if (newStockItemName.Text.Length==0|| newStockItemStock.Text.Length == 0)
            {
                MessageBox.Show("Invalid data");
            }
            else
            {
                StockItemDTO newStockItem = new StockItemDTO
                {
                    Name = newItemName.Text,
                    Price = Convert.ToDouble(newItemPrice.Text),
                };
                _shipper.AddItem(newItem);
                MessageBox.Show("Item was successfully created!");
                this.Close();
            }
        }
    }
}