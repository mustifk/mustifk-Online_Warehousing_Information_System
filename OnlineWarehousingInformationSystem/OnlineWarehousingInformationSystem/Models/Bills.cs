//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineWarehousingInformationSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bills
    {
        public int billID { get; set; }
        public int shipmentID { get; set; }
        public string invoiceID { get; set; }
        public string paymentType { get; set; }
        public int amount { get; set; }
        public System.DateTime operationDate { get; set; }
    
        public virtual Shipments Shipments { get; set; }
    }
}
