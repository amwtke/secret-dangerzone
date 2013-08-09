using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace CSharpChartExplorer
{
    /// <summary>
    /// A simple form to list out all parameters passed to ClickHotSpot event
    /// handler for demo purposes.
    /// </summary>
    public class ParamViewer : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Button OKPB;
        private System.Windows.Forms.ColumnHeader Key;
        private System.Windows.Forms.ColumnHeader Value;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.ListView listView;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        /// <summary>
        /// ParamViewer Constructor
        /// </summary>
        public ParamViewer()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.listView = new System.Windows.Forms.ListView();
            this.OKPB = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.Key = new System.Windows.Forms.ColumnHeader();
            this.Value = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																					   this.Key,
																					   this.Value});
            this.listView.GridLines = true;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView.Location = new System.Drawing.Point(8, 56);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(304, 168);
            this.listView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView.TabIndex = 0;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // OKPB
            // 
            this.OKPB.Location = new System.Drawing.Point(120, 232);
            this.OKPB.Name = "OKPB";
            this.OKPB.Size = new System.Drawing.Size(72, 24);
            this.OKPB.TabIndex = 1;
            this.OKPB.Text = "OK";
            this.OKPB.Click += new System.EventHandler(this.OKPB_Click);
            // 
            // label
            // 
            this.label.Location = new System.Drawing.Point(8, 8);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(304, 48);
            this.label.TabIndex = 2;
            this.label.Text = "This is to demonstrate that ChartDirector charts are clickable. In this demo prog" +
                "ram, we just display the information provided to the ClickHotSpot event handler." +
                " ";
            // 
            // Key
            // 
            this.Key.Text = "Key";
            this.Key.Width = 80;
            // 
            // Value
            // 
            this.Value.Text = "Value";
            this.Value.Width = 220;
            // 
            // ParamViewer
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 15);
            this.ClientSize = new System.Drawing.Size(320, 261);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.label,
																		  this.OKPB,
																		  this.listView});
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ParamViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hot Spot Parameters";
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// ParamViewer Constructor
        /// </summary>
        public void Display(object sender, ChartDirector.WinHotSpotEventArgs e)
        {
            // Add the name of the ChartViewer control that is being clicked
            listView.Items.Add(new ListViewItem(new string[] {"source", 
				((ChartDirector.WinChartViewer)sender).Name}));

            // List out the parameters of the hot spot
            foreach (DictionaryEntry key in e.GetAttrValues())
            {
                listView.Items.Add(new ListViewItem(
                    new string[] { (string)key.Key, (string)key.Value }));
            }

            // Display the form
            ShowDialog();
        }

        /// <summary>
        /// Handler for the OK button
        /// </summary>
        private void OKPB_Click(object sender, System.EventArgs e)
        {
            // Just close the Form
            Close();
        }
    }
}
