using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6
{
    public partial class AddItem : Form
    {
        private Form1 form;
        public AddItem(Form1 parentForm)
        {
            InitializeComponent();
            form = parentForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int itemNum = Convert.ToInt32(textBox1.Text);
                string itemName = textBox2.Text;
                double itemPrice = Convert.ToDouble(textBox3.Text);

                InventoryDB.SaveItems(new List<InventoryItem> { new InventoryItem(itemNum, itemName, (decimal)itemPrice) });
                this.Close();
                form.RefreshItems(); 
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid input. Please enter valid data.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
