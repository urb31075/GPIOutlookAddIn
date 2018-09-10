// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailStatusUserControl.cs" company="urb31075">
//  All Right Reserved 
// </copyright>
// <summary>
//   Defines the EmailStatusUserControl type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GPIOutlookAddIn
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;
    using Outlook = Microsoft.Office.Interop.Outlook;

    /// <summary>
    /// The email status user control.
    /// </summary>
    public partial class NdrUserControl : UserControl
    {
        /// <summary>
        /// The email parsing data list.
        /// </summary>
        private List<EmailParsingData> emailParsingDataList;

        /// <summary>
        /// Initializes a new instance of the <see cref="NdrUserControl"/> class.
        /// </summary>
        public NdrUserControl()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// The email status user control_ load.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void EmailStatusUserControlLoad(object sender, EventArgs e)
        {
            try
            {
                this.NdrDataGridView.AutoGenerateColumns = false;
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
                        if (subFolder.FullFolderPath.Contains("Канцелярия") && subFolder.FullFolderPath.Contains("Уведомления о прочтении"))
                        {
                            selectedIndex = count;                            
                        }

                        count++;
                    }

                    Marshal.ReleaseComObject(subFolders);
                }

                this.FolderComboBox.SelectedIndex = selectedIndex;

                this.NdrDataGridView.SelectionChanged += this.EmailStatusDataGridViewSelectionChanged;
                this.MainToolTip.SetToolTip(this.MaxItemNumericUpDown, @"Максимальное число отображаемых отчетов о недоставке");
                this.MainToolTip.SetToolTip(this.UpdateMaxItemButton, @"Установить максимальное число отображаемых отчетов о недоставке");
                this.MainToolTip.SetToolTip(this.FolderComboBox, @"Выбор источника для сканирования отчетов о недоставке");
                this.MainToolTip.SetToolTip(this.FindParentEmailButton, @"Найти исходное письмо");
                this.MainToolTip.SetToolTip(this.NdrDataGridView, @"Отчеты о недоставке (NDR)");
            }
            catch (Exception ex)
            {
                this.InfoListBox.Items.Add("EmailStatusUserControlLoad " + ex.Message);
            }
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
            this.UpdateNdrDataGrid();
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
            this.UpdateNdrDataGrid();
        }

        /// <summary>
        /// The email status data grid view selection changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void EmailStatusDataGridViewSelectionChanged(object sender, EventArgs e)
        {
            this.DisplayNdrReport();
        }

        /// <summary>
        /// The email status data grid view double click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void EmailStatusDataGridViewDoubleClick(object sender, EventArgs e)
        {
            this.DisplayParentEmail();
        }

        /// <summary>
        /// The find parent email button click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void FindParentEmailButtonClick(object sender, EventArgs e)
        {
            this.DisplayParentEmail();
        }

        /// <summary>
        /// The clear button click.
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
        /// The update email status data grid.
        /// </summary>
        private void UpdateNdrDataGrid()
        {
            try
            {
                var inboxFolder = (Outlook.MAPIFolder)this.FolderComboBox.SelectedItem;
                ThisAddIn.thisApplication.ActiveExplorer().CurrentFolder = inboxFolder;
                ThisAddIn.thisApplication.ActiveExplorer().CurrentFolder.Display();

                var fp = FilterParametersData.GetDefault();
                this.emailParsingDataList = GpiOutlookWrapper.GetMailBoxContent(inboxFolder, fp, "REPORT.IPM.Note.NDR");
                this.InfoToolStripStatusLabel.Text = string.Format("Обнаружено NDR: {0}", this.emailParsingDataList.Count);

                this.NdrDataGridView.DataSource = this.emailParsingDataList;
                if (this.emailParsingDataList.Count > 0)
                {
                    this.NdrDataGridView.SelectedRows[0].Selected = true;
                    this.EmailStatusDataGridViewSelectionChanged(null, null);
                }
            }
            catch (Exception ex)
            {
                this.InfoListBox.Items.Add("FolderComboBoxSelectedIndexChanged " + ex.Message);                
            }            
        }

        /// <summary>
        /// The display ndr report.
        /// </summary>
        private void DisplayNdrReport()
        {
            try
            {
                if (this.NdrDataGridView.SelectedCells.Count == 0)
                {
                    return;
                }

                var row = this.NdrDataGridView.SelectedCells[0].RowIndex;
                var id = (int)this.NdrDataGridView.Rows[row].Cells["IdColumn"].Value;
                var entryId = this.emailParsingDataList.First(c => c.Id == id).EntryId;
                var item = ThisAddIn.thisApplication.GetNamespace("MAPI").GetItemFromID(entryId, Type.Missing);
                var report = item as Outlook.ReportItem;
                if (report != null)
                {
                    var reportFolder = report.Parent as Outlook.MAPIFolder; // Получили папку
                    if (reportFolder != null)
                    { // Установили текущую папку
                        ThisAddIn.thisApplication.ActiveExplorer().CurrentFolder = reportFolder;
                        ThisAddIn.thisApplication.ActiveExplorer().CurrentFolder.Display();
                        Application.DoEvents();
                        Thread.Sleep(500);
                    }

                    if (ThisAddIn.thisApplication.ActiveExplorer().IsItemSelectableInView(report))
                    {
                        ThisAddIn.thisApplication.ActiveExplorer().ClearSelection();
                        ThisAddIn.thisApplication.ActiveExplorer().AddToSelection(report);
                    }
                    else
                    {
                        if (MessageBox.Show(
                            @"Невозможно отобразить отчет о недоставленном сообщении в текущем режиме. Разверните все свернутые группы используя опцию меню 'Развернуть все группы'. Отобразить отчет в новом окне?",
                            @"Внимание!",
                            MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            report.Display();
                        }
                    }

                    var unicodeBytes = Encoding.Unicode.GetBytes(report.Body);
                    var body = Encoding.GetEncoding("koi8-r").GetString(unicodeBytes);
                    body = body.Replace("<br>\r\n<br>\r\n<br>\r\n<br>\r\n<br>\r\n<br>\r\n", string.Empty);
                    body = body.Replace("<br><br><br><br><br><br>", string.Empty);
                    body = body.Replace("color=\"#808080\" size=\"2\" ", "size=\"3\" ");
                    this.webBrowser.DocumentText = body;

                    Marshal.ReleaseComObject(report);
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
        /// The find parent email button_ click.
        /// </summary>
        private void DisplayParentEmail()
        {
            try
            {
                if (this.NdrDataGridView.SelectedCells.Count == 0)
                {
                    return;
                }

                var row = this.NdrDataGridView.SelectedCells[0].RowIndex;
                var id = (int)this.NdrDataGridView.Rows[row].Cells["IdColumn"].Value;

                var entryId = this.emailParsingDataList.First(c => c.Id == id).EntryId;

                var item = ThisAddIn.thisApplication.GetNamespace("MAPI").GetItemFromID(entryId, Type.Missing);
                var conversation = (List<ConversationTableData>)GpiOutlookWrapper.GetConversation(item);

                var paremtMailTableContent = conversation.Where(c => c.CreationTime < item.CreationTime).OrderByDescending(c => c.CreationTime).FirstOrDefault();
                if (paremtMailTableContent == null)
                {
                    MessageBox.Show(@"В письме не обнаружена ссылка на исходное письмо!", @"Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var parentMail = ThisAddIn.thisApplication.GetNamespace("MAPI").GetItemFromID(paremtMailTableContent.EntryId);

                var parentMailFolder = parentMail.Parent as Outlook.MAPIFolder;
                if (parentMailFolder != null)
                { // // Установили текущую папку
                    ThisAddIn.thisApplication.ActiveExplorer().CurrentFolder = parentMailFolder;
                    ThisAddIn.thisApplication.ActiveExplorer().CurrentFolder.Display();
                    Application.DoEvents();
                    Thread.Sleep(500);
                }

                if (ThisAddIn.thisApplication.ActiveExplorer().IsItemSelectableInView(parentMail))
                {
                    ThisAddIn.thisApplication.ActiveExplorer().ClearSelection();
                    ThisAddIn.thisApplication.ActiveExplorer().AddToSelection(parentMail);
                }
                else
                {
                    if (MessageBox.Show(
                        @"Невозможно отобразить письмо в текущем режиме. Разверните все свернутые группы используя опцию меню 'Развернуть все группы'. Отобразить письмо в новом окне?",
                        @"Внимание!",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        parentMail.Display();
                    }
                }
               
                Marshal.ReleaseComObject(parentMail);
                if (parentMailFolder != null)
                {
                    Marshal.ReleaseComObject(parentMailFolder);
                }
            }
            catch (Exception ex)
            {
                this.InfoListBox.Items.Add("DisplayParentEmail " + ex.Message);
            }
        }
    }
}
