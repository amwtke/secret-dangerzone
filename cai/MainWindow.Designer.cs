namespace cai
{
    partial class MainWindow
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (_db != null)
                _db.Close();
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_selectfunction = new System.Windows.Forms.Button();
            this.Bt_duplicate = new System.Windows.Forms.Button();
            this.tb_search = new System.Windows.Forms.TextBox();
            this.Bt_report = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.bt_myreport = new System.Windows.Forms.Button();
            this.bt_syncRecent = new System.Windows.Forms.Button();
            this.doubleBollBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleBollBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1180, 9);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "删除";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 39);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1243, 515);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(176, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "0";
            // 
            // bt_selectfunction
            // 
            this.bt_selectfunction.Location = new System.Drawing.Point(12, 9);
            this.bt_selectfunction.Name = "bt_selectfunction";
            this.bt_selectfunction.Size = new System.Drawing.Size(75, 23);
            this.bt_selectfunction.TabIndex = 4;
            this.bt_selectfunction.Text = "功能";
            this.bt_selectfunction.UseVisualStyleBackColor = true;
            this.bt_selectfunction.Click += new System.EventHandler(this.Add_Click);
            // 
            // Bt_duplicate
            // 
            this.Bt_duplicate.Location = new System.Drawing.Point(972, 10);
            this.Bt_duplicate.Name = "Bt_duplicate";
            this.Bt_duplicate.Size = new System.Drawing.Size(75, 23);
            this.Bt_duplicate.TabIndex = 5;
            this.Bt_duplicate.Text = "重复";
            this.Bt_duplicate.UseVisualStyleBackColor = true;
            this.Bt_duplicate.Click += new System.EventHandler(this.Bt_duplicate_Click);
            // 
            // tb_search
            // 
            this.tb_search.Location = new System.Drawing.Point(288, 9);
            this.tb_search.Name = "tb_search";
            this.tb_search.Size = new System.Drawing.Size(219, 21);
            this.tb_search.TabIndex = 6;
            this.tb_search.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_search_KeyUp);
            // 
            // Bt_report
            // 
            this.Bt_report.Location = new System.Drawing.Point(880, 10);
            this.Bt_report.Name = "Bt_report";
            this.Bt_report.Size = new System.Drawing.Size(75, 23);
            this.Bt_report.TabIndex = 7;
            this.Bt_report.Text = "Report";
            this.Bt_report.UseVisualStyleBackColor = true;
            this.Bt_report.Click += new System.EventHandler(this.Bt_report_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1064, 10);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(110, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "从网络同步数据";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // bt_myreport
            // 
            this.bt_myreport.Location = new System.Drawing.Point(787, 9);
            this.bt_myreport.Name = "bt_myreport";
            this.bt_myreport.Size = new System.Drawing.Size(75, 23);
            this.bt_myreport.TabIndex = 9;
            this.bt_myreport.Text = "Log Report";
            this.bt_myreport.UseVisualStyleBackColor = true;
            this.bt_myreport.Click += new System.EventHandler(this.bt_myreport_Click);
            // 
            // bt_syncRecent
            // 
            this.bt_syncRecent.Location = new System.Drawing.Point(673, 9);
            this.bt_syncRecent.Name = "bt_syncRecent";
            this.bt_syncRecent.Size = new System.Drawing.Size(93, 23);
            this.bt_syncRecent.TabIndex = 10;
            this.bt_syncRecent.Text = "同步最近20期";
            this.bt_syncRecent.UseVisualStyleBackColor = true;
            this.bt_syncRecent.Click += new System.EventHandler(this.bt_syncRecent_Click);
            // 
            // doubleBollBindingSource
            // 
            this.doubleBollBindingSource.DataSource = typeof(cai.DoubleBoll);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 604);
            this.Controls.Add(this.bt_syncRecent);
            this.Controls.Add(this.bt_myreport);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Bt_report);
            this.Controls.Add(this.tb_search);
            this.Controls.Add(this.Bt_duplicate);
            this.Controls.Add(this.bt_selectfunction);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleBollBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_selectfunction;
        private System.Windows.Forms.Button Bt_duplicate;
        private System.Windows.Forms.TextBox tb_search;
        private System.Windows.Forms.DataGridViewTextBoxColumn kaiJiangRiQiDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button Bt_report;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.BindingSource doubleBollBindingSource;
        private System.Windows.Forms.Button bt_myreport;
        private System.Windows.Forms.Button bt_syncRecent;
    }
}

