// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConversationTableData.cs" company="urb31075">
// All Right Reserved  
// </copyright>
// <summary>
//   The conversation table content.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GPIOutlookAddIn
{
    using System;

    /// <summary>
    /// The conversation table content.
    /// </summary>
    public class ConversationTableData
    {
        /// <summary>
        /// Gets or sets the entry id.
        /// </summary>
        public string EntryId { get; set; }

        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets the creation time.
        /// </summary>
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// Gets or sets the last modification time.
        /// </summary>
        public DateTime LastModificationTime { get; set; }

        /// <summary>
        /// Gets or sets the message class.
        /// </summary>
        public string MessageClass { get; set; }
    }
}
