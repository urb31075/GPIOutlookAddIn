// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ThisAddIn.cs" company="urb31075">
//  All Right Reserved 
// </copyright>
// <summary>
//   Defines the ThisAddIn type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GPIOutlookAddIn
{
    using Outlook = Microsoft.Office.Interop.Outlook;

    /// <summary>
    /// The this add in.
    /// </summary>
    public partial class ThisAddIn
    {
        /// <summary>
        /// Gets the this add in.
        /// </summary>
        public static ThisAddIn thisAddIn { get; private set; }

        /// <summary>
        /// Gets the this application.
        /// </summary>
        public static Outlook.Application thisApplication { get; private set; }

        /// <summary>
        /// The this add in startup.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ThisAddInStartup(object sender, System.EventArgs e)
        {
            thisAddIn = this;
            thisApplication = this.Application;
        }

        /// <summary>
        /// The this add in shutdown.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ThisAddInShutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += this.ThisAddInStartup;
            this.Shutdown += this.ThisAddInShutdown;
        }
        
        #endregion
    }
}
