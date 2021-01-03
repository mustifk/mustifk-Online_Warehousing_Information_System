﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class OWISDBEntities : DbContext
    {
        public OWISDBEntities()
            : base("name=OWISDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Packages> Packages { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Shipments> Shipments { get; set; }
        public virtual DbSet<Shipping> Shipping { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Warehouses> Warehouses { get; set; }
        public virtual DbSet<Bills> Bills { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<PackageContents> PackageContents { get; set; }
        public virtual DbSet<Payments> Payments { get; set; }
        public virtual DbSet<WarehouseContents> WarehouseContents { get; set; }
        public virtual DbSet<detailedPackages> detailedPackages { get; set; }
        public virtual DbSet<localPackages> localPackages { get; set; }
        public virtual DbSet<orderPaidByCreditCard> orderPaidByCreditCard { get; set; }
        public virtual DbSet<ordersFromAbroad> ordersFromAbroad { get; set; }
        public virtual DbSet<packageWeights> packageWeights { get; set; }
        public virtual DbSet<pendingPackage> pendingPackage { get; set; }
        public virtual DbSet<receivedPackages> receivedPackages { get; set; }
        public virtual DbSet<sentPackages> sentPackages { get; set; }
        public virtual DbSet<shipmentPaidByCash> shipmentPaidByCash { get; set; }
        public virtual DbSet<userTypeStaff> userTypeStaff { get; set; }
        public virtual DbSet<warehouseStaff> warehouseStaff { get; set; }
        public virtual DbSet<warehouseStaffCount> warehouseStaffCount { get; set; }
    
        [DbFunction("OWISDBEntities", "checkWarehousesWithProductQuantity")]
        public virtual IQueryable<checkWarehousesWithProductQuantity_Result> checkWarehousesWithProductQuantity(Nullable<int> productID, Nullable<int> quantity)
        {
            var productIDParameter = productID.HasValue ?
                new ObjectParameter("productID", productID) :
                new ObjectParameter("productID", typeof(int));
    
            var quantityParameter = quantity.HasValue ?
                new ObjectParameter("quantity", quantity) :
                new ObjectParameter("quantity", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<checkWarehousesWithProductQuantity_Result>("[OWISDBEntities].[checkWarehousesWithProductQuantity](@productID, @quantity)", productIDParameter, quantityParameter);
        }
    
        public virtual ObjectResult<findWarehouseWithZip_Result> findWarehouseWithZip(string zipCode)
        {
            var zipCodeParameter = zipCode != null ?
                new ObjectParameter("zipCode", zipCode) :
                new ObjectParameter("zipCode", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<findWarehouseWithZip_Result>("findWarehouseWithZip", zipCodeParameter);
        }
    
        public virtual ObjectResult<getBillFromDate_Result> getBillFromDate(Nullable<System.DateTime> date)
        {
            var dateParameter = date.HasValue ?
                new ObjectParameter("date", date) :
                new ObjectParameter("date", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getBillFromDate_Result>("getBillFromDate", dateParameter);
        }
    
        public virtual ObjectResult<getDeliveredShipping_Result> getDeliveredShipping()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getDeliveredShipping_Result>("getDeliveredShipping");
        }
    
        public virtual ObjectResult<getPackageFromDate_Result> getPackageFromDate(Nullable<System.DateTime> date)
        {
            var dateParameter = date.HasValue ?
                new ObjectParameter("date", date) :
                new ObjectParameter("date", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getPackageFromDate_Result>("getPackageFromDate", dateParameter);
        }
    
        public virtual ObjectResult<getPaymentsFromDate_Result> getPaymentsFromDate(Nullable<System.DateTime> date)
        {
            var dateParameter = date.HasValue ?
                new ObjectParameter("date", date) :
                new ObjectParameter("date", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getPaymentsFromDate_Result>("getPaymentsFromDate", dateParameter);
        }
    
        public virtual ObjectResult<getShippingDetailOfPackage_Result> getShippingDetailOfPackage(Nullable<int> packageID)
        {
            var packageIDParameter = packageID.HasValue ?
                new ObjectParameter("packageID", packageID) :
                new ObjectParameter("packageID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getShippingDetailOfPackage_Result>("getShippingDetailOfPackage", packageIDParameter);
        }
    
        public virtual ObjectResult<getWarehouseInCountry_Result> getWarehouseInCountry(string country)
        {
            var countryParameter = country != null ?
                new ObjectParameter("country", country) :
                new ObjectParameter("country", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getWarehouseInCountry_Result>("getWarehouseInCountry", countryParameter);
        }
    
        public virtual ObjectResult<lowStockItems_Result> lowStockItems()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<lowStockItems_Result>("lowStockItems");
        }
    
        public virtual ObjectResult<searchForProduct_Result> searchForProduct(string searchParameter)
        {
            var searchParameterParameter = searchParameter != null ?
                new ObjectParameter("searchParameter", searchParameter) :
                new ObjectParameter("searchParameter", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<searchForProduct_Result>("searchForProduct", searchParameterParameter);
        }
    
        public virtual ObjectResult<searchForSupplier_Result> searchForSupplier(string searchParameter)
        {
            var searchParameterParameter = searchParameter != null ?
                new ObjectParameter("searchParameter", searchParameter) :
                new ObjectParameter("searchParameter", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<searchForSupplier_Result>("searchForSupplier", searchParameterParameter);
        }
    
        public virtual ObjectResult<searchForUser_Result> searchForUser(string searchParameter)
        {
            var searchParameterParameter = searchParameter != null ?
                new ObjectParameter("searchParameter", searchParameter) :
                new ObjectParameter("searchParameter", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<searchForUser_Result>("searchForUser", searchParameterParameter);
        }
    
        public virtual ObjectResult<searchForWarehouse_Result> searchForWarehouse(string searchParameter)
        {
            var searchParameterParameter = searchParameter != null ?
                new ObjectParameter("searchParameter", searchParameter) :
                new ObjectParameter("searchParameter", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<searchForWarehouse_Result>("searchForWarehouse", searchParameterParameter);
        }
    
        public virtual int sumProductQuantityInPackage(Nullable<int> packageID)
        {
            var packageIDParameter = packageID.HasValue ?
                new ObjectParameter("packageID", packageID) :
                new ObjectParameter("packageID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sumProductQuantityInPackage", packageIDParameter);
        }
    
        public virtual ObjectResult<updateProductQuantity_Result> updateProductQuantity(string productID, Nullable<int> totalquantity)
        {
            var productIDParameter = productID != null ?
                new ObjectParameter("productID", productID) :
                new ObjectParameter("productID", typeof(string));
    
            var totalquantityParameter = totalquantity.HasValue ?
                new ObjectParameter("totalquantity", totalquantity) :
                new ObjectParameter("totalquantity", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<updateProductQuantity_Result>("updateProductQuantity", productIDParameter, totalquantityParameter);
        }
    
        public virtual ObjectResult<usersWithType_Result> usersWithType(string userType)
        {
            var userTypeParameter = userType != null ?
                new ObjectParameter("userType", userType) :
                new ObjectParameter("userType", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usersWithType_Result>("usersWithType", userTypeParameter);
        }
    }
}
