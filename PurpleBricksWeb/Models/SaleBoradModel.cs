using PurpleBricksLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;

namespace PurpleBricksWeb.Models
{
    public class SaleBoradModel : SalesOrder
    {
        #region properties
        public static IEnumerable<SelectListItem> States { get; set; }
        public static IEnumerable<SelectListItem> BordSizes { get; set; }
        public static IEnumerable<SelectListItem> Titles { get; set; }


        public decimal DiscountRateNSW { get; set; }
        public decimal DiscountRateOther { get; set; }
        public decimal DiscountRate { get; set; }
        #endregion

        #region constructors
        public SaleBoradModel()
        {
            States = GetStateList();
            BordSizes = GetBoardSizeList();
            Titles = GetTitleList();
            DiscountRateNSW = decimal.Parse(ConfigurationManager.AppSettings["DiscountRate.NSW"]);
            DiscountRateOther = decimal.Parse(ConfigurationManager.AppSettings["DiscountRate.Other"]);
            DiscountRate = 0m;
        }

        public SaleBoradModel(SalesOrder order)
        {
            this.PropertyAddress = order.PropertyAddress;
            this.BoardSize = order.BoardSize;
            this.DateTo = order.DateTo;
            this.DailyRate = order.DailyRate;
            this.DiscountRateNSW = order.Discount;
            this.Amount = order.Amount;
            this.Customer = order.Customer;
            this.SalesType = order.SalesType;
            this.CreatedDate = order.CreatedDate;
        }

        #endregion
        
        /// <summary>
        /// Calculates total days between date from and date to.
        /// </summary>
        public int NumberOfDays
        {
            get
            {
                if (DateFrom.HasValue && DateTo.HasValue)
                {
                    return (int)(DateTo.Value - DateFrom.Value).TotalDays;
                }

                return 0;
            }
        }
      
        /// <summary>
        /// Calculate total price of a board for a given state, board size, and for the given number of days.
        /// </summary>
        public decimal GetPrice()
        {
            decimal total = 0m;
            Discount = 0m;
            DailyRate = new UnitPriceDAL().GetUnitPrice(PropertyAddress.State, BoardSize);
            total = DailyRate * NumberOfDays;
            if(NumberOfDays > 10)
            {
                if (PropertyAddress.State == "NSW")
                {
                    Discount = total * DiscountRateNSW / 100;
                    DiscountRate = DiscountRateNSW;
                }
                else
                {
                    Discount = total * DiscountRateOther / 100;
                    DiscountRate = DiscountRateOther;
                }
            }

            Amount = Math.Round(total - Discount, 2);

            return Amount;
        }

        #region Populate Dropdown Lists
        public static IEnumerable<SelectListItem> GetStateList()
        {
            IList<SelectListItem> items = new List<SelectListItem>
            {
                new SelectListItem{Text = "NSW", Value = "NSW"},
                new SelectListItem{Text = "QLD", Value = "QLD"},
                new SelectListItem{Text = "SA", Value = "SA"},
                new SelectListItem{Text = "TAS", Value = "TAS"},
                new SelectListItem{Text = "VIC", Value = "VIC"},
                new SelectListItem{Text = "WA", Value = "WA"},
                new SelectListItem{Text = "ACT", Value = "ACT"},
                new SelectListItem{Text = "NT", Value = "NT"},


            };
            return items;
        }

        public static IEnumerable<SelectListItem> GetBoardSizeList()
        {
            IList<SelectListItem> items = new List<SelectListItem>
            {
                new SelectListItem{Text = "Small", Value = "Small"},
                new SelectListItem{Text = "Large", Value = "Large"},
            };
            return items;
        }

        public static IEnumerable<SelectListItem> GetTitleList()
        {
            IList<SelectListItem> items = new List<SelectListItem>
            {
                new SelectListItem{Text = "Mr", Value = "Mr"},
                new SelectListItem{Text = "Mrs", Value = "Mrs"},
                new SelectListItem{Text = "Miss", Value = "Miss"},
                new SelectListItem{Text = "Dr", Value = "Dr"},
                new SelectListItem{Text = "Ms", Value = "Ms"},
                new SelectListItem{Text = "Prof", Value = "Prof"},
                new SelectListItem{Text = "Rev", Value = "Rev"},
                new SelectListItem{Text = "Lady", Value = "Lady"},
                new SelectListItem{Text = "Sir", Value = "Sir"},
                new SelectListItem{Text = "Other", Value = ""}
            };
            return items;
        }

        #endregion
    }
}