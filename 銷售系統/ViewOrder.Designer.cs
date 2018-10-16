namespace 銷售系統
{
    partial class ViewOrder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label20 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label_OM_Edit_OrderID = new System.Windows.Forms.Label();
            this.comboBox_OM_Edit_PaymentStatus = new System.Windows.Forms.ComboBox();
            this.comboBox_OM_Edit_ShippedStatus = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_OM_Edit_ONote = new System.Windows.Forms.TextBox();
            this.label_OM_Edit_Total = new System.Windows.Forms.Label();
            this.label_OM_Edit_SubTotal = new System.Windows.Forms.Label();
            this.dataGridView_OM_Edit_Cart = new System.Windows.Forms.DataGridView();
            this.label_OM_Edit_CTitle = new System.Windows.Forms.Label();
            this.dateTimePicker_OM_Edit_ShipDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_OM_Edit_ODate = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.comboBox_OM_Edit_ShipVia = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label_OM_Edit_Ono = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label_OM_Edit_CAddress = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label_OM_Edit_CPhone = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label_OM_ViewOrder_Freight = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_OM_Edit_Cart)).BeginInit();
            this.SuspendLayout();
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.SteelBlue;
            this.label20.Font = new System.Drawing.Font("微軟正黑體", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(360, 319);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(90, 25);
            this.label20.TabIndex = 295;
            this.label20.Text = "總計";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.SteelBlue;
            this.label17.Font = new System.Drawing.Font("微軟正黑體", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(360, 278);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(90, 25);
            this.label17.TabIndex = 294;
            this.label17.Text = "運費";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.SteelBlue;
            this.label15.Font = new System.Drawing.Font("微軟正黑體", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(360, 237);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(90, 25);
            this.label15.TabIndex = 293;
            this.label15.Text = "總項小計";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_OM_Edit_OrderID
            // 
            this.label_OM_Edit_OrderID.AutoSize = true;
            this.label_OM_Edit_OrderID.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_OM_Edit_OrderID.Location = new System.Drawing.Point(252, 41);
            this.label_OM_Edit_OrderID.Name = "label_OM_Edit_OrderID";
            this.label_OM_Edit_OrderID.Size = new System.Drawing.Size(71, 21);
            this.label_OM_Edit_OrderID.TabIndex = 286;
            this.label_OM_Edit_OrderID.Text = "OrderID";
            this.label_OM_Edit_OrderID.Visible = false;
            // 
            // comboBox_OM_Edit_PaymentStatus
            // 
            this.comboBox_OM_Edit_PaymentStatus.Enabled = false;
            this.comboBox_OM_Edit_PaymentStatus.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox_OM_Edit_PaymentStatus.FormattingEnabled = true;
            this.comboBox_OM_Edit_PaymentStatus.Items.AddRange(new object[] {
            "已收款",
            "未收款"});
            this.comboBox_OM_Edit_PaymentStatus.Location = new System.Drawing.Point(460, 361);
            this.comboBox_OM_Edit_PaymentStatus.Name = "comboBox_OM_Edit_PaymentStatus";
            this.comboBox_OM_Edit_PaymentStatus.Size = new System.Drawing.Size(82, 29);
            this.comboBox_OM_Edit_PaymentStatus.TabIndex = 285;
            // 
            // comboBox_OM_Edit_ShippedStatus
            // 
            this.comboBox_OM_Edit_ShippedStatus.Enabled = false;
            this.comboBox_OM_Edit_ShippedStatus.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox_OM_Edit_ShippedStatus.FormattingEnabled = true;
            this.comboBox_OM_Edit_ShippedStatus.Items.AddRange(new object[] {
            "已取貨",
            "已出貨",
            "未取貨",
            "未出貨"});
            this.comboBox_OM_Edit_ShippedStatus.Location = new System.Drawing.Point(460, 403);
            this.comboBox_OM_Edit_ShippedStatus.Name = "comboBox_OM_Edit_ShippedStatus";
            this.comboBox_OM_Edit_ShippedStatus.Size = new System.Drawing.Size(82, 29);
            this.comboBox_OM_Edit_ShippedStatus.TabIndex = 284;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.SteelBlue;
            this.label10.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(360, 363);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 25);
            this.label10.TabIndex = 283;
            this.label10.Text = "收款進度";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.SteelBlue;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(360, 405);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 25);
            this.label3.TabIndex = 282;
            this.label3.Text = "出貨進度";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_OM_Edit_ONote
            // 
            this.textBox_OM_Edit_ONote.Enabled = false;
            this.textBox_OM_Edit_ONote.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_OM_Edit_ONote.ForeColor = System.Drawing.Color.MidnightBlue;
            this.textBox_OM_Edit_ONote.Location = new System.Drawing.Point(33, 327);
            this.textBox_OM_Edit_ONote.Multiline = true;
            this.textBox_OM_Edit_ONote.Name = "textBox_OM_Edit_ONote";
            this.textBox_OM_Edit_ONote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_OM_Edit_ONote.Size = new System.Drawing.Size(266, 101);
            this.textBox_OM_Edit_ONote.TabIndex = 281;
            // 
            // label_OM_Edit_Total
            // 
            this.label_OM_Edit_Total.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_OM_Edit_Total.Font = new System.Drawing.Font("微軟正黑體", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_OM_Edit_Total.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label_OM_Edit_Total.Location = new System.Drawing.Point(456, 322);
            this.label_OM_Edit_Total.Name = "label_OM_Edit_Total";
            this.label_OM_Edit_Total.Size = new System.Drawing.Size(69, 22);
            this.label_OM_Edit_Total.TabIndex = 280;
            this.label_OM_Edit_Total.Text = "0";
            this.label_OM_Edit_Total.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_OM_Edit_SubTotal
            // 
            this.label_OM_Edit_SubTotal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_OM_Edit_SubTotal.Font = new System.Drawing.Font("微軟正黑體", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_OM_Edit_SubTotal.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label_OM_Edit_SubTotal.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_OM_Edit_SubTotal.Location = new System.Drawing.Point(456, 240);
            this.label_OM_Edit_SubTotal.Name = "label_OM_Edit_SubTotal";
            this.label_OM_Edit_SubTotal.Size = new System.Drawing.Size(69, 22);
            this.label_OM_Edit_SubTotal.TabIndex = 279;
            this.label_OM_Edit_SubTotal.Text = "0";
            this.label_OM_Edit_SubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataGridView_OM_Edit_Cart
            // 
            this.dataGridView_OM_Edit_Cart.AllowUserToAddRows = false;
            this.dataGridView_OM_Edit_Cart.AllowUserToDeleteRows = false;
            this.dataGridView_OM_Edit_Cart.AllowUserToResizeColumns = false;
            this.dataGridView_OM_Edit_Cart.AllowUserToResizeRows = false;
            this.dataGridView_OM_Edit_Cart.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_OM_Edit_Cart.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView_OM_Edit_Cart.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Sienna;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_OM_Edit_Cart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_OM_Edit_Cart.ColumnHeadersHeight = 29;
            this.dataGridView_OM_Edit_Cart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_OM_Edit_Cart.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView_OM_Edit_Cart.EnableHeadersVisualStyles = false;
            this.dataGridView_OM_Edit_Cart.Location = new System.Drawing.Point(337, 64);
            this.dataGridView_OM_Edit_Cart.MultiSelect = false;
            this.dataGridView_OM_Edit_Cart.Name = "dataGridView_OM_Edit_Cart";
            this.dataGridView_OM_Edit_Cart.ReadOnly = true;
            this.dataGridView_OM_Edit_Cart.RowHeadersVisible = false;
            this.dataGridView_OM_Edit_Cart.RowTemplate.Height = 24;
            this.dataGridView_OM_Edit_Cart.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView_OM_Edit_Cart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_OM_Edit_Cart.Size = new System.Drawing.Size(392, 140);
            this.dataGridView_OM_Edit_Cart.TabIndex = 277;
            // 
            // label_OM_Edit_CTitle
            // 
            this.label_OM_Edit_CTitle.AutoSize = true;
            this.label_OM_Edit_CTitle.Font = new System.Drawing.Font("微軟正黑體", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_OM_Edit_CTitle.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label_OM_Edit_CTitle.Location = new System.Drawing.Point(148, 70);
            this.label_OM_Edit_CTitle.Name = "label_OM_Edit_CTitle";
            this.label_OM_Edit_CTitle.Size = new System.Drawing.Size(71, 22);
            this.label_OM_Edit_CTitle.TabIndex = 266;
            this.label_OM_Edit_CTitle.Text = "label22";
            // 
            // dateTimePicker_OM_Edit_ShipDate
            // 
            this.dateTimePicker_OM_Edit_ShipDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dateTimePicker_OM_Edit_ShipDate.Enabled = false;
            this.dateTimePicker_OM_Edit_ShipDate.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dateTimePicker_OM_Edit_ShipDate.Location = new System.Drawing.Point(148, 212);
            this.dateTimePicker_OM_Edit_ShipDate.Name = "dateTimePicker_OM_Edit_ShipDate";
            this.dateTimePicker_OM_Edit_ShipDate.Size = new System.Drawing.Size(151, 29);
            this.dateTimePicker_OM_Edit_ShipDate.TabIndex = 265;
            // 
            // dateTimePicker_OM_Edit_ODate
            // 
            this.dateTimePicker_OM_Edit_ODate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dateTimePicker_OM_Edit_ODate.Enabled = false;
            this.dateTimePicker_OM_Edit_ODate.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dateTimePicker_OM_Edit_ODate.Location = new System.Drawing.Point(148, 139);
            this.dateTimePicker_OM_Edit_ODate.Name = "dateTimePicker_OM_Edit_ODate";
            this.dateTimePicker_OM_Edit_ODate.Size = new System.Drawing.Size(151, 29);
            this.dateTimePicker_OM_Edit_ODate.TabIndex = 263;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.SteelBlue;
            this.label21.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(32, 216);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(108, 25);
            this.label21.TabIndex = 264;
            this.label21.Text = "出貨日期";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.SteelBlue;
            this.label16.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(32, 141);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(108, 25);
            this.label16.TabIndex = 262;
            this.label16.Text = "下單日期";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.SteelBlue;
            this.label14.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(337, 29);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(392, 33);
            this.label14.TabIndex = 261;
            this.label14.Text = "訂單明細";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox_OM_Edit_ShipVia
            // 
            this.comboBox_OM_Edit_ShipVia.Enabled = false;
            this.comboBox_OM_Edit_ShipVia.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox_OM_Edit_ShipVia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.comboBox_OM_Edit_ShipVia.FormattingEnabled = true;
            this.comboBox_OM_Edit_ShipVia.Items.AddRange(new object[] {
            "自取",
            "寄送"});
            this.comboBox_OM_Edit_ShipVia.Location = new System.Drawing.Point(148, 176);
            this.comboBox_OM_Edit_ShipVia.Name = "comboBox_OM_Edit_ShipVia";
            this.comboBox_OM_Edit_ShipVia.Size = new System.Drawing.Size(92, 29);
            this.comboBox_OM_Edit_ShipVia.TabIndex = 260;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.SteelBlue;
            this.label13.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(32, 179);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(108, 25);
            this.label13.TabIndex = 259;
            this.label13.Text = "出貨方式";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_OM_Edit_Ono
            // 
            this.label_OM_Edit_Ono.AutoSize = true;
            this.label_OM_Edit_Ono.Font = new System.Drawing.Font("微軟正黑體", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_OM_Edit_Ono.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label_OM_Edit_Ono.Location = new System.Drawing.Point(148, 32);
            this.label_OM_Edit_Ono.Name = "label_OM_Edit_Ono";
            this.label_OM_Edit_Ono.Size = new System.Drawing.Size(71, 22);
            this.label_OM_Edit_Ono.TabIndex = 258;
            this.label_OM_Edit_Ono.Text = "label12";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.SteelBlue;
            this.label11.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(32, 297);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(108, 25);
            this.label11.TabIndex = 257;
            this.label11.Text = "訂單備註";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_OM_Edit_CAddress
            // 
            this.label_OM_Edit_CAddress.Font = new System.Drawing.Font("微軟正黑體", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_OM_Edit_CAddress.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label_OM_Edit_CAddress.Location = new System.Drawing.Point(148, 252);
            this.label_OM_Edit_CAddress.Name = "label_OM_Edit_CAddress";
            this.label_OM_Edit_CAddress.Size = new System.Drawing.Size(206, 58);
            this.label_OM_Edit_CAddress.TabIndex = 256;
            this.label_OM_Edit_CAddress.Text = "label10";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.SteelBlue;
            this.label9.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(32, 250);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 25);
            this.label9.TabIndex = 255;
            this.label9.Text = "寄件地址";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_OM_Edit_CPhone
            // 
            this.label_OM_Edit_CPhone.AutoSize = true;
            this.label_OM_Edit_CPhone.Font = new System.Drawing.Font("微軟正黑體", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_OM_Edit_CPhone.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label_OM_Edit_CPhone.Location = new System.Drawing.Point(148, 107);
            this.label_OM_Edit_CPhone.Name = "label_OM_Edit_CPhone";
            this.label_OM_Edit_CPhone.Size = new System.Drawing.Size(61, 22);
            this.label_OM_Edit_CPhone.TabIndex = 254;
            this.label_OM_Edit_CPhone.Text = "label3";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(32, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 25);
            this.label2.TabIndex = 253;
            this.label2.Text = "連絡電話";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label25
            // 
            this.label25.BackColor = System.Drawing.Color.SteelBlue;
            this.label25.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label25.ForeColor = System.Drawing.Color.White;
            this.label25.Location = new System.Drawing.Point(32, 29);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(108, 25);
            this.label25.TabIndex = 251;
            this.label25.Text = "訂單編號";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label26
            // 
            this.label26.BackColor = System.Drawing.Color.SteelBlue;
            this.label26.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label26.ForeColor = System.Drawing.Color.White;
            this.label26.Location = new System.Drawing.Point(32, 67);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(108, 25);
            this.label26.TabIndex = 252;
            this.label26.Text = "客戶稱呼";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_OM_ViewOrder_Freight
            // 
            this.label_OM_ViewOrder_Freight.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_OM_ViewOrder_Freight.Font = new System.Drawing.Font("微軟正黑體", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_OM_ViewOrder_Freight.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label_OM_ViewOrder_Freight.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_OM_ViewOrder_Freight.Location = new System.Drawing.Point(456, 281);
            this.label_OM_ViewOrder_Freight.Name = "label_OM_ViewOrder_Freight";
            this.label_OM_ViewOrder_Freight.Size = new System.Drawing.Size(69, 22);
            this.label_OM_ViewOrder_Freight.TabIndex = 296;
            this.label_OM_ViewOrder_Freight.Text = "0";
            this.label_OM_ViewOrder_Freight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ViewOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(756, 458);
            this.Controls.Add(this.label_OM_ViewOrder_Freight);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label_OM_Edit_OrderID);
            this.Controls.Add(this.comboBox_OM_Edit_PaymentStatus);
            this.Controls.Add(this.comboBox_OM_Edit_ShippedStatus);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_OM_Edit_ONote);
            this.Controls.Add(this.label_OM_Edit_Total);
            this.Controls.Add(this.label_OM_Edit_SubTotal);
            this.Controls.Add(this.dataGridView_OM_Edit_Cart);
            this.Controls.Add(this.label_OM_Edit_CTitle);
            this.Controls.Add(this.dateTimePicker_OM_Edit_ShipDate);
            this.Controls.Add(this.dateTimePicker_OM_Edit_ODate);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.comboBox_OM_Edit_ShipVia);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label_OM_Edit_Ono);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label_OM_Edit_CAddress);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label_OM_Edit_CPhone);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label26);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewOrder";
            this.Text = "ViewOrder";
            this.Load += new System.EventHandler(this.ViewOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_OM_Edit_Cart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label_OM_Edit_OrderID;
        private System.Windows.Forms.ComboBox comboBox_OM_Edit_PaymentStatus;
        private System.Windows.Forms.ComboBox comboBox_OM_Edit_ShippedStatus;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_OM_Edit_ONote;
        private System.Windows.Forms.Label label_OM_Edit_Total;
        private System.Windows.Forms.Label label_OM_Edit_SubTotal;
        private System.Windows.Forms.DataGridView dataGridView_OM_Edit_Cart;
        private System.Windows.Forms.Label label_OM_Edit_CTitle;
        private System.Windows.Forms.DateTimePicker dateTimePicker_OM_Edit_ShipDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker_OM_Edit_ODate;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox comboBox_OM_Edit_ShipVia;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label_OM_Edit_Ono;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label_OM_Edit_CAddress;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label_OM_Edit_CPhone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label_OM_ViewOrder_Freight;
    }
}