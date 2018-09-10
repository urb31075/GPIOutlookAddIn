// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MonitorUserControl.cs" company="urb31075">
//  All Right Reserved 
// </copyright>
// <summary>
//   Defines the MonitroUserControl type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GPIOutlookAddIn
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;
    using Outlook = Microsoft.Office.Interop.Outlook;

    /// <summary>
    /// The monitro user control.
    /// </summary>
    public partial class MonitorUserControl : UserControl
    {
        /// <summary>
        /// The bold font.
        /// </summary>
        private readonly Font boldFontObjectSmeta;
        
        /// <summary>
        /// The email parsing data list.
        /// </summary>
        private List<EmailParsingData> emailParsingDataList;

        /// <summary>
        /// The filter parameters.
        /// </summary>
        private FilterParametersData filterParameters;
     
        /// <summary>
        /// Initializes a new instance of the <see cref="MonitorUserControl"/> class.
        /// </summary>
        public MonitorUserControl()
        {
            this.InitializeComponent();
            this.boldFontObjectSmeta = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold);
        }

        /// <summary>
        /// The monitro user control load.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void MonitroUserControlLoad(object sender, EventArgs e)
        {
            try
            {
                this.filterParameters = FilterParametersData.GetDefault();
                this.FinishDateTimePicker.Value = this.filterParameters.StartDateTime;
                this.StartDateTimePicker.Value = this.filterParameters.FinishDateTime;
                this.SubjectContainTextBox.Text = this.filterParameters.SubjectContain;
                this.NonDeliveryStatusCheckBox.Checked = this.filterParameters.NonDeliveryStatus;
                this.UnknownStatusCheckBox.Checked = this.filterParameters.UnknownStatus;
                this.DeliveryStatusCheckBox.Checked = this.filterParameters.DeliveryStatus;

                this.MonitorStatusDataGridView.AutoGenerateColumns = false;

                var dataGridViewColumn = this.MonitorStatusDataGridView.Columns["CreationTimeColumn"];
                if (dataGridViewColumn != null)
                {
                    dataGridViewColumn.DefaultCellStyle.Format = "dd'.'MM'.'yyyy HH:mm:ss";
                }

                this.webBrowser.Url = new Uri("about:blank");
                this.webBrowser.DocumentText = "<html><body>Ожидание...</body></html>";
                this.Width = 400;

                this.FolderComboBox.Items.Clear();
                var count = 0;
                var selectedIndex = 0;
                foreach (dynamic folder in ThisAddIn.thisApplication.GetNamespace("MAPI").Folders)
                {
                    var subFolders = GpiOutlookWrapper.GetFolder(folder.FolderPath);
                    foreach (Outlook.MAPIFolder subFolder in subFolders.Folders)
                    {
                        this.FolderComboBox.Items.Add(subFolder);
                        //// if (subFolder.FullFolderPath.Contains("r.ugryumov@GASP.RU") && subFolder.FullFolderPath.Contains("Отправленные"))
                        if (subFolder.FullFolderPath.Contains("Отправленные") && 
                           (subFolder.FullFolderPath.Contains("Канцелярия") || subFolder.FullFolderPath.Contains("kancelaria")))
                             {
                                selectedIndex = count;
                             }

                        count++;
                    }

                    Marshal.ReleaseComObject(subFolders);
                }

                this.FolderComboBox.SelectedIndex = selectedIndex;

                this.MonitorStatusDataGridView.SelectionChanged += this.MonitorStatusDataGridViewSelectionChanged;
                this.MainToolTip.SetToolTip(this.FilterButton, @"Показать/скрыть фильтр");
                this.MainToolTip.SetToolTip(this.UpdateButton, @"Обновить список писем");
                this.MainToolTip.SetToolTip(this.FolderComboBox, @"Выбор источника для сканирования отправленных писем");
                this.MainToolTip.SetToolTip(this.StartDateTimePicker, @"Начальная дата");
                this.MainToolTip.SetToolTip(this.FinishDateTimePicker, @"Конечная дата");
                this.MainToolTip.SetToolTip(this.SubjectContainTextBox, @"Фильтр по теме");
                this.MainToolTip.SetToolTip(this.NonDeliveryStatusCheckBox, @"Недоставленный письма");
                this.MainToolTip.SetToolTip(this.DeliveryStatusCheckBox, @"Доставленные письма");
                this.MainToolTip.SetToolTip(this.UnknownStatusCheckBox, @"Нет информации по письму");

                this.MainToolTip.SetToolTip(this.MonitorStatusDataGridView, @"Монитор писем");
            }
            catch (Exception ex)
            {
                this.InfoListBox.Items.Add("EmailStatusUserControlLoad " + ex.Message);
                this.InfoListBox.Items.Add("EmailStatusUserControlLoad " + ex.StackTrace);
            }
        }

        /// <summary>
        /// The monitor status data grid view selection changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void MonitorStatusDataGridViewSelectionChanged(object sender, EventArgs e)
        {
            this.DisplaySourceMail();
        }

        /// <summary>
        /// The folder combo box selected index changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void FolderComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            //// this.UpdateMonitorDataGrid(this.filterParameters);
        }

        /// <summary>
        /// The update max item button click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void UpdateMaxItemButtonClick(object sender, EventArgs e)
        {
            this.UpdateMonitorDataGrid(this.filterParameters);
        }

        /// <summary>
        /// The update email status data grid.
        /// </summary>
        /// <param name="filterParametersData"></param>
        private void UpdateMonitorDataGrid(FilterParametersData filterParametersData)
        {
            var currentCursor = Cursor.Current;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Application.DoEvents();

                this.GetFilterParams();

                if (this.FolderComboBox.SelectedItem != null)
                {
                    var inboxFolder = (Outlook.MAPIFolder)this.FolderComboBox.SelectedItem;
                    ThisAddIn.thisApplication.ActiveExplorer().CurrentFolder = inboxFolder;
                    ThisAddIn.thisApplication.ActiveExplorer().CurrentFolder.Display();

                    this.emailParsingDataList = GpiOutlookWrapper.GetMailBoxContent(inboxFolder, filterParametersData);
                    this.InfoToolStripStatusLabel.Text = $"Обнаружено: {this.emailParsingDataList.Count}";

                    this.MonitorStatusDataGridView.DataSource = this.emailParsingDataList;
                    if (this.emailParsingDataList.Count > 0)
                    {
                        this.MonitorStatusDataGridView.SelectedRows[0].Selected = true;
                        this.MonitorStatusDataGridViewSelectionChanged(null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                this.InfoListBox.Items.Add("UpdateMonitorDataGrid " + ex.Message);
                this.InfoListBox.Items.Add(ex.StackTrace);
                foreach (var err in GpiOutlookWrapper.ErrorList)
                {
                    this.InfoListBox.Items.Add(err);                    
                }
            }
            finally
            {
                this.Cursor = currentCursor;
                Application.DoEvents();
            }
        }

        /// <summary>
        /// The display ndr report.
        /// </summary>
        private void DisplaySourceMail()
        {
            try
            {
                if (this.MonitorStatusDataGridView.SelectedCells.Count == 0)
                {
                    return;
                }

                var row = this.MonitorStatusDataGridView.SelectedCells[0].RowIndex;
                var id = (int)this.MonitorStatusDataGridView.Rows[row].Cells["IdColumn"].Value;
                var entryId = this.emailParsingDataList.First(c => c.Id == id).EntryId;
                var item = ThisAddIn.thisApplication.GetNamespace("MAPI").GetItemFromID(entryId, Type.Missing);
                var mail = item as Outlook.MailItem;
                if (mail != null)
                {
                    var reportFolder = mail.Parent as Outlook.MAPIFolder; // Получили папку
                    if (reportFolder != null)
                    { // Установили текущую папку
                        ThisAddIn.thisApplication.ActiveExplorer().CurrentFolder = reportFolder;
                        ThisAddIn.thisApplication.ActiveExplorer().CurrentFolder.Display();
                        Application.DoEvents();
                        Thread.Sleep(500);
                    }

                    if (ThisAddIn.thisApplication.ActiveExplorer().IsItemSelectableInView(mail))
                    {
                        ThisAddIn.thisApplication.ActiveExplorer().ClearSelection();
                        ThisAddIn.thisApplication.ActiveExplorer().AddToSelection(mail);
                    }
                    else
                    {
                        /*if (MessageBox.Show(
                            @"Невозможно отобразить письмо в текущем режиме. Разверните все свернутые группы используя опцию меню 'Развернуть все группы'. Отобразить отчет в новом окне?",
                            @"Внимание!",
                            MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            mail.Display();
                        }*/
                    }

                    if (mail.Body != null)
                    {
                        var unicodeBytes = Encoding.Unicode.GetBytes(mail.Body);
                        var body = Encoding.GetEncoding("koi8-r").GetString(unicodeBytes);
                        body = body.Replace("<br>\r\n<br>\r\n<br>\r\n<br>\r\n<br>\r\n<br>\r\n", string.Empty);
                        body = body.Replace("<br><br><br><br><br><br>", string.Empty);
                        body = body.Replace("color=\"#808080\" size=\"2\" ", "size=\"3\" ");
                        this.webBrowser.DocumentText = body;
                    }

                    Marshal.ReleaseComObject(mail);
                    if (reportFolder != null)
                    {
                        Marshal.ReleaseComObject(reportFolder);
                    }
                }
            }
            catch (Exception ex)
            {
                this.InfoListBox.Items.Add("DisplayNdrReport " + ex.Message);
            }
        }

        /// <summary>
        /// The monitor status data grid view cell formatting.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void MonitorStatusDataGridViewCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var row = e.RowIndex;
            var status = (GpiOutlookWrapper.EmailStatus)this.MonitorStatusDataGridView["StatusColumn", row].Value;

            switch (status)
            {
                case GpiOutlookWrapper.EmailStatus.Delivery:
                    e.CellStyle.Font = this.MonitorStatusDataGridView.DefaultCellStyle.Font;
                    e.CellStyle.BackColor = Color.LightGreen;
                    e.CellStyle.ForeColor = this.MonitorStatusDataGridView.DefaultCellStyle.ForeColor;
                    break;
                case GpiOutlookWrapper.EmailStatus.Nodelivery:
                    e.CellStyle.Font = this.boldFontObjectSmeta;
                    e.CellStyle.BackColor = Color.Red;
                    e.CellStyle.ForeColor = this.MonitorStatusDataGridView.DefaultCellStyle.ForeColor;
                    break;
                default:
                    e.CellStyle.Font = this.MonitorStatusDataGridView.DefaultCellStyle.Font;
                    e.CellStyle.BackColor = this.MonitorStatusDataGridView.DefaultCellStyle.BackColor;
                    e.CellStyle.ForeColor = this.MonitorStatusDataGridView.DefaultCellStyle.ForeColor;
                    break;
            }

            var dataGridViewColumn = this.MonitorStatusDataGridView.Columns["ImgColumn"];
            if (dataGridViewColumn != null && e.ColumnIndex == dataGridViewColumn.Index)
            {
                    switch (status)
                    {
                        case GpiOutlookWrapper.EmailStatus.Nodelivery:
                            e.Value = this.StatusImageList.Images[0];
                            break;
                        case GpiOutlookWrapper.EmailStatus.Unknown: 
                            e.Value = this.StatusImageList.Images[2];
                            break;
                        case GpiOutlookWrapper.EmailStatus.Delivery: 
                            e.Value = this.StatusImageList.Images[1];
                            break;
                    }
            }
        }

        /// <summary>
        /// The filter button click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void FilterButtonClick(object sender, EventArgs e)
        {
            this.TopPanel.Visible = !this.TopPanel.Visible;
            this.SetPanelLayout();
        }

        /// <summary>
        /// The set panel layout.
        /// </summary>
        private void SetPanelLayout()
        {
            this.TopPanel.Height = this.TopPanel.Visible ? 83 : 0;
            this.BottomPanel.Top = this.TopPanel.Visible ? 110 : 28;
            this.BottomPanel.Height = this.TopPanel.Visible ? this.Height - 83 - 80 : this.Height - 0 - 80;
        }

        /// <summary>
        /// The get filter params.
        /// </summary>
        private void GetFilterParams()
        {
            this.filterParameters.StartDateTime = this.FinishDateTimePicker.Value;
            this.filterParameters.FinishDateTime = this.StartDateTimePicker.Value;
            this.filterParameters.SubjectContain = this.SubjectContainTextBox.Text.ToLower();
            this.filterParameters.NonDeliveryStatus = this.NonDeliveryStatusCheckBox.Checked;
            this.filterParameters.UnknownStatus = this.UnknownStatusCheckBox.Checked;
            this.filterParameters.DeliveryStatus = this.DeliveryStatusCheckBox.Checked;            
        }

        /// <summary>
        /// The clear button_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ClearButtonClick(object sender, EventArgs e)
        {
            this.InfoListBox.Items.Clear();
        }

        /// <summary>
        /// The clipboard button click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ClipboardButtonClick(object sender, EventArgs e)
        {
            //// var msg = this.InfoListBox.Items.Cast<object>().Aggregate(string.Empty, (current, item) => current + (item + "\r\n"));
            var msg = this.InfoListBox.Items.Cast<object>().Aggregate(string.Empty, (current, item) => current + (item + "\r\n"));
            Clipboard.SetText(msg);
        }
    }
}
