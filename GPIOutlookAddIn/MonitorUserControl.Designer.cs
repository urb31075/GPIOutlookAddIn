namespace GPIOutlookAddIn
{
    partial class MonitorUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonitorUserControl));
            this.FolderComboBox = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.MonitorStatusDataGridView = new System.Windows.Forms.DataGridView();
            this.IdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreationTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AdresColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubjectColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImgColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.NonDeliveryStatusCheckBox = new System.Windows.Forms.CheckBox();
            this.StatusImageList = new System.Windows.Forms.ImageList(this.components);
            this.DeliveryStatusCheckBox = new System.Windows.Forms.CheckBox();
            this.UnknownStatusCheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SubjectContainTextBox = new System.Windows.Forms.TextBox();
            this.StartDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.FinishDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.FilterButton = new System.Windows.Forms.Button();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ClipboardButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.InfoListBox = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.MainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.InfoToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MonitorStatusDataGridView)).BeginInit();
            this.TopPanel.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.MainStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // FolderComboBox
            // 
            this.FolderComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FolderComboBox.DisplayMember = "FullFolderPath";
            this.FolderComboBox.FormattingEnabled = true;
            this.FolderComboBox.Location = new System.Drawing.Point(153, 4);
            this.FolderComboBox.Name = "FolderComboBox";
            this.FolderComboBox.Size = new System.Drawing.Size(204, 21);
            this.FolderComboBox.TabIndex = 17;
            this.FolderComboBox.SelectedIndexChanged += new System.EventHandler(this.FolderComboBoxSelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(370, 806);
            this.tabControl1.TabIndex = 21;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.BottomPanel);
            this.tabPage1.Controls.Add(this.TopPanel);
            this.tabPage1.Controls.Add(this.FilterButton);
            this.tabPage1.Controls.Add(this.UpdateButton);
            this.tabPage1.Controls.Add(this.FolderComboBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(362, 780);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Монитор";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // BottomPanel
            // 
            this.BottomPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BottomPanel.Controls.Add(this.MonitorStatusDataGridView);
            this.BottomPanel.Location = new System.Drawing.Point(3, 114);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(356, 660);
            this.BottomPanel.TabIndex = 22;
            // 
            // MonitorStatusDataGridView
            // 
            this.MonitorStatusDataGridView.AllowUserToAddRows = false;
            this.MonitorStatusDataGridView.AllowUserToDeleteRows = false;
            this.MonitorStatusDataGridView.AllowUserToResizeRows = false;
            this.MonitorStatusDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MonitorStatusDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MonitorStatusDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdColumn,
            this.CreationTimeColumn,
            this.AdresColumn,
            this.SubjectColumn,
            this.StatusColumn,
            this.ImgColumn});
            this.MonitorStatusDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MonitorStatusDataGridView.Location = new System.Drawing.Point(0, 0);
            this.MonitorStatusDataGridView.MultiSelect = false;
            this.MonitorStatusDataGridView.Name = "MonitorStatusDataGridView";
            this.MonitorStatusDataGridView.ReadOnly = true;
            this.MonitorStatusDataGridView.RowHeadersVisible = false;
            this.MonitorStatusDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.MonitorStatusDataGridView.RowTemplate.Height = 23;
            this.MonitorStatusDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MonitorStatusDataGridView.Size = new System.Drawing.Size(356, 660);
            this.MonitorStatusDataGridView.TabIndex = 1;
            this.MonitorStatusDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.MonitorStatusDataGridViewCellFormatting);
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
            this.CreationTimeColumn.FillWeight = 120F;
            this.CreationTimeColumn.HeaderText = "Создан";
            this.CreationTimeColumn.MinimumWidth = 120;
            this.CreationTimeColumn.Name = "CreationTimeColumn";
            this.CreationTimeColumn.ReadOnly = true;
            this.CreationTimeColumn.Width = 120;
            // 
            // AdresColumn
            // 
            this.AdresColumn.DataPropertyName = "DisplayTo";
            this.AdresColumn.HeaderText = "Адрес";
            this.AdresColumn.Name = "AdresColumn";
            this.AdresColumn.ReadOnly = true;
            this.AdresColumn.Width = 150;
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
            // StatusColumn
            // 
            this.StatusColumn.DataPropertyName = "Status";
            this.StatusColumn.HeaderText = "Статус";
            this.StatusColumn.MinimumWidth = 100;
            this.StatusColumn.Name = "StatusColumn";
            this.StatusColumn.ReadOnly = true;
            this.StatusColumn.Visible = false;
            // 
            // ImgColumn
            // 
            this.ImgColumn.FillWeight = 24F;
            this.ImgColumn.HeaderText = "";
            this.ImgColumn.MinimumWidth = 24;
            this.ImgColumn.Name = "ImgColumn";
            this.ImgColumn.ReadOnly = true;
            this.ImgColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ImgColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ImgColumn.Width = 24;
            // 
            // TopPanel
            // 
            this.TopPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TopPanel.Controls.Add(this.label4);
            this.TopPanel.Controls.Add(this.label3);
            this.TopPanel.Controls.Add(this.NonDeliveryStatusCheckBox);
            this.TopPanel.Controls.Add(this.DeliveryStatusCheckBox);
            this.TopPanel.Controls.Add(this.UnknownStatusCheckBox);
            this.TopPanel.Controls.Add(this.label2);
            this.TopPanel.Controls.Add(this.label1);
            this.TopPanel.Controls.Add(this.SubjectContainTextBox);
            this.TopPanel.Controls.Add(this.StartDateTimePicker);
            this.TopPanel.Controls.Add(this.FinishDateTimePicker);
            this.TopPanel.Location = new System.Drawing.Point(3, 28);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(356, 83);
            this.TopPanel.TabIndex = 21;
            // 
            // NonDeliveryStatusCheckBox
            // 
            this.NonDeliveryStatusCheckBox.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.NonDeliveryStatusCheckBox.ImageIndex = 0;
            this.NonDeliveryStatusCheckBox.ImageList = this.StatusImageList;
            this.NonDeliveryStatusCheckBox.Location = new System.Drawing.Point(107, 54);
            this.NonDeliveryStatusCheckBox.Name = "NonDeliveryStatusCheckBox";
            this.NonDeliveryStatusCheckBox.Size = new System.Drawing.Size(40, 26);
            this.NonDeliveryStatusCheckBox.TabIndex = 44;
            this.NonDeliveryStatusCheckBox.UseVisualStyleBackColor = true;
            // 
            // StatusImageList
            // 
            this.StatusImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("StatusImageList.ImageStream")));
            this.StatusImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.StatusImageList.Images.SetKeyName(0, "Blocked.png");
            this.StatusImageList.Images.SetKeyName(1, "Complete.png");
            this.StatusImageList.Images.SetKeyName(2, "Warning.png");
            // 
            // DeliveryStatusCheckBox
            // 
            this.DeliveryStatusCheckBox.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DeliveryStatusCheckBox.ImageIndex = 1;
            this.DeliveryStatusCheckBox.ImageList = this.StatusImageList;
            this.DeliveryStatusCheckBox.Location = new System.Drawing.Point(160, 54);
            this.DeliveryStatusCheckBox.Name = "DeliveryStatusCheckBox";
            this.DeliveryStatusCheckBox.Size = new System.Drawing.Size(40, 26);
            this.DeliveryStatusCheckBox.TabIndex = 43;
            this.DeliveryStatusCheckBox.UseVisualStyleBackColor = true;
            // 
            // UnknownStatusCheckBox
            // 
            this.UnknownStatusCheckBox.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.UnknownStatusCheckBox.ImageIndex = 2;
            this.UnknownStatusCheckBox.ImageList = this.StatusImageList;
            this.UnknownStatusCheckBox.Location = new System.Drawing.Point(212, 54);
            this.UnknownStatusCheckBox.Name = "UnknownStatusCheckBox";
            this.UnknownStatusCheckBox.Size = new System.Drawing.Size(40, 26);
            this.UnknownStatusCheckBox.TabIndex = 42;
            this.UnknownStatusCheckBox.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(179, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "До:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "От:";
            // 
            // SubjectContainTextBox
            // 
            this.SubjectContainTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SubjectContainTextBox.Location = new System.Drawing.Point(98, 30);
            this.SubjectContainTextBox.Name = "SubjectContainTextBox";
            this.SubjectContainTextBox.Size = new System.Drawing.Size(254, 20);
            this.SubjectContainTextBox.TabIndex = 37;
            // 
            // StartDateTimePicker
            // 
            this.StartDateTimePicker.Location = new System.Drawing.Point(29, 5);
            this.StartDateTimePicker.Name = "StartDateTimePicker";
            this.StartDateTimePicker.Size = new System.Drawing.Size(140, 20);
            this.StartDateTimePicker.TabIndex = 36;
            // 
            // FinishDateTimePicker
            // 
            this.FinishDateTimePicker.Location = new System.Drawing.Point(212, 5);
            this.FinishDateTimePicker.Name = "FinishDateTimePicker";
            this.FinishDateTimePicker.Size = new System.Drawing.Size(140, 20);
            this.FinishDateTimePicker.TabIndex = 34;
            // 
            // FilterButton
            // 
            this.FilterButton.Image = global::GPIOutlookAddIn.Properties.Resources.Filter2HS;
            this.FilterButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FilterButton.Location = new System.Drawing.Point(3, 3);
            this.FilterButton.Name = "FilterButton";
            this.FilterButton.Size = new System.Drawing.Size(71, 23);
            this.FilterButton.TabIndex = 2;
            this.FilterButton.Text = "Фильтр";
            this.FilterButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.FilterButton.UseVisualStyleBackColor = true;
            this.FilterButton.Click += new System.EventHandler(this.FilterButtonClick);
            // 
            // UpdateButton
            // 
            this.UpdateButton.Image = global::GPIOutlookAddIn.Properties.Resources.all_sm;
            this.UpdateButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UpdateButton.Location = new System.Drawing.Point(74, 3);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(78, 23);
            this.UpdateButton.TabIndex = 20;
            this.UpdateButton.Text = "Обновить";
            this.UpdateButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateMaxItemButtonClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ClipboardButton);
            this.tabPage2.Controls.Add(this.ClearButton);
            this.tabPage2.Controls.Add(this.InfoLabel);
            this.tabPage2.Controls.Add(this.InfoListBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(362, 780);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Отладка";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ClipboardButton
            // 
            this.ClipboardButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ClipboardButton.Location = new System.Drawing.Point(199, 7);
            this.ClipboardButton.Name = "ClipboardButton";
            this.ClipboardButton.Size = new System.Drawing.Size(75, 23);
            this.ClipboardButton.TabIndex = 3;
            this.ClipboardButton.Text = "Clipboard";
            this.ClipboardButton.UseVisualStyleBackColor = true;
            this.ClipboardButton.Click += new System.EventHandler(this.ClipboardButtonClick);
            // 
            // ClearButton
            // 
            this.ClearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearButton.Location = new System.Drawing.Point(280, 9);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(75, 23);
            this.ClearButton.TabIndex = 2;
            this.ClearButton.Text = "Очистить";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButtonClick);
            // 
            // InfoLabel
            // 
            this.InfoLabel.AutoSize = true;
            this.InfoLabel.Location = new System.Drawing.Point(6, 12);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(35, 13);
            this.InfoLabel.TabIndex = 1;
            this.InfoLabel.Text = "label1";
            // 
            // InfoListBox
            // 
            this.InfoListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InfoListBox.FormattingEnabled = true;
            this.InfoListBox.HorizontalScrollbar = true;
            this.InfoListBox.Items.AddRange(new object[] {
            "111",
            "222",
            "333"});
            this.InfoListBox.Location = new System.Drawing.Point(6, 41);
            this.InfoListBox.Name = "InfoListBox";
            this.InfoListBox.ScrollAlwaysVisible = true;
            this.InfoListBox.Size = new System.Drawing.Size(350, 732);
            this.InfoListBox.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.webBrowser);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(362, 780);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Web";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 0);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(362, 780);
            this.webBrowser.TabIndex = 0;
            // 
            // MainStatusStrip
            // 
            this.MainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InfoToolStripStatusLabel});
            this.MainStatusStrip.Location = new System.Drawing.Point(0, 812);
            this.MainStatusStrip.Name = "MainStatusStrip";
            this.MainStatusStrip.Size = new System.Drawing.Size(376, 22);
            this.MainStatusStrip.TabIndex = 22;
            this.MainStatusStrip.Text = "statusStrip1";
            // 
            // InfoToolStripStatusLabel
            // 
            this.InfoToolStripStatusLabel.Name = "InfoToolStripStatusLabel";
            this.InfoToolStripStatusLabel.Size = new System.Drawing.Size(118, 17);
            this.InfoToolStripStatusLabel.Text = "toolStripStatusLabel1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 45;
            this.label3.Text = "Тема содержит:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 46;
            this.label4.Text = "Статус письма:";
            // 
            // MonitorUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainStatusStrip);
            this.Controls.Add(this.tabControl1);
            this.Name = "MonitorUserControl";
            this.Size = new System.Drawing.Size(376, 834);
            this.Load += new System.EventHandler(this.MonitroUserControlLoad);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.BottomPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MonitorStatusDataGridView)).EndInit();
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.MainStatusStrip.ResumeLayout(false);
            this.MainStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.ComboBox FolderComboBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label InfoLabel;
        private System.Windows.Forms.ListBox InfoListBox;
        private System.Windows.Forms.DataGridView MonitorStatusDataGridView;
        private System.Windows.Forms.StatusStrip MainStatusStrip;
        private System.Windows.Forms.ToolTip MainToolTip;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.ToolStripStatusLabel InfoToolStripStatusLabel;
        private System.Windows.Forms.ImageList StatusImageList;
        private System.Windows.Forms.Button FilterButton;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.CheckBox NonDeliveryStatusCheckBox;
        private System.Windows.Forms.CheckBox DeliveryStatusCheckBox;
        private System.Windows.Forms.CheckBox UnknownStatusCheckBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SubjectContainTextBox;
        private System.Windows.Forms.DateTimePicker StartDateTimePicker;
        private System.Windows.Forms.DateTimePicker FinishDateTimePicker;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button ClipboardButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreationTimeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AdresColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusColumn;
        private System.Windows.Forms.DataGridViewImageColumn ImgColumn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}
