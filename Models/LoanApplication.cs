//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class LoanApplication
    {
        [Key]
        public int Id { get; set; }
        public string Loan_No { get; set; }
        public Nullable<System.DateTime> Application_Date { get; set; }
        public string Loan_Product_Type { get; set; }
        public string Loan_Product_Type_Name { get; set; }
        public string Member_No { get; set; }
        public string Member_Name { get; set; }
        public Nullable<decimal> Requested_Amount { get; set; }
        public Nullable<decimal> Approved_Amount { get; set; }
        public Nullable<decimal> Interest { get; set; }
        public int Status { get; set; }
        public string RecID { get; set; }
        public string Captured_By { get; set; }
        public string Global_Dimension_1_Code { get; set; }
        public string Global_Dimension_2_Code { get; set; }
        public string Staff_No { get; set; }
    }
}
