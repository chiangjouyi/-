using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 銷售系統
{
    public partial class AddOrder : Form
    {
        SqlConnectionStringBuilder scsb;

        public AddOrder()
        {
            InitializeComponent();
        }

        private void AddOrder_Load(object sender, EventArgs e)
        {
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            scsb.InitialCatalog = "SaleSystem";
            scsb.IntegratedSecurity = true;
            ccombox(); //客戶選單
            plist();   //產品選單
            cart();   //購物車
        }
        //取消新增訂單
        private void button_OM_Add_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        //客戶選單
        void ccombox()
        {
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSQL = "select C_Title from Customers";
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            DataSet ds = new DataSet();
            adpt.Fill(ds, "ctitle");

            for (int i = 0; i < ds.Tables["ctitle"].Rows.Count; i++)
            {
                comboBox_OM_Add_CTitle.Items.Add(ds.Tables["ctitle"].Rows[i][0]);
            }
        }
        private void comboBox_OM_Add_CTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSQL = "select *from Customers where C_Title like @SearchTitle";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@SearchTitle", "%" + comboBox_OM_Add_CTitle.Text + "%");
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read() == true)
            {
                label_OM_Add_CID.Text = string.Format("{0}", reader["C_ID"]);
                label_OM_Add_CPhone.Text = string.Format("{0}", reader["C_Phone"]);
                label_OM_Add_CAddress.Text = string.Format("{0}", reader["C_Address"]);
            }
            reader.Close();
            con.Close();
        }
        //產品選單
        public void plist()
        {
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSQL = "select P_ID, P_Name, P_UnitPrice from Products";
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            dataGridView_OM_Add_PList.DataSource = dt;
            pdgvout();
        }
        void pdgvout()
        {
            this.dataGridView_OM_Add_PList.ClearSelection();
            this.dataGridView_OM_Add_PList.Columns[0].Width = 50;
            this.dataGridView_OM_Add_PList.Columns[1].Width = 160;
            this.dataGridView_OM_Add_PList.Columns[2].Width = 65;
            this.dataGridView_OM_Add_PList.Columns[0].ReadOnly = true;
            this.dataGridView_OM_Add_PList.Columns[1].ReadOnly = true;
            this.dataGridView_OM_Add_PList.Columns[2].ReadOnly = true;
            this.dataGridView_OM_Add_PList.Columns[0].HeaderText = "編號";
            this.dataGridView_OM_Add_PList.Columns[1].HeaderText = "名稱";
            this.dataGridView_OM_Add_PList.Columns[2].HeaderText = "單價";
        }
        private void dataGridView_OM_Add_PList_MouseClick(object sender, MouseEventArgs e)
        {
            label_PID.Text = dataGridView_OM_Add_PList.SelectedRows[0].Cells[0].Value.ToString();
            label_OM_Add_SelectP.Text = dataGridView_OM_Add_PList.SelectedRows[0].Cells[1].Value.ToString();
            label_OM_Add_PUnitPrice.Text = dataGridView_OM_Add_PList.SelectedRows[0].Cells[2].Value.ToString();
           
            numericUpDown_OM_Add_Qty.Value = 1;
            int Qty = (int)numericUpDown_OM_Add_Qty.Value;
            int UnitPrice = Int32.Parse(label_OM_Add_PUnitPrice.Text);
            int sub = UnitPrice * Qty;
            label_OM_Add_SubP.Text = Convert.ToString(sub);
            label_OM_Add_SubP.Refresh();
        }
        //購買數量
        private void numericUpDown_OM_Add_Qty_ValueChanged(object sender, EventArgs e)
        {
            if (label_OM_Add_SelectP.Text != "")
            {
                int Qty = (int)numericUpDown_OM_Add_Qty.Value;
                int UnitPrice = Int32.Parse(label_OM_Add_PUnitPrice.Text);
                int sub = UnitPrice * Qty;
                label_OM_Add_SubP.Text = sub.ToString();
                label_OM_Add_SubP.Refresh();
            }
            else
            {
                numericUpDown_OM_Add_Qty.Value = 0;
            }
        }
        
        //購物車
        public void cart()
        {
            dataGridView_OM_Add_Cart.ColumnCount = 5;
            this.dataGridView_OM_Add_Cart.Columns[4].Visible = false;
            this.dataGridView_OM_Add_Cart.Columns[0].Width = 170;
            this.dataGridView_OM_Add_Cart.Columns[1].Width = 80;
            this.dataGridView_OM_Add_Cart.Columns[2].Width = 70;
            this.dataGridView_OM_Add_Cart.Columns[3].Width = 100;
            this.dataGridView_OM_Add_Cart.Columns[0].ReadOnly = true;
            this.dataGridView_OM_Add_Cart.Columns[1].ReadOnly = true;
            this.dataGridView_OM_Add_Cart.Columns[2].ReadOnly = true;
            this.dataGridView_OM_Add_Cart.Columns[3].ReadOnly = true;
            this.dataGridView_OM_Add_Cart.Columns[0].HeaderText = "產品";
            this.dataGridView_OM_Add_Cart.Columns[1].HeaderText = "單價";
            this.dataGridView_OM_Add_Cart.Columns[2].HeaderText = "數量";
            this.dataGridView_OM_Add_Cart.Columns[3].HeaderText = "單項小計";
            this.dataGridView_OM_Add_Cart.Columns[4].Name = "PID";
            this.dataGridView_OM_Add_Cart.Columns[1].Name = "單價";
            this.dataGridView_OM_Add_Cart.Columns[2].Name = "數量";
            this.dataGridView_OM_Add_Cart.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }
        //將產品加入購物車
        private void button_OM_Add_AddtoCart_Click(object sender, EventArgs e)
        {
            bool carthasit = false;

            if ((label_OM_Add_SelectP.Text != "") && (label_OM_Add_PUnitPrice.Text != "") && (numericUpDown_OM_Add_Qty.Value > 0))
            {
                for (int x = 0; x < dataGridView_OM_Add_Cart.Rows.Count; x++)
                {
                    if (dataGridView_OM_Add_Cart.Rows[x].Cells[4].Value.ToString() == label_PID.Text)
                    {
                        carthasit = true;
                    }
                }
                if (carthasit == false)
                {
                    dataGridView_OM_Add_Cart.Rows.Add(label_OM_Add_SelectP.Text, label_OM_Add_PUnitPrice.Text, numericUpDown_OM_Add_Qty.Value.ToString(), label_OM_Add_SubP.Text, label_PID.Text);
                    int subtotal = Convert.ToInt32(label_OM_Add_SubTotal.Text);
                    int sub = Convert.ToInt32(label_OM_Add_SubP.Text);
                    int SubTotal = subtotal + sub;
                    label_OM_Add_SubTotal.Text = SubTotal.ToString();
                    int intfreight = Convert.ToInt32(textBox_OM_Add_Freight.Text);
                    int Total = SubTotal + intfreight;
                    label_OM_Add_Total.Text = Total.ToString();                    
                    label_OM_Add_SelectP.Text = "";
                    label_OM_Add_PUnitPrice.Text = "";
                    numericUpDown_OM_Add_Qty.Value = 0;
                    label_OM_Add_SubP.Text = "";
                }
                else
                {
                    MessageBox.Show("購物車內已有該項產品，如欲更改數量請先將原先項目移除再重新選擇數量加入");
                }
            }
            else
            {
                MessageBox.Show("請選擇購買產品與數量");
            }
        }
        //運費
        private void textBox_OM_Add_Freight_TextChanged(object sender, EventArgs e)
        {           
            int intfreight = 0;
            bool iffreight =false;
            iffreight = System.Int32.TryParse(textBox_OM_Add_Freight.Text, out intfreight);
            if (iffreight)
            {
                int SubTotal = Convert.ToInt32(label_OM_Add_SubTotal.Text);            
                int Freight = Convert.ToInt32(textBox_OM_Add_Freight.Text);
                int Total = SubTotal + Freight;
                label_OM_Add_Total.Text = Total.ToString();
            }
            else
            { MessageBox.Show("運費請輸入正整數"); }
        }
        //移除購物車內產品
        private void button_OM_Add_RemovefromCart_Click(object sender, EventArgs e)
        {
            if (dataGridView_OM_Add_Cart.Rows.Count > 0)
            {
                int subtotal = Convert.ToInt32(label_OM_Add_SubTotal.Text);
                int sub = Convert.ToInt32(dataGridView_OM_Add_Cart.SelectedRows[0].Cells[3].Value.ToString());
                int SubTotal = subtotal - sub;
                int intfreight = Convert.ToInt32(textBox_OM_Add_Freight.Text);
                int Total = SubTotal + intfreight;
                label_OM_Add_SubTotal.Text = SubTotal.ToString();
                label_OM_Add_Total.Text = Total.ToString();
                dataGridView_OM_Add_Cart.Rows.RemoveAt(dataGridView_OM_Add_Cart.SelectedRows[0].Index);               
            }
            else
            {
                MessageBox.Show("購物車目前無任何產品");
            }
        }
        //確認新增訂單
        private void button_OM_Add_Add_Click(object sender, EventArgs e)
        {
            if (comboBox_OM_Add_CTitle.Text == "")
            {
                MessageBox.Show("請至少選擇客戶才能成立訂單");
            }
            else
            {
                SqlConnection con = new SqlConnection(scsb.ToString());
                con.Open();
                SqlCommand cmd = new SqlCommand("", con);
                SqlTransaction Transaction = con.BeginTransaction();
                cmd.Transaction = Transaction;
                try
                {
                    cmd.CommandText = "insert into Orders values(@NewCTitle,@NewOrderDate,@NewShippedDate,@NewPayStatus,@NewShipStatus,@NewNote,@NewFreight,@NewTotal,@NewShipVia); SELECT SCOPE_IDENTITY()";
                    cmd.Parameters.AddWithValue("@NewCTitle", label_OM_Add_CID.Text);
                    cmd.Parameters.AddWithValue("@NewOrderDate", (DateTime)dateTimePicker_OM_Add_ODate.Value);
                    cmd.Parameters.AddWithValue("@NewShippedDate", (DateTime)dateTimePicker_OM_Add_ShipDate.Value);
                    cmd.Parameters.AddWithValue("@NewPayStatus", "未收款");
                    cmd.Parameters.AddWithValue("@NewShipStatus", label_OM_Add_ShipViaStatus.Text);
                    cmd.Parameters.AddWithValue("@NewNote", textBox_OM_Add_ONote.Text);
                    cmd.Parameters.AddWithValue("@NewFreight", textBox_OM_Add_Freight.Text);
                    cmd.Parameters.AddWithValue("@NewTotal", label_OM_Add_Total.Text);
                    cmd.Parameters.AddWithValue("@NewShipVia", comboBox_OM_Add_ShipVia.Text);
                    int intNewOrderID = Convert.ToInt32(cmd.ExecuteScalar());
                    label_OM_Add_Ono.Text = intNewOrderID.ToString();
                    cmd.Parameters.AddWithValue("@NewOrderID", "");
                    cmd.Parameters.AddWithValue("@NewPID", "");
                    cmd.Parameters.AddWithValue("@NewPrice", "");
                    cmd.Parameters.AddWithValue("@NewQty", "");

                    for (int i = 0; i < dataGridView_OM_Add_Cart.Rows.Count; i++)
                    {
                        cmd.CommandText = "INSERT INTO OrderDetails Values(@NewOrderID,@NewPID,@NewPrice,@NewQty)";
                        cmd.Parameters["@NewOrderID"].Value = intNewOrderID.ToString();
                        cmd.Parameters["@NewPID"].Value = dataGridView_OM_Add_Cart.Rows[i].Cells["PID"].Value.ToString();
                        cmd.Parameters["@NewPrice"].Value = dataGridView_OM_Add_Cart.Rows[i].Cells["單價"].Value.ToString();
                        cmd.Parameters["@NewQty"].Value = dataGridView_OM_Add_Cart.Rows[i].Cells["數量"].Value.ToString();
                        cmd.ExecuteNonQuery();
                    }
                    Transaction.Commit();
                }
                finally { con.Close(); }
                Close();
                MessageBox.Show("訂單新增完畢");
            }
            
        }
        
        //自取或寄送
        private void comboBox_OM_Add_ShipVia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_OM_Add_ShipVia.Text == "自取")
            {
                label_OM_Add_ShipViaStatus.Text = "未取貨";
            }
            else if (comboBox_OM_Add_ShipVia.Text == "寄送")
            {
                label_OM_Add_ShipViaStatus.Text = "未出貨";
            }
        }

        private void AddOrder_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}




