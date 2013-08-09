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
            this.Add = new System.Windows.Forms.Button();
            this.Bt_duplicate = new System.Windows.Forms.Button();
            this.tb_search = new System.Windows.Forms.TextBox();
            this.Bt_report = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.doubleBollBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.openDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstProvinceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qiShuDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saleTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.red1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.red2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.red3DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.red4DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.red5DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.red6DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.blueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.touJiangDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.touJiangZhuShuDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.erJiangDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.erJiangZhuShuDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sanJiangDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sanJiangZhuShuDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.allBollsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.openDateDataGridViewTextBoxColumn,
            this.firstProvinceDataGridViewTextBoxColumn,
            this.qiShuDataGridViewTextBoxColumn,
            this.saleTotalDataGridViewTextBoxColumn,
            this.red1DataGridViewTextBoxColumn,
            this.red2DataGridViewTextBoxColumn,
            this.red3DataGridViewTextBoxColumn,
            this.red4DataGridViewTextBoxColumn,
            this.red5DataGridViewTextBoxColumn,
            this.red6DataGridViewTextBoxColumn,
            this.blueDataGridViewTextBoxColumn,
            this.touJiangDataGridViewTextBoxColumn,
            this.touJiangZhuShuDataGridViewTextBoxColumn,
            this.erJiangDataGridViewTextBoxColumn,
            this.erJiangZhuShuDataGridViewTextBoxColumn,
            this.sanJiangDataGridViewTextBoxColumn,
            this.sanJiangZhuShuDataGridViewTextBoxColumn,
            this.allBollsDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.doubleBollBindingSource;
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
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(12, 9);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(75, 23);
            this.Add.TabIndex = 4;
            this.Add.Text = "加入";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Bt_duplicate
            // 
            this.Bt_duplicate.Location = new System.Drawing.Point(961, 10);
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
            // doubleBollBindingSource
            // 
            this.doubleBollBindingSource.DataSource = typeof(cai.DoubleBoll);
            // 
            // openDateDataGridViewTextBoxColumn
            // 
            this.openDateDataGridViewTextBoxColumn.DataPropertyName = "OpenDate";
            this.openDateDataGridViewTextBoxColumn.HeaderText = "OpenDate";
            this.openDateDataGridViewTextBoxColumn.Name = "openDateDataGridViewTextBoxColumn";
            this.openDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // firstProvinceDataGridViewTextBoxColumn
            // 
            this.firstProvinceDataGridViewTextBoxColumn.DataPropertyName = "FirstProvince";
            this.firstProvinceDataGridViewTextBoxColumn.HeaderText = "FirstProvince";
            this.firstProvinceDataGridViewTextBoxColumn.Name = "firstProvinceDataGridViewTextBoxColumn";
            this.firstProvinceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qiShuDataGridViewTextBoxColumn
            // 
            this.qiShuDataGridViewTextBoxColumn.DataPropertyName = "QiShu";
            this.qiShuDataGridViewTextBoxColumn.HeaderText = "QiShu";
            this.qiShuDataGridViewTextBoxColumn.Name = "qiShuDataGridViewTextBoxColumn";
            this.qiShuDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // saleTotalDataGridViewTextBoxColumn
            // 
            this.saleTotalDataGridViewTextBoxColumn.DataPropertyName = "SaleTotal";
            this.saleTotalDataGridViewTextBoxColumn.HeaderText = "SaleTotal";
            this.saleTotalDataGridViewTextBoxColumn.Name = "saleTotalDataGridViewTextBoxColumn";
            this.saleTotalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // red1DataGridViewTextBoxColumn
            // 
            this.red1DataGridViewTextBoxColumn.DataPropertyName = "Red1";
            this.red1DataGridViewTextBoxColumn.HeaderText = "Red1";
            this.red1DataGridViewTextBoxColumn.Name = "red1DataGridViewTextBoxColumn";
            this.red1DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // red2DataGridViewTextBoxColumn
            // 
            this.red2DataGridViewTextBoxColumn.DataPropertyName = "Red2";
            this.red2DataGridViewTextBoxColumn.HeaderText = "Red2";
            this.red2DataGridViewTextBoxColumn.Name = "red2DataGridViewTextBoxColumn";
            this.red2DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // red3DataGridViewTextBoxColumn
            // 
            this.red3DataGridViewTextBoxColumn.DataPropertyName = "Red3";
            this.red3DataGridViewTextBoxColumn.HeaderText = "Red3";
            this.red3DataGridViewTextBoxColumn.Name = "red3DataGridViewTextBoxColumn";
            this.red3DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // red4DataGridViewTextBoxColumn
            // 
            this.red4DataGridViewTextBoxColumn.DataPropertyName = "Red4";
            this.red4DataGridViewTextBoxColumn.HeaderText = "Red4";
            this.red4DataGridViewTextBoxColumn.Name = "red4DataGridViewTextBoxColumn";
            this.red4DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // red5DataGridViewTextBoxColumn
            // 
            this.red5DataGridViewTextBoxColumn.DataPropertyName = "Red5";
            this.red5DataGridViewTextBoxColumn.HeaderText = "Red5";
            this.red5DataGridViewTextBoxColumn.Name = "red5DataGridViewTextBoxColumn";
            this.red5DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // red6DataGridViewTextBoxColumn
            // 
            this.red6DataGridViewTextBoxColumn.DataPropertyName = "Red6";
            this.red6DataGridViewTextBoxColumn.HeaderText = "Red6";
            this.red6DataGridViewTextBoxColumn.Name = "red6DataGridViewTextBoxColumn";
            this.red6DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // blueDataGridViewTextBoxColumn
            // 
            this.blueDataGridViewTextBoxColumn.DataPropertyName = "Blue";
            this.blueDataGridViewTextBoxColumn.HeaderText = "Blue";
            this.blueDataGridViewTextBoxColumn.Name = "blueDataGridViewTextBoxColumn";
            this.blueDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // touJiangDataGridViewTextBoxColumn
            // 
            this.touJiangDataGridViewTextBoxColumn.DataPropertyName = "TouJiang";
            this.touJiangDataGridViewTextBoxColumn.HeaderText = "TouJiang";
            this.touJiangDataGridViewTextBoxColumn.Name = "touJiangDataGridViewTextBoxColumn";
            this.touJiangDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // touJiangZhuShuDataGridViewTextBoxColumn
            // 
            this.touJiangZhuShuDataGridViewTextBoxColumn.DataPropertyName = "TouJiangZhuShu";
            this.touJiangZhuShuDataGridViewTextBoxColumn.HeaderText = "TouJiangZhuShu";
            this.touJiangZhuShuDataGridViewTextBoxColumn.Name = "touJiangZhuShuDataGridViewTextBoxColumn";
            this.touJiangZhuShuDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // erJiangDataGridViewTextBoxColumn
            // 
            this.erJiangDataGridViewTextBoxColumn.DataPropertyName = "ErJiang";
            this.erJiangDataGridViewTextBoxColumn.HeaderText = "ErJiang";
            this.erJiangDataGridViewTextBoxColumn.Name = "erJiangDataGridViewTextBoxColumn";
            this.erJiangDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // erJiangZhuShuDataGridViewTextBoxColumn
            // 
            this.erJiangZhuShuDataGridViewTextBoxColumn.DataPropertyName = "ErJiangZhuShu";
            this.erJiangZhuShuDataGridViewTextBoxColumn.HeaderText = "ErJiangZhuShu";
            this.erJiangZhuShuDataGridViewTextBoxColumn.Name = "erJiangZhuShuDataGridViewTextBoxColumn";
            this.erJiangZhuShuDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sanJiangDataGridViewTextBoxColumn
            // 
            this.sanJiangDataGridViewTextBoxColumn.DataPropertyName = "SanJiang";
            this.sanJiangDataGridViewTextBoxColumn.HeaderText = "SanJiang";
            this.sanJiangDataGridViewTextBoxColumn.Name = "sanJiangDataGridViewTextBoxColumn";
            this.sanJiangDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sanJiangZhuShuDataGridViewTextBoxColumn
            // 
            this.sanJiangZhuShuDataGridViewTextBoxColumn.DataPropertyName = "SanJiangZhuShu";
            this.sanJiangZhuShuDataGridViewTextBoxColumn.HeaderText = "SanJiangZhuShu";
            this.sanJiangZhuShuDataGridViewTextBoxColumn.Name = "sanJiangZhuShuDataGridViewTextBoxColumn";
            this.sanJiangZhuShuDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // allBollsDataGridViewTextBoxColumn
            // 
            this.allBollsDataGridViewTextBoxColumn.DataPropertyName = "AllBolls";
            this.allBollsDataGridViewTextBoxColumn.HeaderText = "AllBolls";
            this.allBollsDataGridViewTextBoxColumn.Name = "allBollsDataGridViewTextBoxColumn";
            this.allBollsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 604);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Bt_report);
            this.Controls.Add(this.tb_search);
            this.Controls.Add(this.Bt_duplicate);
            this.Controls.Add(this.Add);
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
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button Bt_duplicate;
        private System.Windows.Forms.TextBox tb_search;
        private System.Windows.Forms.DataGridViewTextBoxColumn kaiJiangRiQiDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button Bt_report;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn openDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstProvinceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qiShuDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn saleTotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn red1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn red2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn red3DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn red4DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn red5DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn red6DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn blueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn touJiangDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn touJiangZhuShuDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn erJiangDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn erJiangZhuShuDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sanJiangDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sanJiangZhuShuDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn allBollsDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource doubleBollBindingSource;
    }
}

