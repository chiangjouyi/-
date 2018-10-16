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
    public partial class EditOrder : Form
    {
        SqlConnectionStringBuilder scsb;
        public string OrderID = " ";

        public EditOrder()
        {
            InitializeComponent();
        }

        private void EditOrder_Load(object sender, EventArgs e)
        {
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            scsb.InitialCatalog = "SaleSystem";
            scsb.IntegratedSecurity = true;
            plist();
            label_OM_Edit_OrderID.Text = OrderID;
            cart();
            orderinfo();
            ordersubtotal();
        }
              
        //訂單資訊
        void orderinfo()
        {
            int intID = 0;
            Int32.TryParse(label_OM_Edit_OrderID.Text, out intID);
            if (intID > 0)
            {
                SqlConnection con = new SqlConnection(scsb.ToString());
                con.Open();
                string strSQL = "select o.C_ID,o.Order_ID,c.C_Title,c.C_Phone,o.Order_Date,o.ShipVia,o.Shipped_Date,c.C_Address,o.Order_Note,o.Payment_Status,o.Shipped_Status,o.Freight,o.Total,(Total-Freight) from Orders as o inner join Customers as c on o.C_ID = c.C_ID where o.Order_ID = @SearchOrderID";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@SearchOrderID", intID);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read() == true)
                {
                    label_OM_Edit_CID.Text = string.Format("{0}", reader["C_ID"]);
                    label_OM_Edit_Ono.Text = string.Format("{0}", reader["Order_ID"]);
                    label_OM_Edit_CTitle.Text = string.Format("{0}", reader["C_Title"]);
                    label_OM_Edit_CPhone.Text = string.Format("{0}", reader["C_Phone"]);
                    dateTimePicker_OM_Edit_ODate.Value = (DateTime)reader["Order_Date"];
                    comboBox_OM_Edit_ShipVia.Text = string.Format("{0}", reader["ShipVia"]);
                    dateTimePicker_OM_Edit_ShipDate.Value = (DateTime)reader["Shipped_Date"];
                    label_OM_Edit_CAddress.Text = string.Format("{0}", reader["C_Address"]);
                    textBox_OM_Edit_ONote.Text = string.Format("{0}", reader["Order_Note"]);
                    comboBox_OM_Edit_PaymentStatus.Text = string.Format("{0}", reader["Payment_Status"]);
                    comboBox_OM_Edit_ShippedStatus.Text = string.Format("{0}", reader["Shipped_Status"]);
                    textBox_OM_Edit_Freight.Text = string.Format("{0}", reader["Freight"]);
                    label_OM_Edit_Total.Text = string.Format("{0}", reader["Total"]);
                }
                reader.Close();
                con.Close();
            }
        }
        //訂單總項小計資訊
        void ordersubtotal()
        {
            int intID = 0;
            Int32.TryParse(label_OM_Edit_OrderID.Text, out intID);
            if (intID > 0)
            {
                SqlConnection con = new SqlConnection(scsb.ToString());
                con.Open();
                string strSQL = "select sum(p.P_UnitPrice*od.Quantity) as subtotal from OrderDetails as od inner join Products as p on od.P_ID = p.P_ID where od.Order_ID = @SearchOrderID group by od.Order_ID";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@SearchOrderID", intID);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read() == true)
                {
                    label_OM_Edit_SubTotal.Text = string.Format("{0}", reader["subtotal"]);
                }
                reader.Close();
                con.Close();
            }
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
            dataGridView_OM_Edit_PList.DataSource = dt;
            pdgvout();
        }
        void pdgvout()
        {
            this.dataGridView_OM_Edit_PList.Columns[0].Width = 50;
            this.dataGridView_OM_Edit_PList.Columns[1].Width = 170;
            this.dataGridView_OM_Edit_PList.Columns[2].Width = 65;
            this.dataGridView_OM_Edit_PList.Columns[0].ReadOnly = true;
            this.dataGridView_OM_Edit_PList.Columns[1].ReadOnly = true;
            this.dataGridView_OM_Edit_PList.Columns[2].ReadOnly = true;
            this.dataGridView_OM_Edit_PList.Columns[0].HeaderText = "編號";
            this.dataGridView_OM_Edit_PList.Columns[1].HeaderText = "名稱";
            this.dataGridView_OM_Edit_PList.Columns[2].HeaderText = "單價";
        }

        //選取產品
        private void dataGridView_OM_Edit_PList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label_PID.Text = dataGridView_OM_Edit_PList.SelectedRows[0].Cells[0].Value.ToString();
            label_OM_Edit_SelectP.Text = dataGridView_OM_Edit_PList.SelectedRows[0].Cells[1].Value.ToString();
            label_OM_Edit_PUnitPrice.Text = dataGridView_OM_Edit_PList.SelectedRows[0].Cells[2].Value.ToString();

            numericUpDown_OM_Edit_Qty.Value = 1;
            int Qty = (int)numericUpDown_OM_Edit_Qty.Value;
            int UnitPrice = Int32.Parse(label_OM_Edit_PUnitPrice.Text);
            int sub = UnitPrice * Qty;
            label_OM_Edit_SubP.Text = Convert.ToString(sub);
            label_OM_Edit_SubP.Refresh();
        }
        
        //購買數量
        private void numericUpDown_OM_Edit_Qty_ValueChanged(object sender, EventArgs e)
        {
            if (label_OM_Edit_SelectP.Text != "")
            {
                int Qty = (int)numericUpDown_OM_Edit_Qty.Value;
                int UnitPrice = Int32.Parse(label_OM_Edit_PUnitPrice.Text);
                int sub = UnitPrice * Qty;
                label_OM_Edit_SubP.Text = sub.ToString();
                label_OM_Edit_SubP.Refresh();
            }
            else
            {
                numericUpDown_OM_Edit_Qty.Value = 0;
            }
        }

        //購物車
        public void cart()
        {
            int intID = 0;
            Int32.TryParse(label_OM_Edit_OrderID.Text, out intID);
            if (intID > 0)
            {
                SqlConnection con = new SqlConnection(scsb.ToString());
                con.Open();
                string strSQL = "select p.P_Name,p.P_UnitPrice,od.Quantity, p.P_UnitPrice*od.Quantity,od.P_ID from OrderDetails as od inner join Products as p on od.P_ID = p.P_ID where od.Order_ID = @SearchOrderID";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@SearchOrderID", intID);
                SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
                DataTable dt = new DataTable();
                adpt.SelectCommand = cmd;
                adpt.Fill(dt);
                dataGridView_OM_Edit_Cart.DataSource = dt;
                cartout();
            }
        }
        void cartout()
        {
            this.dataGridView_OM_Edit_Cart.Columns[4].Visible = false;                
            this.dataGridView_OM_Edit_Cart.Columns[0].Width = 170;
            this.dataGridView_OM_Edit_Cart.Columns[1].Width = 80;
            this.dataGridView_OM_Edit_Cart.Columns[2].Width = 70;
            this.dataGridView_OM_Edit_Cart.Columns[3].Width = 100;
            this.dataGridView_OM_Edit_Cart.Columns[0].ReadOnly = true;
            this.dataGridView_OM_Edit_Cart.Columns[1].ReadOnly = true;
            this.dataGridView_OM_Edit_Cart.Columns[2].ReadOnly = true;
            this.dataGridView_OM_Edit_Cart.Columns[3].ReadOnly = true;
            this.dataGridView_OM_Edit_Cart.Columns[0].HeaderText = "產品";
            this.dataGridView_OM_Edit_Cart.Columns[1].HeaderText = "單價";
            this.dataGridView_OM_Edit_Cart.Columns[2].HeaderText = "數量";
            this.dataGridView_OM_Edit_Cart.Columns[3].HeaderText = "單項小計";
            this.dataGridView_OM_Edit_Cart.Columns[3].DefaultCellStyle.Alignment= DataGridViewContentAlignment.MiddleRight; 
        }
        
        //將產品加入購物車
        private void button_OM_Edit_AddtoCart_Click(object sender, EventArgs e)
        {
            bool carthasit = false;

            if ((label_OM_Edit_SelectP.Text != "") && (label_OM_Edit_PUnitPrice.Text != "") && (numericUpDown_OM_Edit_Qty.Value > 0))
            {
                for (int x = 0; x < dataGridView_OM_Edit_Cart.Rows.Count; x++)
                {
                    if (dataGridView_OM_Edit_Cart.Rows[x].Cells[4].Value.ToString() == label_PID.Text)
                    {
                        carthasit = true;
                    }
                }
                if (carthasit == false)
                {
                    SqlConnection con = new SqlConnection(scsb.ToString());
                    con.Open();
                    string strSQL = "insert into OrderDetails values(@NewOrderID,@NewPID,@NewUnitPrice,@NewQty)";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    cmd.Parameters.AddWithValue("@NewOrderID", label_OM_Edit_OrderID.Text);
                    cmd.Parameters.AddWithValue("@NewPID", label_PID.Text);
                    cmd.Parameters.AddWithValue("@NewUnitPrice", label_OM_Edit_PUnitPrice.Text);
                    cmd.Parameters.AddWithValue("@NewQty", numericUpDown_OM_Edit_Qty.Value.ToString());
                    int rows = cmd.ExecuteNonQuery();

                    string strSQL1 = "select p.P_Name,p.P_UnitPrice,od.Quantity, p.P_UnitPrice*od.Quantity,od.P_ID from OrderDetails as od inner join Products as p on od.P_ID = p.P_ID where od.Order_ID = " + label_OM_Edit_OrderID.Text + "";
                    SqlDataAdapter adpt = new SqlDataAdapter(strSQL1, con);
                    DataSet ds = new DataSet();
                    adpt.Fill(ds);
                    dataGridView_OM_Edit_Cart.DataSource = ds.Tables[0];
                    con.Close();
                    int subtotal = Convert.ToInt32(label_OM_Edit_SubTotal.Text);
                    int sub = Convert.ToInt32(label_OM_Edit_SubP.Text);
                    int SubTotal = subtotal + sub;
                    label_OM_Edit_SubTotal.Text = SubTotal.ToString();
                    int intfreight = Convert.ToInt32(textBox_OM_Edit_Freight.Text);
                    int Total = SubTotal + intfreight;
                    label_OM_Edit_Total.Text = Total.ToString();
                    label_OM_Edit_SelectP.Text = "";
                    label_OM_Edit_PUnitPrice.Text = "";
                    numericUpDown_OM_Edit_Qty.Value = 0;
                    label_OM_Edit_SubP.Text = "";
                    MessageBox.Show("加入購物車!");
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
        
        //從購物車移除產品
        private void button_OM_Edit_RemovefromCart_Click(object sender, EventArgs e)
        {
            if (dataGridView_OM_Edit_Cart.Rows.Count > 0)
            {                
                SqlConnection con = new SqlConnection(scsb.ToString());
                con.Open();
                string strSQL = "DELETE FROM OrderDetails WHERE  Order_ID="+ label_OM_Edit_OrderID .Text+ " and P_ID= "+ dataGridView_OM_Edit_Cart.SelectedRows[0].Cells[4].Value.ToString() +"";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.ExecuteNonQuery();
                con.Close();
                int subtotal = Convert.ToInt32(label_OM_Edit_SubTotal.Text);
                int sub = Convert.ToInt32(dataGridView_OM_Edit_Cart.SelectedRows[0].Cells[3].Value.ToString());
                int SubTotal = subtotal - sub;
                int intfreight = Convert.ToInt32(textBox_OM_Edit_Freight.Text);
                int Total = SubTotal + intfreight;
                label_OM_Edit_SubTotal.Text = SubTotal.ToString();
                label_OM_Edit_Total.Text = Total.ToString();
                dataGridView_OM_Edit_Cart.Rows.RemoveAt(dataGridView_OM_Edit_Cart.SelectedRows[0].Index);
            }
            else { MessageBox.Show("購物車已空!"); }
        }
        
        //修改運費
        private void textBox_OM_Edit_Freight_TextChanged(object sender, EventArgs e)
        {
            int intfreight = 0;
            bool iffreight = false;
            iffreight = System.Int32.TryParse(textBox_OM_Edit_Freight.Text, out intfreight);
            if (iffreight)
            {
                int SubTotal = Convert.ToInt32(label_OM_Edit_SubTotal.Text);
                int Freight = Convert.ToInt32(textBox_OM_Edit_Freight.Text);
                int Total = SubTotal + Freight;
                label_OM_Edit_Total.Text = Total.ToString();
            }
            else
            { MessageBox.Show("運費請輸入正整數"); }
        }
        
        //確認上傳更改資料
        private void button_OM_Edit_Add_Click(object sender, EventArgs e)
        {
            int intOrderID = 0;
            Int32.TryParse(label_OM_Edit_OrderID.Text, out intOrderID);

            if (intOrderID > 0)
            {
                SqlConnection con = new SqlConnection(scsb.ToString());
                con.Open();
                string strSQL = "update Orders set Order_Date=@NewODate, Shipped_Date=@NewSDate, Payment_Status=@NewPStatus, Shipped_Status=@NewSStatus, Order_Note=@NewNote,Freight=@NewFreight,ShipVia=@NewShipVia,Total=@NewTotal where Order_ID=@OriginalOrderID ";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@OriginalOrderID", intOrderID);
                cmd.Parameters.AddWithValue("@NewODate", (DateTime)dateTimePicker_OM_Edit_ODate.Value);
                cmd.Parameters.AddWithValue("@NewSDate", (DateTime)dateTimePicker_OM_Edit_ShipDate.Value);
                cmd.Parameters.AddWithValue("@NewPStatus", comboBox_OM_Edit_PaymentStatus.Text);
                cmd.Parameters.AddWithValue("@NewSStatus", comboBox_OM_Edit_ShippedStatus.Text);
                cmd.Parameters.AddWithValue("@NewNote", textBox_OM_Edit_ONote.Text);
                cmd.Parameters.AddWithValue("@NewFreight", textBox_OM_Edit_Freight.Text);
                cmd.Parameters.AddWithValue("@NewShipVia", comboBox_OM_Edit_ShipVia.Text);
                cmd.Parameters.AddWithValue("@NewTotal", label_OM_Edit_Total.Text);
                cmd.ExecuteNonQuery();//只執行不查詢
                con.Close();
                MessageBox.Show("資料編輯完畢");
            }
            else
            { }
            Close();
        }

        private void EditOrder_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
