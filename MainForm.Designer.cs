﻿namespace JIP
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.dgv_Bids = new System.Windows.Forms.DataGridView();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.tbpg_Bids = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tbx_SelectedBid = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.iGCellStyleDesign1 = new TenTec.Windows.iGridLib.iGCellStyleDesign();
            this.iGColHdrStyleDesign1 = new TenTec.Windows.iGridLib.iGColHdrStyleDesign();
            this.iGDropDownList1 = new TenTec.Windows.iGridLib.iGDropDownList(this.components);
            this.iGrid1 = new TenTec.Windows.iGridLib.iGrid();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Bids)).BeginInit();
            this.TabControl.SuspendLayout();
            this.tbpg_Bids.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Bids
            // 
            this.dgv_Bids.AllowUserToAddRows = false;
            this.dgv_Bids.AllowUserToDeleteRows = false;
            this.dgv_Bids.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Bids.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Bids.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Bids.Location = new System.Drawing.Point(0, 0);
            this.dgv_Bids.Name = "dgv_Bids";
            this.dgv_Bids.ReadOnly = true;
            this.dgv_Bids.Size = new System.Drawing.Size(806, 231);
            this.dgv_Bids.TabIndex = 0;
            this.dgv_Bids.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Bids_CellClick);
            // 
            // TabControl
            // 
            this.TabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl.Controls.Add(this.tbpg_Bids);
            this.TabControl.Controls.Add(this.tabPage2);
            this.TabControl.Location = new System.Drawing.Point(12, 12);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(830, 361);
            this.TabControl.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.TabControl.TabIndex = 2;
            // 
            // tbpg_Bids
            // 
            this.tbpg_Bids.Controls.Add(this.panel1);
            this.tbpg_Bids.Controls.Add(this.button2);
            this.tbpg_Bids.Controls.Add(this.button1);
            this.tbpg_Bids.Controls.Add(this.tbx_SelectedBid);
            this.tbpg_Bids.Location = new System.Drawing.Point(4, 22);
            this.tbpg_Bids.Name = "tbpg_Bids";
            this.tbpg_Bids.Padding = new System.Windows.Forms.Padding(3);
            this.tbpg_Bids.Size = new System.Drawing.Size(822, 335);
            this.tbpg_Bids.TabIndex = 0;
            this.tbpg_Bids.Text = "Предварительный расчет";
            this.tbpg_Bids.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dgv_Bids);
            this.panel1.Location = new System.Drawing.Point(7, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(809, 234);
            this.panel1.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(511, 17);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 20);
            this.button2.TabIndex = 2;
            this.button2.Text = "button1";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(414, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 20);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbx_SelectedBid
            // 
            this.tbx_SelectedBid.Location = new System.Drawing.Point(7, 17);
            this.tbx_SelectedBid.Name = "tbx_SelectedBid";
            this.tbx_SelectedBid.Size = new System.Drawing.Size(384, 20);
            this.tbx_SelectedBid.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(805, 618);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Заказы";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // iGrid1
            // 
            this.iGrid1.Header.Height = 16;
            this.iGrid1.Location = new System.Drawing.Point(0, 0);
            this.iGrid1.Name = "iGrid1";
            this.iGrid1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 421);
            this.Controls.Add(this.TabControl);
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "LPR-Mold";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Bids)).EndInit();
            this.TabControl.ResumeLayout(false);
            this.tbpg_Bids.ResumeLayout(false);
            this.tbpg_Bids.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Bids;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage tbpg_Bids;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox tbx_SelectedBid;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private TenTec.Windows.iGridLib.iGCellStyleDesign iGCellStyleDesign1;
        private TenTec.Windows.iGridLib.iGColHdrStyleDesign iGColHdrStyleDesign1;
        private TenTec.Windows.iGridLib.iGDropDownList iGDropDownList1;
        private TenTec.Windows.iGridLib.iGrid iGrid1;
    }
}