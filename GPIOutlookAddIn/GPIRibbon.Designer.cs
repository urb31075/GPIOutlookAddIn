namespace GPIOutlookAddIn
{
    partial class GpiRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public GpiRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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
            this.tab1 = this.Factory.CreateRibbonTab();
            this.GPIGroup = this.Factory.CreateRibbonGroup();
            this.MonitorToggleButton = this.Factory.CreateRibbonToggleButton();
            this.ViewEmailStatusToggleButton = this.Factory.CreateRibbonToggleButton();
            this.HideServicePanelsToggleButton = this.Factory.CreateRibbonToggleButton();
            this.SetupButton = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.GPIGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.GPIGroup);
            this.tab1.Label = "TabAddIns";
            this.tab1.Name = "tab1";
            // 
            // GPIGroup
            // 
            this.GPIGroup.Items.Add(this.MonitorToggleButton);
            this.GPIGroup.Items.Add(this.ViewEmailStatusToggleButton);
            this.GPIGroup.Items.Add(this.HideServicePanelsToggleButton);
            this.GPIGroup.Items.Add(this.SetupButton);
            this.GPIGroup.Label = "Отслеживание статуса писем";
            this.GPIGroup.Name = "GPIGroup";
            // 
            // MonitorToggleButton
            // 
            this.MonitorToggleButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.MonitorToggleButton.Image = global::GPIOutlookAddIn.Properties.Resources.Monitor;
            this.MonitorToggleButton.Label = "Монитор";
            this.MonitorToggleButton.Name = "MonitorToggleButton";
            this.MonitorToggleButton.ShowImage = true;
            this.MonitorToggleButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.MonitorToggleButtonClick);
            // 
            // ViewEmailStatusToggleButton
            // 
            this.ViewEmailStatusToggleButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.ViewEmailStatusToggleButton.Image = global::GPIOutlookAddIn.Properties.Resources.NdrEnvelope;
            this.ViewEmailStatusToggleButton.Label = "Просмотр статуса писем";
            this.ViewEmailStatusToggleButton.Name = "ViewEmailStatusToggleButton";
            this.ViewEmailStatusToggleButton.ShowImage = true;
            this.ViewEmailStatusToggleButton.Visible = false;
            this.ViewEmailStatusToggleButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ViewEmailStatusToggleButtonClick);
            // 
            // HideServicePanelsToggleButton
            // 
            this.HideServicePanelsToggleButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.HideServicePanelsToggleButton.Image = global::GPIOutlookAddIn.Properties.Resources.KeepWindowVisible;
            this.HideServicePanelsToggleButton.Label = "Скрыть служебные панели";
            this.HideServicePanelsToggleButton.Name = "HideServicePanelsToggleButton";
            this.HideServicePanelsToggleButton.ShowImage = true;
            this.HideServicePanelsToggleButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.HideServicePanelsToggleButtonClick);
            // 
            // SetupButton
            // 
            this.SetupButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.SetupButton.Enabled = false;
            this.SetupButton.Image = global::GPIOutlookAddIn.Properties.Resources.SetupDialog;
            this.SetupButton.Label = "Настройки";
            this.SetupButton.Name = "SetupButton";
            this.SetupButton.ShowImage = true;
            this.SetupButton.Visible = false;
            this.SetupButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.SetupButtonClick);
            // 
            // GpiRibbon
            // 
            this.Name = "GpiRibbon";
            this.RibbonType = "Microsoft.Outlook.Explorer";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.GpiRibbonLoad);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.GPIGroup.ResumeLayout(false);
            this.GPIGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup GPIGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton HideServicePanelsToggleButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton ViewEmailStatusToggleButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton SetupButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton MonitorToggleButton;
    }

    partial class ThisRibbonCollection
    {
        internal GpiRibbon GPIRibbon
        {
            get { return this.GetRibbon<GpiRibbon>(); }
        }
    }
}
