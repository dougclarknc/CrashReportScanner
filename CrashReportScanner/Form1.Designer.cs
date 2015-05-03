namespace CrashReportScanner
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.eastPanel = new System.Windows.Forms.Panel();
            this.printButton = new System.Windows.Forms.Button();
            this.pdfButton = new System.Windows.Forms.Button();
            this.updateOutputButton = new System.Windows.Forms.Button();
            this.createOutputButton = new System.Windows.Forms.Button();
            this.locationButton = new System.Windows.Forms.Button();
            this.datePicker = new System.Windows.Forms.MonthCalendar();
            this.inputLabel = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.crashExcelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.eastPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.crashExcelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // eastPanel
            // 
            this.eastPanel.Controls.Add(this.printButton);
            this.eastPanel.Controls.Add(this.pdfButton);
            this.eastPanel.Controls.Add(this.updateOutputButton);
            this.eastPanel.Controls.Add(this.createOutputButton);
            this.eastPanel.Controls.Add(this.locationButton);
            this.eastPanel.Controls.Add(this.datePicker);
            this.eastPanel.Controls.Add(this.inputLabel);
            resources.ApplyResources(this.eastPanel, "eastPanel");
            this.eastPanel.Name = "eastPanel";
            // 
            // printButton
            // 
            resources.ApplyResources(this.printButton, "printButton");
            this.printButton.Name = "printButton";
            this.printButton.UseVisualStyleBackColor = true;
            // 
            // pdfButton
            // 
            resources.ApplyResources(this.pdfButton, "pdfButton");
            this.pdfButton.Name = "pdfButton";
            this.pdfButton.UseVisualStyleBackColor = true;
            this.pdfButton.Click += new System.EventHandler(this.pdfButton_Click);
            // 
            // updateOutputButton
            // 
            resources.ApplyResources(this.updateOutputButton, "updateOutputButton");
            this.updateOutputButton.Name = "updateOutputButton";
            this.updateOutputButton.UseVisualStyleBackColor = true;
            this.updateOutputButton.Click += new System.EventHandler(this.updateOutputButton_Click);
            // 
            // createOutputButton
            // 
            resources.ApplyResources(this.createOutputButton, "createOutputButton");
            this.createOutputButton.Name = "createOutputButton";
            this.createOutputButton.UseVisualStyleBackColor = true;
            this.createOutputButton.Click += new System.EventHandler(this.createOutputButton_Click);
            // 
            // locationButton
            // 
            resources.ApplyResources(this.locationButton, "locationButton");
            this.locationButton.Name = "locationButton";
            this.locationButton.UseVisualStyleBackColor = true;
            this.locationButton.Click += new System.EventHandler(this.locationButton_Click);
            // 
            // datePicker
            // 
            resources.ApplyResources(this.datePicker, "datePicker");
            this.datePicker.Name = "datePicker";
            // 
            // inputLabel
            // 
            resources.ApplyResources(this.inputLabel, "inputLabel");
            this.inputLabel.Name = "inputLabel";
            // 
            // folderBrowserDialog1
            // 
            resources.ApplyResources(this.folderBrowserDialog1, "folderBrowserDialog1");
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.Name = "dataGridView1";
            // 
            // crashExcelBindingSource
            // 
            this.crashExcelBindingSource.DataSource = typeof(CrashReportScanner.CrashExcel);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.eastPanel);
            this.Name = "Form1";
            this.eastPanel.ResumeLayout(false);
            this.eastPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.crashExcelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel eastPanel;
        private System.Windows.Forms.Button updateOutputButton;
        private System.Windows.Forms.Button createOutputButton;
        private System.Windows.Forms.Button locationButton;
        private System.Windows.Forms.MonthCalendar datePicker;
        private System.Windows.Forms.Label inputLabel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource crashExcelBindingSource;
        private System.Windows.Forms.Button pdfButton;
        private System.Windows.Forms.Button printButton;
    }
}

