// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FilterParametersData.cs" company="urb31075">
//  All Right Reserved 
// </copyright>
// <summary>
//   The filter parameters.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GPIOutlookAddIn
{
    using System;

    /// <summary>
    /// The filter parameters.
    /// </summary>
    public class FilterParametersData
    {
        /// <summary>
        /// Gets or sets the start date time.
        /// </summary>
        public DateTime StartDateTime { get; set; }

        /// <summary>
        /// Gets or sets the finish date time.
        /// </summary>
        public DateTime FinishDateTime { get; set; }

        /// <summary>
        /// Gets or sets the theme contain.
        /// </summary>
        public string SubjectContain { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether non delivery status.
        /// </summary>
        public bool NonDeliveryStatus { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether unknown status.
        /// </summary>
        public bool UnknownStatus { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether delivery status.
        /// </summary>
        public bool DeliveryStatus { get; set; }

        /// <summary>
        /// The get default filter parameters.
        /// </summary>
        /// <returns>
        /// The <see cref="FilterParametersData"/>.
        /// </returns>
        public static FilterParametersData GetDefault()
        {
            var filterParameters = new FilterParametersData
            {
                StartDateTime = DateTime.Now,
                FinishDateTime = DateTime.Now.AddDays(-1),
                SubjectContain = string.Empty
            };

            return filterParameters;
        }
    }
}
