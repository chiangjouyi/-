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
    public partial class ViewOrder : Form
    {
        SqlConnectionStringBuilder scsb;
        public string OrderID = " ";

        public ViewOrder()
        {
            InitializeComponent();
        }

        private void ViewOrder_Load(object sender, EventArgs e)
        {
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            scsb.InitialCatalog = "SaleSystem";
            scsb.IntegratedSecurity = true;
            label_OM_Edit_OrderID.Text = OrderID;
            cart();
            orderinfo();
            SubTotal();
        }

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

            this.dataGridView_OM_Edit_Cart.ClearSelection();
            this.dataGridView_OM_Edit_Cart.Columns[4].Visible = false;
            this.dataGridView_OM_Edit_Cart.Columns[0].Width = 140;
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
            this.dataGridView_OM_Edit_Cart.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        void orderinfo()
        {
            int intID = 0;
            Int32.TryParse(label_OM_Edit_OrderID.Text, out intID);
            if (intID > 0)
            {
                SqlConnection con = new SqlConnection(scsb.ToString());
                con.Open();
                string strSQL = "select o.Order_ID,c.C_Title,c.C_Phone,o.Order_Date,o.ShipVia,o.Shipped_Date,c.C_Address,o.Order_Note,o.Payment_Status,o.Shipped_Status,o.Freight,o.Total from Orders as o inner join Customers as c on o.C_ID = c.C_ID where o.Order_ID = @SearchOrderID";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@SearchOrderID", intID);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read() == true)
                {
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
                    label_OM_ViewOrder_Freight.Text = string.Format("{0}", reader["Freight"]);
                    label_OM_Edit_Total.Text = string.Format("{0}", reader["Total"]);
                }
                reader.Close();
                con.Close();
            }
        }


        void SubTotal()
        {
            int subtotal = 0;
            int freight = Convert.ToInt32(label_OM_ViewOrder_Freight.Text);
            int toatl = Convert.ToInt32(label_OM_Edit_Total.Text);
            subtotal = toatl - freight;
            label_OM_Edit_SubTotal.Text = subtotal.ToString();
        }
    }
}
