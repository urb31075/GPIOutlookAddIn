using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPIOutlookAddIn
{
    using System.Security.Policy;

    using Microsoft.Exchange.WebServices.Data;

    public class GpiExchangeWrapper
    {
        /// <summary>
        /// The conversation id property.
        /// </summary>
        private readonly ExtendedPropertyDefinition ConversationIdProperty = new ExtendedPropertyDefinition(0x3013, MapiPropertyType.Binary);
        
        /// <summary>
        /// The property definition bases.
        /// </summary>
        private static readonly PropertyDefinitionBase[] propertyDefinitionBases =
            {
                ItemSchema.ConversationId,
                ItemSchema.ItemClass,
                ItemSchema.Subject, ItemSchema.Attachments,
                ItemSchema.DateTimeSent,
                ItemSchema.DateTimeCreated,
                ItemSchema.DateTimeReceived,
                ItemSchema.DisplayCc, ItemSchema.DisplayTo,
                ItemSchema.Body, 
                ItemSchema.UniqueBody
            };

        public static PropertySet GetPropertiesSet()
        {
            return new PropertySet(BasePropertySet.IdOnly, propertyDefinitionBases);
        }

        /// <summary>
        /// The get mail box content.
        /// </summary>
        /// <param name="folderName">
        /// The folder name.
        /// </param>
        /// <param name="mailbox">
        /// The mailbox.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public static List<EmailParsingData> GetMailBoxContent(WellKnownFolderName folderName, string mailBox, string itemClass = "")
        {
            var mailBoxContent = new List<EmailParsingData>();

            var propertySet = new PropertySet(BasePropertySet.IdOnly, propertyDefinitionBases);
            var itemView = new ItemView(1111);
            var service = new ExchangeService(ExchangeVersion.Exchange2010_SP2) { UseDefaultCredentials = true };
            service.AutodiscoverUrl(mailBox);
            try
            {
                var findResult = itemClass == string.Empty ?
                    service.FindItems(new FolderId(folderName, mailBox), itemView) :
                    service.FindItems(new FolderId(folderName, mailBox), new SearchFilter.IsEqualTo(ItemSchema.ItemClass, itemClass), itemView); // "REPORT.IPM.Note.NDR" "REPORT.IPM.Note.DR"

                foreach (var item in findResult)
                {
                    var itemBody = service.BindToItems(new[] { item.Id }, propertySet).First().Item;
                    mailBoxContent.Add(new EmailParsingData
                    {
                        //itemId = item.Id,
                        ItemClass = itemBody.ItemClass,
                        CreationTime = itemBody.DateTimeCreated,
                        LastModificationTime = itemBody.LastModifiedTime,
                        Subject = itemBody.Subject,
                        //Body = itemBody.Body,
                        DisplayTo = itemBody.DisplayTo,
                        DisplayCc = itemBody.DisplayCc,
                        ConversationId = itemBody.ConversationId
                    });
                }

                return mailBoxContent;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /*private void RefreshButton_Click(object sender, EventArgs e)
        {
            var mailBox = this.FolderComboBox.Text;
            var folderName = WellKnownFolderName.Inbox;

            this.InfoListBox.Items.Clear();
            this.InfoListBox.Items.Add(string.Format("Статистика по: {0}   {1}", folderName, mailBox));

            var service = new ExchangeService(ExchangeVersion.Exchange2010_SP2) { UseDefaultCredentials = true };
            service.AutodiscoverUrl(mailBox);

            this.InfoListBox.Items.Add(string.Empty);

            this.emailParsingDataList = GpiExchangeWrapper.GetMailBoxContent(folderName, mailBox, "REPORT.IPM.Note.NDR");

            this.InfoListBox.Items.Add(string.Format("NDR: {0}", this.emailParsingDataList.Count));
            this.EmailStatusDataGridView.DataSource = this.emailParsingDataList;
            if (this.emailParsingDataList.Count > 0)
            {
                this.EmailStatusDataGridView.SelectedRows[0].Selected = true;
                this.EmailStatusDataGridView_SelectionChanged(sender, e);
            }

            var propertySet = GpiExchangeWrapper.GetPropertiesSet();
            var itemView = new ItemView(100);
            var cidGuid = new byte[16];
            var count = 0;
            foreach (var item in this.emailParsingDataList)
            {
                this.InfoListBox.Items.Add(string.Format("{0} NDR: {1}  {2}    Тема: \"{3}\"   DisplayTo = {4}   {5}", ++count, item.ItemClass, item.CreationTime, item.Subject, item.DisplayTo, item.ConversationId.UniqueId));
                var cidBinary = Convert.FromBase64String(item.ConversationId.UniqueId);
                Array.Copy(cidBinary, 43, cidGuid, 0, 16); // it seems that the value required are the 16 last bytes
                var searchGuid = Convert.ToBase64String(cidGuid);

                SearchFilter conversation = new SearchFilter.IsEqualTo(this.ConversationIdProperty, searchGuid);
                var scanFolderNameList = new List<WellKnownFolderName>
                                             {
                                                 WellKnownFolderName.Inbox,
                                                 WellKnownFolderName.SentItems
                                             };

                foreach (var scanFolderName in scanFolderNameList)
                {
                    var findConversationItemResult = service.FindItems(new FolderId(scanFolderName, mailBox), conversation, itemView);
                    foreach (var conversationItem in findConversationItemResult)
                    {
                        var bindItem = service.BindToItems(new[] { conversationItem.Id }, propertySet).First().Item;
                        this.InfoListBox.Items.Add(string.Format("          CNV: {0} {1}  Тема: \"{2}\"   DisplayTo = {3}", scanFolderName, bindItem.DateTimeSent, bindItem.Subject, bindItem.DisplayTo));
                    }
                }

                this.InfoListBox.Items.Add(string.Empty);
            }
        }*/
    }
}
