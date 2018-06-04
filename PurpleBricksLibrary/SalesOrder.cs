using System;

namespace PurpleBricksLibrary
{
    /// <summary>
    /// Indicates the sales type: Lead or Order
    /// </summary>
    public enum SalesType
    {
        Lead,
        Order
    }

    /// <summary>
    /// Holds order/lead details
    /// </summary>
    public class SalesOrder
    {
        #region Properties
        public PropertyAddress PropertyAddress { get; set; }
        public BoardSize BoardSize { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public decimal DailyRate { get; set; }
        public decimal Discount { get; set; }
        public decimal Amount { get; set; }
        public Customer Customer { get; set; }
        public SalesType SalesType { get; set; }
        public DateTime? CreatedDate { get; set; }
        #endregion
    }
}
