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
    
    public partial class checkWarehousesWithProductQuantity_Result
    {
        public int warehouseID { get; set; }
        public string warehouseName { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public Nullable<int> currentCapacity { get; set; }
        public string warehouseStatus { get; set; }
        public int quantity { get; set; }
    }
}
