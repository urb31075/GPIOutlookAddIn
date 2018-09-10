namespace GPIOutlookAddIn
{
    partial class NdrUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.FindParentEmailButton = new System.Windows.Forms.Button();
            this.FolderComboBox = new System.Windows.Forms.ComboBox();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.WorkingTabPage = new System.Windows.Forms.TabPage();
            this.UpdateMaxItemButton = new System.Windows.Forms.Button();
            this.MaxItemNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.MainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.InfoToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.NdrDataGridView = new System.Windows.Forms.DataGridView();
            this.IdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreationTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubjectColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DebugTabPage = new System.Windows.Forms.TabPage();
            this.ClearButton = new System.Windows.Forms.Button();
            this.InfoListBox = new System.Windows.Forms.ListBox();
            this.webPage = new System.Windows.Forms.TabPage();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.MainToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.MainTabControl.SuspendLayout();
            this.WorkingTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxItemNumericUpDown)).BeginInit();
            this.MainStatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NdrDataGridView)).BeginInit();
            this.DebugTabPage.SuspendLayout();
            this.webPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // FindParentEmailButton
            // 
            this.FindParentEmailButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FindParentEmailButton.Location = new System.Drawing.Point(370, 6);
            this.FindParentEmailButton.Name = "FindParentEmailButton";
            this.FindParentEmailButton.Size = new System.Drawing.Size(66, 23);
            this.FindParentEmailButton.TabIndex = 13;
            this.FindParentEmailButton.Text = "Исходное";
            this.FindParentEmailButton.UseVisualStyleBackColor = true;
            this.FindParentEmailButton.Click += new System.EventHandler(this.FindParentEmailButtonClick);
            // 
            // FolderComboBox
            // 
            this.FolderComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FolderComboBox.DisplayMember = "FullFolderPath";
            this.FolderComboBox.FormattingEnabled = true;
            this.FolderComboBox.Location = new System.Drawing.Point(78, 7);
            this.FolderComboBox.Name = "FolderComboBox";
            this.FolderComboBox.Size = new System.Drawing.Size(291, 21);
            this.FolderComboBox.TabIndex = 11;
            this.FolderComboBox.SelectedIndexChanged += new System.EventHandler(this.FolderComboBoxSelectedIndexChanged);
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.WorkingTabPage);
            this.MainTabControl.Controls.Add(this.DebugTabPage);
            this.MainTabControl.Controls.Add(this.webPage);
            this.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTabControl.Location = new System.Drawing.Point(0, 0);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(450, 700);
            this.MainTabControl.TabIndex = 1;
            // 
            // WorkingTabPage
            // 
            this.WorkingTabPage.Controls.Add(this.UpdateMaxItemButton);
            this.WorkingTabPage.Controls.Add(this.MaxItemNumericUpDown);
            this.WorkingTabPage.Controls.Add(this.MainStatusStrip);
            this.WorkingTabPage.Controls.Add(this.FindParentEmailButton);
            this.WorkingTabPage.Controls.Add(this.NdrDataGridView);
            this.WorkingTabPage.Controls.Add(this.FolderComboBox);
            this.WorkingTabPage.Location = new System.Drawing.Point(4, 22);
            this.WorkingTabPage.Name = "WorkingTabPage";
            this.WorkingTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.WorkingTabPage.Size = new System.Drawing.Size(442, 674);
            this.WorkingTabPage.TabIndex = 0;
            this.WorkingTabPage.Text = "Статус писем";
            this.WorkingTabPage.UseVisualStyleBackColor = true;
            // 
            // UpdateMaxItemButton
            // 
            this.UpdateMaxItemButton.Location = new System.Drawing.Point(51, 6);
            this.UpdateMaxItemButton.Name = "UpdateMaxItemButton";
            this.UpdateMaxItemButton.Size = new System.Drawing.Size(26, 22);
            this.UpdateMaxItemButton.TabIndex = 16;
            this.UpdateMaxItemButton.Text = "...";
            this.UpdateMaxItemButton.UseVisualStyleBackColor = true;
            this.UpdateMaxItemButton.Click += new System.EventHandler(this.UpdateMaxItemButtonClick);
            // 
            // MaxItemNumericUpDown
            // 
            this.MaxItemNumericUpDown.Location = new System.Drawing.Point(6, 7);
            this.MaxItemNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.MaxItemNumericUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.MaxItemNumericUpDown.Name = "MaxItemNumericUpDown";
            this.MaxItemNumericUpDown.Size = new System.Drawing.Size(45, 20);
            this.MaxItemNumericUpDown.TabIndex = 15;
            this.MaxItemNumericUpDown.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // MainStatusStrip
            // 
            this.MainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InfoToolStripStatusLabel,
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.MainStatusStrip.Location = new System.Drawing.Point(3, 649);
            this.MainStatusStrip.Name = "MainStatusStrip";
            this.MainStatusStrip.Size = new System.Drawing.Size(436, 22);
            this.MainStatusStrip.TabIndex = 14;
            this.MainStatusStrip.Text = "statusStrip1";
            // 
            // InfoToolStripStatusLabel
            // 
            this.InfoToolStripStatusLabel.Name = "InfoToolStripStatusLabel";
            this.InfoToolStripStatusLabel.Size = new System.Drawing.Size(10, 17);
            this.InfoToolStripStatusLabel.Text = " ";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // NdrDataGridView
            // 
            this.NdrDataGridView.AllowUserToAddRows = false;
            this.NdrDataGridView.AllowUserToDeleteRows = false;
            this.NdrDataGridView.AllowUserToResizeRows = false;
            this.NdrDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NdrDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.NdrDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdColumn,
            this.CreationTimeColumn,
            this.SubjectColumn});
            this.NdrDataGridView.Location = new System.Drawing.Point(6, 33);
            this.NdrDataGridView.MultiSelect = false;
            this.NdrDataGridView.Name = "NdrDataGridView";
            this.NdrDataGridView.ReadOnly = true;
            this.NdrDataGridView.RowHeadersVisible = false;
            this.NdrDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.NdrDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.NdrDataGridView.Size = new System.Drawing.Size(430, 613);
            this.NdrDataGridView.TabIndex = 0;
            this.NdrDataGridView.DoubleClick += new System.EventHandler(this.EmailStatusDataGridViewDoubleClick);
            // 
            // IdColumn
            // 
            this.IdColumn.DataPropertyName = "Id";
            this.IdColumn.FillWeight = 50F;
            this.IdColumn.HeaderText = "№";
            this.IdColumn.Name = "IdColumn";
            this.IdColumn.ReadOnly = true;
            this.IdColumn.Visible = false;
            this.IdColumn.Width = 50;
            // 
            // CreationTimeColumn
            // 
            this.CreationTimeColumn.DataPropertyName = "CreationTime";
            this.CreationTimeColumn.HeaderText = "Создан";
            this.CreationTimeColumn.MinimumWidth = 100;
            this.CreationTimeColumn.Name = "CreationTimeColumn";
            this.CreationTimeColumn.ReadOnly = true;
            // 
            // SubjectColumn
            // 
            this.SubjectColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SubjectColumn.DataPropertyName = "Subject";
            this.SubjectColumn.FillWeight = 200F;
            this.SubjectColumn.HeaderText = "Тема";
            this.SubjectColumn.Name = "SubjectColumn";
            this.SubjectColumn.ReadOnly = true;
            // 
            // DebugTabPage
            // 
            this.DebugTabPage.Controls.Add(this.ClearButton);
            this.DebugTabPage.Controls.Add(this.InfoListBox);
            this.DebugTabPage.Location = new System.Drawing.Point(4, 22);
            this.DebugTabPage.Name = "DebugTabPage";
            this.DebugTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.DebugTabPage.Size = new System.Drawing.Size(442, 674);
            this.DebugTabPage.TabIndex = 1;
            this.DebugTabPage.Text = "Отладка";
            this.DebugTabPage.UseVisualStyleBackColor = true;
            // 
            // ClearButton
            // 
            this.ClearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearButton.Location = new System.Drawing.Point(361, 6);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(75, 23);
            this.ClearButton.TabIndex = 3;
            this.ClearButton.Text = "Очистить";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButtonClick);
            // 
            // InfoListBox
            // 
            this.InfoListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InfoListBox.FormattingEnabled = true;
            this.InfoListBox.Location = new System.Drawing.Point(6, 32);
            this.InfoListBox.Name = "InfoListBox";
            this.InfoListBox.Size = new System.Drawing.Size(430, 628);
            this.InfoListBox.TabIndex = 0;
            // 
            // webPage
            // 
            this.webPage.Controls.Add(this.webBrowser);
            this.webPage.Location = new System.Drawing.Point(4, 22);
            this.webPage.Name = "webPage";
            this.webPage.Size = new System.Drawing.Size(442, 674);
            this.webPage.TabIndex = 2;
            this.webPage.Text = "Информация по NDR";
            this.webPage.UseVisualStyleBackColor = true;
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 0);
            this.webBrowser.MinimumSize = new System.Drawing.Size(23, 23);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(442, 674);
            this.webBrowser.TabIndex = 7;
            // 
            // NdrUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainTabControl);
            this.Name = "NdrUserControl";
            this.Size = new System.Drawing.Size(450, 700);
            this.Load += new System.EventHandler(this.EmailStatusUserControlLoad);
            this.MainTabControl.ResumeLayout(false);
            this.WorkingTabPage.ResumeLayout(false);
            this.WorkingTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxItemNumericUpDown)).EndInit();
            this.MainStatusStrip.ResumeLayout(false);
            this.MainStatusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NdrDataGridView)).EndInit();
            this.DebugTabPage.ResumeLayout(false);
            this.webPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox FolderComboBox;
        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage WorkingTabPage;
        private System.Windows.Forms.TabPage DebugTabPage;
        private System.Windows.Forms.ListBox InfoListBox;
        private System.Windows.Forms.Button FindParentEmailButton;
        private System.Windows.Forms.StatusStrip MainStatusStrip;
        private System.Windows.Forms.DataGridView NdrDataGridView;
        private System.Windows.Forms.TabPage webPage;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.ToolStripStatusLabel InfoToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreationTimeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectColumn;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.NumericUpDown MaxItemNumericUpDown;
        private System.Windows.Forms.Button UpdateMaxItemButton;
        private System.Windows.Forms.ToolTip MainToolTip;

    }
}
