using System;
using System.Collections;
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
    public partial class MainPage : Form
    {
        SqlConnectionStringBuilder scsb;

        public MainPage()
        {
            InitializeComponent();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            scsb.InitialCatalog = "SaleSystem";
            scsb.IntegratedSecurity = true;
            showodata();
            occombox();
            showcdata();
            ccombox();
            showpdata();
            pcombox();
            listboxwithallpidsinorders();
            canlsccombox();
        }
        private void MainPage_MouseClick(object sender, MouseEventArgs e)
        {
            dataGridView_OM.ClearSelection();
            dataGridView_PM.ClearSelection();
            dataGridView_CM.ClearSelection();
        }

        //******CM******
        private void tabPage_CM_Click(object sender, EventArgs e)
        {
            dataGridView_CM.ClearSelection();
            comboBox_CM_CTitle.Text = "";
            textBox_CM_CPhone.Text = "";
            textBox_CM_CAddress.Text = "";
            textBox_CM_CNote.Text = "";
        }      
        //All Customers DGV
        public void showcdata()
        {
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSQL = "select C_ID,C_Title,C_Phone,C_Address,C_Note from Customers";
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            dataGridView_CM.DataSource = dt;
            cdgvout();
        }
        void cdgvout()
        {
            this.dataGridView_CM.ClearSelection();
            this.dataGridView_CM.Columns["C_ID"].Visible = false;
            this.dataGridView_CM.Columns[1].Width = 115;
            this.dataGridView_CM.Columns[2].Width = 150;
            this.dataGridView_CM.Columns[3].Width = 425;
            this.dataGridView_CM.Columns[4].Width = 210;
            this.dataGridView_CM.Columns[1].ReadOnly = true;
            this.dataGridView_CM.Columns[2].ReadOnly = true;
            this.dataGridView_CM.Columns[3].ReadOnly = true;
            this.dataGridView_CM.Columns[4].ReadOnly = true;
            this.dataGridView_CM.Columns[1].HeaderText = "客戶稱呼";
            this.dataGridView_CM.Columns[2].HeaderText = "連絡電話";
            this.dataGridView_CM.Columns[3].HeaderText = "寄件地址";
            this.dataGridView_CM.Columns[4].HeaderText = "備註";
        }
        private void dataGridView_CM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox_CM_CTitle.Text = dataGridView_CM.SelectedRows[0].Cells[1].Value.ToString();
            textBox_CM_CPhone.Text = dataGridView_CM.SelectedRows[0].Cells[2].Value.ToString();
            textBox_CM_CAddress.Text = dataGridView_CM.SelectedRows[0].Cells[3].Value.ToString();
            textBox_CM_CNote.Text = dataGridView_CM.SelectedRows[0].Cells[4].Value.ToString();
            label_CM_CID.Text = dataGridView_CM.SelectedRows[0].Cells[0].Value.ToString();//最後要隱藏
        }       
        //Customers Titles
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
                comboBox_CM_CTitle.Items.Add(ds.Tables["ctitle"].Rows[i][0]);
            }
        }        
        private void comboBox_CM_CTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSQL = "select *from Customers where C_Title like '%" + comboBox_CM_CTitle.Text + "%'";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read() == true)
            {
                textBox_CM_CPhone.Text = string.Format("{0}", reader["C_Phone"]);
                textBox_CM_CAddress.Text = string.Format("{0}", reader["C_Address"]);
                textBox_CM_CNote.Text = string.Format("{0}", reader["C_Note"]);
            }
            reader.Close();
            con.Close();
        }        
        //Search Customer
        private void button__CM_Search_Click(object sender, EventArgs e)
        {
            if ((comboBox_CM_CTitle.Text != "") && (textBox_CM_CPhone.Text == ""))
            {
                SqlConnection con = new SqlConnection(scsb.ToString());
                con.Open();
                string strSQL = "select *from Customers where C_Title like '%" + comboBox_CM_CTitle.Text + "%'";
                SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
                DataSet ds = new DataSet();
                adpt.Fill(ds);
                dataGridView_CM.DataSource = ds.Tables[0];
                cdgvout();
                con.Close();
            }
            else if ((comboBox_CM_CTitle.Text == "") && (textBox_CM_CPhone.Text != ""))
            {
                SqlConnection con = new SqlConnection(scsb.ToString());
                con.Open();
                string strSQL = "select *from Customers where C_Phone like '%" + textBox_CM_CPhone.Text + "%'";
                SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
                DataSet ds = new DataSet();
                adpt.Fill(ds);
                dataGridView_CM.DataSource = ds.Tables[0];
                cdgvout();
                con.Close();
            }
            else if ((comboBox_CM_CTitle.Text != "") && (textBox_CM_CPhone.Text != ""))
            {
                SqlConnection con = new SqlConnection(scsb.ToString());
                con.Open();
                string strSQL = "select *from Customers where C_Title like '%" + comboBox_CM_CTitle.Text + "%' and C_Phone like '%" + textBox_CM_CPhone.Text + "%'";
                SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
                DataSet ds = new DataSet();
                adpt.Fill(ds);
                dataGridView_CM.DataSource = ds.Tables[0];
                cdgvout();
                con.Close();
            }
            else
            {
                MessageBox.Show("請輸入客戶稱呼或電話搜尋");
            }
        }
        private void button__CM_BlankSearch_Click(object sender, EventArgs e)
        {
            comboBox_CM_CTitle.Text = "";
            textBox_CM_CPhone.Text = "";
            textBox_CM_CAddress.Text = "";
            textBox_CM_CNote.Text = "";
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSQL = "select *from Customers";
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            dataGridView_CM.DataSource = ds.Tables[0];
            cdgvout();
            con.Close();
        }
        //Add Customer
        private void button_CM_Add_Click(object sender, EventArgs e)
        {
            if ((comboBox_CM_CTitle.Text != "") || (textBox_CM_CPhone.Text != "") || (textBox_CM_CAddress.Text != "") || (textBox_CM_CNote.Text != ""))
            {
                SqlConnection con = new SqlConnection(scsb.ToString());
                con.Open();
                string strSQL = "insert into Customers values(@NewTitle,@NewPhone,@NewAddress,@NewNote)";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@NewTitle", comboBox_CM_CTitle.Text);
                cmd.Parameters.AddWithValue("@NewPhone", textBox_CM_CPhone.Text);
                cmd.Parameters.AddWithValue("@NewAddress", textBox_CM_CAddress.Text);
                cmd.Parameters.AddWithValue("@NewNote", textBox_CM_CNote.Text);
                int rows = cmd.ExecuteNonQuery();
                string strSQL1 = "select *from Customers";
                SqlDataAdapter adpt = new SqlDataAdapter(strSQL1, con);
                DataSet ds = new DataSet();
                adpt.Fill(ds);
                dataGridView_CM.DataSource = ds.Tables[0];
                con.Close();
                comboBox_CM_CTitle.Text = "";
                textBox_CM_CPhone.Text = "";
                textBox_CM_CAddress.Text = "";
                textBox_CM_CNote.Text = "";
                MessageBox.Show("客戶資料新增完畢");
                comboBox_CM_CTitle.Items.Clear();
                comboBox_SaleAnls_Customers.Items.Clear();
                comboBox_OM_CTitle.Items.Clear();
                occombox();
                ccombox();
                canlsccombox();
            }
            else
            {
                MessageBox.Show("請輸入至少一項新資料");
            }
        }
        //Delete Customer
        private void button_CM_Delete_Click(object sender, EventArgs e)
        {
            if ((comboBox_CM_CTitle.Text == "") && (textBox_CM_CPhone.Text == "") && (textBox_CM_CAddress.Text == "") && (textBox_CM_CNote.Text == ""))
            {
                MessageBox.Show("請選擇欲刪除客戶資料列");
            }
            else
            {
                bool inOrder = false;
                for (int x = 0; x < dataGridView_OM.Rows.Count; x++)
                {
                    if (dataGridView_OM.Rows[x].Cells[2].Value.ToString() == comboBox_CM_CTitle.Text)
                    {
                        inOrder = true;
                    }
                }
                if (inOrder == false)
                {
                    DialogResult drResult;
                    drResult = MessageBox.Show("確認刪除該筆客戶資料嗎?", "刪除客戶資料", MessageBoxButtons.OKCancel);
                    if (drResult == DialogResult.Cancel)
                    {
                        dataGridView_CM.ClearSelection();
                    }
                    else
                    {
                        SqlConnection con = new SqlConnection(scsb.ToString());
                        con.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = "delete from Customers where C_ID =" + dataGridView_CM.SelectedRows[0].Cells[0].Value.ToString() + "";
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                        con.Close();
                        dataGridView_CM.Rows.RemoveAt(dataGridView_CM.SelectedRows[0].Index);
                        comboBox_CM_CTitle.Text = "";
                        textBox_CM_CPhone.Text = "";
                        textBox_CM_CAddress.Text = "";
                        textBox_CM_CNote.Text = "";
                        label_CM_CID.Text = "";
                        MessageBox.Show("該客戶資料已刪除");
                        comboBox_CM_CTitle.Items.Clear();
                        comboBox_SaleAnls_Customers.Items.Clear();
                        comboBox_OM_CTitle.Items.Clear();
                        occombox();
                        ccombox();
                        canlsccombox();
                    }
                }
                else
                {
                    MessageBox.Show("此客戶存在於訂單中,若欲刪除請先將其訂單均刪除");
                }
            }
        }
       //Edit Customer
        private void button_CM_Edit_Click(object sender, EventArgs e)
        {
            if ((comboBox_CM_CTitle.Text == "") && (textBox_CM_CPhone.Text == "") && (textBox_CM_CAddress.Text == "") && (textBox_CM_CNote.Text == ""))
            {
                MessageBox.Show("請選擇欲修改客戶資料列");
            }
            else
            {
                DialogResult drResult;
                drResult = MessageBox.Show("確認修改該筆客戶資料嗎?", "修改客戶資料", MessageBoxButtons.OKCancel);
                if (drResult == DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                    int intID = 0;
                    Int32.TryParse(label_CM_CID.Text, out intID);

                    if (intID > 0)
                    {
                        SqlConnection con = new SqlConnection(scsb.ToString());
                        con.Open();
                        string strSQL = "update Customers set C_Title=@NewTitle, C_Phone=@NewPhone, C_Address=@NewAddress, C_Note=@NewNote where C_ID=@SearchID";
                        SqlCommand cmd = new SqlCommand(strSQL, con);
                        cmd.Parameters.AddWithValue("@SearchID", intID);
                        cmd.Parameters.AddWithValue("@NewTitle", comboBox_CM_CTitle.Text);
                        cmd.Parameters.AddWithValue("@NewPhone", textBox_CM_CPhone.Text);
                        cmd.Parameters.AddWithValue("@NewAddress", textBox_CM_CAddress.Text);
                        cmd.Parameters.AddWithValue("@NewNote", textBox_CM_CNote.Text);
                        int rows = cmd.ExecuteNonQuery();
                        string strSQL1 = "select *from Customers";
                        SqlDataAdapter adpt = new SqlDataAdapter(strSQL1, con);
                        DataSet ds = new DataSet();
                        adpt.Fill(ds);
                        dataGridView_CM.DataSource = ds.Tables[0];
                        con.Close();
                        comboBox_CM_CTitle.Text = "";
                        textBox_CM_CPhone.Text = "";
                        textBox_CM_CAddress.Text = "";
                        textBox_CM_CNote.Text = "";
                        MessageBox.Show("客戶資料修改完畢");
                        comboBox_CM_CTitle.Items.Clear();
                        comboBox_SaleAnls_Customers.Items.Clear();
                        comboBox_OM_CTitle.Items.Clear();
                        occombox();
                        ccombox();
                        canlsccombox();
                    }
                }
            }
        }

        
        
        
        //******PM******
        private void tabPage_PM_Click(object sender, EventArgs e)
        {
            dataGridView_PM.ClearSelection();
            comboBox_PM_PName.Text = "";
            textBox_PM_PID.Text = "";
            textBox_PM_PSpec.Text = "";
            textBox_PM_PUnitPrice.Text = "";
        }
        //All Products DGV
        public void showpdata()
        {
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSQL = "select P_ID,P_Name,P_Spec,P_UnitPrice from Products";
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            dataGridView_PM.DataSource = dt;
            pdgvout();
        }
        void pdgvout()
        {
            this.dataGridView_PM.ClearSelection();
            this.dataGridView_PM.Columns[0].Width = 120;
            this.dataGridView_PM.Columns[1].Width = 250;
            this.dataGridView_PM.Columns[2].Width = 180;
            this.dataGridView_PM.Columns[3].Width = 130;
            this.dataGridView_PM.Columns[0].ReadOnly = true;
            this.dataGridView_PM.Columns[1].ReadOnly = true;
            this.dataGridView_PM.Columns[2].ReadOnly = true;
            this.dataGridView_PM.Columns[3].ReadOnly = true;
            this.dataGridView_PM.Columns[0].HeaderText = "產品編號";
            this.dataGridView_PM.Columns[1].HeaderText = "產品名稱";
            this.dataGridView_PM.Columns[2].HeaderText = "規格";
            this.dataGridView_PM.Columns[3].HeaderText = "單價";
        }
        private void dataGridView_PM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox_PM_PName.Text = dataGridView_PM.SelectedRows[0].Cells[1].Value.ToString();
            textBox_PM_PID.Text = dataGridView_PM.SelectedRows[0].Cells[0].Value.ToString();
            textBox_PM_PSpec.Text = dataGridView_PM.SelectedRows[0].Cells[2].Value.ToString();
            textBox_PM_PUnitPrice.Text = dataGridView_PM.SelectedRows[0].Cells[3].Value.ToString();
        }
        //Products Name
        void pcombox()
        {
            SqlConnection con = new SqlConnection(scsb.ToString());
            string strSQL = "select P_Name from Products";
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            DataSet ds = new DataSet();
            adpt.Fill(ds, "pname");

            for (int i = 0; i < ds.Tables["pname"].Rows.Count; i++)
            {
                comboBox_PM_PName.Items.Add(ds.Tables["pname"].Rows[i][0]);
            }
        }       
        private void comboBox_PM_PName_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSQL = "select *from Products where P_Name like '%" + comboBox_PM_PName.Text + "%'";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read() == true)
            {
                textBox_PM_PID.Text = string.Format("{0}", reader["P_ID"]);
                textBox_PM_PSpec.Text = string.Format("{0}", reader["P_Spec"]);
                textBox_PM_PUnitPrice.Text = string.Format("{0}", reader["P_UnitPrice"]);
            }
            reader.Close();
            con.Close();
        }
        //Search Product
        private void button__PM_Search_Click(object sender, EventArgs e)
        {
            if (comboBox_PM_PName.Text != "")
            {
                SqlConnection con = new SqlConnection(scsb.ToString());
                con.Open();
                string strSQL = "select *from Products where P_Name like '%" + comboBox_PM_PName.Text + "%'";
                SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
                DataSet ds = new DataSet();
                adpt.Fill(ds);
                dataGridView_PM.DataSource = ds.Tables[0];
                cdgvout();
                con.Close();
            }
            else
            {
                MessageBox.Show("請輸入產品名稱搜尋");
            }
        }
        private void button__PM_BlankSearch_Click(object sender, EventArgs e)
        {
            comboBox_PM_PName.Text = "";
            textBox_PM_PID.Text = "";
            textBox_PM_PSpec.Text = "";
            textBox_PM_PUnitPrice.Text = "";
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSQL = "select *from Products";
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            dataGridView_PM.DataSource = ds.Tables[0];
            cdgvout();
            con.Close();
        }
        //Add Product
        private void button_PM_Add_Click(object sender, EventArgs e)
        {
            if (textBox_PM_PID.Text == "")
            {
                MessageBox.Show("請建立產品編號");
            }
            else
            {
                int newPID = 0;
                int newPrice = 0;
                bool ifNum = System.Int32.TryParse(textBox_PM_PID.Text, out newPID);
                bool ifPrice = System.Int32.TryParse(textBox_PM_PUnitPrice.Text, out newPrice);
                bool pidexists = false;
                for (int x = 0; x < dataGridView_PM.Rows.Count; x++)
                {
                    if (dataGridView_PM.Rows[x].Cells[0].Value.ToString() == textBox_PM_PID.Text)
                    {
                        pidexists = true;
                    }
                }
                if ((ifNum == true) &&(ifPrice==true)&& (newPID > 0) &&(newPrice>0) && (pidexists == false))
                {
                    SqlConnection con = new SqlConnection(scsb.ToString());
                    con.Open();
                    string strSQL = "insert into Products values(@NewID,@NewName,@NewSpec,@NewPrice)";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    cmd.Parameters.AddWithValue("@NewID", textBox_PM_PID.Text);
                    cmd.Parameters.AddWithValue("@NewName", comboBox_PM_PName.Text);
                    cmd.Parameters.AddWithValue("@NewSpec", textBox_PM_PSpec.Text);
                    cmd.Parameters.AddWithValue("@NewPrice", textBox_PM_PUnitPrice.Text);
                    int rows = cmd.ExecuteNonQuery();
                    string strSQL1 = "select *from Products";
                    SqlDataAdapter adpt = new SqlDataAdapter(strSQL1, con);
                    DataSet ds = new DataSet();
                    adpt.Fill(ds);
                    dataGridView_PM.DataSource = ds.Tables[0];
                    pdgvout();
                    con.Close();
                    comboBox_PM_PName.Text = "";
                    textBox_PM_PID.Text = "";
                    textBox_PM_PSpec.Text = "";
                    textBox_PM_PUnitPrice.Text = "";
                    MessageBox.Show("產品資料新增完畢");
                    comboBox_PM_PName.Items.Clear();
                    pcombox();
                }
                else
                {
                    MessageBox.Show("產品編號請輸入不與現有編號重複之正整數\n請注意價格");
                }
            }
        }
        //Delete Product
        //Get All P_IDs which in OrderDetails
        public void listboxwithallpidsinorders()
        {
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSQL = "select distinct P_ID from OrderDetails";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                listBox_OM_PIDsInAllOrders.Items.Add(reader["P_ID"]);
            }
            reader.Close();
            con.Close();
        }
        private void button_PM_Delete_Click(object sender, EventArgs e)
        {
            bool inOrder = false;
            foreach (var item in listBox_OM_PIDsInAllOrders.Items)
            {
                if (item.ToString() == textBox_PM_PID.Text)
                {
                    inOrder=true;
                }
            }
            if (textBox_PM_PID.Text == "")
            {
                MessageBox.Show("請選擇欲刪除產品資料列");
            }
            else
            {
                if (inOrder ==false)
                {
                    SqlConnection con = new SqlConnection(scsb.ToString());
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "delete from Products where P_ID =" + dataGridView_PM.SelectedRows[0].Cells[0].Value.ToString() + "";
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    dataGridView_PM.Rows.RemoveAt(dataGridView_PM.SelectedRows[0].Index);
                    pdgvout();
                    comboBox_PM_PName.Text = "";
                    textBox_PM_PID.Text = "";
                    textBox_PM_PSpec.Text = "";
                    textBox_PM_PUnitPrice.Text = "";
                    MessageBox.Show("該產品資料已刪除");
                    comboBox_PM_PName.Items.Clear();
                    pcombox();
                }
                else
                {                  
                    MessageBox.Show("此產品存在於訂單中,若欲刪除請先將其訂單均刪除");
                }
            }
        }
        //Edit Product
        private void button_PM_Edit_Click(object sender, EventArgs e)
        {
            if (textBox_PM_PID.Text == "")
            {
                MessageBox.Show("請選擇欲修改產品資料列");
            }
            else
            {
                DialogResult drResult;
                drResult = MessageBox.Show("確認修改該筆產品資料嗎?", "修改產品資料", MessageBoxButtons.OKCancel);
                if (drResult == DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                    int intID = 0;
                    Int32.TryParse(textBox_PM_PID.Text, out intID);

                    if (intID > 0)
                    {
                        SqlConnection con = new SqlConnection(scsb.ToString());
                        con.Open();
                        string strSQL = "update Products set P_Name=@NewName, P_Spec=@NewSpec, P_UnitPrice=@NewUnitPrice where P_ID=@SearchID";
                        SqlCommand cmd = new SqlCommand(strSQL, con);
                        cmd.Parameters.AddWithValue("@SearchID", intID);
                        cmd.Parameters.AddWithValue("@NewName", comboBox_PM_PName.Text);
                        cmd.Parameters.AddWithValue("@NewSpec", textBox_PM_PSpec.Text);
                        cmd.Parameters.AddWithValue("@NewUnitPrice", textBox_PM_PUnitPrice.Text);
                        int rows = cmd.ExecuteNonQuery();

                        string strSQL1 = "select *from Products";
                        SqlDataAdapter adpt = new SqlDataAdapter(strSQL1, con);
                        DataSet ds = new DataSet();
                        adpt.Fill(ds);
                        dataGridView_PM.DataSource = ds.Tables[0];
                        con.Close();
                        comboBox_PM_PName.Text = "";
                        textBox_PM_PID.Text = "";
                        textBox_PM_PSpec.Text = "";
                        textBox_PM_PUnitPrice.Text = "";
                        MessageBox.Show("產品資料修改完畢");
                        comboBox_PM_PName.Items.Clear();
                        pcombox();
                    }
                }
            }
        }




        //******OM******
        private void tabPage_OM_Click(object sender, EventArgs e)
        {
            dataGridView_OM.ClearSelection();
        }
        //All Orders DGV
        public void showodata()
        {
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSQL = "select o.Order_ID,o.Order_Date,c.C_Title,c.C_Phone,o.Total,o.Payment_Status,o.Shipped_Status,o.Shipped_Date from Orders as o inner join Customers as c on o.C_ID = c.C_ID";
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            dataGridView_OM.DataSource = dt;
            odgvout();
        }
        void odgvout()
        {
            this.dataGridView_OM.ClearSelection();
            //this.dataGridView_OM.Columns["Order_ID"].Visible = false;
            this.dataGridView_OM.Columns[0].Width = 70;
            this.dataGridView_OM.Columns[1].Width = 120;
            this.dataGridView_OM.Columns[2].Width = 110;
            this.dataGridView_OM.Columns[3].Width = 140;
            this.dataGridView_OM.Columns[4].Width = 100;
            this.dataGridView_OM.Columns[5].Width = 100;
            this.dataGridView_OM.Columns[6].Width = 145;
            this.dataGridView_OM.Columns[7].Width = 140;
            this.dataGridView_OM.Columns[0].ReadOnly = true;
            this.dataGridView_OM.Columns[1].ReadOnly = true;
            this.dataGridView_OM.Columns[2].ReadOnly = true;
            this.dataGridView_OM.Columns[3].ReadOnly = true;
            this.dataGridView_OM.Columns[4].ReadOnly = true;
            this.dataGridView_OM.Columns[5].ReadOnly = true;
            this.dataGridView_OM.Columns[6].ReadOnly = true;
            this.dataGridView_OM.Columns[7].ReadOnly = true;
            this.dataGridView_OM.Columns[0].HeaderText = "編號";
            this.dataGridView_OM.Columns[1].HeaderText = "下單日期";
            this.dataGridView_OM.Columns[2].HeaderText = "購買客戶";
            this.dataGridView_OM.Columns[3].HeaderText = "連絡電話";
            this.dataGridView_OM.Columns[4].HeaderText = "應付總額";
            this.dataGridView_OM.Columns[5].HeaderText = "收款進度";
            this.dataGridView_OM.Columns[6].HeaderText = "出貨/取貨進度";
            this.dataGridView_OM.Columns[7].HeaderText = "出貨/取貨日期";
            this.dataGridView_OM.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView_OM.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView_OM.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView_OM.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView_OM.Columns[1].DefaultCellStyle.Format = "yyyy-MM-dd";
            this.dataGridView_OM.Columns[7].DefaultCellStyle.Format = "yyyy-MM-dd";
            this.dataGridView_OM.Columns[1].DefaultCellStyle.Font = new Font("微軟正黑體", 12, FontStyle.Bold); ;
            this.dataGridView_OM.Columns[7].DefaultCellStyle.Font= new Font("微軟正黑體", 12, FontStyle.Bold); ;
        }
        private void dataGridView_OM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label_OM_OrderID.Text = dataGridView_OM.SelectedRows[0].Cells[0].Value.ToString();             
        }
        //***Search Order***
        private void button__OM_Search_Click(object sender, EventArgs e)
        {
            if (dataGridView_OM.SelectedRows.Count > 0)
            {
                ViewOrder ViewOrderForm = new ViewOrder();
                ViewOrderForm.OrderID = label_OM_OrderID.Text.ToString();
                ViewOrderForm.ShowDialog();
            }
            else { MessageBox.Show("請選取欲查詢訂單"); }
        }
        private void button__OM_BlankSearch_Click(object sender, EventArgs e)
        {
            comboBox_OM_CTitle.Text = "";
            textBox_OM_CPhone.Text = "";
            comboBox_OM_PaymentStatus.Text = "";
            comboBox_OM_ShippedStatus.Text = "";
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSQL = "select o.Order_ID,o.Order_Date,c.C_Title,c.C_Phone,o.Total,o.Payment_Status,o.Shipped_Status,o.Shipped_Date from Orders as o inner join Customers as c on o.C_ID = c.C_ID";
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            dataGridView_OM.DataSource = ds.Tables[0];
            odgvout();
            con.Close();
        }
        //C_Title ComboBox
        void occombox()
        {
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSQL = "select C_Title from Customers";
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            DataSet ds = new DataSet();
            adpt.Fill(ds, "ctitle");

            for (int i = 0; i < ds.Tables["ctitle"].Rows.Count; i++)
            {
                comboBox_OM_CTitle.Items.Add(ds.Tables["ctitle"].Rows[i][0]);
            }
        }
        //AutoSearch
        void searchOrder()
        {
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            if ((comboBox_OM_CTitle.Text != "") && (textBox_OM_CPhone.Text == "") && (comboBox_OM_PaymentStatus.Text == "") && (comboBox_OM_ShippedStatus.Text == ""))
            {
                string strSQL = "SELECT o.Order_ID,o.Order_Date,c.C_Title,c.C_Phone,o.Total,o.Payment_Status,o.Shipped_Status,o.Shipped_Date FROM Orders as o inner join Customers as c on o.C_ID=c.C_ID where c.C_Title LIKE '%" + comboBox_OM_CTitle.Text + "%'";
                SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                dataGridView_OM.DataSource = dt;
                odgvout();
            }
            else if ((comboBox_OM_CTitle.Text == "") && (textBox_OM_CPhone.Text != "") && (comboBox_OM_PaymentStatus.Text == "") && (comboBox_OM_ShippedStatus.Text == ""))
            {
                string strSQL = "SELECT o.Order_ID,o.Order_Date,c.C_Title,c.C_Phone,o.Total,o.Payment_Status,o.Shipped_Status,o.Shipped_Date FROM Orders as o inner join Customers as c on  o.C_ID=c.C_ID where c.C_Phone LIKE '%" + textBox_OM_CPhone.Text + "%'";
                SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                dataGridView_OM.DataSource = dt;
                odgvout();
            }
            else if ((comboBox_OM_CTitle.Text == "") && (textBox_OM_CPhone.Text == "") && (comboBox_OM_PaymentStatus.Text != "") && (comboBox_OM_ShippedStatus.Text == ""))
            {
                string strSQL = "SELECT o.Order_ID,o.Order_Date,c.C_Title,c.C_Phone,o.Total,o.Payment_Status,o.Shipped_Status,o.Shipped_Date FROM Orders as o inner join Customers as c on o.C_ID=c.C_ID where o.Payment_Status = '" + comboBox_OM_PaymentStatus.Text + "'";
                SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                dataGridView_OM.DataSource = dt;
                odgvout();
            }
            else if ((comboBox_OM_CTitle.Text == "") && (textBox_OM_CPhone.Text == "") && (comboBox_OM_PaymentStatus.Text == "") && (comboBox_OM_ShippedStatus.Text != ""))
            {
                string strSQL = "SELECT o.Order_ID,o.Order_Date,c.C_Title,c.C_Phone,o.Total,o.Payment_Status,o.Shipped_Status,o.Shipped_Date FROM Orders as o inner join Customers as c on  o.C_ID=c.C_ID where o.Shipped_Status = '" + comboBox_OM_ShippedStatus.Text + "'";
                SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                dataGridView_OM.DataSource = dt;
                odgvout();
            }
            else if ((comboBox_OM_CTitle.Text != "") && (textBox_OM_CPhone.Text != "") && (comboBox_OM_PaymentStatus.Text == "") && (comboBox_OM_ShippedStatus.Text == ""))
            {
                string strSQL = "SELECT o.Order_ID,o.Order_Date,c.C_Title,c.C_Phone,o.Total,o.Payment_Status,o.Shipped_Status,o.Shipped_Date FROM Orders as o inner join Customers as c on  o.C_ID=c.C_ID where c.C_Title LIKE '%" + comboBox_OM_CTitle.Text + "%' and c.C_Phone LIKE '%" + textBox_OM_CPhone.Text + "%'";
                SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                dataGridView_OM.DataSource = dt;
                odgvout();
            }
            else if ((comboBox_OM_CTitle.Text != "") && (textBox_OM_CPhone.Text == "") && (comboBox_OM_PaymentStatus.Text != "") && (comboBox_OM_ShippedStatus.Text == ""))
            {
                string strSQL = "SELECT o.Order_ID,o.Order_Date,c.C_Title,c.C_Phone,o.Total,o.Payment_Status,o.Shipped_Status,o.Shipped_Date FROM Orders as o inner join Customers as c on o.C_ID=c.C_ID where c.C_Title LIKE '%" + comboBox_OM_CTitle.Text + "%' and o.Payment_Status = '" + comboBox_OM_PaymentStatus.Text + "'";
                SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                dataGridView_OM.DataSource = dt;
                odgvout();
            }
            else if ((comboBox_OM_CTitle.Text != "") && (textBox_OM_CPhone.Text == "") && (comboBox_OM_PaymentStatus.Text == "") && (comboBox_OM_ShippedStatus.Text != ""))
            {
                string strSQL = "SELECT o.Order_ID,o.Order_Date,c.C_Title,c.C_Phone,o.Total,o.Payment_Status,o.Shipped_Status,o.Shipped_Date FROM Orders as o inner join Customers as c on o.C_ID=c.C_ID where c.C_Title LIKE '%" + comboBox_OM_CTitle.Text + "%' and o.Shipped_Status = '" + comboBox_OM_ShippedStatus.Text + "'";
                SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                dataGridView_OM.DataSource = dt;
                odgvout();
            }
            else if ((comboBox_OM_CTitle.Text == "") && (textBox_OM_CPhone.Text != "") && (comboBox_OM_PaymentStatus.Text != "") && (comboBox_OM_ShippedStatus.Text == ""))
            {
                string strSQL = "SELECT o.Order_ID,o.Order_Date,c.C_Title,c.C_Phone,o.Total,o.Payment_Status,o.Shipped_Status,o.Shipped_Date FROM Orders as o inner join Customers as c on o.C_ID=c.C_ID where c.C_Phone LIKE '%" + textBox_OM_CPhone.Text + "%' and o.Payment_Status = '" + comboBox_OM_PaymentStatus.Text + "'";
                SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                dataGridView_OM.DataSource = dt;
                odgvout();
            }
            else if ((comboBox_OM_CTitle.Text == "") && (textBox_OM_CPhone.Text != "") && (comboBox_OM_PaymentStatus.Text == "") && (comboBox_OM_ShippedStatus.Text != ""))
            {
                string strSQL = "SELECT o.Order_ID,o.Order_Date,c.C_Title,c.C_Phone,o.Total,o.Payment_Status,o.Shipped_Status,o.Shipped_Date FROM Orders as o inner join Customers as c on o.C_ID=c.C_ID where c.C_Phone LIKE '%" + textBox_OM_CPhone.Text + "%' and o.Shipped_Status = '" + comboBox_OM_ShippedStatus.Text + "'";
                SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                dataGridView_OM.DataSource = dt;
                odgvout();
            }
            else if ((comboBox_OM_CTitle.Text == "") && (textBox_OM_CPhone.Text == "") && (comboBox_OM_PaymentStatus.Text != "") && (comboBox_OM_ShippedStatus.Text != ""))
            {
                string strSQL = "SELECT o.Order_ID,o.Order_Date,c.C_Title,c.C_Phone,o.Total,o.Payment_Status,o.Shipped_Status,o.Shipped_Date FROM Orders as o inner join Customers as c on o.C_ID=c.C_ID where o.Payment_Status = '" + comboBox_OM_PaymentStatus.Text + "' and o.Shipped_Status = '" + comboBox_OM_ShippedStatus.Text + "'";
                SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                dataGridView_OM.DataSource = dt;
                odgvout();
            }
            else if ((comboBox_OM_CTitle.Text != "") && (textBox_OM_CPhone.Text != "") && (comboBox_OM_PaymentStatus.Text != "") && (comboBox_OM_ShippedStatus.Text == ""))
            {
                string strSQL = "SELECT o.Order_ID,o.Order_Date,c.C_Title,c.C_Phone,o.Total,o.Payment_Status,o.Shipped_Status,o.Shipped_Date FROM Orders as o inner join Customers as c on o.C_ID=c.C_ID where c.C_Title LIKE '%" + comboBox_OM_CTitle.Text + "%' and c.C_Phone LIKE '%" + textBox_OM_CPhone.Text + "%' and o.Payment_Status = '" + comboBox_OM_PaymentStatus.Text + "'";
                SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                dataGridView_OM.DataSource = dt;
                odgvout();
            }
            else if ((comboBox_OM_CTitle.Text == "") && (textBox_OM_CPhone.Text != "") && (comboBox_OM_PaymentStatus.Text != "") && (comboBox_OM_ShippedStatus.Text != ""))
            {
                string strSQL = "SELECT o.Order_ID,o.Order_Date,c.C_Title,c.C_Phone,o.Total,o.Payment_Status,o.Shipped_Status,o.Shipped_Date FROM Orders as o inner join Customers as c on o.C_ID=c.C_ID where c.C_Phone LIKE '%" + textBox_OM_CPhone.Text + "%' and o.Payment_Status = '" + comboBox_OM_PaymentStatus.Text + "' and o.Shipped_Status = '" + comboBox_OM_ShippedStatus.Text + "'";
                SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                dataGridView_OM.DataSource = dt;
                odgvout();
            }
            else if ((comboBox_OM_CTitle.Text != "") && (textBox_OM_CPhone.Text == "") && (comboBox_OM_PaymentStatus.Text != "") && (comboBox_OM_ShippedStatus.Text != ""))
            {
                string strSQL = "SELECT o.Order_ID,o.Order_Date,c.C_Title,c.C_Phone,o.Total,o.Payment_Status,o.Shipped_Status,o.Shipped_Date FROM Orders as o inner join Customers as c on o.C_ID=c.C_ID where c.C_Title LIKE '%" + comboBox_OM_CTitle.Text + "%' and o.Payment_Status = '" + comboBox_OM_PaymentStatus.Text + "' and o.Shipped_Status = '" + comboBox_OM_ShippedStatus.Text + "'";
                SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                dataGridView_OM.DataSource = dt;
                odgvout();
            }
            else if ((comboBox_OM_CTitle.Text != "") && (textBox_OM_CPhone.Text != "") && (comboBox_OM_PaymentStatus.Text == "") && (comboBox_OM_ShippedStatus.Text != ""))
            {
                string strSQL = "SELECT o.Order_ID,o.Order_Date,c.C_Title,c.C_Phone,o.Total,o.Payment_Status,o.Shipped_Status,o.Shipped_Date FROM Orders as o inner join Customers as c on o.C_ID=c.C_ID where c.C_Title LIKE '%" + comboBox_OM_CTitle.Text + "%' and c.C_Phone LIKE '%" + textBox_OM_CPhone.Text + "%' and o.Shipped_Status = '" + comboBox_OM_ShippedStatus.Text + "'";
                SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                dataGridView_OM.DataSource = dt;
                odgvout();
            }
            else if ((comboBox_OM_CTitle.Text != "") && (textBox_OM_CPhone.Text != "") && (comboBox_OM_PaymentStatus.Text != "") && (comboBox_OM_ShippedStatus.Text != ""))
            {
                string strSQL = "SELECT o.Order_ID,o.Order_Date,c.C_Title,c.C_Phone,o.Total,o.Payment_Status,o.Shipped_Status,o.Shipped_Date FROM Orders as o inner join Customers as c on o.C_ID=c.C_ID where c.C_Title LIKE '%" + comboBox_OM_CTitle.Text + "%' and c.C_Phone LIKE '%" + textBox_OM_CPhone.Text + "%' and o.Payment_Status = '" + comboBox_OM_PaymentStatus.Text + "' and o.Shipped_Status = '" + comboBox_OM_ShippedStatus.Text + "'";
                SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                dataGridView_OM.DataSource = dt;
                odgvout();
            }
        }
        private void comboBox_OM_CTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSQL = "select *from Customers where C_Title like '%" + comboBox_OM_CTitle.Text + "%'";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read() == true)
            {
                textBox_OM_CPhone.Text = string.Format("{0}", reader["C_Phone"]);
            }
            reader.Close();
            con.Close();
            searchOrder();
        }
        private void comboBox_OM_CTitle_TextUpdate(object sender, EventArgs e)
        {
            searchOrder();
        }
        private void textBox_OM_CPhone_TextChanged(object sender, EventArgs e)
        {
            searchOrder();
        }
        private void comboBox_OM_PaymentStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchOrder();
        }
        private void comboBox_OM_ShippedStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchOrder();
        }

        //Add Order
        private void button__OM_Add_Click(object sender, EventArgs e)
        {
            AddOrder AddOrderForm = new AddOrder();
            AddOrderForm.FormClosing += new FormClosingEventHandler(this.AddOrder_FormClosing);
            AddOrderForm.ShowDialog();
            comboBox_OM_CTitle.Text = "";
            textBox_OM_CPhone.Text = "";
            comboBox_OM_PaymentStatus.Text = "";
            comboBox_OM_ShippedStatus.Text = "";
        }
        //Refresh OM_DGV after Add
        private void AddOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            showodata();
        }
        //Delete Order
        private void button__OM_Delete_Click(object sender, EventArgs e)
        {
            if (dataGridView_OM.SelectedRows.Count > 0)
            {
                DialogResult drResult;
                drResult = MessageBox.Show("確認刪除"+ label_OM_OrderID.Text+ "號訂單嗎?", "刪除該筆訂單", MessageBoxButtons.OKCancel);
                if (drResult == DialogResult.Cancel)
                {
                    dataGridView_OM.ClearSelection();
                }
                else
                {
                    int intID = 0;
                    Int32.TryParse(label_OM_OrderID.Text, out intID);

                    if (intID > 0)
                    {
                        SqlConnection con = new SqlConnection(scsb.ToString());
                        con.Open();
                        string strSQL = "delete from OrderDetails where Order_ID = (select Order_ID from Orders where Order_ID = @SearchID); delete from Orders where Order_ID = @SearchID";
                        SqlCommand cmd = new SqlCommand(strSQL, con);
                        cmd.Parameters.AddWithValue("@SearchID", intID);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        dataGridView_OM.Rows.RemoveAt(dataGridView_OM.SelectedRows[0].Index);
                        MessageBox.Show("訂單刪除完畢");
                        comboBox_OM_CTitle.Text = "";
                        textBox_OM_CPhone.Text = "";
                        comboBox_OM_PaymentStatus.Text = "";
                        comboBox_OM_ShippedStatus.Text = "";
                    }
                }
            }
            else { MessageBox.Show("請選取欲刪除訂單"); }
        }
        //Edit Order
        private void button__OM_Edit_Click(object sender, EventArgs e)
        {
            if (dataGridView_OM.SelectedRows.Count > 0)
            {
                EditOrder EditOrderForm = new EditOrder();
                EditOrderForm.OrderID = label_OM_OrderID.Text.ToString();
                EditOrderForm.FormClosing += new FormClosingEventHandler(this.EditOrder_FormClosing);
                EditOrderForm.ShowDialog();
                comboBox_OM_CTitle.Text = "";
                textBox_OM_CPhone.Text = "";
                comboBox_OM_PaymentStatus.Text = "";
                comboBox_OM_ShippedStatus.Text = "";
            }
            else { MessageBox.Show("請選取欲編輯訂單"); }
        }
        //Refresh OM_DGV after Add
        private void EditOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            showodata();
        }




        //******SaleAnalysis******      
        //Products Anls
        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSQL = "select od.P_ID,p.P_Name,sum(Quantity) as TotalQty,p.P_UnitPrice,sum(Quantity)*p.P_UnitPrice as TotalAmount from OrderDetails as od inner join Products as p on od.P_ID = p.P_ID where od.Order_ID in (select Order_ID from Orders where Order_Date between '" + dateTimePicker1.Value.Date.ToShortDateString() + "' and '" + dateTimePicker2.Value.Date.ToShortDateString() + "') group by od.P_ID,p.P_Name,p.P_UnitPrice";
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            dataGridView_SaleAnls.DataSource = dt;
            panlsdgvout();
        }
        void panlsdgvout()
        {
            this.dataGridView_SaleAnls.ClearSelection();
            this.dataGridView_SaleAnls.Columns[0].Visible = false;
            this.dataGridView_SaleAnls.Columns[1].HeaderText = "名稱";
            this.dataGridView_SaleAnls.Columns[2].HeaderText = "銷售總量";
            this.dataGridView_SaleAnls.Columns[3].HeaderText = "單價";
            this.dataGridView_SaleAnls.Columns[4].HeaderText = "銷售總額";
            this.dataGridView_SaleAnls.Columns[1].Width = 145;
            this.dataGridView_SaleAnls.Columns[2].Width = 95;
            this.dataGridView_SaleAnls.Columns[3].Width = 75;
            this.dataGridView_SaleAnls.Columns[4].DefaultCellStyle.Alignment= DataGridViewContentAlignment.MiddleRight;
            this.dataGridView_SaleAnls.ColumnHeadersDefaultCellStyle.Font = new Font("微軟正黑體", 14, FontStyle.Bold);
            this.dataGridView_SaleAnls.DefaultCellStyle.Font = new Font("微軟正黑體", 13, FontStyle.Bold);
        }
        //Customers Anls
        void canlsccombox()
        {
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSQL = "select C_Title from Customers";
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            DataSet ds = new DataSet();
            adpt.Fill(ds, "ctitle");

            for (int i = 0; i < ds.Tables["ctitle"].Rows.Count; i++)
            {
                comboBox_SaleAnls_Customers.Items.Add(ds.Tables["ctitle"].Rows[i][0]);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox_SaleAnls_Customers.Text == "")
            {
                SqlConnection con = new SqlConnection(scsb.ToString());
                con.Open();
                string strSQL = "select o.C_ID,c.C_Title,count(Order_ID),sum(Total),sum(Freight),sum(Total)-sum(Freight) from Orders as o inner join Customers as c on o.C_ID = c.C_ID where o.Order_Date between '" + dateTimePicker4.Value.Date.ToShortDateString()+ "' and '" + dateTimePicker3.Value.Date.ToShortDateString() + "' group by o.C_ID,c.C_Title";
                SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                dataGridView_CustomerAnls.DataSource = dt;
                appfor1();
            }
            else
            {
                if (label_CAnls_CID.Text != "")
                {
                    SqlConnection con = new SqlConnection(scsb.ToString());
                    con.Open();
                    string strSQL = "select od.P_ID,p.P_Name,sum(od.Quantity) from(OrderDetails as od inner join Orders as o on od.Order_ID = o.Order_ID) inner join Products as p on od.P_ID = p.P_ID where C_ID = '" + label_CAnls_CID.Text + "' and Order_Date between '" + dateTimePicker4.Value.Date.ToShortDateString() + "'and '" + dateTimePicker3.Value.Date.ToShortDateString() + "' group by od.P_ID,p.P_Name";
                    SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
                    DataTable dt = new DataTable();
                    adpt.Fill(dt);
                    dataGridView_CustomerAnls.DataSource = dt;
                    appfor2();
                }
            }
        }
        void appfor1()
        {
            this.dataGridView_CustomerAnls.ClearSelection();  
            this.dataGridView_CustomerAnls.Columns[0].Visible = false;
            this.dataGridView_CustomerAnls.Columns[1].HeaderText = "客戶";
            this.dataGridView_CustomerAnls.Columns[2].HeaderText = "下單次數";
            this.dataGridView_CustomerAnls.Columns[3].HeaderText = "支付總額";
            this.dataGridView_CustomerAnls.Columns[4].HeaderText = "運費總額";
            this.dataGridView_CustomerAnls.Columns[5].HeaderText = "消費總額";
            this.dataGridView_CustomerAnls.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView_CustomerAnls.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView_CustomerAnls.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView_CustomerAnls.ColumnHeadersDefaultCellStyle.Font = new Font("微軟正黑體",14,FontStyle.Bold);
            this.dataGridView_CustomerAnls.DefaultCellStyle.Font = new Font("微軟正黑體", 13, FontStyle.Bold);
        }
        void appfor2()
        {
            this.dataGridView_CustomerAnls.ClearSelection();
            this.dataGridView_CustomerAnls.Columns[0].Visible = false;
            this.dataGridView_CustomerAnls.Columns[1].HeaderText = "購買產品";
            this.dataGridView_CustomerAnls.Columns[2].HeaderText = "購買總量";
            this.dataGridView_CustomerAnls.Columns[1].Width = 210;
            this.dataGridView_CustomerAnls.ColumnHeadersDefaultCellStyle.Font = new Font("微軟正黑體", 14, FontStyle.Bold);
            this.dataGridView_CustomerAnls.DefaultCellStyle.Font = new Font("微軟正黑體", 13, FontStyle.Bold);
        }
        private void comboBox_SaleAnls_Customers_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSQL = "select *from Customers where C_Title like '%" + comboBox_SaleAnls_Customers.Text + "%'";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read() == true)
            {
                label_CAnls_CID.Text = string.Format("{0}", reader["C_ID"]);
            }
            reader.Close();
            con.Close();
            searchOrder();
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            TabPage tp = tabControl1.TabPages[e.Index];

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            RectangleF headerRect = new RectangleF(e.Bounds.X - 5, e.Bounds.Y + 3, e.Bounds.Width + 10, e.Bounds.Height + 3);
            SolidBrush sb = new SolidBrush(Color.AliceBlue);
            if (tabControl1.SelectedIndex == e.Index)
            {
                sb.Color = Color.AliceBlue;
                g.FillRectangle(sb, e.Bounds);
                g.DrawString(tp.Text, tabControl1.Font, new SolidBrush(Color.MidnightBlue), headerRect, sf);
            }
            else
            {
                sb.Color = Color.SlateGray;
                g.FillRectangle(sb, e.Bounds);
                g.DrawString(tp.Text, tabControl1.Font, new SolidBrush(Color.White), headerRect, sf);
            }
        }

       
    }
}