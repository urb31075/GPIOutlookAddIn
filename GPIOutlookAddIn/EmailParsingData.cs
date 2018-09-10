using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPIOutlookAddIn
{
    using Microsoft.Exchange.WebServices.Data;

    /// <summary>
    /// The email parsing data.
    /// </summary>
    public class EmailParsingData
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public string EntryId { get; set; }

        /// <summary>
        /// Gets or sets the creation time.
        /// </summary>
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// Gets or sets the last modification time.
        /// </summary>
        public DateTime LastModificationTime { get; set; }

        /// <summary>
        /// Gets or sets the item class.
        /// </summary>
        public string ItemClass { get; set; }

        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets the display to.
        /// </summary>
        public string DisplayTo { get; set; }

        /// <summary>
        /// Gets or sets the display cc.
        /// </summary>
        public string DisplayCc { get; set; }

        /// <summary>
        /// Gets or sets the conversation id.
        /// </summary>
        public ConversationId ConversationId { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        public GpiOutlookWrapper.EmailStatus Status { get; set; }
    }
}
