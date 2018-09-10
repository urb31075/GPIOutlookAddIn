// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GpiOutlookWrapper.cs" company="urb31075">
//  All Right Reserved 
// </copyright>
// <summary>
//   Defines the ConversationTableContent type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GPIOutlookAddIn
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using Microsoft.Exchange.WebServices.Data;
    using Outlook = Microsoft.Office.Interop.Outlook;

    /// <summary>
    /// The gpi outlook wrapper.
    /// </summary>
    public class GpiOutlookWrapper
    {
        /// <summary>
        /// The pr smtp address.
        /// </summary>
        private const string PrSmtpAddress = "http://schemas.microsoft.com/mapi/proptag/0x39FE001E"; 
        
        /// <summary>
        /// The email status.
        /// </summary>
        public enum EmailStatus
        {
            /// <summary>
            /// The nodelivery.
            /// </summary>
            Nodelivery,

            /// <summary>
            /// The unknown.
            /// </summary>
            Unknown,

            /// <summary>
            /// The delivery.
            /// </summary>
            Delivery
        }
        
        /// <summary>
        /// Gets or sets the error list.
        /// </summary>
        public static List<string> ErrorList { get; set; }

        /// <summary>
        /// The get mail box content.
        /// </summary>
        /// <param name="inboxFolder">
        /// The inbox folder.
        /// </param>
        /// <param name="filterParameters">
        /// The filter Parameters.
        /// </param>
        /// <param name="messageClass">
        /// The message Class.
        /// </param>
        /// <returns>
        /// The list of EmailParsingData.
        /// </returns>
        public static List<EmailParsingData> GetMailBoxContent(Outlook.MAPIFolder inboxFolder, FilterParametersData filterParameters, string messageClass = "IPM.Note")
        {
            var mailBoxContent = new List<EmailParsingData>();
            if (inboxFolder == null)
            {
                return mailBoxContent;
            }

            Outlook.Items folderItems = null;

            var start = DateTime.MinValue;
            try
            {
                folderItems = inboxFolder.Items;
                folderItems.Sort("[CreationTime]", true);
               
                start = DateTime.Now;

                var deliveryReportFilter = GenerateFilter(filterParameters, "REPORT.IPM.Note.DR");

                var deliveryReportList = GetDeliveryReportList(deliveryReportFilter);

                var filter = GenerateFilter(filterParameters, messageClass);
                var item = folderItems.Find(filter);              
                while (item != null)
                {
                    if (!CheckSubjectFilter(filterParameters, item.Subject))
                    { 
                        Marshal.ReleaseComObject(item);
                        item = folderItems.FindNext();
                        continue;
                    }

                    var parsingData = GetEmailParsingData(item);

                    if (parsingData.Subject.Contains(@"15292"))
                    {
                        var x = 0;
                    }

                    parsingData.Status = GetEmailStatusFromConversation(item, parsingData.CreationTime);
                    if (parsingData.Status == EmailStatus.Unknown)
                    {
                        parsingData.Status = GetEmailStatusFromSubject(item.Subject, deliveryReportList);
                    }

                    if (!CheckStatusFilter(filterParameters, parsingData.Status))
                    {
                        Marshal.ReleaseComObject(item);
                        item = folderItems.FindNext();
                        continue;                        
                    }

                    mailBoxContent.Add(parsingData);

                    Marshal.ReleaseComObject(item);
                    item = folderItems.FindNext();
                }
            }
            catch (Exception ex)
            {
               ErrorList.Add(MethodBase.GetCurrentMethod().Name + " " + ex.Message);
            }
            finally
            {
                if (folderItems != null)
                {
                    Marshal.ReleaseComObject(folderItems);
                }
            }
            
            var dyration = (DateTime.Now - start).TotalSeconds;
            return mailBoxContent.OrderByDescending(c => c.CreationTime).ToList();
        }

        private static List<EmailParsingData> GetDeliveryReportList(string filter)
        {
            try
            {
                var mailBoxContent = new List<EmailParsingData>();
                Outlook.Items folderItems = null;

                Outlook.MAPIFolder inboxFolder = null;
                foreach (dynamic folder in ThisAddIn.thisApplication.GetNamespace("MAPI").Folders)
                {
                    var subFolders = GpiOutlookWrapper.GetFolder(folder.FolderPath);
                    foreach (Outlook.MAPIFolder subFolder in subFolders.Folders)
                    {
                        if (subFolder.FullFolderPath.Contains("Уведомления о прочтении") &&
                           (subFolder.FullFolderPath.Contains("Канцелярия") || subFolder.FullFolderPath.Contains("kancelaria")))
                        {
                            inboxFolder = subFolder;
                        }
                    }

                    Marshal.ReleaseComObject(subFolders);
                }

                if (inboxFolder == null)
                {
                    return mailBoxContent;
                }

                folderItems = inboxFolder.Items;
                folderItems.Sort("[CreationTime]", true);

                var item = folderItems.Find(filter);
                while (item != null)
                {
                    var parsingData = new EmailParsingData();
                    parsingData.Subject = item.Subject;
                    parsingData.ItemClass = item.MessageClass;
                    parsingData.CreationTime = item.CreationTime;
                    mailBoxContent.Add(parsingData);
                    Marshal.ReleaseComObject(item);
                    item = folderItems.FindNext();
                }

                return mailBoxContent;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static string GenerateFilter(FilterParametersData filterParameters, string messageClass)
        {
            var minDateTime = filterParameters.StartDateTime < filterParameters.FinishDateTime
                                  ? filterParameters.StartDateTime.Date
                                  : filterParameters.FinishDateTime.Date;
            var maxDateTime = filterParameters.StartDateTime > filterParameters.FinishDateTime
                                  ? filterParameters.StartDateTime.Date
                                  : filterParameters.FinishDateTime.Date;
            minDateTime = minDateTime.AddDays(-1);
            maxDateTime = maxDateTime.AddDays(1);

            var filter = $"[CreationTime] < '{maxDateTime.Day:00}/{maxDateTime.Month:00}/{maxDateTime.Year:0000}' and [CreationTime] > '{minDateTime.Day:00}/{minDateTime.Month:00}/{minDateTime.Year:0000}'";

            if (messageClass != string.Empty)
            {
                var addFilter = " and [MessageClass] = '" + messageClass + "'";
                filter += addFilter;
            }

            return filter;
        }

        private static EmailParsingData GetEmailParsingData(dynamic item)
        {
            var parsingData = new EmailParsingData
                                  {
                                      EntryId = item.EntryID,
                                      CreationTime = item.CreationTime,
                                      Subject = item.Subject ?? string.Empty,
                                      ItemClass = item.MessageClass,
                                      LastModificationTime = item.LastModificationTime,
                                      ConversationId = item.ConversationID,
                                      DisplayTo = GetDisplayTo(item),
                                      Status = EmailStatus.Unknown
                                  };
             return parsingData;
        }

        private static string GetDisplayTo(dynamic item)
        {
            var displayTo = string.Empty;
            try
            {
                if (item.Recipients != null)
                {
                    foreach (Outlook.Recipient recip in item.Recipients)
                    {
                        var pa = recip.PropertyAccessor;
                        string smtpAddress = pa.GetProperty(PrSmtpAddress).ToString();
                        displayTo += displayTo + smtpAddress + "  ";
                    }

                    displayTo = displayTo.Trim();
                }
            }
            catch (Exception ex)
            {
                var y = 0;
                // Ignore
            }

            return displayTo;
        }

        private static bool CheckSubjectFilter(FilterParametersData filterParameters, string subject)
        {
            var condition = subject.ToLower().Contains(filterParameters.SubjectContain);
            return condition;
        }

        private static bool CheckStatusFilter(FilterParametersData filterParameters, EmailStatus status)
        {
            var condition = true;

            if (filterParameters.NonDeliveryStatus || filterParameters.UnknownStatus || filterParameters.DeliveryStatus)
            {
                var ndr = filterParameters.NonDeliveryStatus && (status == EmailStatus.Nodelivery);
                var unk = filterParameters.UnknownStatus && (status == EmailStatus.Unknown);
                var dr = filterParameters.DeliveryStatus && (status == EmailStatus.Delivery);
                if (!(ndr || unk || dr))
                {
                    condition = false;
                }
            }

            return condition;
        }

        private static EmailStatus GetEmailStatusFromConversation(dynamic item, DateTime creationTime)
        {
            var emailStatus = EmailStatus.Unknown;
            var conversation = (List<ConversationTableData>)GpiOutlookWrapper.GetConversation(item);
            if (conversation != null)
            {
                var conversationList = conversation.Where(c => c.CreationTime > creationTime).OrderBy(c => c.CreationTime).ToList();
                if (conversationList.Any())
                {
                    foreach (var parentMail in conversationList)
                    {
                        if (parentMail.MessageClass == "IPM.Note")
                        {
                            emailStatus = EmailStatus.Delivery;
                            break;
                        }

                        if (parentMail.MessageClass == "REPORT.IPM.Note.DR")
                        {
                            emailStatus = EmailStatus.Delivery;
                            break;
                        }

                        if (parentMail.MessageClass == "REPORT.IPM.Note.NDR")
                        {
                            emailStatus = EmailStatus.Nodelivery;
                            break;
                        }

                        if (parentMail.MessageClass == "REPORT.IPM.Note.IPNRN")
                        {
                            emailStatus = EmailStatus.Delivery;
                            break;
                        }

                        if (parentMail.MessageClass == "REPORT.IPM.Note.IPNNRN")
                        {
                            emailStatus = EmailStatus.Delivery;
                            break;
                        }
                    }
                }
            }

            return emailStatus;
        }

        private static EmailStatus GetEmailStatusFromSubject(string subject, List<EmailParsingData> deliveryReportList)
        {
            try
            {
                subject = subject.Replace("№", " ").Replace("-", " ").Replace("_", " ");
                var subjectSplit = subject.Split(' ');
                if (subjectSplit.Length == 0)
                {
                    return EmailStatus.Unknown;
                }

                var signatureList = new List<string>();

                foreach (var  ss in subjectSplit)
                {
                    if (ss.Length > 1)
                    {
                        if (char.IsDigit(ss[0]))
                        {
                            signatureList.Add(ss);
                        }
                    }
                }

                if (signatureList.Any())
                {
                    if (signatureList.Count == 1)
                    {
                        DateTime result;
                        var parseResult = DateTime.TryParse(signatureList[0], out result);
                        if (parseResult) // Если это дата то по ней искать бессмысленно
                        {
                            return EmailStatus.Unknown;
                        }
                    }

                    var chekSignatureResult = false;
                    foreach (var dr in deliveryReportList)
                    {
                        var subjectLowerCase = dr.Subject.ToLower();
                        chekSignatureResult = true;

                        foreach (var signature in signatureList)
                        {
                            if (!subjectLowerCase.Contains(signature))
                            {
                                chekSignatureResult = false;
                                break;
                            }
                        }

                        if (chekSignatureResult)
                        {
                            break;
                        }
                    }

                    if (chekSignatureResult)
                    {
                        return EmailStatus.Delivery;
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return EmailStatus.Unknown;
        }

        /// <summary>
        /// The get conversation.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The list of ConversationTableContent
        /// </returns>
        public static List<ConversationTableData> GetConversation(dynamic item)
        {
            Outlook.Conversation conv = null;
            try
            {
                var ctc = new List<ConversationTableData>();
                conv = item.GetConversation();
                if (conv != null)
                {
                    var table = conv.GetTable();
                    while (!table.EndOfTable)
                    {
                        var nextRow = table.GetNextRow();
                        var x = new ConversationTableData
                                    {
                                        CreationTime = Convert.ToDateTime(nextRow["CreationTime"]),
                                        MessageClass = nextRow["MessageClass"].ToString()
                                    };
                        
                        // x.EntryId = nextRow["EntryID"].ToString();
                        // x.Subject = nextRow["Subject"] != null ? nextRow["Subject"].ToString() : string.Empty;
                        // x.LastModificationTime = Convert.ToDateTime(nextRow["LastModificationTime"]);
                        ctc.Add(x);
                    }
                }

                return ctc;
            }
            catch (Exception ex)
            {
                ErrorList.Add(MethodBase.GetCurrentMethod().Name + " " + ex.Message);
                return null;
            }
            finally
            {
                if (conv != null)
                {
                    Marshal.ReleaseComObject(conv);
                }
            }
        }

        /// <summary>
        /// The get folder.
        /// </summary>
        /// <param name="folderPath">
        /// The folder path.
        /// </param>
        /// <returns>
        /// The <see cref="Folder"/>.
        /// </returns>
        public static Outlook.Folder GetFolder(string folderPath)
        {
            Outlook.Folder returnFolder;

            try
            {
                folderPath = folderPath.TrimStart("\\".ToCharArray()); // Remove leading "\" characters.
                var folders = folderPath.Split("\\".ToCharArray()); // Split the folder path into individual folder names.
                returnFolder = ThisAddIn.thisApplication.Session.Folders[folders[0]] as Outlook.Folder; // Retrieve a reference to the root folder.
                if (returnFolder != null)
                {   // If the root folder exists, look in subfolders.
                    // Look through folder names, skipping the first
                    // folder, which you already retrieved.
                    for (int i = 1; i < folders.Length; i++)
                    {
                        var folderName = folders[i];
                        if (returnFolder == null)
                        {
                            continue;
                        }

                        var subFolders = returnFolder.Folders;
                        returnFolder = subFolders[folderName] as Outlook.Folder;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorList.Add(MethodBase.GetCurrentMethod().Name + " " + ex.Message);
                returnFolder = null;
            }

            return returnFolder;
        }
    }
}

/*if ((item.ConversationID as string) != null)
{
    var ci = (string)item.ConversationID;
    if (ci == string.Empty)
    {
        Marshal.ReleaseComObject(item);                            
        item = folderItems.FindNext();
        continue;
    }
}*/

// var myApp = ThisAddIn.thisApplication;
// var ns = myApp.GetNamespace("MAPI");
// var defaultFolder = ns.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);

/*foreach (var sourceEncoding in Encoding.GetEncodings())
{

    var bytes = sourceEncoding.GetEncoding().GetBytes(r.Body);
    foreach (var targetEncoding in Encoding.GetEncodings())
    {
        {
            var result = targetEncoding.GetEncoding().GetString(bytes);
            if (result.Contains("<html>"))
            {
                Console.WriteLine("Source Encoding: {0} TargetEncoding: {1}", sourceEncoding.CodePage, targetEncoding.CodePage);
            }
        }
    }
}*/

/*private void EnumerateConversation(object item, Outlook.Conversation conversation)
        {
            Outlook.SimpleItems items = conversation.GetChildren(item);
            if (items.Count > 0)
            {
                foreach (object myItem in items)
                {
                    if (myItem is Outlook.MailItem)
                    {
                        var mailItem = myItem as Outlook.MailItem;
                        var inFolder = mailItem.Parent as Outlook.Folder;
                    }

                    EnumerateConversation(myItem, conversation);
                }
            }
        }*/

/*var count = 0;
var testStart = DateTime.Now;
var testItem = folderItems.Find(filter);
while (testItem != null)
{
    try
    {
        string subject = testItem.Subject ?? string.Empty;
        if (subject.Contains("14857"))
        {
            count++;
        }

        Marshal.ReleaseComObject(testItem);
        testItem = folderItems.FindNext();
    }
    catch (Exception ex)
    {
        break;
    }
}

var testDyration = (DateTime.Now - testStart).TotalSeconds;*/
