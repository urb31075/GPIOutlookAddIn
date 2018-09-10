// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GPIRibbon.cs" company="urb31075">
// All Right Reserved  
// </copyright>
// <summary>
//   Defines the GPIRibbon type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GPIOutlookAddIn
{
    using System.Windows.Forms;
    using Microsoft.Office.Core;
    using Microsoft.Office.Interop.Outlook;
    using Microsoft.Office.Tools.Ribbon;

    using Application = System.Windows.Forms.Application;
    using CustomTaskPane = Microsoft.Office.Tools.CustomTaskPane;

    /// <summary>
    /// The gpi ribbon.
    /// </summary>
    public partial class GpiRibbon
    {
        /// <summary>
        /// The this ribbon.
        /// </summary>
        private IRibbonUI thisRibbon;

        /// <summary>
        /// The email status pane.
        /// </summary>
        private CustomTaskPane monitorPane;

        /// <summary>
        /// The email status pane.
        /// </summary>
        private CustomTaskPane emailStatusPane;

        /// <summary>
        /// The gpi ribbon load.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void GpiRibbonLoad(object sender, RibbonUIEventArgs e)
        {
            this.thisRibbon = e.RibbonUI;
            this.HideServicePanelsToggleButton.Label = "Скрыть служебные панели";
            this.HideServicePanelsToggleButton.Checked = false;
        }

        /// <summary>
        /// The hide service panels toggle button click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void HideServicePanelsToggleButtonClick(object sender, RibbonControlEventArgs e)
        {
            var status = this.HideServicePanelsToggleButton.Checked;
            ThisAddIn.thisApplication.ActiveExplorer().ShowPane(OlPane.olNavigationPane, !status);
            ThisAddIn.thisApplication.ActiveExplorer().ShowPane(OlPane.olFolderList, !status);
            ThisAddIn.thisApplication.ActiveExplorer().ShowPane(OlPane.olOutlookBar, !status);
            ThisAddIn.thisApplication.ActiveExplorer().ShowPane(OlPane.olPreview, !status);
            ThisAddIn.thisApplication.ActiveExplorer().ShowPane(OlPane.olToDoBar, !status);
            this.HideServicePanelsToggleButton.Label = status ? " Показать служебные панели" : "Скрыть служебные панели";
        }

        /// <summary>
        /// The monitor button click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void MonitorToggleButtonClick(object sender, RibbonControlEventArgs e)
        {
            var currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            Application.DoEvents();
            if (this.monitorPane == null)
            {
                this.monitorPane = ThisAddIn.thisAddIn.CustomTaskPanes.Add(new MonitorUserControl(), "Монитор");
                this.monitorPane.VisibleChanged += (s, ea) =>
                {
                    this.thisRibbon.Invalidate();
                };

                this.monitorPane.DockPosition = (MsoCTPDockPosition)MsoCTPDockPosition.msoCTPDockPositionLeft;
                this.monitorPane.Width = 370;
            }

            this.monitorPane.Visible = !this.monitorPane.Visible; // Visiblethis.MonitorToggleButton.Checked;
            Cursor.Current = currentCursor;
        }

        /// <summary>
        /// The view email status toggle button click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ViewEmailStatusToggleButtonClick(object sender, RibbonControlEventArgs e)
        {
            if (this.emailStatusPane == null)
            {
                this.emailStatusPane = ThisAddIn.thisAddIn.CustomTaskPanes.Add(new NdrUserControl(), "Статус писем");
                this.emailStatusPane.VisibleChanged += (s, ea) =>
                {
                    this.thisRibbon.Invalidate();
                };

                this.emailStatusPane.DockPosition = (MsoCTPDockPosition)MsoCTPDockPosition.msoCTPDockPositionLeft;
                this.emailStatusPane.Width = 400;
            }

            this.emailStatusPane.Visible = this.ViewEmailStatusToggleButton.Checked;
        }

        /// <summary>
        /// The setup button click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void SetupButtonClick(object sender, RibbonControlEventArgs e)
        {
            var mainForm = new Form { Text = @"Настройки (отладка)" };
            mainForm.ShowDialog();
        }
    }
}
